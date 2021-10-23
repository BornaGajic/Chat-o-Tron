using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using static Utility.Utility;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using Common.POCO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace ChatServer
{
	class Program
	{
		private static Dictionary<Guid, List<TcpClient>> RoomClients = new Dictionary<Guid, List<TcpClient>>();
		private static List<TcpClient> ConnectedClients = new List<TcpClient>();

		static async Task Main (string[] args)
		{
			var serverBroadcastThread = new Thread(new ThreadStart( () => {
				UdpClient server = new UdpClient(11000);
				var host = Dns.GetHostEntry(Dns.GetHostName());

				while (true)
				{
					var clientEp = new IPEndPoint(IPAddress.Any, 0);
					server.Receive(ref clientEp);
					
					var adress = Encoding.ASCII.GetBytes(GetLocalIPAddress());
					server.Send(adress, adress.Length, clientEp);
				}				
			}));

			serverBroadcastThread.IsBackground = true;
			serverBroadcastThread.Start();

			TcpListener serverSocket = new TcpListener(IPAddress.Any, 7777);
			
			serverSocket.Start();
			Console.WriteLine(" >> Server Started");

			Task<TcpClient> client = null;
			while (true)
			{
				if (client == null)
				{
					client = serverSocket.AcceptTcpClientAsync();
				}
				if (client.IsCompleted)
				{
					ConnectedClients.Add(client.Result);
					Console.WriteLine(" >> Client connected!");

					client = null;
				}

				for (int i = 0; i < ConnectedClients.Count; i++)
				{
					TcpClient connectedClient = ConnectedClients[i];

					NetworkStream ns = connectedClient.GetStream();
					
					if (ns.DataAvailable)
					{
						byte[] data = new byte[1024];

						int count = await ns.ReadAsync(data, 0, data.Length);
						
						JsonData payloadJson = JsonConvert.DeserializeObject<JsonData>(Encoding.ASCII.GetString(data, 0, count));
						
						switch(payloadJson.command)
						{
							case Commands.Leave:
								RoomClients[payloadJson.room.id].Remove(connectedClient);
								LeaveRoom(connectedClient, payloadJson.room.id);
								break;
							case Commands.LeaveAll:
								LeaveAll(connectedClient);
								break;
							case Commands.Post:
								PostMessage(payloadJson, connectedClient);
								break;
							case Commands.Join:
								RoomClients[payloadJson.room.id].Add(connectedClient);
								break;
							case Commands.Refresh:
								RefreshRooms(connectedClient);
								break;
							case Commands.NewRoom:
								NewRoom(connectedClient);
								break;
						}
					}
				}
			}
		}

		private static async void NewRoom (TcpClient client)
		{
			NetworkStream ns = client.GetStream();

			Guid roomId = Guid.NewGuid();
			RoomClients[roomId] = new List<TcpClient>(){client};

			string response = JsonConvert.SerializeObject(new JsonData () {
				command = Commands.NewRoom,
				room = new Room () { id = roomId }
			});
			
			await ns.WriteAsync(Encoding.ASCII.GetBytes(response), 0, response.Length);
		}

		private static async void LeaveRoom (TcpClient client, Guid roomId)
		{
			NetworkStream ns = client.GetStream();

			string response = JsonConvert.SerializeObject(new JsonData () {
				command = Commands.Leave,
				room = new Room () { id = roomId }
			});

			await ns.WriteAsync(Encoding.ASCII.GetBytes(response), 0, response.Length);
		}

		private static void LeaveAll (TcpClient client)
		{
			foreach (KeyValuePair<Guid, List<TcpClient>> room in RoomClients)
			{
				if (room.Value.Contains(client))
				{
					room.Value.Remove(client);
				}
			}

			lock (ConnectedClients)
			{
				ConnectedClients.Remove(client);
			}

			Console.WriteLine(" >> Client disconnected!");
		}


		private static async void PostMessage (JsonData payload, TcpClient sender)
		{
			// Parallelizable!
			foreach (TcpClient c in RoomClients[payload.room.id])
			{
				payload.isMessageMine = c == sender;
				
				string response = JsonConvert.SerializeObject(payload);
				
				byte[] byteResponse = Encoding.ASCII.GetBytes(response);

				NetworkStream clientNs = c.GetStream();

				await clientNs.WriteAsync(byteResponse, 0, response.Length);	
			}
		}

		private static async void RefreshRooms (TcpClient client)
		{
			NetworkStream ns = client.GetStream();
			
			JsonData data = new JsonData() { command = Commands.Refresh };
			
			if (RoomClients.Count > 0)
			{

				for (int i = 0; i < RoomClients.Count; i++)
				{
					Guid roomId = RoomClients.Keys.ToList()[i];
					string roomName = "Room " + i.ToString();
					int size = RoomClients[roomId].Count;

					Room room = new Room () {
						id = roomId,
						name = roomName,
						numOfParticipants = size
					};

					data.activeRooms.Add(room);
				}			
			}

			byte[] byteResponse = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data));
			
			await ns.WriteAsync(byteResponse, 0, byteResponse.Length);	
		}
	}
}
