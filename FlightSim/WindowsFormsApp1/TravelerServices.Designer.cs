namespace WindowsFormsApp1
{
    partial class TravelerServices
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
            this.bookingService = new System.Windows.Forms.Button();
            this.paymentService = new System.Windows.Forms.Button();
            this.TravelerServicesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bookingService
            // 
            this.bookingService.Location = new System.Drawing.Point(286, 134);
            this.bookingService.Name = "bookingService";
            this.bookingService.Size = new System.Drawing.Size(206, 56);
            this.bookingService.TabIndex = 0;
            this.bookingService.Text = "button1";
            this.bookingService.UseVisualStyleBackColor = true;
            this.bookingService.Click += new System.EventHandler(this.button1_Click);
            // 
            // paymentService
            // 
            this.paymentService.Location = new System.Drawing.Point(286, 249);
            this.paymentService.Name = "paymentService";
            this.paymentService.Size = new System.Drawing.Size(206, 56);
            this.paymentService.TabIndex = 0;
            this.paymentService.Text = "button1";
            this.paymentService.UseVisualStyleBackColor = true;
            this.paymentService.Click += new System.EventHandler(this.button2_Click);
            // 
            // TravelerServicesLabel
            // 
            this.TravelerServicesLabel.AutoSize = true;
            this.TravelerServicesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravelerServicesLabel.Location = new System.Drawing.Point(270, 26);
            this.TravelerServicesLabel.Name = "TravelerServicesLabel";
            this.TravelerServicesLabel.Size = new System.Drawing.Size(234, 32);
            this.TravelerServicesLabel.TabIndex = 1;
            this.TravelerServicesLabel.Text = "Traveler Services";
            // 
            // TravelerServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TravelerServicesLabel);
            this.Controls.Add(this.paymentService);
            this.Controls.Add(this.bookingService);
            this.Name = "TravelerServices";
            this.Text = "TravelerServices";
            this.Load += new System.EventHandler(this.TravelerServices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bookingService;
        private System.Windows.Forms.Button paymentService;
        private System.Windows.Forms.Label TravelerServicesLabel;
    }
}