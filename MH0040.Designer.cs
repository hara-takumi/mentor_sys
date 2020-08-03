namespace Menter
{
    partial class MH0040
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTitle = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReport = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.btnRowInsert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnToroku = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDatePlan = new Metroit.Windows.Forms.MetDateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPlanPlace = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPlanEndM = new System.Windows.Forms.ComboBox();
            this.cboPlanEndH = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboPlanStartM = new System.Windows.Forms.ComboBox();
            this.cboPlanStartH = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEndM = new System.Windows.Forms.ComboBox();
            this.cboEndH = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStartM = new System.Windows.Forms.ComboBox();
            this.cboStartH = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDn = new System.Windows.Forms.Button();
            this.lblMenta = new System.Windows.Forms.Label();
            this.btnRowDelete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlPromote = new System.Windows.Forms.Panel();
            this.lblMentee = new System.Windows.Forms.Label();
            this.lblPlanPlace = new System.Windows.Forms.Label();
            this.lblPlanTime = new System.Windows.Forms.Label();
            this.lblDatePlan = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblExecTime = new System.Windows.Forms.Label();
            this.lblExecDate = new System.Windows.Forms.Label();
            this.lblMentor = new System.Windows.Forms.Label();
            this.btnRemand = new System.Windows.Forms.Button();
            this.dtpExecDate = new Metroit.Windows.Forms.MetDateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.cboMentee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatePlan)).BeginInit();
            this.pnlPromote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExecDate)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.txtTitle.Location = new System.Drawing.Point(24, 17);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(254, 27);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "メンター活動実績入力";
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(16, 642);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 32);
            this.btnReturn.TabIndex = 21;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReport.Location = new System.Drawing.Point(263, 642);
            this.btnReport.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(102, 32);
            this.btnReport.TabIndex = 24;
            this.btnReport.Text = "報告";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(1425, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "ログインユーザー";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label10.Location = new System.Drawing.Point(100, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 22);
            this.label10.TabIndex = 46;
            this.label10.Text = "予定場所：";
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(575, 92);
            this.txtReport.MaxLength = 1000;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(633, 355);
            this.txtReport.TabIndex = 17;
            this.txtReport.Text = "";
            this.txtReport.TextChanged += new System.EventHandler(this.txtReport_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label16.Location = new System.Drawing.Point(571, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 22);
            this.label16.TabIndex = 51;
            this.label16.Text = "報告事項";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label17.Location = new System.Drawing.Point(571, 474);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(233, 22);
            this.label17.TabIndex = 52;
            this.label17.Text = "メンター推進チームコメント";
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
            this.dgvIchiran.Location = new System.Drawing.Point(575, 524);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(633, 150);
            this.dgvIchiran.TabIndex = 20;
            this.dgvIchiran.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIchiran_CellValidated);
            // 
            // btnRowInsert
            // 
            this.btnRowInsert.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnRowInsert.Location = new System.Drawing.Point(987, 478);
            this.btnRowInsert.Name = "btnRowInsert";
            this.btnRowInsert.Size = new System.Drawing.Size(102, 32);
            this.btnRowInsert.TabIndex = 18;
            this.btnRowInsert.Text = "行追加";
            this.btnRowInsert.UseVisualStyleBackColor = true;
            this.btnRowInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnSave.Location = new System.Drawing.Point(130, 642);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 32);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "一時保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnToroku
            // 
            this.btnToroku.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnToroku.Location = new System.Drawing.Point(263, 642);
            this.btnToroku.Name = "btnToroku";
            this.btnToroku.Size = new System.Drawing.Size(102, 32);
            this.btnToroku.TabIndex = 23;
            this.btnToroku.Text = "登録";
            this.btnToroku.UseVisualStyleBackColor = true;
            this.btnToroku.Click += new System.EventHandler(this.btnToroku_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDatePlan);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtPlanPlace);
            this.panel1.Controls.Add(this.txtPlace);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboPlanEndM);
            this.panel1.Controls.Add(this.cboPlanEndH);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cboPlanStartM);
            this.panel1.Controls.Add(this.cboPlanStartH);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboEndM);
            this.panel1.Controls.Add(this.cboEndH);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboStartM);
            this.panel1.Controls.Add(this.cboStartH);
            this.panel1.Location = new System.Drawing.Point(207, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 349);
            this.panel1.TabIndex = 5;
            // 
            // dtpDatePlan
            // 
            this.dtpDatePlan.AcceptNull = true;
            this.dtpDatePlan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePlan.Location = new System.Drawing.Point(0, 205);
            this.dtpDatePlan.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDatePlan.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDatePlan.Name = "dtpDatePlan";
            this.dtpDatePlan.Size = new System.Drawing.Size(200, 29);
            this.dtpDatePlan.TabIndex = 11;
            this.dtpDatePlan.Value = null;
            this.dtpDatePlan.ValueChanged += new System.EventHandler(this.dtpDatePlan_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label19.Location = new System.Drawing.Point(115, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 22);
            this.label19.TabIndex = 90;
            this.label19.Text = "円";
            // 
            // txtPlanPlace
            // 
            this.txtPlanPlace.Location = new System.Drawing.Point(0, 309);
            this.txtPlanPlace.MaxLength = 24;
            this.txtPlanPlace.Name = "txtPlanPlace";
            this.txtPlanPlace.Size = new System.Drawing.Size(306, 29);
            this.txtPlanPlace.TabIndex = 16;
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(0, 47);
            this.txtPlace.MaxLength = 24;
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(309, 29);
            this.txtPlace.TabIndex = 9;
            this.txtPlace.TextChanged += new System.EventHandler(this.txtPlace_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label11.Location = new System.Drawing.Point(139, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 22);
            this.label11.TabIndex = 87;
            this.label11.Text = "～";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label12.Location = new System.Drawing.Point(233, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 22);
            this.label12.TabIndex = 86;
            this.label12.Text = "：";
            // 
            // cboPlanEndM
            // 
            this.cboPlanEndM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanEndM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanEndM.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboPlanEndM.FormattingEnabled = true;
            this.cboPlanEndM.ItemHeight = 21;
            this.cboPlanEndM.Location = new System.Drawing.Point(255, 257);
            this.cboPlanEndM.Name = "cboPlanEndM";
            this.cboPlanEndM.Size = new System.Drawing.Size(54, 29);
            this.cboPlanEndM.TabIndex = 15;
            this.cboPlanEndM.TextChanged += new System.EventHandler(this.cboPlanEndM_TextChanged);
            // 
            // cboPlanEndH
            // 
            this.cboPlanEndH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanEndH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanEndH.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboPlanEndH.FormattingEnabled = true;
            this.cboPlanEndH.ItemHeight = 21;
            this.cboPlanEndH.Location = new System.Drawing.Point(175, 257);
            this.cboPlanEndH.Name = "cboPlanEndH";
            this.cboPlanEndH.Size = new System.Drawing.Size(54, 29);
            this.cboPlanEndH.TabIndex = 14;
            this.cboPlanEndH.TextChanged += new System.EventHandler(this.cboPlanEndH_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label13.Location = new System.Drawing.Point(60, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 22);
            this.label13.TabIndex = 83;
            this.label13.Text = "：";
            // 
            // cboPlanStartM
            // 
            this.cboPlanStartM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanStartM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanStartM.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboPlanStartM.FormattingEnabled = true;
            this.cboPlanStartM.ItemHeight = 21;
            this.cboPlanStartM.Location = new System.Drawing.Point(82, 258);
            this.cboPlanStartM.Name = "cboPlanStartM";
            this.cboPlanStartM.Size = new System.Drawing.Size(54, 29);
            this.cboPlanStartM.TabIndex = 13;
            this.cboPlanStartM.TextChanged += new System.EventHandler(this.cboPlanStartM_TextChanged);
            // 
            // cboPlanStartH
            // 
            this.cboPlanStartH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanStartH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlanStartH.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboPlanStartH.FormattingEnabled = true;
            this.cboPlanStartH.ItemHeight = 21;
            this.cboPlanStartH.Location = new System.Drawing.Point(0, 259);
            this.cboPlanStartH.Name = "cboPlanStartH";
            this.cboPlanStartH.Size = new System.Drawing.Size(54, 29);
            this.cboPlanStartH.TabIndex = 12;
            this.cboPlanStartH.TextChanged += new System.EventHandler(this.cboPlanStartH_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPrice.Location = new System.Drawing.Point(0, 93);
            this.txtPrice.MaxLength = 6;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 29);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label7.Location = new System.Drawing.Point(139, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 22);
            this.label7.TabIndex = 79;
            this.label7.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label5.Location = new System.Drawing.Point(233, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 78;
            this.label5.Text = "：";
            // 
            // cboEndM
            // 
            this.cboEndM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEndM.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboEndM.FormattingEnabled = true;
            this.cboEndM.ItemHeight = 21;
            this.cboEndM.Location = new System.Drawing.Point(255, 5);
            this.cboEndM.Name = "cboEndM";
            this.cboEndM.Size = new System.Drawing.Size(54, 29);
            this.cboEndM.TabIndex = 8;
            this.cboEndM.TextChanged += new System.EventHandler(this.cboEndM_TextChanged);
            // 
            // cboEndH
            // 
            this.cboEndH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEndH.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboEndH.FormattingEnabled = true;
            this.cboEndH.ItemHeight = 21;
            this.cboEndH.Location = new System.Drawing.Point(175, 6);
            this.cboEndH.Name = "cboEndH";
            this.cboEndH.Size = new System.Drawing.Size(54, 29);
            this.cboEndH.TabIndex = 7;
            this.cboEndH.TextChanged += new System.EventHandler(this.cboEndH_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label4.Location = new System.Drawing.Point(58, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 22);
            this.label4.TabIndex = 75;
            this.label4.Text = "：";
            // 
            // cboStartM
            // 
            this.cboStartM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStartM.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboStartM.FormattingEnabled = true;
            this.cboStartM.ItemHeight = 21;
            this.cboStartM.Location = new System.Drawing.Point(82, 6);
            this.cboStartM.Name = "cboStartM";
            this.cboStartM.Size = new System.Drawing.Size(54, 29);
            this.cboStartM.TabIndex = 6;
            this.cboStartM.TextChanged += new System.EventHandler(this.cboStartM_TextChanged);
            // 
            // cboStartH
            // 
            this.cboStartH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboStartH.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboStartH.FormattingEnabled = true;
            this.cboStartH.ItemHeight = 21;
            this.cboStartH.Location = new System.Drawing.Point(0, 6);
            this.cboStartH.Name = "cboStartH";
            this.cboStartH.Size = new System.Drawing.Size(54, 29);
            this.cboStartH.TabIndex = 5;
            this.cboStartH.TextChanged += new System.EventHandler(this.cboStartH_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label6.Location = new System.Drawing.Point(123, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "実施日：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label20.Location = new System.Drawing.Point(110, 145);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 22);
            this.label20.TabIndex = 23;
            this.label20.Text = "メンティー：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(100, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "実施時間：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label8.Location = new System.Drawing.Point(100, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 22);
            this.label8.TabIndex = 34;
            this.label8.Text = "実施場所：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label9.Location = new System.Drawing.Point(144, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 22);
            this.label9.TabIndex = 36;
            this.label9.Text = "経費：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label14.Location = new System.Drawing.Point(100, 482);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 22);
            this.label14.TabIndex = 38;
            this.label14.Text = "予定時間：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label15.Location = new System.Drawing.Point(122, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 22);
            this.label15.TabIndex = 48;
            this.label15.Text = "予定日：";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(271, 53);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 37);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "→";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDn
            // 
            this.btnDn.Location = new System.Drawing.Point(205, 53);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(40, 37);
            this.btnDn.TabIndex = 1;
            this.btnDn.Text = "←";
            this.btnDn.UseVisualStyleBackColor = true;
            this.btnDn.Click += new System.EventHandler(this.btnDn_Click);
            // 
            // lblMenta
            // 
            this.lblMenta.AutoSize = true;
            this.lblMenta.Location = new System.Drawing.Point(124, 103);
            this.lblMenta.Name = "lblMenta";
            this.lblMenta.Size = new System.Drawing.Size(85, 22);
            this.lblMenta.TabIndex = 99;
            this.lblMenta.Text = "メンター：";
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnRowDelete.Location = new System.Drawing.Point(1106, 478);
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.Size = new System.Drawing.Size(102, 32);
            this.btnRowDelete.TabIndex = 19;
            this.btnRowDelete.Text = "行削除";
            this.btnRowDelete.UseVisualStyleBackColor = true;
            this.btnRowDelete.Click += new System.EventHandler(this.btnRowDelete_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnDelete.Location = new System.Drawing.Point(382, 642);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 32);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlPromote
            // 
            this.pnlPromote.Controls.Add(this.lblMentee);
            this.pnlPromote.Controls.Add(this.lblPlanPlace);
            this.pnlPromote.Controls.Add(this.lblPlanTime);
            this.pnlPromote.Controls.Add(this.lblDatePlan);
            this.pnlPromote.Controls.Add(this.lblPrice);
            this.pnlPromote.Controls.Add(this.lblPlace);
            this.pnlPromote.Controls.Add(this.lblExecTime);
            this.pnlPromote.Controls.Add(this.lblExecDate);
            this.pnlPromote.Location = new System.Drawing.Point(200, 129);
            this.pnlPromote.Name = "pnlPromote";
            this.pnlPromote.Size = new System.Drawing.Size(368, 490);
            this.pnlPromote.TabIndex = 97;
            this.pnlPromote.Visible = false;
            // 
            // lblMentee
            // 
            this.lblMentee.AutoSize = true;
            this.lblMentee.Location = new System.Drawing.Point(6, 17);
            this.lblMentee.Name = "lblMentee";
            this.lblMentee.Size = new System.Drawing.Size(110, 22);
            this.lblMentee.TabIndex = 109;
            this.lblMentee.Text = "メンティー名";
            // 
            // lblPlanPlace
            // 
            this.lblPlanPlace.AutoSize = true;
            this.lblPlanPlace.Location = new System.Drawing.Point(7, 407);
            this.lblPlanPlace.Name = "lblPlanPlace";
            this.lblPlanPlace.Size = new System.Drawing.Size(98, 22);
            this.lblPlanPlace.TabIndex = 105;
            this.lblPlanPlace.Text = "予定場所";
            // 
            // lblPlanTime
            // 
            this.lblPlanTime.AutoSize = true;
            this.lblPlanTime.Location = new System.Drawing.Point(7, 354);
            this.lblPlanTime.Name = "lblPlanTime";
            this.lblPlanTime.Size = new System.Drawing.Size(142, 22);
            this.lblPlanTime.TabIndex = 104;
            this.lblPlanTime.Text = "18:00 ～ 20:00";
            // 
            // lblDatePlan
            // 
            this.lblDatePlan.AutoSize = true;
            this.lblDatePlan.Location = new System.Drawing.Point(7, 301);
            this.lblDatePlan.Name = "lblDatePlan";
            this.lblDatePlan.Size = new System.Drawing.Size(153, 22);
            this.lblDatePlan.TabIndex = 103;
            this.lblDatePlan.Text = "2020年7月21日";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(7, 186);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(80, 22);
            this.lblPrice.TabIndex = 102;
            this.lblPrice.Text = "7,000円";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(7, 142);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(54, 22);
            this.lblPlace.TabIndex = 101;
            this.lblPlace.Text = "場所";
            // 
            // lblExecTime
            // 
            this.lblExecTime.AutoSize = true;
            this.lblExecTime.Location = new System.Drawing.Point(7, 101);
            this.lblExecTime.Name = "lblExecTime";
            this.lblExecTime.Size = new System.Drawing.Size(142, 22);
            this.lblExecTime.TabIndex = 100;
            this.lblExecTime.Text = "18:00 ～ 20:00";
            // 
            // lblExecDate
            // 
            this.lblExecDate.AutoSize = true;
            this.lblExecDate.Location = new System.Drawing.Point(7, 58);
            this.lblExecDate.Name = "lblExecDate";
            this.lblExecDate.Size = new System.Drawing.Size(142, 22);
            this.lblExecDate.TabIndex = 99;
            this.lblExecDate.Text = "2020年7月8日";
            // 
            // lblMentor
            // 
            this.lblMentor.AutoSize = true;
            this.lblMentor.Location = new System.Drawing.Point(203, 103);
            this.lblMentor.Name = "lblMentor";
            this.lblMentor.Size = new System.Drawing.Size(96, 22);
            this.lblMentor.TabIndex = 102;
            this.lblMentor.Text = "メンター名";
            // 
            // btnRemand
            // 
            this.btnRemand.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnRemand.Location = new System.Drawing.Point(382, 642);
            this.btnRemand.Name = "btnRemand";
            this.btnRemand.Size = new System.Drawing.Size(102, 32);
            this.btnRemand.TabIndex = 24;
            this.btnRemand.Text = "差し戻し";
            this.btnRemand.UseVisualStyleBackColor = true;
            this.btnRemand.Click += new System.EventHandler(this.btnRemand_Click);
            // 
            // dtpExecDate
            // 
            this.dtpExecDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExecDate.Location = new System.Drawing.Point(205, 184);
            this.dtpExecDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpExecDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpExecDate.Name = "dtpExecDate";
            this.dtpExecDate.Size = new System.Drawing.Size(200, 29);
            this.dtpExecDate.TabIndex = 4;
            this.dtpExecDate.Value = new System.DateTime(2020, 7, 28, 11, 22, 5, 405);
            this.dtpExecDate.ValueChanged += new System.EventHandler(this.dtpExecDate_ValueChanged);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Location = new System.Drawing.Point(891, 22);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(317, 22);
            this.lblUser.TabIndex = 107;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(853, 484);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(355, 22);
            this.lblComment.TabIndex = 109;
            this.lblComment.Text = "※コメントを確認したらチェックしてください";
            // 
            // cboMentee
            // 
            this.cboMentee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentee.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentee.FormattingEnabled = true;
            this.cboMentee.ItemHeight = 21;
            this.cboMentee.Location = new System.Drawing.Point(205, 142);
            this.cboMentee.Name = "cboMentee";
            this.cboMentee.Size = new System.Drawing.Size(158, 29);
            this.cboMentee.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 111;
            this.label1.Text = "次回実施";
            // 
            // MH0040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnRemand);
            this.Controls.Add(this.lblMentor);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlPromote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnToroku);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDn);
            this.Controls.Add(this.btnRowDelete);
            this.Controls.Add(this.btnRowInsert);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dtpExecDate);
            this.Controls.Add(this.cboMentee);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMenta);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MH0040";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MH0040";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MH0040_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatePlan)).EndInit();
            this.pnlPromote.ResumeLayout(false);
            this.pnlPromote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpExecDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtReport;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Button btnRowInsert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnToroku;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPlanPlace;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPlanEndM;
        private System.Windows.Forms.ComboBox cboPlanEndH;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboPlanStartM;
        private System.Windows.Forms.ComboBox cboPlanStartH;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEndM;
        private System.Windows.Forms.ComboBox cboEndH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStartM;
        private System.Windows.Forms.ComboBox cboStartH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDn;
        private System.Windows.Forms.Label lblMenta;
        private System.Windows.Forms.Button btnRowDelete;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlPromote;
        private System.Windows.Forms.Label lblPlanPlace;
        private System.Windows.Forms.Label lblPlanTime;
        private System.Windows.Forms.Label lblDatePlan;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblExecTime;
        private System.Windows.Forms.Label lblExecDate;
        private System.Windows.Forms.Label lblMentor;
        private System.Windows.Forms.Button btnRemand;
        private Metroit.Windows.Forms.MetDateTimePicker dtpExecDate;
        private System.Windows.Forms.Label lblUser;
        private Metroit.Windows.Forms.MetDateTimePicker dtpDatePlan;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblMentee;
        private System.Windows.Forms.ComboBox cboMentee;
        private System.Windows.Forms.Label label1;
    }
}

