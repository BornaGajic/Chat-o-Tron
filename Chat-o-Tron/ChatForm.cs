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
using Newtonsoft.Json;
using Common.POCO;
using static Utility.Utility;
using System.Threading;

namespace Chat_o_Tron
{
	public partial class ChatForm : Form
	{
		private TcpClient Client {get; set;}
		private Guid RoomId {get; set;}
		
		public ChatForm (TcpClient client, Guid roomId)
		{
			InitializeComponent();

			Client = client;
			RoomId = roomId;
		}

		private void SendButton_Click (object sender, EventArgs e)
		{
			// Add message locally (ShowMessage), on the serverside step over client that sent the message

			if (inputBox.Text.Length != 0)
			{
				string username = Utility.Utility.username;

				byte[] request = Encoding.ASCII.GetBytes(
					JsonConvert.SerializeObject(new JsonData () {
						command = Commands.Post,
						room = new Room () { id = RoomId },
						message = inputBox.Text,
						username = username
					})
				);

				inputBox.Text = "";

				Client.GetStream().Write(request, 0, request.Length);
			}
		}

		private async void ChatForm_FormClosingAsync (object sender, FormClosingEventArgs e)
		{
			byte[] requestLeave = Encoding.ASCII.GetBytes(
				JsonConvert.SerializeObject(new JsonData () {
					command = Commands.Leave,
					room = new Room () { id = RoomId }
				})
			);

			byte[] requestRefresh = Encoding.ASCII.GetBytes(
				JsonConvert.SerializeObject(new JsonData () {
					command = Commands.Refresh
				})
			);

			Client.GetStream().Write(requestLeave, 0, requestLeave.Length);

			await Task.Run(() => {
				Thread.Sleep(500);
			});

			try
			{
				Client.GetStream().Write(requestRefresh, 0, requestRefresh.Length);
			}
			catch
			{
				return; // app closed before refresh.
			}
		}

		public void ShowMessage (string message, bool isMessageMine, string username)
		{
			chatBox.RowCount++;

			Label Username = new Label()
			{
				Text = username,
				Dock = DockStyle.Fill,
				TextAlign = ContentAlignment.MiddleCenter,
			};

			Label newMessage = new Label()
			{ 
				Text = message, 
				Dock = DockStyle.Fill,
				BorderStyle = BorderStyle.FixedSingle,
				TextAlign = ContentAlignment.BottomRight,
				Margin = new Padding(0, 0, 0, 5),
				Padding = new Padding(0, -2, 0, 2)
			};


			float colWidth;
			if (isMessageMine == true)
			{
				chatBox.ColumnStyles[1].Width += 0.1f * chatBox.ColumnStyles[1].Width;
				colWidth = (chatBox.ColumnStyles[1].Width / 100) * chatBox.Width;
			}
			else
			{
				chatBox.ColumnStyles[0].Width += 0.1f * chatBox.ColumnStyles[0].Width;
				colWidth = (chatBox.ColumnStyles[0].Width / 100) * chatBox.Width;
			}
			
			using (Graphics g = chatBox.CreateGraphics())
			{
				SizeF stringSize = g.MeasureString(message, chatBox.Font, (int)colWidth);

				float rowHeight = Math.Abs(newMessage.Padding.Top) + newMessage.Padding.Bottom + stringSize.Height + (0.25f * (float)Math.Ceiling(stringSize.Height));

				chatBox.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
			}

			chatBox.Controls.Add(newMessage, isMessageMine ? 1 : 0, chatBox.RowCount - 1);
			
			ToolTip messageToolTip = new ToolTip();
			messageToolTip.SetToolTip(newMessage, DateTime.Now.ToString());

			if (isMessageMine)
				chatBox.ColumnStyles[1].Width -= 0.1f * chatBox.ColumnStyles[1].Width;
			else
				chatBox.ColumnStyles[0].Width -= 0.1f * chatBox.ColumnStyles[0].Width;
		}
	}
}
