using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using static Utility.Utility;
using System.Threading;
using System.Net.Http.Headers;
using Common.POCO;
using Newtonsoft.Json;

namespace Chat_o_Tron
{
	public partial class MenuForm : Form
	{
		private Thread WorkerThread { get; set; }
		private CancellationTokenSource CancelToken { get; }

		private TcpClient Client { get; set; }

		private Dictionary<Guid, ChatForm> activeChatRooms { get; set; } = new Dictionary<Guid, ChatForm>();

		public MenuForm (TcpClient client)
		{
			InitializeComponent();

			Client = client;
			CancelToken = new CancellationTokenSource();

			RefreshButton.Click += RefreshRoomButton_Click;
		}

		private async void CreateRoomButton_Click (object sender, EventArgs e)
		{
			byte[] data = Encoding.UTF8.GetBytes(
				JsonConvert.SerializeObject(new JsonData () {
					command = Commands.NewRoom
				})
			);

			await Client.GetStream().WriteAsync(data, 0, data.Length);

			await RefreshRooms();
		}

		private async void RefreshRoomButton_Click (object sender, EventArgs e)
		{
			await RefreshRooms();
		}

		private async Task RefreshRooms ()
		{
			byte[] data = Encoding.UTF8.GetBytes(
				JsonConvert.SerializeObject(new JsonData () {
					command = Commands.Refresh
				})
			);

			await Client.GetStream().WriteAsync(data, 0, data.Length);
		}

		private async void JoinRoom (Guid roomId, string roomName)
		{
			byte[] data = Encoding.UTF8.GetBytes(
				JsonConvert.SerializeObject(new JsonData() {
					command = Commands.Join,
					room = new Room () { id = roomId } 
				})
			);

			await Client.GetStream().WriteAsync(data, 0, data.Length);

			activeChatRooms[roomId] = new ChatForm(Client, roomId)
			{
				Text = roomName
			};

			activeChatRooms[roomId].Show();

			await RefreshRooms();
		}

		private void ClientReciever (CancellationToken cancelToken)
		{	
			byte[] buffer = new byte[2048];

			Task<int> recievedCountOfBytes = null;

			Decoder decoder = Encoding.UTF8.GetDecoder();

			StringBuilder message = new StringBuilder();
			JsonData payload = null;

			while (this.Visible == true && !cancelToken.IsCancellationRequested)
			{
				do
				{
					if (!Client.GetStream().CanRead)
					{
						continue;
					}

					try
					{
						recievedCountOfBytes = Client.GetStream().ReadAsync(buffer, 0, buffer.Length);

						recievedCountOfBytes.Wait(cancelToken);
					}
					catch (Exception e)
					{
						if (cancelToken.IsCancellationRequested)
						{
							return;
						}

						Console.WriteLine(e.Data); 
					}

					char[] chars = new char[decoder.GetCharCount(buffer, 0, recievedCountOfBytes.Result)];
					decoder.GetChars(buffer, 0, recievedCountOfBytes.Result, chars, 0);

					message.Append(chars);
				}
				while (Client.GetStream().DataAvailable);

				payload = JsonConvert.DeserializeObject<JsonData>(message.ToString());

				switch (payload.command)
				{
					case Commands.Leave:
						activeChatRooms.Remove(payload.room.id);
						break;
					case Commands.Post:
						ChatForm room = activeChatRooms[payload.room.id];

						this.Invoke(new Action<string, bool, string>(room.ShowMessage), payload.message, payload.isMessageMine, payload.username);
						break;
					case Commands.Refresh:
						if (payload.activeRooms.Count > 0)
						{
							var func = new Action<List<Room>>(this.ShowRoomList);

							this.Invoke(func, payload.activeRooms);
						}
						break;
					case Commands.NewRoom:
						activeChatRooms[payload.room.id] = new ChatForm(Client, payload.room.id);

						this.Invoke(new MethodInvoker(activeChatRooms[payload.room.id].Show));
						break;
				}

				message.Clear();
			}
		}

		private void ShowRoomList (List<Room> activeRooms)
		{
			bool contains = false;

			foreach (Room room in activeRooms)
			{
				foreach (ListViewItem item in RoomList.Items)
				{
					if (item.Text == room.name)
					{	
						contains = true;
						item.SubItems[1].Text = room.numOfParticipants.ToString();

						break;
					}
				}

				if (!contains)
				{
					var listItem = new ListViewItem (new string[] { room.name, room.numOfParticipants.ToString() })
					{
						Font = new Font("Arial", 12),
						Tag = room.id
					};

					RoomList.Items.Add(listItem);
				}

				contains = false;
			}
		}

		private async void MenuForm_Shown (object sender, EventArgs e)
		{
			WorkerThread = new Thread(() => ClientReciever(CancelToken.Token));
			
			WorkerThread.IsBackground = true;
			WorkerThread.Start();

			await RefreshRooms();
		}

		private void RoomList_DoubleClick (object sender, EventArgs e)
		{
			string roomId = RoomList.SelectedItems[0].Tag.ToString();
			string roomName = RoomList.SelectedItems[0].Text.ToString();

			if (!activeChatRooms.ContainsKey(Guid.Parse(roomId)))
			{
				JoinRoom(Guid.Parse(roomId), roomName);	
			}
		}

		private void MenuForm_FormClosing (object sender, FormClosingEventArgs e)
		{
			byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new JsonData () { command = Commands.LeaveAll }));
	
			Client.GetStream().Write(data, 0, data.Length);
			
			CancelToken.Cancel();
		}
	}
}
