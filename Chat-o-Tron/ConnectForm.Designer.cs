namespace Chat_o_Tron
{
	partial class ConnectForm
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
			this.AcceptButton = new System.Windows.Forms.Button();
			this.Username = new System.Windows.Forms.Label();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// AcceptButton
			// 
			this.AcceptButton.Location = new System.Drawing.Point(67, 126);
			this.AcceptButton.Name = "AcceptButton";
			this.AcceptButton.Size = new System.Drawing.Size(108, 23);
			this.AcceptButton.TabIndex = 0;
			this.AcceptButton.Text = "Connect";
			this.AcceptButton.UseVisualStyleBackColor = true;
			this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
			// 
			// Username
			// 
			this.Username.AutoSize = true;
			this.Username.Location = new System.Drawing.Point(22, 68);
			this.Username.Name = "Username";
			this.Username.Size = new System.Drawing.Size(55, 13);
			this.Username.TabIndex = 2;
			this.Username.Text = "Username";
			// 
			// usernameBox
			// 
			this.usernameBox.Location = new System.Drawing.Point(83, 65);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(144, 20);
			this.usernameBox.TabIndex = 4;
			// 
			// ConnectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(257, 185);
			this.Controls.Add(this.usernameBox);
			this.Controls.Add(this.Username);
			this.Controls.Add(this.AcceptButton);
			this.Name = "ConnectForm";
			this.Text = "Log in";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
			
		private new System.Windows.Forms.Button AcceptButton;
		private System.Windows.Forms.Label Username;
		private System.Windows.Forms.TextBox usernameBox;
	}
}

