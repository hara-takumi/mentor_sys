namespace Menter
{
    partial class MS0010
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.メンター活動報告書 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dtpEnd = new Metroit.Windows.Forms.MetDateTimePicker();
            this.dtpStart = new Metroit.Windows.Forms.MetDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMenty = new System.Windows.Forms.Label();
            this.cboMentee = new System.Windows.Forms.ComboBox();
            this.lblMenta = new System.Windows.Forms.Label();
            this.cboMenta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.SuspendLayout();
            // 
            // メンター活動報告書
            // 
            this.メンター活動報告書.AutoSize = true;
            this.メンター活動報告書.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.メンター活動報告書.Location = new System.Drawing.Point(40, 30);
            this.メンター活動報告書.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.メンター活動報告書.Name = "メンター活動報告書";
            this.メンター活動報告書.Size = new System.Drawing.Size(317, 27);
            this.メンター活動報告書.TabIndex = 2;
            this.メンター活動報告書.Text = "メンター・メンティーマスタ一覧";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.dtpEnd);
            this.pnlHeader.Controls.Add(this.dtpStart);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.lblMenty);
            this.pnlHeader.Controls.Add(this.cboMentee);
            this.pnlHeader.Controls.Add(this.lblMenta);
            this.pnlHeader.Controls.Add(this.cboMenta);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Location = new System.Drawing.Point(45, 70);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1029, 149);
            this.pnlHeader.TabIndex = 12;
            // 
            // dtpEnd
            // 
            this.dtpEnd.AcceptNull = true;
            this.dtpEnd.Location = new System.Drawing.Point(365, 16);
            this.dtpEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.AcceptNull = true;
            this.dtpStart.Location = new System.Drawing.Point(107, 16);
            this.dtpStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 29);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.Value = null;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label5.Location = new System.Drawing.Point(321, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "～";
            // 
            // lblMenty
            // 
            this.lblMenty.AutoSize = true;
            this.lblMenty.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenty.Location = new System.Drawing.Point(15, 110);
            this.lblMenty.Name = "lblMenty";
            this.lblMenty.Size = new System.Drawing.Size(88, 22);
            this.lblMenty.TabIndex = 22;
            this.lblMenty.Text = "メンティー";
            // 
            // cboMentee
            // 
            this.cboMentee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentee.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentee.FormattingEnabled = true;
            this.cboMentee.ItemHeight = 21;
            this.cboMentee.Location = new System.Drawing.Point(107, 106);
            this.cboMentee.Name = "cboMentee";
            this.cboMentee.Size = new System.Drawing.Size(158, 29);
            this.cboMentee.TabIndex = 4;
            // 
            // lblMenta
            // 
            this.lblMenta.AutoSize = true;
            this.lblMenta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenta.Location = new System.Drawing.Point(15, 64);
            this.lblMenta.Name = "lblMenta";
            this.lblMenta.Size = new System.Drawing.Size(74, 22);
            this.lblMenta.TabIndex = 20;
            this.lblMenta.Text = "メンター";
            // 
            // cboMenta
            // 
            this.cboMenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMenta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMenta.FormattingEnabled = true;
            this.cboMenta.ItemHeight = 21;
            this.cboMenta.Location = new System.Drawing.Point(107, 60);
            this.cboMenta.Name = "cboMenta";
            this.cboMenta.Size = new System.Drawing.Size(158, 29);
            this.cboMenta.TabIndex = 3;
            this.cboMenta.TextChanged += new System.EventHandler(this.cboMenta_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label6.Location = new System.Drawing.Point(15, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "適用日";
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIchiran.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIchiran.Location = new System.Drawing.Point(45, 279);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1143, 350);
            this.dgvIchiran.TabIndex = 8;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            this.dgvIchiran.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentDoubleClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(45, 635);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(84, 36);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnInsert.Location = new System.Drawing.Point(271, 228);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(115, 36);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "新規登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnClear.Location = new System.Drawing.Point(156, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnDisplay.Location = new System.Drawing.Point(45, 228);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(84, 36);
            this.btnDisplay.TabIndex = 5;
            this.btnDisplay.Text = "表示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Location = new System.Drawing.Point(871, 34);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(317, 22);
            this.lblUser.TabIndex = 100;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MS0010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.メンター活動報告書);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MS0010";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS0010";
            this.Load += new System.EventHandler(this.MS0010_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label メンター活動報告書;
        private System.Windows.Forms.Panel pnlHeader;
        private Metroit.Windows.Forms.MetDateTimePicker dtpEnd;
        private Metroit.Windows.Forms.MetDateTimePicker dtpStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMenty;
        private System.Windows.Forms.ComboBox cboMentee;
        private System.Windows.Forms.Label lblMenta;
        private System.Windows.Forms.ComboBox cboMenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Label lblUser;
    }
}