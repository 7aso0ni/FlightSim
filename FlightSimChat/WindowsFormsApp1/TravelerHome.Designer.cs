namespace WindowsFormsApp1
{
    partial class TravelerHome
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
            this.flightDisplay = new System.Windows.Forms.DataGridView();
            this.depLocationTextBox = new System.Windows.Forms.TextBox();
            this.desLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchFlight = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bookFlightButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.profileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightDisplay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flightDisplay
            // 
            this.flightDisplay.AllowUserToAddRows = false;
            this.flightDisplay.AllowUserToDeleteRows = false;
            this.flightDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightDisplay.Location = new System.Drawing.Point(30, 130);
            this.flightDisplay.Name = "flightDisplay";
            this.flightDisplay.ReadOnly = true;
            this.flightDisplay.RowHeadersWidth = 51;
            this.flightDisplay.RowTemplate.Height = 26;
            this.flightDisplay.Size = new System.Drawing.Size(744, 358);
            this.flightDisplay.TabIndex = 0;
            this.flightDisplay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightDisplay_CellContentClick);
            // 
            // depLocationTextBox
            // 
            this.depLocationTextBox.Location = new System.Drawing.Point(37, 72);
            this.depLocationTextBox.Name = "depLocationTextBox";
            this.depLocationTextBox.Size = new System.Drawing.Size(239, 22);
            this.depLocationTextBox.TabIndex = 1;
            // 
            // desLocationTextBox
            // 
            this.desLocationTextBox.Location = new System.Drawing.Point(37, 144);
            this.desLocationTextBox.Name = "desLocationTextBox";
            this.desLocationTextBox.Size = new System.Drawing.Size(239, 22);
            this.desLocationTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Depature: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destination: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.searchFlight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.depLocationTextBox);
            this.groupBox1.Controls.Add(this.desLocationTextBox);
            this.groupBox1.Location = new System.Drawing.Point(802, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 252);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search for Filght";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(191, 197);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(86, 33);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchFlight
            // 
            this.searchFlight.Location = new System.Drawing.Point(40, 197);
            this.searchFlight.Name = "searchFlight";
            this.searchFlight.Size = new System.Drawing.Size(126, 33);
            this.searchFlight.TabIndex = 5;
            this.searchFlight.Text = "Search";
            this.searchFlight.UseVisualStyleBackColor = true;
            this.searchFlight.Click += new System.EventHandler(this.searchFlight_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bookFlightButton);
            this.groupBox2.Location = new System.Drawing.Point(802, 404);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 101);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Booking";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // bookFlightButton
            // 
            this.bookFlightButton.Location = new System.Drawing.Point(65, 35);
            this.bookFlightButton.Name = "bookFlightButton";
            this.bookFlightButton.Size = new System.Drawing.Size(200, 38);
            this.bookFlightButton.TabIndex = 0;
            this.bookFlightButton.Text = "Book Filght";
            this.bookFlightButton.UseVisualStyleBackColor = true;
            this.bookFlightButton.Click += new System.EventHandler(this.bookFlightButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(307, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 52);
            this.label3.TabIndex = 7;
            this.label3.Text = "Flights";
            // 
            // profileButton
            // 
            this.profileButton.Location = new System.Drawing.Point(978, 24);
            this.profileButton.Name = "profileButton";
            this.profileButton.Size = new System.Drawing.Size(133, 33);
            this.profileButton.TabIndex = 8;
            this.profileButton.Text = "Profile";
            this.profileButton.UseVisualStyleBackColor = true;
            this.profileButton.Click += new System.EventHandler(this.profileButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1041, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Chats";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TravelerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 535);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.profileButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flightDisplay);
            this.Name = "TravelerHome";
            this.Text = "TravelerHome";
            this.Load += new System.EventHandler(this.TravelerHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightDisplay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView flightDisplay;
        private System.Windows.Forms.TextBox depLocationTextBox;
        private System.Windows.Forms.TextBox desLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchFlight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bookFlightButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button profileButton;
        private System.Windows.Forms.Button button1;
    }
}