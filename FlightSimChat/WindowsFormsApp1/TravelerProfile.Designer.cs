namespace WindowsFormsApp1
{
    partial class TravelerProfile
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.passportField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emailField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updatePayment = new System.Windows.Forms.Button();
            this.cvvField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.expiryDateField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cardNumberField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cardNameField = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passportField);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.emailField);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameField);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(57, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile";
            // 
            // passportField
            // 
            this.passportField.Location = new System.Drawing.Point(10, 152);
            this.passportField.Name = "passportField";
            this.passportField.ReadOnly = true;
            this.passportField.Size = new System.Drawing.Size(266, 22);
            this.passportField.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passport number";
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(10, 96);
            this.emailField.Name = "emailField";
            this.emailField.ReadOnly = true;
            this.emailField.Size = new System.Drawing.Size(266, 22);
            this.emailField.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email Address";
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(10, 41);
            this.nameField.Name = "nameField";
            this.nameField.ReadOnly = true;
            this.nameField.Size = new System.Drawing.Size(266, 22);
            this.nameField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updatePayment);
            this.groupBox2.Controls.Add(this.cardNameField);
            this.groupBox2.Controls.Add(this.cvvField);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.expiryDateField);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cardNumberField);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(408, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 343);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Details";
            // 
            // updatePayment
            // 
            this.updatePayment.Location = new System.Drawing.Point(94, 295);
            this.updatePayment.Name = "updatePayment";
            this.updatePayment.Size = new System.Drawing.Size(102, 32);
            this.updatePayment.TabIndex = 6;
            this.updatePayment.Text = "Update";
            this.updatePayment.UseVisualStyleBackColor = true;
            this.updatePayment.Click += new System.EventHandler(this.updatePayment_Click);
            // 
            // cvvField
            // 
            this.cvvField.Location = new System.Drawing.Point(10, 152);
            this.cvvField.Name = "cvvField";
            this.cvvField.Size = new System.Drawing.Size(254, 22);
            this.cvvField.TabIndex = 5;
            this.cvvField.TextChanged += new System.EventHandler(this.cvvField_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "CVV";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // expiryDateField
            // 
            this.expiryDateField.Location = new System.Drawing.Point(10, 96);
            this.expiryDateField.Name = "expiryDateField";
            this.expiryDateField.Size = new System.Drawing.Size(254, 22);
            this.expiryDateField.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Expiry Date";
            // 
            // cardNumberField
            // 
            this.cardNumberField.Location = new System.Drawing.Point(10, 41);
            this.cardNumberField.Name = "cardNumberField";
            this.cardNumberField.Size = new System.Drawing.Size(254, 22);
            this.cardNumberField.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Card number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Card Name";
            // 
            // cardNameField
            // 
            this.cardNameField.Location = new System.Drawing.Point(10, 212);
            this.cardNameField.Name = "cardNameField";
            this.cardNameField.Size = new System.Drawing.Size(254, 22);
            this.cardNameField.TabIndex = 5;
            this.cardNameField.TextChanged += new System.EventHandler(this.cvvField_TextChanged);
            // 
            // TravelerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TravelerProfile";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TravelerProfile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passportField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updatePayment;
        private System.Windows.Forms.TextBox cvvField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox expiryDateField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cardNumberField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cardNameField;
    }
}