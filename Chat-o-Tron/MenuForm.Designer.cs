namespace Chat_o_Tron
{
	partial class MenuForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.CreateRoomButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.RoomList = new System.Windows.Forms.ListView();
			this.RoomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// CreateRoomButton
			// 
			this.CreateRoomButton.Location = new System.Drawing.Point(3, 3);
			this.CreateRoomButton.Name = "CreateRoomButton";
			this.CreateRoomButton.Size = new System.Drawing.Size(94, 62);
			this.CreateRoomButton.TabIndex = 0;
			this.CreateRoomButton.Text = "Create Room";
			this.CreateRoomButton.UseVisualStyleBackColor = true;
			this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(3, 417);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(94, 72);
			this.RefreshButton.TabIndex = 5;
			this.RefreshButton.Text = "Refresh List";
			this.RefreshButton.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.CreateRoomButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.RefreshButton, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.97566F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.02434F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(100, 493);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Location = new System.Drawing.Point(12, 27);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.RoomList);
			this.splitContainer1.Size = new System.Drawing.Size(334, 499);
			this.splitContainer1.SplitterDistance = 106;
			this.splitContainer1.TabIndex = 8;
			// 
			// RoomList
			// 
			this.RoomList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RoomName,
            this.Num});
			this.RoomList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RoomList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.RoomList.FullRowSelect = true;
			this.RoomList.HideSelection = false;
			this.RoomList.Location = new System.Drawing.Point(0, 0);
			this.RoomList.MultiSelect = false;
			this.RoomList.Name = "RoomList";
			this.RoomList.Scrollable = false;
			this.RoomList.Size = new System.Drawing.Size(224, 499);
			this.RoomList.TabIndex = 0;
			this.RoomList.TileSize = new System.Drawing.Size(500, 100);
			this.RoomList.UseCompatibleStateImageBehavior = false;
			this.RoomList.View = System.Windows.Forms.View.Details;
			this.RoomList.DoubleClick += new System.EventHandler(this.RoomList_DoubleClick);
			// 
			// RoomName
			// 
			this.RoomName.Text = "Room name";
			this.RoomName.Width = 114;
			// 
			// Num
			// 
			this.Num.Text = "Num";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(358, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 538);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(374, 577);
			this.MinimumSize = new System.Drawing.Size(374, 577);
			this.Name = "MenuForm";
			this.Text = "Chat-o-Tron";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
			this.Shown += new System.EventHandler(this.MenuForm_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button CreateRoomButton;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView RoomList;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ColumnHeader RoomName;
		private System.Windows.Forms.ColumnHeader Num;
	}
}