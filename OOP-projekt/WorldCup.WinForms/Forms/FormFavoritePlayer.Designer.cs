namespace WorldCup.WinForms.Forms
{
    partial class FormFavoritePlayers
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
            this.clbPlayers = new System.Windows.Forms.CheckedListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
           

            this.clbPlayers.FormattingEnabled = true;
            this.clbPlayers.Location = new System.Drawing.Point(50, 50);
            this.clbPlayers.Name = "clbPlayers";
            this.clbPlayers.Size = new System.Drawing.Size(700, 300);
            this.clbPlayers.TabIndex = 0;
           
            

            this.btnConfirm.Location = new System.Drawing.Point(300, 370);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(200, 50);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Potvrdi";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
           
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clbPlayers);
            this.Controls.Add(this.btnConfirm);
            this.Name = "FormFavoritePlayers";
            this.Text = "Omiljeni igrači";
            this.Load += new System.EventHandler(this.FormFavoritePlayers_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbPlayers;
        private System.Windows.Forms.Button btnConfirm;
    }
}
