namespace WindowsFormsApp1
{
    partial class TravelerPayment
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(45, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 481);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight information";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(268, 454);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(364, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Information";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passport number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(364, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 314);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 86);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(158, 20);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "New payment method";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(177, 20);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Existing payment method";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Make payment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(4, 244);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(249, 22);
            this.textBox4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "CVV";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(4, 188);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(249, 22);
            this.textBox5.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Expiry Date";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(4, 133);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(249, 22);
            this.textBox6.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Card number";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(665, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 360);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add Travelers";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 22);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passport number";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add Traveler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(164, 42);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Number of travelers";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Total price:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(88, 24);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 22);
            this.textBox7.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Seat type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 24);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(9, 215);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(164, 22);
            this.textBox8.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Extra luggage";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(9, 273);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(89, 24);
            this.comboBox2.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(214, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Add insurance for luggage?";
            // 
            // TravelerPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 597);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TravelerPayment";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
    }
}