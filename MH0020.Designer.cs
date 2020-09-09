namespace Menter
{
    partial class MH0020
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
            this.btnIchiranMentor = new System.Windows.Forms.Button();
            this.btnIchiranTeam = new System.Windows.Forms.Button();
            this.btnKrihiShokai = new System.Windows.Forms.Button();
            this.btnMasta = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.メンター活動報告書 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIchiranMentor
            // 
            this.btnIchiranMentor.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnIchiranMentor.Location = new System.Drawing.Point(45, 192);
            this.btnIchiranMentor.Name = "btnIchiranMentor";
            this.btnIchiranMentor.Size = new System.Drawing.Size(327, 71);
            this.btnIchiranMentor.TabIndex = 1;
            this.btnIchiranMentor.Text = "メンター活動実績入力";
            this.btnIchiranMentor.UseVisualStyleBackColor = true;
            this.btnIchiranMentor.Click += new System.EventHandler(this.btnIchiranMentor_Click);
            // 
            // btnIchiranTeam
            // 
            this.btnIchiranTeam.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnIchiranTeam.Location = new System.Drawing.Point(434, 192);
            this.btnIchiranTeam.Name = "btnIchiranTeam";
            this.btnIchiranTeam.Size = new System.Drawing.Size(327, 71);
            this.btnIchiranTeam.TabIndex = 2;
            this.btnIchiranTeam.Text = "メンター活動実績確認";
            this.btnIchiranTeam.UseVisualStyleBackColor = true;
            this.btnIchiranTeam.Click += new System.EventHandler(this.btnIchiranTeam_Click);
            // 
            // btnKrihiShokai
            // 
            this.btnKrihiShokai.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnKrihiShokai.Location = new System.Drawing.Point(823, 192);
            this.btnKrihiShokai.Name = "btnKrihiShokai";
            this.btnKrihiShokai.Size = new System.Drawing.Size(327, 71);
            this.btnKrihiShokai.TabIndex = 3;
            this.btnKrihiShokai.Text = "メンター活動経費照会";
            this.btnKrihiShokai.UseVisualStyleBackColor = true;
            this.btnKrihiShokai.Click += new System.EventHandler(this.btnKrihiShokai_Click);
            // 
            // btnMasta
            // 
            this.btnMasta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnMasta.Location = new System.Drawing.Point(434, 311);
            this.btnMasta.Name = "btnMasta";
            this.btnMasta.Size = new System.Drawing.Size(327, 71);
            this.btnMasta.TabIndex = 4;
            this.btnMasta.Text = "メンター・メンティーマスタメンテナンス";
            this.btnMasta.UseVisualStyleBackColor = true;
            this.btnMasta.Click += new System.EventHandler(this.btnMasta_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnLogout.Location = new System.Drawing.Point(823, 520);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(327, 71);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "ログアウト";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // メンター活動報告書
            // 
            this.メンター活動報告書.AutoSize = true;
            this.メンター活動報告書.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.メンター活動報告書.Location = new System.Drawing.Point(452, 57);
            this.メンター活動報告書.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.メンター活動報告書.Name = "メンター活動報告書";
            this.メンター活動報告書.Size = new System.Drawing.Size(286, 27);
            this.メンター活動報告書.TabIndex = 3;
            this.メンター活動報告書.Text = "メンター活動報告システム";
            // 
            // MH0020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.メンター活動報告書);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMasta);
            this.Controls.Add(this.btnKrihiShokai);
            this.Controls.Add(this.btnIchiranTeam);
            this.Controls.Add(this.btnIchiranMentor);
            this.Name = "MH0020";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MH0020";
            this.Load += new System.EventHandler(this.MH0020_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIchiranMentor;
        private System.Windows.Forms.Button btnIchiranTeam;
        private System.Windows.Forms.Button btnKrihiShokai;
        private System.Windows.Forms.Button btnMasta;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label メンター活動報告書;
    }
}