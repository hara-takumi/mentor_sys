namespace Menter
{
    partial class MH0030
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dtpEnd = new Metroit.Windows.Forms.MetDateTimePicker();
            this.dtpStart = new Metroit.Windows.Forms.MetDateTimePicker();
            this.lblDash = new System.Windows.Forms.Label();
            this.chkCorrect = new System.Windows.Forms.CheckBox();
            this.lblMenty = new System.Windows.Forms.Label();
            this.cboMentee = new System.Windows.Forms.ComboBox();
            this.lblMenta = new System.Windows.Forms.Label();
            this.cboMentor = new System.Windows.Forms.ComboBox();
            this.lblExecDate = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.txtTitle.Location = new System.Drawing.Point(27, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(254, 27);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "メンター活動実績一覧";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.dtpEnd);
            this.pnlHeader.Controls.Add(this.dtpStart);
            this.pnlHeader.Controls.Add(this.lblDash);
            this.pnlHeader.Controls.Add(this.chkCorrect);
            this.pnlHeader.Controls.Add(this.lblMenty);
            this.pnlHeader.Controls.Add(this.cboMentee);
            this.pnlHeader.Controls.Add(this.lblMenta);
            this.pnlHeader.Controls.Add(this.cboMentor);
            this.pnlHeader.Controls.Add(this.lblExecDate);
            this.pnlHeader.Location = new System.Drawing.Point(32, 60);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1029, 149);
            this.pnlHeader.TabIndex = 1;
            // 
            // dtpEnd
            // 
            this.dtpEnd.AcceptNull = true;
            this.dtpEnd.Location = new System.Drawing.Point(352, 15);
            this.dtpEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpEnd.TabIndex = 11;
            this.dtpEnd.Value = null;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.AcceptNull = true;
            this.dtpStart.Location = new System.Drawing.Point(102, 15);
            this.dtpStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 29);
            this.dtpStart.TabIndex = 10;
            this.dtpStart.Value = null;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblDash.Location = new System.Drawing.Point(314, 19);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(32, 22);
            this.lblDash.TabIndex = 30;
            this.lblDash.Text = "～";
            // 
            // chkCorrect
            // 
            this.chkCorrect.AutoSize = true;
            this.chkCorrect.Location = new System.Drawing.Point(588, 110);
            this.chkCorrect.Name = "chkCorrect";
            this.chkCorrect.Size = new System.Drawing.Size(195, 26);
            this.chkCorrect.TabIndex = 14;
            this.chkCorrect.Text = "コメント未確認のみ";
            this.chkCorrect.UseVisualStyleBackColor = true;
            // 
            // lblMenty
            // 
            this.lblMenty.AutoSize = true;
            this.lblMenty.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenty.Location = new System.Drawing.Point(10, 108);
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
            this.cboMentee.Location = new System.Drawing.Point(102, 104);
            this.cboMentee.Name = "cboMentee";
            this.cboMentee.Size = new System.Drawing.Size(158, 29);
            this.cboMentee.TabIndex = 13;
            // 
            // lblMenta
            // 
            this.lblMenta.AutoSize = true;
            this.lblMenta.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMenta.Location = new System.Drawing.Point(10, 62);
            this.lblMenta.Name = "lblMenta";
            this.lblMenta.Size = new System.Drawing.Size(74, 22);
            this.lblMenta.TabIndex = 20;
            this.lblMenta.Text = "メンター";
            // 
            // cboMentor
            // 
            this.cboMentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentor.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentor.FormattingEnabled = true;
            this.cboMentor.ItemHeight = 21;
            this.cboMentor.Location = new System.Drawing.Point(102, 58);
            this.cboMentor.Name = "cboMentor";
            this.cboMentor.Size = new System.Drawing.Size(158, 29);
            this.cboMentor.TabIndex = 12;
            this.cboMentor.TextChanged += new System.EventHandler(this.cboMentor_TextChanged);
            // 
            // lblExecDate
            // 
            this.lblExecDate.AutoSize = true;
            this.lblExecDate.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblExecDate.Location = new System.Drawing.Point(10, 19);
            this.lblExecDate.Name = "lblExecDate";
            this.lblExecDate.Size = new System.Drawing.Size(76, 22);
            this.lblExecDate.TabIndex = 11;
            this.lblExecDate.Text = "実施日";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnCreate.Location = new System.Drawing.Point(32, 233);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(84, 36);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "表示";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnClear.Location = new System.Drawing.Point(143, 233);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 36);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnInsert.Location = new System.Drawing.Point(258, 233);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(115, 36);
            this.btnInsert.TabIndex = 17;
            this.btnInsert.Text = "新規登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIchiran.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIchiran.Location = new System.Drawing.Point(32, 301);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1143, 318);
            this.dgvIchiran.TabIndex = 18;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            this.dgvIchiran.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentDoubleClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(32, 634);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(84, 36);
            this.btnReturn.TabIndex = 19;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Location = new System.Drawing.Point(858, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(317, 22);
            this.lblUser.TabIndex = 102;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MH0030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.txtTitle);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MH0030";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MH0030";
            this.Load += new System.EventHandler(this.MH0020_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMenty;
        private System.Windows.Forms.ComboBox cboMentee;
        private System.Windows.Forms.Label lblMenta;
        private System.Windows.Forms.ComboBox cboMentor;
        private System.Windows.Forms.Label lblExecDate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.CheckBox chkCorrect;
        private System.Windows.Forms.Label lblDash;
        private Metroit.Windows.Forms.MetDateTimePicker dtpStart;
        private Metroit.Windows.Forms.MetDateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblUser;
    }
}