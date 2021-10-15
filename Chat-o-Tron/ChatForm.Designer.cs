namespace Chat_o_Tron
{
	partial class ChatForm
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
			this.inputBox = new System.Windows.Forms.TextBox();
			this.SendButton = new System.Windows.Forms.Button();
			this.chatBox = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// inputBox
			// 
			this.inputBox.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.inputBox.Location = new System.Drawing.Point(12, 317);
			this.inputBox.Multiline = true;
			this.inputBox.Name = "inputBox";
			this.inputBox.Size = new System.Drawing.Size(376, 139);
			this.inputBox.TabIndex = 1;
			// 
			// SendButton
			// 
			this.SendButton.Location = new System.Drawing.Point(12, 463);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(376, 23);
			this.SendButton.TabIndex = 2;
			this.SendButton.Text = "Send";
			this.SendButton.UseVisualStyleBackColor = true;
			this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
			// 
			// chatBox
			// 
			this.chatBox.AutoScroll = true;
			this.chatBox.ColumnCount = 2;
			this.chatBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.chatBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.chatBox.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chatBox.Location = new System.Drawing.Point(0, 3);
			this.chatBox.Name = "chatBox";
			this.chatBox.RowCount = 2;
			this.chatBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.97403F));
			this.chatBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.02597F));
			this.chatBox.Size = new System.Drawing.Size(388, 308);
			this.chatBox.TabIndex = 3;
			// 
			// ChatForm
			// 
			this.AcceptButton = this.SendButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 498);
			this.Controls.Add(this.chatBox);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.inputBox);
			this.MaximumSize = new System.Drawing.Size(416, 537);
			this.MinimumSize = new System.Drawing.Size(416, 537);
			this.Name = "ChatForm";
			this.Text = "ChatForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosingAsync);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox inputBox;
		private System.Windows.Forms.Button SendButton;
		private System.Windows.Forms.TableLayoutPanel chatBox;
	}
}