namespace WorldCup.WinForms.Forms
{
    partial class SettingsForm
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
            comboLanguage = new ComboBox();
            comboTournament = new ComboBox();
            btnConfirm = new Button();
            SuspendLayout();
            


            comboLanguage.FormattingEnabled = true;
            comboLanguage.Location = new Point(185, 120);
            comboLanguage.Name = "comboLanguage";
            comboLanguage.Size = new Size(345, 40);
            comboLanguage.TabIndex = 0;
            


            comboTournament.FormattingEnabled = true;
            comboTournament.Location = new Point(185, 244);
            comboTournament.Name = "comboTournament";
            comboTournament.Size = new Size(345, 40);
            comboTournament.TabIndex = 1;
            
            

            btnConfirm.Location = new Point(269, 349);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(170, 54);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "POTVRDI";
            btnConfirm.UseVisualStyleBackColor = true;
            


            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirm);
            Controls.Add(comboTournament);
            Controls.Add(comboLanguage);
            Name = "SettingsForm";
            Text = "SettingsForm";     
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboLanguage;
        private ComboBox comboTournament;
        private Button btnConfirm;
    }
}