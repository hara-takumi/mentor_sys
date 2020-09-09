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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSuisinb = new System.Windows.Forms.Panel();
            this.dtpEndSuisnb = new Metroit.Windows.Forms.MetDateTimePicker();
            this.dtpStartSuisnb = new Metroit.Windows.Forms.MetDateTimePicker();
            this.lblDash = new System.Windows.Forms.Label();
            this.chkCorrectSuisnb = new System.Windows.Forms.CheckBox();
            this.lblMentee = new System.Windows.Forms.Label();
            this.cboMenteeSuisinb = new System.Windows.Forms.ComboBox();
            this.lblMentor = new System.Windows.Forms.Label();
            this.cboMentor = new System.Windows.Forms.ComboBox();
            this.lblExecDate = new System.Windows.Forms.Label();
            this.pnlMentor = new System.Windows.Forms.Panel();
            this.dtpEnd = new Metroit.Windows.Forms.MetDateTimePicker();
            this.dtpStart = new Metroit.Windows.Forms.MetDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCorrect = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMentee = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.SENTAKU = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MENTOR_RESULT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXEC_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENTEE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORRECT_FLG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORRECT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSuisinb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndSuisnb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartSuisnb)).BeginInit();
            this.pnlMentor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.lblTitle.Location = new System.Drawing.Point(27, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 27);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "メンター活動実績一覧";
            // 
            // pnlSuisinb
            // 
            this.pnlSuisinb.Controls.Add(this.dtpEndSuisnb);
            this.pnlSuisinb.Controls.Add(this.dtpStartSuisnb);
            this.pnlSuisinb.Controls.Add(this.lblDash);
            this.pnlSuisinb.Controls.Add(this.chkCorrectSuisnb);
            this.pnlSuisinb.Controls.Add(this.lblMentee);
            this.pnlSuisinb.Controls.Add(this.cboMenteeSuisinb);
            this.pnlSuisinb.Controls.Add(this.lblMentor);
            this.pnlSuisinb.Controls.Add(this.cboMentor);
            this.pnlSuisinb.Controls.Add(this.lblExecDate);
            this.pnlSuisinb.Location = new System.Drawing.Point(32, 60);
            this.pnlSuisinb.Name = "pnlSuisinb";
            this.pnlSuisinb.Size = new System.Drawing.Size(1029, 149);
            this.pnlSuisinb.TabIndex = 1;
            // 
            // dtpEndSuisnb
            // 
            this.dtpEndSuisnb.AcceptNull = true;
            this.dtpEndSuisnb.Location = new System.Drawing.Point(352, 15);
            this.dtpEndSuisnb.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpEndSuisnb.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEndSuisnb.Name = "dtpEndSuisnb";
            this.dtpEndSuisnb.Size = new System.Drawing.Size(200, 29);
            this.dtpEndSuisnb.TabIndex = 2;
            this.dtpEndSuisnb.Value = null;
            this.dtpEndSuisnb.ValueChanged += new System.EventHandler(this.dtpEndSuisnb_ValueChanged);
            // 
            // dtpStartSuisnb
            // 
            this.dtpStartSuisnb.AcceptNull = true;
            this.dtpStartSuisnb.Location = new System.Drawing.Point(102, 15);
            this.dtpStartSuisnb.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpStartSuisnb.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStartSuisnb.Name = "dtpStartSuisnb";
            this.dtpStartSuisnb.Size = new System.Drawing.Size(200, 29);
            this.dtpStartSuisnb.TabIndex = 1;
            this.dtpStartSuisnb.Value = null;
            this.dtpStartSuisnb.ValueChanged += new System.EventHandler(this.dtpStartSuisnb_ValueChanged);
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
            // chkCorrectSuisnb
            // 
            this.chkCorrectSuisnb.AutoSize = true;
            this.chkCorrectSuisnb.Location = new System.Drawing.Point(588, 110);
            this.chkCorrectSuisnb.Name = "chkCorrectSuisnb";
            this.chkCorrectSuisnb.Size = new System.Drawing.Size(195, 26);
            this.chkCorrectSuisnb.TabIndex = 5;
            this.chkCorrectSuisnb.Text = "コメント未確認のみ";
            this.chkCorrectSuisnb.UseVisualStyleBackColor = true;
            // 
            // lblMentee
            // 
            this.lblMentee.AutoSize = true;
            this.lblMentee.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMentee.Location = new System.Drawing.Point(10, 108);
            this.lblMentee.Name = "lblMentee";
            this.lblMentee.Size = new System.Drawing.Size(88, 22);
            this.lblMentee.TabIndex = 22;
            this.lblMentee.Text = "メンティー";
            // 
            // cboMenteeSuisinb
            // 
            this.cboMenteeSuisinb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenteeSuisinb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMenteeSuisinb.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMenteeSuisinb.FormattingEnabled = true;
            this.cboMenteeSuisinb.ItemHeight = 21;
            this.cboMenteeSuisinb.Location = new System.Drawing.Point(102, 104);
            this.cboMenteeSuisinb.Name = "cboMenteeSuisinb";
            this.cboMenteeSuisinb.Size = new System.Drawing.Size(158, 29);
            this.cboMenteeSuisinb.TabIndex = 4;
            // 
            // lblMentor
            // 
            this.lblMentor.AutoSize = true;
            this.lblMentor.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblMentor.Location = new System.Drawing.Point(10, 62);
            this.lblMentor.Name = "lblMentor";
            this.lblMentor.Size = new System.Drawing.Size(74, 22);
            this.lblMentor.TabIndex = 20;
            this.lblMentor.Text = "メンター";
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
            this.cboMentor.TabIndex = 3;
            this.cboMentor.SelectedValueChanged += new System.EventHandler(this.cboMentor_SelectedValueChanged);
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
            // pnlMentor
            // 
            this.pnlMentor.Controls.Add(this.dtpEnd);
            this.pnlMentor.Controls.Add(this.dtpStart);
            this.pnlMentor.Controls.Add(this.label1);
            this.pnlMentor.Controls.Add(this.chkCorrect);
            this.pnlMentor.Controls.Add(this.label2);
            this.pnlMentor.Controls.Add(this.cboMentee);
            this.pnlMentor.Controls.Add(this.label4);
            this.pnlMentor.Location = new System.Drawing.Point(29, 60);
            this.pnlMentor.Name = "pnlMentor";
            this.pnlMentor.Size = new System.Drawing.Size(1029, 149);
            this.pnlMentor.TabIndex = 103;
            // 
            // dtpEnd
            // 
            this.dtpEnd.AcceptNull = true;
            this.dtpEnd.Location = new System.Drawing.Point(352, 54);
            this.dtpEnd.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpEnd.TabIndex = 3;
            this.dtpEnd.Value = null;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.AcceptNull = true;
            this.dtpStart.Location = new System.Drawing.Point(102, 54);
            this.dtpStart.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 29);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.Value = null;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(314, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "～";
            // 
            // chkCorrect
            // 
            this.chkCorrect.AutoSize = true;
            this.chkCorrect.Location = new System.Drawing.Point(588, 110);
            this.chkCorrect.Name = "chkCorrect";
            this.chkCorrect.Size = new System.Drawing.Size(195, 26);
            this.chkCorrect.TabIndex = 4;
            this.chkCorrect.Text = "コメント未確認のみ";
            this.chkCorrect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "メンティー";
            // 
            // cboMentee
            // 
            this.cboMentee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentee.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentee.FormattingEnabled = true;
            this.cboMentee.ItemHeight = 21;
            this.cboMentee.Location = new System.Drawing.Point(102, 15);
            this.cboMentee.Name = "cboMentee";
            this.cboMentee.Size = new System.Drawing.Size(158, 29);
            this.cboMentee.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label4.Location = new System.Drawing.Point(10, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "実施日";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnCreate.Location = new System.Drawing.Point(32, 233);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(84, 36);
            this.btnCreate.TabIndex = 6;
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
            this.btnClear.TabIndex = 7;
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
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "新規登録";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.AllowUserToAddRows = false;
            this.dgvIchiran.AllowUserToResizeColumns = false;
            this.dgvIchiran.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIchiran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIchiran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SENTAKU,
            this.MENTOR_RESULT_ID,
            this.EXEC_DATE,
            this.MENTOR_NAME,
            this.MENTEE_NAME,
            this.STATUS,
            this.REPORT_DT,
            this.CORRECT_FLG,
            this.CORRECT_DT});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIchiran.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIchiran.Location = new System.Drawing.Point(32, 310);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowHeadersVisible = false;
            dataGridViewCellStyle6.NullValue = null;
            this.dgvIchiran.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvIchiran.RowTemplate.Height = 30;
            this.dgvIchiran.Size = new System.Drawing.Size(1143, 318);
            this.dgvIchiran.TabIndex = 9;
            this.dgvIchiran.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentClick);
            this.dgvIchiran.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellContentDoubleClick);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(32, 634);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(84, 36);
            this.btnReturn.TabIndex = 10;
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
            // SENTAKU
            // 
            this.SENTAKU.DataPropertyName = "SENTAKU";
            this.SENTAKU.HeaderText = "";
            this.SENTAKU.Name = "SENTAKU";
            // 
            // MENTOR_RESULT_ID
            // 
            this.MENTOR_RESULT_ID.DataPropertyName = "MENTOR_RESULT_ID";
            this.MENTOR_RESULT_ID.HeaderText = "メンター実績ID";
            this.MENTOR_RESULT_ID.Name = "MENTOR_RESULT_ID";
            this.MENTOR_RESULT_ID.ReadOnly = true;
            this.MENTOR_RESULT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MENTOR_RESULT_ID.Visible = false;
            // 
            // EXEC_DATE
            // 
            this.EXEC_DATE.DataPropertyName = "EXEC_DATE";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.EXEC_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.EXEC_DATE.HeaderText = "実施日";
            this.EXEC_DATE.Name = "EXEC_DATE";
            this.EXEC_DATE.ReadOnly = true;
            this.EXEC_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EXEC_DATE.Width = 150;
            // 
            // MENTOR_NAME
            // 
            this.MENTOR_NAME.DataPropertyName = "MENTOR_NAME";
            this.MENTOR_NAME.HeaderText = "メンター";
            this.MENTOR_NAME.Name = "MENTOR_NAME";
            this.MENTOR_NAME.ReadOnly = true;
            this.MENTOR_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MENTOR_NAME.Width = 120;
            // 
            // MENTEE_NAME
            // 
            this.MENTEE_NAME.DataPropertyName = "MENTEE_NAME";
            this.MENTEE_NAME.HeaderText = "メンティ―";
            this.MENTEE_NAME.Name = "MENTEE_NAME";
            this.MENTEE_NAME.ReadOnly = true;
            this.MENTEE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MENTEE_NAME.Width = 120;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "状況";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUS.Width = 110;
            // 
            // REPORT_DT
            // 
            this.REPORT_DT.DataPropertyName = "REPORT_DT";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.REPORT_DT.DefaultCellStyle = dataGridViewCellStyle3;
            this.REPORT_DT.HeaderText = "報告日時";
            this.REPORT_DT.Name = "REPORT_DT";
            this.REPORT_DT.ReadOnly = true;
            this.REPORT_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.REPORT_DT.Width = 195;
            // 
            // CORRECT_FLG
            // 
            this.CORRECT_FLG.DataPropertyName = "CORRECT_FLG";
            this.CORRECT_FLG.HeaderText = "メンター確認コメント";
            this.CORRECT_FLG.Name = "CORRECT_FLG";
            this.CORRECT_FLG.ReadOnly = true;
            this.CORRECT_FLG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CORRECT_FLG.Width = 130;
            // 
            // CORRECT_DT
            // 
            this.CORRECT_DT.DataPropertyName = "CORRECT_DT";
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.CORRECT_DT.DefaultCellStyle = dataGridViewCellStyle4;
            this.CORRECT_DT.HeaderText = "最終確認日時";
            this.CORRECT_DT.Name = "CORRECT_DT";
            this.CORRECT_DT.ReadOnly = true;
            this.CORRECT_DT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CORRECT_DT.Width = 195;
            // 
            // MH0030
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.pnlMentor);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlSuisinb);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MH0030";
            this.Text = "MH0030";
            this.Load += new System.EventHandler(this.MH0020_Load);
            this.pnlSuisinb.ResumeLayout(false);
            this.pnlSuisinb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndSuisnb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartSuisnb)).EndInit();
            this.pnlMentor.ResumeLayout(false);
            this.pnlMentor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSuisinb;
        private System.Windows.Forms.Label lblMentee;
        private System.Windows.Forms.ComboBox cboMenteeSuisinb;
        private System.Windows.Forms.Label lblMentor;
        private System.Windows.Forms.ComboBox cboMentor;
        private System.Windows.Forms.Label lblExecDate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.CheckBox chkCorrectSuisnb;
        private System.Windows.Forms.Label lblDash;
        private Metroit.Windows.Forms.MetDateTimePicker dtpStartSuisnb;
        private Metroit.Windows.Forms.MetDateTimePicker dtpEndSuisnb;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlMentor;
        private Metroit.Windows.Forms.MetDateTimePicker dtpEnd;
        private Metroit.Windows.Forms.MetDateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCorrect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMentee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewButtonColumn SENTAKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENTOR_RESULT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXEC_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENTOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENTEE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORRECT_FLG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORRECT_DT;
    }
}