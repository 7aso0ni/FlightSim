namespace WindowsFormsApp1
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.chatHistoryGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.startNewButton = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.chatListBox = new System.Windows.Forms.ListBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.openSelectedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chatHistoryGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatHistoryGrid
            // 
            this.chatHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chatHistoryGrid.Location = new System.Drawing.Point(6, 13);
            this.chatHistoryGrid.Name = "chatHistoryGrid";
            this.chatHistoryGrid.RowHeadersWidth = 51;
            this.chatHistoryGrid.RowTemplate.Height = 24;
            this.chatHistoryGrid.Size = new System.Drawing.Size(331, 407);
            this.chatHistoryGrid.TabIndex = 0;
            this.chatHistoryGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.chatHistoryGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chatHistoryGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 413);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous Chats";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openSelectedButton);
            this.groupBox2.Controls.Add(this.startNewButton);
            this.groupBox2.Controls.Add(this.MessageBox);
            this.groupBox2.Controls.Add(this.userNameText);
            this.groupBox2.Controls.Add(this.SendButton);
            this.groupBox2.Controls.Add(this.chatListBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(361, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 382);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chat";
            // 
            // startNewButton
            // 
            this.startNewButton.Location = new System.Drawing.Point(112, 38);
            this.startNewButton.Name = "startNewButton";
            this.startNewButton.Size = new System.Drawing.Size(100, 23);
            this.startNewButton.TabIndex = 4;
            this.startNewButton.Text = "Start new chat";
            this.startNewButton.UseVisualStyleBackColor = true;
            this.startNewButton.Click += new System.EventHandler(this.startNewButton_Click);
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(6, 38);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(100, 22);
            this.userNameText.TabIndex = 5;
            this.userNameText.TextChanged += new System.EventHandler(this.userNameText_TextChanged);
            // 
            // chatListBox
            // 
            this.chatListBox.FormattingEnabled = true;
            this.chatListBox.ItemHeight = 16;
            this.chatListBox.Location = new System.Drawing.Point(6, 67);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(415, 260);
            this.chatListBox.TabIndex = 0;
            this.chatListBox.SelectedIndexChanged += new System.EventHandler(this.chatListBox_SelectedIndexChanged);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(346, 341);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 34);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(15, 347);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(325, 22);
            this.MessageBox.TabIndex = 2;
            this.MessageBox.TextChanged += new System.EventHandler(this.MessageBox_TextChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(691, 27);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // openSelectedButton
            // 
            this.openSelectedButton.Location = new System.Drawing.Point(281, 38);
            this.openSelectedButton.Name = "openSelectedButton";
            this.openSelectedButton.Size = new System.Drawing.Size(140, 23);
            this.openSelectedButton.TabIndex = 3;
            this.openSelectedButton.Text = "Open selected chat";
            this.openSelectedButton.UseVisualStyleBackColor = true;
            this.openSelectedButton.Click += new System.EventHandler(this.openSelectedButton_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Chat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Chat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatHistoryGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView chatHistoryGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button startNewButton;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListBox chatListBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button openSelectedButton;
    }
}