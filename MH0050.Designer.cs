namespace Menter
{
    partial class MH0050
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.メンター活動報告書 = new System.Windows.Forms.Label();
            this.dgvIchiran = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMonthTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboYearTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonthFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboYearFrom = new System.Windows.Forms.ComboBox();
            this.lblMenta = new System.Windows.Forms.Label();
            this.cboMentor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.EXEC_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENTEE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTH_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // メンター活動報告書
            // 
            this.メンター活動報告書.AutoSize = true;
            this.メンター活動報告書.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.メンター活動報告書.Location = new System.Drawing.Point(37, 26);
            this.メンター活動報告書.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.メンター活動報告書.Name = "メンター活動報告書";
            this.メンター活動報告書.Size = new System.Drawing.Size(254, 27);
            this.メンター活動報告書.TabIndex = 1;
            this.メンター活動報告書.Text = "メンター活動経費照会";
            // 
            // dgvIchiran
            // 
            this.dgvIchiran.AllowUserToAddRows = false;
            this.dgvIchiran.AllowUserToResizeColumns = false;
            this.dgvIchiran.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIchiran.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIchiran.ColumnHeadersHeight = 40;
            this.dgvIchiran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIchiran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXEC_DATE,
            this.MENTOR_NAME,
            this.MENTEE_NAME,
            this.PRICE,
            this.MONTH_PRICE,
            this.PLACE});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIchiran.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIchiran.EnableHeadersVisualStyles = false;
            this.dgvIchiran.Location = new System.Drawing.Point(42, 299);
            this.dgvIchiran.Name = "dgvIchiran";
            this.dgvIchiran.RowHeadersVisible = false;
            this.dgvIchiran.RowTemplate.Height = 21;
            this.dgvIchiran.Size = new System.Drawing.Size(1143, 318);
            this.dgvIchiran.TabIndex = 9;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.label7);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.cboMonthTo);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.cboYearTo);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.cboMonthFrom);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cboYearFrom);
            this.pnlHeader.Controls.Add(this.lblMenta);
            this.pnlHeader.Controls.Add(this.cboMentor);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Location = new System.Drawing.Point(42, 56);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1029, 149);
            this.pnlHeader.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label7.Location = new System.Drawing.Point(351, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 22);
            this.label7.TabIndex = 29;
            this.label7.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label4.Location = new System.Drawing.Point(599, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "月";
            // 
            // cboMonthTo
            // 
            this.cboMonthTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonthTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMonthTo.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMonthTo.FormattingEnabled = true;
            this.cboMonthTo.ItemHeight = 21;
            this.cboMonthTo.Location = new System.Drawing.Point(525, 13);
            this.cboMonthTo.Name = "cboMonthTo";
            this.cboMonthTo.Size = new System.Drawing.Size(58, 29);
            this.cboMonthTo.TabIndex = 5;
            this.cboMonthTo.TextChanged += new System.EventHandler(this.cboMonthTo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label5.Location = new System.Drawing.Point(487, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 22);
            this.label5.TabIndex = 26;
            this.label5.Text = "年";
            // 
            // cboYearTo
            // 
            this.cboYearTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYearTo.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboYearTo.FormattingEnabled = true;
            this.cboYearTo.ItemHeight = 21;
            this.cboYearTo.Location = new System.Drawing.Point(397, 13);
            this.cboYearTo.Name = "cboYearTo";
            this.cboYearTo.Size = new System.Drawing.Size(84, 29);
            this.cboYearTo.TabIndex = 4;
            this.cboYearTo.TextChanged += new System.EventHandler(this.cboYearTo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(309, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "月";
            // 
            // cboMonthFrom
            // 
            this.cboMonthFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonthFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMonthFrom.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMonthFrom.FormattingEnabled = true;
            this.cboMonthFrom.ItemHeight = 21;
            this.cboMonthFrom.Location = new System.Drawing.Point(235, 13);
            this.cboMonthFrom.Name = "cboMonthFrom";
            this.cboMonthFrom.Size = new System.Drawing.Size(58, 29);
            this.cboMonthFrom.TabIndex = 3;
            this.cboMonthFrom.TextChanged += new System.EventHandler(this.cboMonthFrom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(197, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "年";
            // 
            // cboYearFrom
            // 
            this.cboYearFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYearFrom.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboYearFrom.FormattingEnabled = true;
            this.cboYearFrom.ItemHeight = 21;
            this.cboYearFrom.Location = new System.Drawing.Point(107, 13);
            this.cboYearFrom.Name = "cboYearFrom";
            this.cboYearFrom.Size = new System.Drawing.Size(84, 29);
            this.cboYearFrom.TabIndex = 2;
            this.cboYearFrom.TextChanged += new System.EventHandler(this.cboYearFrom_TextChanged);
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
            // cboMentor
            // 
            this.cboMentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMentor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMentor.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.cboMentor.FormattingEnabled = true;
            this.cboMentor.ItemHeight = 21;
            this.cboMentor.Location = new System.Drawing.Point(107, 60);
            this.cboMentor.Name = "cboMentor";
            this.cboMentor.Size = new System.Drawing.Size(158, 29);
            this.cboMentor.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label6.Location = new System.Drawing.Point(15, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "年月";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnCreate.Location = new System.Drawing.Point(42, 230);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(84, 36);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "表示";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnClear.Location = new System.Drawing.Point(149, 230);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 36);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(42, 634);
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
            this.lblUser.Location = new System.Drawing.Point(868, 26);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(317, 22);
            this.lblUser.TabIndex = 103;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EXEC_DATE
            // 
            this.EXEC_DATE.DataPropertyName = "EXEC_DATE";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd";
            dataGridViewCellStyle2.NullValue = null;
            this.EXEC_DATE.DefaultCellStyle = dataGridViewCellStyle2;
            this.EXEC_DATE.HeaderText = "実施日";
            this.EXEC_DATE.Name = "EXEC_DATE";
            this.EXEC_DATE.ReadOnly = true;
            this.EXEC_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EXEC_DATE.Width = 200;
            // 
            // MENTOR_NAME
            // 
            this.MENTOR_NAME.DataPropertyName = "MENTOR_NAME";
            this.MENTOR_NAME.HeaderText = "メンター";
            this.MENTOR_NAME.Name = "MENTOR_NAME";
            this.MENTOR_NAME.ReadOnly = true;
            this.MENTOR_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MENTOR_NAME.Width = 130;
            // 
            // MENTEE_NAME
            // 
            this.MENTEE_NAME.DataPropertyName = "MENTEE_NAME";
            this.MENTEE_NAME.HeaderText = "メンティー";
            this.MENTEE_NAME.Name = "MENTEE_NAME";
            this.MENTEE_NAME.ReadOnly = true;
            this.MENTEE_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MENTEE_NAME.Width = 130;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.PRICE.DefaultCellStyle = dataGridViewCellStyle3;
            this.PRICE.HeaderText = "経費（円）";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRICE.Width = 150;
            // 
            // MONTH_PRICE
            // 
            this.MONTH_PRICE.DataPropertyName = "MONTH_PRICE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = null;
            this.MONTH_PRICE.DefaultCellStyle = dataGridViewCellStyle4;
            this.MONTH_PRICE.HeaderText = "月合計（円）";
            this.MONTH_PRICE.Name = "MONTH_PRICE";
            this.MONTH_PRICE.ReadOnly = true;
            this.MONTH_PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MONTH_PRICE.Width = 130;
            // 
            // PLACE
            // 
            this.PLACE.DataPropertyName = "PLACE";
            this.PLACE.HeaderText = "実施場所";
            this.PLACE.Name = "PLACE";
            this.PLACE.ReadOnly = true;
            this.PLACE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PLACE.Width = 130;
            // 
            // MH0050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 682);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvIchiran);
            this.Controls.Add(this.メンター活動報告書);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MH0050";
            this.Text = "MH0050";
            this.Load += new System.EventHandler(this.MH0050_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIchiran)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label メンター活動報告書;
        private System.Windows.Forms.DataGridView dgvIchiran;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonthFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYearFrom;
        private System.Windows.Forms.Label lblMenta;
        private System.Windows.Forms.ComboBox cboMentor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMonthTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboYearTo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXEC_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENTOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENTEE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTH_PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACE;
    }
}