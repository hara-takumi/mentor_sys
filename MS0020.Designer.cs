namespace Menter
{
    partial class MS0020
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
            this.lblMenty = new System.Windows.Forms.Label();
            this.cboMentee = new System.Windows.Forms.ComboBox();
            this.lblMenta = new System.Windows.Forms.Label();
            this.cboMenta = new System.Windows.Forms.ComboBox();
            this.メンター活動報告書 = new System.Windows.Forms.Label();
            this.dtpStart = new Metroit.Windows.Forms.MetDateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInsertUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblMenteeNm = new System.Windows.Forms.Label();
            this.lblMentorNm = new System.Windows.Forms.Label();
            this.dtpEnd = new Metroit.Windows.Forms.MetDateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            this.pnlUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMenty
            // 
            this.lblMenty.AutoSize = true;
            this.lblMenty.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenty.Location = new System.Drawing.Point(87, 169);
            this.lblMenty.Name = "lblMenty";
            this.lblMenty.Size = new System.Drawing.Size(88, 22);
            this.lblMenty.TabIndex = 26;
            this.lblMenty.Text = "メンティー";
            // 
            // cboMentee
            // 
            this.cboMentee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentee.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentee.FormattingEnabled = true;
            this.cboMentee.ItemHeight = 21;
            this.cboMentee.Location = new System.Drawing.Point(190, 165);
            this.cboMentee.Name = "cboMentee";
            this.cboMentee.Size = new System.Drawing.Size(158, 29);
            this.cboMentee.TabIndex = 2;
            // 
            // lblMenta
            // 
            this.lblMenta.AutoSize = true;
            this.lblMenta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenta.Location = new System.Drawing.Point(101, 114);
            this.lblMenta.Name = "lblMenta";
            this.lblMenta.Size = new System.Drawing.Size(74, 22);
            this.lblMenta.TabIndex = 24;
            this.lblMenta.Text = "メンター";
            // 
            // cboMenta
            // 
            this.cboMenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMenta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMenta.FormattingEnabled = true;
            this.cboMenta.ItemHeight = 21;
            this.cboMenta.Location = new System.Drawing.Point(190, 111);
            this.cboMenta.Name = "cboMenta";
            this.cboMenta.Size = new System.Drawing.Size(158, 29);
            this.cboMenta.TabIndex = 1;
            // 
            // メンター活動報告書
            // 
            this.メンター活動報告書.AutoSize = true;
            this.メンター活動報告書.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.メンター活動報告書.Location = new System.Drawing.Point(39, 29);
            this.メンター活動報告書.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.メンター活動報告書.Name = "メンター活動報告書";
            this.メンター活動報告書.Size = new System.Drawing.Size(386, 27);
            this.メンター活動報告書.TabIndex = 27;
            this.メンター活動報告書.Text = "メンター・メンティーマスタメンテナンス";
            // 
            // dtpStart
            // 
            this.dtpStart.AcceptNull = true;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(190, 219);
            this.dtpStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 29);
            this.dtpStart.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label6.Location = new System.Drawing.Point(55, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 32;
            this.label6.Text = "適用開始日";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(55, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 36;
            this.label1.Text = "適用終了日";
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(44, 612);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(115, 36);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsertUpdate
            // 
            this.btnInsertUpdate.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnInsertUpdate.Location = new System.Drawing.Point(197, 612);
            this.btnInsertUpdate.Name = "btnInsertUpdate";
            this.btnInsertUpdate.Size = new System.Drawing.Size(115, 36);
            this.btnInsertUpdate.TabIndex = 6;
            this.btnInsertUpdate.Text = "更新";
            this.btnInsertUpdate.UseVisualStyleBackColor = true;
            this.btnInsertUpdate.Click += new System.EventHandler(this.btnInsertUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnDelete.Location = new System.Drawing.Point(339, 612);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 36);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.Controls.Add(this.lblStart);
            this.pnlUpdate.Controls.Add(this.lblMenteeNm);
            this.pnlUpdate.Controls.Add(this.lblMentorNm);
            this.pnlUpdate.Location = new System.Drawing.Point(190, 106);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(381, 161);
            this.pnlUpdate.TabIndex = 98;
            this.pnlUpdate.Visible = false;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(3, 116);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(142, 22);
            this.lblStart.TabIndex = 99;
            this.lblStart.Text = "2020年7月8日";
            // 
            // lblMenteeNm
            // 
            this.lblMenteeNm.AutoSize = true;
            this.lblMenteeNm.Location = new System.Drawing.Point(3, 62);
            this.lblMenteeNm.Name = "lblMenteeNm";
            this.lblMenteeNm.Size = new System.Drawing.Size(110, 22);
            this.lblMenteeNm.TabIndex = 93;
            this.lblMenteeNm.Text = "メンティー名";
            // 
            // lblMentorNm
            // 
            this.lblMentorNm.AutoSize = true;
            this.lblMentorNm.Location = new System.Drawing.Point(3, 8);
            this.lblMentorNm.Name = "lblMentorNm";
            this.lblMentorNm.Size = new System.Drawing.Size(96, 22);
            this.lblMentorNm.TabIndex = 92;
            this.lblMentorNm.Text = "メンター名";
            // 
            // dtpEnd
            // 
            this.dtpEnd.AcceptNull = true;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(190, 273);
            this.dtpEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpEnd.TabIndex = 4;
            this.dtpEnd.Value = null;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Location = new System.Drawing.Point(867, 29);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(317, 22);
            this.lblUser.TabIndex = 101;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MS0020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.pnlUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsertUpdate);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.メンター活動報告書);
            this.Controls.Add(this.lblMenty);
            this.Controls.Add(this.cboMentee);
            this.Controls.Add(this.lblMenta);
            this.Controls.Add(this.cboMenta);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MS0020";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS0020";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MS0020_FormClosing);
            this.Load += new System.EventHandler(this.MS0020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            this.pnlUpdate.ResumeLayout(false);
            this.pnlUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenty;
        private System.Windows.Forms.ComboBox cboMentee;
        private System.Windows.Forms.Label lblMenta;
        private System.Windows.Forms.ComboBox cboMenta;
        private System.Windows.Forms.Label メンター活動報告書;
        private Metroit.Windows.Forms.MetDateTimePicker dtpStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnInsertUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlUpdate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblMenteeNm;
        private System.Windows.Forms.Label lblMentorNm;
        private Metroit.Windows.Forms.MetDateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblUser;
    }
}