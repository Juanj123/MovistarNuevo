namespace Ticket
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.CrystalReport11 = new Ticket.CrystalReport1();
            this.lblticket = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblticket
            // 
            this.lblticket.AutoSize = true;
            this.lblticket.Location = new System.Drawing.Point(2, 9);
            this.lblticket.Name = "lblticket";
            this.lblticket.Size = new System.Drawing.Size(0, 13);
            this.lblticket.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 566);
            this.Controls.Add(this.lblticket);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CrystalReport1 CrystalReport11;
        public System.Windows.Forms.Label lblticket;
    }
}

