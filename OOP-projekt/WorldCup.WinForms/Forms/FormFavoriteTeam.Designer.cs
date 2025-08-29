namespace WorldCup.WinForms.Forms
{
    partial class FormFavoriteTeam
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
            comboTeams = new ComboBox();
            btnConfirm = new Button();
            SuspendLayout();
           
            

            comboTeams.FormattingEnabled = true;
            comboTeams.Location = new Point(182, 94);
            comboTeams.Name = "comboTeams";
            comboTeams.Size = new Size(380, 40);
            comboTeams.TabIndex = 0;
            


            btnConfirm.Location = new Point(307, 217);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(150, 46);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
           


            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirm);
            Controls.Add(comboTeams);
            Name = "FormFavoriteTeam";
            Text = "FormFavoriteTeam";
            Load += FormFavoriteTeam_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboTeams;
        private Button btnConfirm;
    }
}