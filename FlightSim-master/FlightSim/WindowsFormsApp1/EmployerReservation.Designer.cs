﻿namespace WindowsFormsApp1
{
    partial class EmployerReservation
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.insuranceCombo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.luggageTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.seatTypeCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.addTravelerButton = new System.Windows.Forms.Button();
            this.passportTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flightInfoGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.confirmBookingButton = new System.Windows.Forms.Button();
            this.generateReceiptButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.travelerDetailGrid = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightInfoGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travelerDetailGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.insuranceCombo);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.luggageTextBox);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.seatTypeCombo);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.addTravelerButton);
            this.groupBox4.Controls.Add(this.passportTextBox);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(298, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 360);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add Travelers";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // insuranceCombo
            // 
            this.insuranceCombo.FormattingEnabled = true;
            this.insuranceCombo.Location = new System.Drawing.Point(9, 224);
            this.insuranceCombo.Name = "insuranceCombo";
            this.insuranceCombo.Size = new System.Drawing.Size(89, 24);
            this.insuranceCombo.TabIndex = 15;
            this.insuranceCombo.SelectedIndexChanged += new System.EventHandler(this.insuranceCombo_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Add insurance for luggage?";
            // 
            // luggageTextBox
            // 
            this.luggageTextBox.Location = new System.Drawing.Point(9, 166);
            this.luggageTextBox.Name = "luggageTextBox";
            this.luggageTextBox.Size = new System.Drawing.Size(164, 22);
            this.luggageTextBox.TabIndex = 13;
            this.luggageTextBox.TextChanged += new System.EventHandler(this.luggageTextBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Extra luggage";
            // 
            // seatTypeCombo
            // 
            this.seatTypeCombo.FormattingEnabled = true;
            this.seatTypeCombo.Location = new System.Drawing.Point(9, 103);
            this.seatTypeCombo.Name = "seatTypeCombo";
            this.seatTypeCombo.Size = new System.Drawing.Size(89, 24);
            this.seatTypeCombo.TabIndex = 11;
            this.seatTypeCombo.SelectedIndexChanged += new System.EventHandler(this.seatTypeCombo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Seat type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 9;
            // 
            // addTravelerButton
            // 
            this.addTravelerButton.Location = new System.Drawing.Point(79, 281);
            this.addTravelerButton.Name = "addTravelerButton";
            this.addTravelerButton.Size = new System.Drawing.Size(112, 26);
            this.addTravelerButton.TabIndex = 6;
            this.addTravelerButton.Text = "Add Traveler";
            this.addTravelerButton.UseVisualStyleBackColor = true;
            this.addTravelerButton.Click += new System.EventHandler(this.addTravelerButton_Click);
            // 
            // passportTextBox
            // 
            this.passportTextBox.Location = new System.Drawing.Point(9, 46);
            this.passportTextBox.Name = "passportTextBox";
            this.passportTextBox.Size = new System.Drawing.Size(164, 22);
            this.passportTextBox.TabIndex = 5;
            this.passportTextBox.TextChanged += new System.EventHandler(this.passportTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passport number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flightInfoGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 481);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight information";
            // 
            // flightInfoGrid
            // 
            this.flightInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightInfoGrid.Location = new System.Drawing.Point(6, 21);
            this.flightInfoGrid.Name = "flightInfoGrid";
            this.flightInfoGrid.RowHeadersWidth = 51;
            this.flightInfoGrid.RowTemplate.Height = 24;
            this.flightInfoGrid.Size = new System.Drawing.Size(268, 454);
            this.flightInfoGrid.TabIndex = 0;
            this.flightInfoGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightInfoGrid_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.confirmBookingButton);
            this.groupBox2.Controls.Add(this.generateReceiptButton);
            this.groupBox2.Location = new System.Drawing.Point(298, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Booking Confirmation";
            // 
            // confirmBookingButton
            // 
            this.confirmBookingButton.Location = new System.Drawing.Point(70, 31);
            this.confirmBookingButton.Name = "confirmBookingButton";
            this.confirmBookingButton.Size = new System.Drawing.Size(121, 26);
            this.confirmBookingButton.TabIndex = 17;
            this.confirmBookingButton.Text = "Confirm Booking";
            this.confirmBookingButton.UseVisualStyleBackColor = true;
            this.confirmBookingButton.Click += new System.EventHandler(this.confirmBookingButton_Click);
            // 
            // generateReceiptButton
            // 
            this.generateReceiptButton.Location = new System.Drawing.Point(70, 63);
            this.generateReceiptButton.Name = "generateReceiptButton";
            this.generateReceiptButton.Size = new System.Drawing.Size(121, 26);
            this.generateReceiptButton.TabIndex = 16;
            this.generateReceiptButton.Text = "Generate Receipt";
            this.generateReceiptButton.UseVisualStyleBackColor = true;
            this.generateReceiptButton.Click += new System.EventHandler(this.generateReceiptButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.travelerDetailGrid);
            this.groupBox3.Location = new System.Drawing.Point(568, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 481);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Traveler(s) details";
            // 
            // travelerDetailGrid
            // 
            this.travelerDetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travelerDetailGrid.Location = new System.Drawing.Point(6, 21);
            this.travelerDetailGrid.Name = "travelerDetailGrid";
            this.travelerDetailGrid.RowHeadersWidth = 51;
            this.travelerDetailGrid.RowTemplate.Height = 24;
            this.travelerDetailGrid.Size = new System.Drawing.Size(268, 454);
            this.travelerDetailGrid.TabIndex = 0;
            this.travelerDetailGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.travelerDetailGrid_CellContentClick);
            // 
            // EmployerReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "EmployerReservation";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EmployerReservation_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flightInfoGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travelerDetailGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox insuranceCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox luggageTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox seatTypeCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addTravelerButton;
        private System.Windows.Forms.TextBox passportTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView flightInfoGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button confirmBookingButton;
        private System.Windows.Forms.Button generateReceiptButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView travelerDetailGrid;
    }
}