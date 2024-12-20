namespace WindowsFormsApp1
{
    partial class CreateUser
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
            this.createUserLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contactInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.createUserBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createUserLabel
            // 
            this.createUserLabel.AutoSize = true;
            this.createUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserLabel.Location = new System.Drawing.Point(317, 25);
            this.createUserLabel.Name = "createUserLabel";
            this.createUserLabel.Size = new System.Drawing.Size(131, 29);
            this.createUserLabel.TabIndex = 0;
            this.createUserLabel.Text = "createUser";
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(280, 119);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(238, 22);
            this.usernameText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(280, 181);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(238, 22);
            this.emailText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(280, 238);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(238, 22);
            this.passwordText.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // contactInfo
            // 
            this.contactInfo.Location = new System.Drawing.Point(280, 296);
            this.contactInfo.Name = "contactInfo";
            this.contactInfo.Size = new System.Drawing.Size(238, 22);
            this.contactInfo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone Number";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // createUserBtn
            // 
            this.createUserBtn.Location = new System.Drawing.Point(311, 366);
            this.createUserBtn.Name = "createUserBtn";
            this.createUserBtn.Size = new System.Drawing.Size(177, 31);
            this.createUserBtn.TabIndex = 3;
            this.createUserBtn.Text = "Create User";
            this.createUserBtn.UseVisualStyleBackColor = true;
            this.createUserBtn.Click += new System.EventHandler(this.createUserBtn_Click);
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.createUserBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contactInfo);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.createUserLabel);
            this.Name = "CreateUser";
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createUserLabel;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contactInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createUserBtn;
    }
}