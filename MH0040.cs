using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0040 : Form
    {
        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        private User user;
        string programId = "MH0040";
        DateTime dt = System.DateTime.Now;
        public bool torokuFlg = false;
        public bool flg = false;
        public bool changeFlg = false;
        public bool rowInsertFlg = false;
        bool shokaiMode = false;
        private List<String> delList = new List<string>();

        public List<string> _resultIdList;
        public string _mentorResultId;
        public int _mode;
        public string _resultId;

        private enum mode
        {
            MENTA,
            SUISHINBU
        }

        public enum column
        {
            COMMENT_ID,
            CORRECT_FLG,
            CORRECT_FLG_OLD,
            EMPLOYEE_ID,
            EMPLOYEE_NM,
            CONTENT,
            CONTENT_OLD,
            WRITER_DATE,
            STETUS
        }

        public enum hyouji
        {
            MENTOR_ID,
            MENTOR_NM,
            MENTEE_ID,
            MENTEE_NM,
            EXEC_DATE,
            STATUS,
            START_TIME,
            END_TIME,
            PLACE,
            PRICE,
            DATE_PLAN,
            START_PLAN_TIME,
            END_PLAN_TIME,
            PLAN_PLACE,
            OTHER,
        }

        public MH0040(User user, List<string> list)
        {
            this.user = user;
            _resultIdList = list;
            _mentorResultId = "";
            InitializeComponent();
        }

        public MH0040(User user, List<string> list, string mentorResultId)
        {
            this.user = user;
            _resultIdList = list;
            _mentorResultId = mentorResultId;
            InitializeComponent();
        }

        public MH0040(User user, List<string> list, string mentorResultId, int mode)
        {
            this.user = user;
            _resultIdList = list;
            _mentorResultId = mentorResultId;
            _mode = mode;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialization();
        }
        /// <summary>
        /// コンボセット
        /// </summary>
        private void setCbo()
        {

            cboStartH.DataSource = comU.CHour().ToArray();
            cboEndH.DataSource = comU.CHour().ToArray();
            cboStartM.DataSource = comU.CMinute().ToArray();
            cboEndM.DataSource = comU.CMinute().ToArray();

            cboPlanStartH.DataSource = comU.CHour().ToArray();
            cboPlanEndH.DataSource = comU.CHour().ToArray();
            cboPlanStartM.DataSource = comU.CMinute().ToArray();
            cboPlanEndM.DataSource = comU.CMinute().ToArray();

            SetMentee();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {

            //セルの内容に合わせて、行の高さが自動的に調節されるようにする
            dgvIchiran.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //"Column1"列のセルのテキストを折り返して表示する
            dgvIchiran.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvIchiran.RowTemplate.Height = 50;
            dgvIchiran.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIchiran.AllowUserToAddRows = false;
            dgvIchiran.RowHeadersVisible = false;
            dgvIchiran.AllowUserToResizeColumns = false;

            lblUser.Text = user.Name;

            //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
            if (_mentorResultId.Equals(""))
            {
                dtpExecDate.Value = System.DateTime.Now;
                dtpExecDate.MaxDate = DateTime.Now;
                //コンボボックス設定
                setCbo();

                btnUp.Enabled = false;
                pnlPromote.Visible = false;
                lblMenta.Visible = false;
                lblMentor.Visible = false;
                btnRowInsert.Visible = false;
                btnRowDelete.Visible = false;
                btnToroku.Visible = false;
                btnRemand.Visible = false;
                btnDelete.Visible = false;

                cboStartH.SelectedIndex = -1;
                cboStartM.SelectedIndex = -1;
                cboEndH.SelectedIndex = -1;
                cboEndM.SelectedIndex = -1;
                cboPlanStartH.SelectedIndex = -1;
                cboPlanStartM.SelectedIndex = -1;
                cboPlanEndH.SelectedIndex = -1;
                cboPlanEndM.SelectedIndex = -1;
            }
            //更新(遷移元から引数としてメンター実績IDを取得)の場合
            else
            {

                //最初の行の場合、"←"非活性
                if (_mentorResultId.Equals(_resultIdList.First()))
                {
                    btnDn.Enabled = false;
                }
                //推進チームコメント取得
                if (!GetComent())
                {
                    return;
                }


                DataSet ds = new DataSet();
                //メンター実績取得
                GetResult(ref ds);

                string status = ds.Tables[0].Rows[0][(int)hyouji.STATUS].ToString();

                //推進チーム用の場合
                if (_mode == (int)mode.SUISHINBU)
                {
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    dispReported(ds);
                    //最終行の場合→非活性
                    if (_mentorResultId.Equals(_resultIdList.Last()))
                    {
                        btnUp.Enabled = false;
                    }
                    //差戻の場合、差戻ボタン非表示
                    if (status.Equals("2"))
                    {
                        btnRemand.Visible = false;
                    }
                    lblComment.Visible = false;
                    txtTitle.Text = "メンター活動実績確認";
                }
                //メンター用の場合
                else
                {
                    if (status.Equals("0"))
                    {
                        dispNotReported(ds);
                    }
                    else if (status.Equals("2"))
                    {
                        dispNotReported(ds);
                        btnSave.Visible = false;
                    }
                    else
                    {
                        dispReported(ds);
                    }

                    lblMenta.Visible = false;
                    lblMentor.Visible = false;
                    btnRowInsert.Visible = false;
                    btnRowDelete.Visible = false;
                    btnRemand.Visible = false;
                }

                //排他登録
                TorokuHaita();

            }
            //メンター実績ID配列が0件でない場合
            if (_resultIdList.Count == 0)
            {
                btnUp.Enabled = false;
                btnDn.Enabled = false;
            }
            flg = true;

        }
        /// <summary>
        /// 取得した時刻をラベルへセット
        /// </summary>
        private void setTimeLbl(string startTime, string endTime, Label setLbl)
        {
            string startTimeH = "";
            string startTimeM = "";
            string endTimeH = "";
            string endTimeM = "";
            if (!startTime.Equals(""))
            {
                startTimeH = startTime.Substring(0, 2) + "：";
                startTimeM = startTime.Substring(2, 2);
            }
            if (!endTime.Equals(""))
            {
                endTimeH = endTime.Substring(0, 2) + "：";
                endTimeM = endTime.Substring(2, 2);
            }
            if (!string.IsNullOrEmpty(startTime) || !string.IsNullOrEmpty(endTime))
            {
                setLbl.Text = startTimeH + startTimeM + "～" + endTimeH + endTimeM;
            }
            else
            {
                setLbl.Text = "";
            }
        }
        /// <summary>
        /// 更新:報告済み
        /// </summary>
        private void dispReported(DataSet ds)
        {
            DateTime execDate = DateTime.Parse(ds.Tables[0].Rows[0][(int)hyouji.EXEC_DATE].ToString());
            lblMentor.Text = ds.Tables[0].Rows[0][(int)hyouji.MENTOR_NM].ToString();
            lblMentee.Text = ds.Tables[0].Rows[0][(int)hyouji.MENTEE_NM].ToString();
            lblExecDate.Text = execDate.ToShortDateString();

            string startTime = ds.Tables[0].Rows[0][(int)hyouji.START_TIME].ToString();
            string endTime = ds.Tables[0].Rows[0][(int)hyouji.END_TIME].ToString();
            //実施時刻セット
            setTimeLbl(startTime, endTime, lblExecTime);
            lblPlace.Text = ds.Tables[0].Rows[0][(int)hyouji.PLACE].ToString();
            lblPrice.Text = String.Format("{0:#,0}", ds.Tables[0].Rows[0][(int)hyouji.PRICE]) + "円";
            //予定日セット
            string strDatePlan = ds.Tables[0].Rows[0][(int)hyouji.DATE_PLAN].ToString();
            if (strDatePlan.Equals(""))
            {
                lblDatePlan.Text = "";
            }
            else
            {
                DateTime datePlan = DateTime.Parse(strDatePlan);
                lblDatePlan.Text = datePlan.ToShortDateString();
            }
            string startPlanTime = ds.Tables[0].Rows[0][(int)hyouji.START_PLAN_TIME].ToString();
            string endPlanTime = ds.Tables[0].Rows[0][(int)hyouji.END_PLAN_TIME].ToString();
            //予定時刻セット
            setTimeLbl(startPlanTime, endPlanTime, lblPlanTime);

            lblPlanPlace.Text = ds.Tables[0].Rows[0][(int)hyouji.PLAN_PLACE].ToString();

            txtReport.Text = ds.Tables[0].Rows[0][(int)hyouji.OTHER].ToString();

            txtReport.ReadOnly = true;
            txtReport.BackColor = SystemColors.ButtonFace;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            pnlPromote.Visible = true;
        }
        /// <summary>
        /// 取得した時刻をコンボボックスへセット
        /// </summary>
        private void setTimeCbo(string startTime, string endTime, ComboBox comboStartH, ComboBox comboStartM, ComboBox comboEndH, ComboBox comboEndM)
        {
            if (!startTime.Equals(""))
            {

                string startTimeH = startTime.Substring(0, 2);
                if (startTime.Substring(0, 1) == "0")
                {
                    startTimeH = startTime.Substring(1, 1);
                }
                string startTimeM = startTime.Substring(2, 2);

                comboStartH.Text = startTimeH;
                comboStartM.Text = startTimeM;
            }
            else
            {
                comboStartH.SelectedIndex = -1;
                comboStartM.SelectedIndex = -1;
            }
            if (!endTime.Equals(""))
            {
                string endTimeH = endTime.Substring(0, 2);
                if (endTime.Substring(0, 1) == "0")
                {
                    endTimeH = endTime.Substring(1, 1);
                }
                string endTimeM = endTime.Substring(2, 2);
                comboEndH.Text = endTimeH;
                comboEndM.Text = endTimeM;
            }
            else
            {
                comboEndH.SelectedIndex = -1;
                comboEndM.SelectedIndex = -1;
            }
        }
        /// <summary>
        /// 更新:未報告・差戻
        /// </summary>
        private void dispNotReported(DataSet ds)
        {

            if (Convert.ToDateTime(ds.Tables[0].Rows[0][(int)hyouji.EXEC_DATE]) < DateTime.Now)
            {
                dtpExecDate.MaxDate = DateTime.Now;
            }
            dtpExecDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][(int)hyouji.EXEC_DATE].ToString());
            //コンボボックス設定
            setCbo();
            cboMentee.SelectedValue = ds.Tables[0].Rows[0][(int)hyouji.MENTEE_ID].ToString();
            string startTime = ds.Tables[0].Rows[0][(int)hyouji.START_TIME].ToString();
            string endTime = ds.Tables[0].Rows[0][(int)hyouji.END_TIME].ToString();
            //実施時刻をコンボへセット
            setTimeCbo(startTime, endTime, cboStartH, cboStartM, cboEndH, cboEndM);


            txtPlace.Text = ds.Tables[0].Rows[0][(int)hyouji.PLACE].ToString();
            txtPrice.Text = String.Format("{0:#,0}", ds.Tables[0].Rows[0][(int)hyouji.PRICE]);

            string strDatePlan = ds.Tables[0].Rows[0][(int)hyouji.DATE_PLAN].ToString();
            if (!strDatePlan.Equals(""))
            {
                dtpDatePlan.Text = ds.Tables[0].Rows[0][(int)hyouji.DATE_PLAN].ToString();
            }

            string startPlanTime = ds.Tables[0].Rows[0][(int)hyouji.START_PLAN_TIME].ToString();
            string endPlanTime = ds.Tables[0].Rows[0][(int)hyouji.END_PLAN_TIME].ToString();
            //予定時刻をコンボへセット
            setTimeCbo(startPlanTime, endPlanTime, cboPlanStartH, cboPlanStartM, cboPlanEndH, cboPlanEndM);


            txtPlanPlace.Text = ds.Tables[0].Rows[0][(int)hyouji.PLAN_PLACE].ToString();
            txtReport.Text = ds.Tables[0].Rows[0][(int)hyouji.OTHER].ToString();
            btnToroku.Visible = false;
        }

        /// <summary>
        /// メンター実績ID取得
        /// </summary>
        public void GetResult(ref DataSet ds)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      MENTOR_ID");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME ");
            sql.Append("     ,MENTEE_ID");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME");
            sql.Append("     ,EXEC_DATE");
            sql.Append("     ,STATUS");
            sql.Append("     ,START_TIME");
            sql.Append("     ,END_TIME");
            sql.Append("     ,PLACE");
            sql.Append("     ,PRICE");
            sql.Append("     ,DATE_PLAN");
            sql.Append("     ,START_PLAN_TIME");
            sql.Append("     ,END_PLAN_TIME");
            sql.Append("     ,PLAN_PLACE");
            sql.Append("     ,OTHER");
            sql.Append("   FROM TRN_MENTOR_RESULT ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTOR ");
            sql.Append("     ON MENTOR_ID = MENTOR.MST_SHAIN_CODE ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTEE ");
            sql.Append("     ON MENTEE_ID = MENTEE.MST_SHAIN_CODE ");
            sql.Append($" WHERE MENTOR_RESULT_ID = {_mentorResultId}");

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンター実績の取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }


        }

        /// <summary>
        /// コメント取得
        /// </summary>
        public bool GetComent()
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      COMMENT_ID");
            sql.Append("     ,CORRECT_FLG");
            sql.Append("     ,CORRECT_FLG");
            sql.Append("     ,EMPLOYEE_ID ");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append("     ,COMMENT");
            sql.Append("     ,COMMENT");
            sql.Append("     ,INSERT_DATE");
            sql.Append("   FROM TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append("   LEFT JOIN MST_SHAIN ");
            sql.Append("     ON EMPLOYEE_ID = MST_SHAIN_CODE ");
            sql.Append($" WHERE MENTOR_RESULT_ID = {_mentorResultId}");

            DataSet ds = new DataSet();
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("推進チームコメントの取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            //STATUS列追加
            ds.Tables[0].Columns.Add();
            dgvIchiran.DataSource = ds.Tables[0];


            dgvIchiran.Columns[(int)column.EMPLOYEE_NM].HeaderText = "記入者";
            dgvIchiran.Columns[(int)column.WRITER_DATE].HeaderText = "記入日時";
            dgvIchiran.Columns[(int)column.CONTENT].HeaderText = "内容";
            dgvIchiran.Columns[(int)column.CORRECT_FLG].HeaderText = "";

            dgvIchiran.Columns[(int)column.EMPLOYEE_NM].ReadOnly = true;
            dgvIchiran.Columns[(int)column.WRITER_DATE].ReadOnly = true;

            if (_mode == (int)mode.SUISHINBU)
            {
                dgvIchiran.Columns[(int)column.CORRECT_FLG].ReadOnly = true;
            }
            else
            {
                dgvIchiran.Columns[(int)column.CONTENT].ReadOnly = true;
            }

            dgvIchiran.Columns[(int)column.COMMENT_ID].Visible = false;
            dgvIchiran.Columns[(int)column.CORRECT_FLG_OLD].Visible = false;
            dgvIchiran.Columns[(int)column.EMPLOYEE_ID].Visible = false;
            dgvIchiran.Columns[(int)column.CONTENT_OLD].Visible = false;
            dgvIchiran.Columns[(int)column.STETUS].Visible = false;

            dgvIchiran.Columns[(int)column.EMPLOYEE_NM].Width = 110;
            dgvIchiran.Columns[(int)column.WRITER_DATE].Width = 180;
            dgvIchiran.Columns[(int)column.CONTENT].Width = 280;
            dgvIchiran.Columns[(int)column.CORRECT_FLG].Width = 30;

            ((DataGridViewTextBoxColumn)dgvIchiran.Columns[(int)column.CONTENT]).MaxInputLength = 512;


            for (int i = 0; i < dgvIchiran.RowCount; i++)
            {

                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                dgvIchiran[(int)column.CORRECT_FLG, i] = cell;
                if ((string)dgvIchiran[(int)column.CORRECT_FLG, i].Value == "0")
                {
                    dgvIchiran[(int)column.CORRECT_FLG, i].Value = false;
                    dgvIchiran[(int)column.CORRECT_FLG_OLD, i].Value = false;
                }
                else
                {

                    dgvIchiran[(int)column.CORRECT_FLG, i].Value = true;
                    dgvIchiran[(int)column.CORRECT_FLG_OLD, i].Value = true;
                }
                //他者のコメントは編集不可
                if (_mode == (int)mode.SUISHINBU)
                {
                    if (!dgvIchiran[(int)column.EMPLOYEE_ID, i].Value.ToString().Equals(user.Id))
                    {
                        dgvIchiran[(int)column.CONTENT, i].ReadOnly = true;
                    }
                }
                dgvIchiran[(int)column.STETUS, i].Value = "";
            }
            foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvIchiran.CurrentCell = null;
            dgvIchiran.MultiSelect = false;

            return true;
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        private void TorokuHaita()
        {
            if (!comU.InsertHaitaTrn(_mentorResultId, user.Id, programId))
            {
                btnDelete.Enabled = false;
                btnReport.Enabled = false;
                btnSave.Enabled = false;
                btnRemand.Enabled = false;
                btnToroku.Enabled = false;

                btnRowDelete.Enabled = false;
                btnRowInsert.Enabled = false;

                dgvIchiran.ReadOnly = true;
                shokaiMode = true;
            }

        }

        /// <summary>
        /// コンボボックスセット(メンティ―)
        /// </summary>
        public void SetMentee()
        {
            DataSet dataSet = new DataSet();
            if (!mentee(ref dataSet))
            {
                this.Close();
                return;
            }
            string initSelected = null;
            //foreach (DataRow ds in dataSet.Tables[0].Rows)
            //{
            //    if ((DateTime)ds["TEKIYO_START_DATE"] <= System.DateTime.Now.Date && (DateTime)ds["TEKIYO_END_DATE"] >= System.DateTime.Now.Date)
            //    {
            //        initSelected = ds["MST_SHAIN_CODE"].ToString();
            //    }
            //}
            var ds = dataSet.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("TEKIYO_START_DATE") <= DateTime.Now.Date && r.Field<DateTime>("TEKIYO_END_DATE") >= DateTime.Now.Date).FirstOrDefault();
            if(ds != null)
            {
                initSelected = ds["MST_SHAIN_CODE"].ToString();
            }
            // コンボボックスにデータテーブルをセット
            this.cboMentee.DataSource = dataSet.Tables[0].DefaultView.ToTable(true, "MST_SHAIN_CODE", "MST_SHAIN_NAME");
            // 表示用の列を設定
            this.cboMentee.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMentee.ValueMember = "MST_SHAIN_CODE";
            if (initSelected != null)
            {
                cboMentee.SelectedValue = initSelected;
            }
        }


        /// <summary>
        /// メンティ―コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool mentee(ref DataSet ds)
        {

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append("     ,TEKIYO_START_DATE");
            sql.Append("     ,TEKIYO_END_DATE");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" INNER JOIN mst_shain");
            sql.Append("   ON MENTEE_ID = MST_SHAIN_CODE");
            sql.Append($"   AND MENTOR_ID = {user.Id}");
            sql.Append(" ORDER BY TEKIYO_START_DATE DESC ");

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー");
                return false;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンティーコンボボックスの取得に失敗しました", "エラー");
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }


            return true;

        }

        /// <summary>
        /// 最大実績ID取得
        /// </summary>
        /// <returns></returns>
        public int mentorResultCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MAX(MENTOR_RESULT_ID)");
            sql.Append(" FROM TRN_MENTOR_RESULT");

            DataSet ds = new DataSet();

            dBManager.ExecuteQuery(sql.ToString(), ds);

            int count = 0;
            if (ds.Tables["Table1"].Rows[0]["MAX(MENTOR_RESULT_ID)"] != DBNull.Value)
            {
                count = Convert.ToInt32(ds.Tables["Table1"].Rows[0]["MAX(MENTOR_RESULT_ID)"].ToString());
            }
            return count;
        }



        /// <summary>
        /// 行削除チェック
        /// </summary>
        /// <returns></returns>
        public bool rowDeleteCheck()
        {
            DialogResult result = MessageBox.Show("削除を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 時刻チェック
        /// </summary>
        /// <returns></returns>
        public bool timeCheck()
        {
            if (!cboStartH.Text.Equals("") & cboStartM.Text.Equals(""))
            {
                MessageBox.Show("実施開始分を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboStartM;
                return false;
            }
            if (cboStartH.Text.Equals("") & !cboStartM.Text.Equals(""))
            {
                MessageBox.Show("実施開始時を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboStartH;
                return false;
            }
            if (!cboEndH.Text.Equals("") & cboEndM.Text.Equals(""))
            {
                MessageBox.Show("実施終了分を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboEndM;
                return false;
            }
            if (cboEndH.Text.Equals("") & !cboEndM.Text.Equals(""))
            {
                MessageBox.Show("実施終了時を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboEndH;
                return false;
            }
            if (!cboStartH.Text.Equals("") && !cboStartM.Text.Equals("") && !cboEndH.Text.Equals("") && !cboEndM.Text.Equals(""))
            {
                int startH = Convert.ToInt32(cboStartH.Text);
                int startM = Convert.ToInt32(cboStartM.Text);
                int endH = Convert.ToInt32(cboEndH.Text);
                int endM = Convert.ToInt32(cboEndM.Text);
                if (startH > endH)
                {
                    this.ActiveControl = cboStartH;
                    MessageBox.Show("実施時間が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (startH == endH)
                {
                    if (startM > endM)
                    {
                        this.ActiveControl = cboStartH;
                        MessageBox.Show("実施時間が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (startM == endM)
                    {
                        this.ActiveControl = cboStartH;
                        MessageBox.Show("実施開始時間と実施終了時間が同じです", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            if (!cboPlanStartH.Text.Equals("") & cboPlanStartM.Text.Equals(""))
            {
                MessageBox.Show("予定開始分を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboPlanStartM;
                return false;
            }
            if (cboPlanStartH.Text.Equals("") & !cboPlanStartM.Text.Equals(""))
            {
                MessageBox.Show("予定開始時を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboPlanStartH;
                return false;
            }
            if (!cboPlanEndH.Text.Equals("") & cboPlanEndM.Text.Equals(""))
            {
                MessageBox.Show("予定終了分を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboPlanEndM;
                return false;
            }
            if (cboPlanEndH.Text.Equals("") & !cboPlanEndM.Text.Equals(""))
            {
                MessageBox.Show("予定終了時を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboPlanEndH;
                return false;
            }
            if (!cboPlanStartH.Text.Equals("") && !cboPlanStartM.Text.Equals("") && !cboPlanEndH.Text.Equals("") && !cboPlanEndM.Text.Equals(""))
            {
                int startPlanH = Convert.ToInt32(cboPlanStartH.Text);
                int startPlanM = Convert.ToInt32(cboPlanStartM.Text);
                int endPlanH = Convert.ToInt32(cboPlanEndH.Text);
                int endPlanM = Convert.ToInt32(cboPlanEndM.Text);
                if (startPlanH > endPlanH)
                {
                    this.ActiveControl = cboPlanStartH;
                    MessageBox.Show("予定時間が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (startPlanH == endPlanH)
                {
                    if (startPlanM > endPlanM)
                    {
                        this.ActiveControl = cboPlanStartH;
                        MessageBox.Show("予定時間が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (startPlanM == endPlanM)
                    {
                        this.ActiveControl = cboPlanStartH;
                        MessageBox.Show("予定開始時間と予定終了時間が同じです", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }


            return true;
        }

        private bool menteeCheck()
        {
            string exec = getDateTimePick(dtpExecDate.Value);
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     COUNT(MENTEE_ID)");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append($" WHERE MENTOR_ID = '{user.Id}'");
            sql.Append($" AND TEKIYO_START_DATE <= '{exec}'");
            sql.Append($" AND TEKIYO_END_DATE >= '{exec}'");
            sql.Append($" AND MENTEE_ID = '{cboMentee.SelectedValue}'");

            DataSet ds = new DataSet();

            dBManager.ExecuteQuery(sql.ToString(), ds);

            if (ds.Tables["Table1"].Rows[0]["COUNT(MENTEE_ID)"] != DBNull.Value)
            {
                if(Convert.ToInt32(ds.Tables["Table1"].Rows[0]["COUNT(MENTEE_ID)"].ToString()) != 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 一時保存入力チェック
        /// </summary>
        /// <returns></returns>
        public bool saveInputCheck()
        {
            if (cboMentee.SelectedIndex == -1)
            {
                MessageBox.Show("メンティーを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMentee;
                return false;
            }
            if (!menteeCheck())
            {
                MessageBox.Show("選択した実施日はメンティーの適用日の範囲外です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMentee;
                return false;
            }
            if (dtpExecDate.Value != null && dtpDatePlan.Value != null)
            {
                if (dtpExecDate.Value >= dtpDatePlan.Value)
                {
                    MessageBox.Show("予定日は実施日より後の日付を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = dtpDatePlan;
                    return false;
                }
            }

            if (!timeCheck())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 一時保存チェック
        /// </summary>
        /// <returns></returns>
        public bool saveExecute()
        {
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string dml = "";
            string table = "メンター実績";
            try
            {
                dBManager.BeginTran();
                //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
                if (_mentorResultId.Equals(""))
                {
                    dml = "登録";
                    MInsert("0");
                }
                else
                {
                    dml = "更新";
                    MUpdate("0");

                }

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{table}テーブルの{dml}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dBManager.RollBack();
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return true;
        }

        /// <summary>
        /// 報告入力チェック
        /// </summary>
        /// <returns></returns>
        public bool reportInputCheck()
        {

            if (cboMentee.SelectedIndex == -1)
            {
                MessageBox.Show("メンティーを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMentee;
                return false;
            }
            if (!menteeCheck())
            {
                MessageBox.Show("選択した実施日はメンティーの適用日の範囲外です", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMentee;
                return false;
            }
            if (cboStartH.Text.Equals(""))
            {
                MessageBox.Show("実施開始時を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboStartH;
                return false;
            }
            if (cboStartM.Text.Equals(""))
            {
                MessageBox.Show("実施開始分を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboStartM;
                return false;
            }
            if (cboEndH.Text.Equals(""))
            {
                MessageBox.Show("実施終了時を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboEndH;
                return false;
            }
            if (cboEndM.Text.Equals(""))
            {
                MessageBox.Show("実施終了分を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboEndM;
                return false;
            }
            if (txtPlace.Text.Equals(""))
            {
                MessageBox.Show("実施場所を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txtPlace;
                return false;
            }
            if (txtPrice.Text.Equals(""))
            {
                MessageBox.Show("経費を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txtPrice;
                return false;
            }
            if (txtReport.Text.Equals(""))
            {
                MessageBox.Show("報告事項を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txtReport;
                return false;
            }
            if (dtpExecDate.Value != null && dtpDatePlan.Value != null)
            {
                if (dtpExecDate.Value > dtpDatePlan.Value)
                {
                    MessageBox.Show("予定日は実施日より後の日付を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = dtpDatePlan;
                    return false;
                }
            }

            if (!timeCheck())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 報告実行
        /// </summary>
        /// <returns></returns>
        public bool reportExcute()
        {

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string dml = "";
            string table = "";
            try
            {
                dBManager.BeginTran();
                //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
                if (_mentorResultId.Equals(""))
                {
                    table = "メンター実績";
                    dml = "登録";
                    MInsert("1");
                }
                else
                {
                    table = "メンター実績";
                    dml = "更新";
                    MUpdate("1");
                    table = "推進チームコメント";
                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    for (int i = 0; i < dgvIchiran.Rows.Count; i++)
                    {

                        if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "1")
                        {
                            CUpdate(i);
                        }

                    }

                }

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{table}テーブルの{dml}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dBManager.RollBack();
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return true;
        }

        /// <summary>
        /// 登録実行
        /// </summary>
        /// <returns></returns>
        public bool insertExcute()
        {
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string dml = "";
            try
            {
                dBManager.BeginTran();
                //メンター用
                if (_mode == (int)mode.MENTA)
                {
                    dml = "更新";
                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    for (int i = 0; i < dgvIchiran.Rows.Count; i++)
                    {

                        string id = dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString();
                        string correct = dgvIchiran[(int)column.CORRECT_FLG, i].Value.ToString();
                        if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "1")
                        {
                            CUpdate(i);
                        }

                    }
                }
                //推進チーム用
                else
                {

                    dml = "削除";
                    SDelete();
                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    for (int i = 0; i < dgvIchiran.Rows.Count; i++)
                    {

                        if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "0")
                        {
                            dml = "登録";
                            SInsert(i);
                        }
                        else if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "1")
                        {
                            dml = "更新";
                            SUpdate(i);
                        }


                    }
                }

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"推進チームコメントテーブルの{dml}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dBManager.RollBack();
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return true;
        }

        /// <summary>
        /// 登録入力チェック(明細変更)
        /// </summary>
        /// <returns></returns>
        public bool insertInputCheckM()
        {
            for (int i = 0; i < dgvIchiran.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dgvIchiran[(int)column.STETUS, i].Value.ToString()))
                {
                    break;
                }
                if (i == dgvIchiran.Rows.Count - 1 && delList.Count == 0)
                {
                    MessageBox.Show("明細が変更されていません", "エラー");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 登録入力チェック(コメント)
        /// </summary>
        /// <returns></returns>
        public bool insertInputCheckComment()
        {

            for (int i = 0; i < dgvIchiran.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvIchiran[(int)column.CONTENT, i].Value.ToString()))
                {
                    MessageBox.Show("コメントを入力してください", "エラー");
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 削除実行
        /// </summary>
        /// <returns></returns>
        private bool deleteExcute()
        {
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string dml = "";
            string table = "";
            try
            {
                dBManager.BeginTran();
                table = "メンター実績";
                dml = "削除";
                MDelete();
                table = "推進チームコメント";
                MPDelete();

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{table}テーブルの{dml}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dBManager.RollBack();
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return true;
        }

        /// <summary>
        /// 差し戻し入力チェック
        /// </summary>
        /// <returns></returns>
        public bool remandInputCheck()
        {
            if (dgvIchiran.Rows.Count == 0)
            {
                MessageBox.Show("コメントを入力してください", "エラー");
                return false;
            }
            for (int i = 0; i < dgvIchiran.Rows.Count; i++)
            {
                if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "0")
                {
                    if (string.IsNullOrEmpty(dgvIchiran[(int)column.CONTENT, i].Value.ToString()))
                    {
                        MessageBox.Show("コメントを入力してください", "エラー");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                if (i == dgvIchiran.Rows.Count - 1)
                {
                    MessageBox.Show("差戻理由を追加してください", "エラー");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// ダイアログチェック
        /// </summary>
        /// <returns></returns>
        public bool diarogCheck(string processing)
        {
            DialogResult result = MessageBox.Show($"{processing}を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 差し戻し実行
        /// </summary>
        /// <returns></returns>
        private bool remandExcute()
        {
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string dml = "";
            string table = "";
            try
            {
                dBManager.BeginTran();
                table = "推進チームコメント";
                dml = "削除";
                SDelete();
                //値の変更を行った明細の数だけ繰り返し処理を行う
                for (int i = 0; i < dgvIchiran.Rows.Count; i++)
                {

                    if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "0")
                    {
                        dml = "登録";
                        SInsert(i);
                    }
                    else if (dgvIchiran[(int)column.STETUS, i].Value.ToString() == "1")
                    {
                        dml = "更新";
                        SUpdate(i);
                    }
                }
                table = "メンター実績";
                dml = "更新";
                //差戻処理
                remandUpdate();

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{table}テーブルの{dml}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dBManager.RollBack();
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return true;
        }

        /// <summary>
        /// DateTimePickerの値から日付を取得
        /// </summary>
        private string getDateTimePick(DateTime? dateTime)
        {
            string result = "null";

            if (!string.IsNullOrEmpty(dateTime.ToString()))
            {
                result = ((DateTime)dateTime).Year.ToString() + String.Format("{0:D2}", ((DateTime)dateTime).Month) + String.Format("{0:D2}", ((DateTime)dateTime).Day);
            }

            return result;
        }

        /// <summary>
        /// メンター実績登録処理
        /// </summary>
        /// <returns></returns>
        private void MInsert(string status)
        {
            string exec = getDateTimePick(dtpExecDate.Value);

            string plan = getDateTimePick(dtpDatePlan.Value);

            string startTime = "Null";
            string endTime = "Null";
            if (!cboStartH.Text.Equals("") && !cboStartM.Text.Equals(""))
            {
                startTime = comU.CAddQuotation(cboStartH.Text.PadLeft(2, '0') + cboStartM.Text.PadLeft(2, '0'));
            }
            if (!cboEndH.Text.Equals("") && !cboEndM.Text.Equals(""))
            {
                endTime = comU.CAddQuotation(cboEndH.Text.PadLeft(2, '0') + cboEndM.Text.PadLeft(2, '0'));
            }

            string price = "Null";
            if (!txtPrice.Text.Equals(""))
            {
                price = txtPrice.Text.Replace(",", "");
            }

            string startPlanTime = "Null";
            string endPlanTime = "Null";
            if (!cboPlanStartH.Text.Equals("") && !cboPlanStartM.Text.Equals(""))
            {
                startPlanTime = comU.CAddQuotation(cboPlanStartH.Text.PadLeft(2, '0') + cboPlanStartM.Text.PadLeft(2, '0'));
            }
            if (!cboPlanEndH.Text.Equals("") && !cboPlanEndM.Text.Equals(""))
            {
                endPlanTime = comU.CAddQuotation(cboPlanEndH.Text.PadLeft(2, '0') + cboPlanEndM.Text.PadLeft(2, '0'));
            }

            int recordCount = mentorResultCount();

            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO TRN_MENTOR_RESULT ");
            sql.Append("    (MENTOR_RESULT_ID ");
            sql.Append("    ,EXEC_DATE ");
            sql.Append("    ,MENTOR_ID ");
            sql.Append("    ,MENTEE_ID ");
            sql.Append("    ,STATUS ");
            sql.Append("    ,REPORT_DT ");
            sql.Append("    ,START_TIME ");
            sql.Append("    ,END_TIME ");
            sql.Append("    ,PLACE ");
            sql.Append("    ,PRICE ");
            sql.Append("    ,DATE_PLAN ");
            sql.Append("    ,START_PLAN_TIME ");
            sql.Append("    ,END_PLAN_TIME ");
            sql.Append("    ,PLAN_PLACE ");
            sql.Append("    ,OTHER ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES (");
            if (recordCount != 0)
            {
                sql.Append($"    '{recordCount + 1}' ");
            }
            else
            {
                sql.Append("    1 ");
            }
            sql.Append($"    ,{exec} ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,'{cboMentee.SelectedValue}'");
            sql.Append($"    ,{status} ");
            if (status == "0")
            {
                sql.Append("    ,Null ");
            }
            else
            {
                sql.Append("    ,now() ");
            }
            sql.Append($"    ,{startTime} ");
            sql.Append($"    ,{endTime} ");
            if (!txtPlace.Text.Equals(""))
            {
                sql.Append($"    ,{comU.CAddQuotation(txtPlace.Text)} ");
            }
            else
            {
                sql.Append("    ,Null ");
            }

            sql.Append($"    ,{price} ");
            sql.Append($"    ,{plan} ");
            sql.Append($"    ,{startPlanTime} ");
            sql.Append($"    ,{endPlanTime} ");
            if (!txtPlanPlace.Text.Equals(""))
            {
                sql.Append($"    ,{comU.CAddQuotation(txtPlanPlace.Text)} ");
            }
            else
            {
                sql.Append("    ,Null ");
            }
            if (!txtReport.Text.Equals(""))
            {
                sql.Append($"    ,{comU.CAddQuotation(txtReport.Text)} ");
            }
            else
            {
                sql.Append("    ,Null ");
            }

            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");


            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 推進チームコメント登録
        /// </summary>
        /// <returns></returns>
        private void SInsert(int i)
        {
            dgvIchiran[(int)column.WRITER_DATE, i].Value = DateTime.Now;
            string id = dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString();
            string content = dgvIchiran[(int)column.CONTENT, i].Value.ToString();
            string writeDate = dgvIchiran[(int)column.WRITER_DATE, i].Value.ToString();
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append("    (MENTOR_RESULT_ID ");
            sql.Append("    ,COMMENT_ID ");
            sql.Append("    ,EMPLOYEE_ID ");
            sql.Append("    ,INSERT_DATE ");
            sql.Append("    ,COMMENT ");
            sql.Append("    ,CORRECT_FLG ");
            sql.Append("    ,CORRECT_DT ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES ");
            sql.Append($"    ({_mentorResultId} ");
            sql.Append($"    ,{id} ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)}");
            sql.Append($"    ,{comU.CAddQuotation(writeDate)} ");
            sql.Append($"    ,{comU.CAddQuotation(content)} ");
            sql.Append("    ,'0' ");
            sql.Append("    ,Null ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");


            dBManager.ExecuteNonQuery(sql.ToString());


        }

        /// <summary>
        /// メンター実績更新処理
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private void MUpdate(string status)
        {
            string exec = getDateTimePick(dtpExecDate.Value);

            string plan = getDateTimePick(dtpDatePlan.Value);

            string startTime = "Null";
            string endTime = "Null";
            if (!cboStartH.Text.Equals("") && !cboStartM.Text.Equals(""))
            {
                startTime = comU.CAddQuotation(cboStartH.Text.PadLeft(2, '0') + cboStartM.Text.PadLeft(2, '0'));
            }
            if (!cboEndH.Text.Equals("") && !cboEndM.Text.Equals(""))
            {
                endTime = comU.CAddQuotation(cboEndH.Text.PadLeft(2, '0') + cboEndM.Text.PadLeft(2, '0'));
            }
            string price = "Null";
            if (!txtPrice.Text.Equals(""))
            {
                price = txtPrice.Text.Replace(",", "");
            }

            string startPlanTime = "Null";
            string endPlanTime = "Null";
            if (!cboPlanStartH.Text.Equals("") && !cboPlanStartM.Text.Equals(""))
            {
                startPlanTime = comU.CAddQuotation(cboPlanStartH.Text.PadLeft(2, '0') + cboPlanStartM.Text.PadLeft(2, '0'));
            }
            if (!cboPlanEndH.Text.Equals("") && !cboPlanEndM.Text.Equals(""))
            {
                endPlanTime = comU.CAddQuotation(cboPlanEndH.Text.PadLeft(2, '0') + cboPlanEndM.Text.PadLeft(2, '0'));
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT ");
            sql.Append($"    SET  EXEC_DATE = {exec} ");
            sql.Append($"     ,    MENTOR_ID = {comU.CAddQuotation(user.Id)} ");
            sql.Append($"     ,    MENTEE_ID = '{cboMentee.SelectedValue}' ");

            sql.Append($"     ,    STATUS = {status} ");
            if (status == "0")
            {
                sql.Append($"     ,    REPORT_DT = Null ");
            }
            else
            {
                sql.Append($"     ,    REPORT_DT = now() ");
            }
            sql.Append($"     ,    START_TIME = {startTime} ");
            sql.Append($"     ,    END_TIME = {endTime} ");
            sql.Append($"     ,    PLACE = {comU.CAddQuotation(txtPlace.Text)} ");
            sql.Append($"     ,    PRICE = {price} ");
            sql.Append($"     ,    DATE_PLAN = {plan} ");
            sql.Append($"     ,    START_PLAN_TIME = {startPlanTime} ");
            sql.Append($"     ,    END_PLAN_TIME = {endPlanTime} ");
            sql.Append($"     ,    PLAN_PLACE = {comU.CAddQuotation(txtPlanPlace.Text)} ");
            sql.Append($"     ,    OTHER = {comU.CAddQuotation(txtReport.Text)} ");
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(user.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");


            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// メンターコメント更新
        /// </summary>
        /// <returns></returns>
        private void CUpdate(int i)
        {
            string id = dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString();
            string correctFlg = dgvIchiran[(int)column.CORRECT_FLG, i].Value.ToString();
            string check;
            if (correctFlg == "True")
            {
                check = "1";
            }
            else
            {
                check = "0";
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append($"    SET  CORRECT_FLG = {check} ");
            if (check.Equals("0"))
            {
                sql.Append("     ,    CORRECT_DT = null ");
            }
            else
            {
                sql.Append($"     ,    CORRECT_DT = now() ");
            }
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(user.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
            sql.Append($"   AND COMMENT_ID = '{id}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }


        /// <summary>
        /// 推進チームコメント更新
        /// </summary>
        /// <returns></returns>
        private void SUpdate(int i)
        {
            dgvIchiran[(int)column.WRITER_DATE, i].Value = DateTime.Now;
            string id = dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString();
            string content = dgvIchiran[(int)column.CONTENT, i].Value.ToString();
            string writeDate = dgvIchiran[(int)column.WRITER_DATE, i].Value.ToString();
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append($"    SET  COMMENT = {comU.CAddQuotation(content)} ");
            sql.Append($"      ,INSERT_DATE = {comU.CAddQuotation(writeDate)}  ");
            sql.Append("      ,CORRECT_FLG = 0 ");
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(user.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
            sql.Append($"   AND COMMENT_ID = '{id}'");


            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 推進チームコメント削除
        /// </summary>
        /// <returns></returns>
        private void SDelete()
        {
            for (int i = 0; i < delList.Count; i++)
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TRN_MENTOR_RESULT_PROMOTE ");
                sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
                sql.Append($"   AND COMMENT_ID = '{delList[i]}'");


                dBManager.ExecuteNonQuery(sql.ToString());
            }
        }


        /// <summary>
        /// 差し戻し更新
        /// </summary>
        /// <returns></returns>
        private void remandUpdate()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT ");
            sql.Append("    SET  STATUS = '2' ");
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(user.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");


            dBManager.ExecuteNonQuery(sql.ToString());
        }


        /// <summary>
        /// 削除処理(推進チームコメントテーブル)
        /// </summary>
        /// <returns></returns>
        private void MPDelete()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");


            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 削除処理(メンター実績テーブル)
        /// </summary>
        /// <returns></returns>
        private void MDelete()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_MENTOR_RESULT ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");


            dBManager.ExecuteNonQuery(sql.ToString());
        }


        /// <summary>
        /// 行追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            rowInsertFlg = true;
            DataTable dta = (DataTable)dgvIchiran.DataSource;
            dta.Rows.Add(getCommentId(), false, false, user.Id, user.Name, "", "", null, 0);
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            dgvIchiran[(int)column.CORRECT_FLG, dgvIchiran.Rows.Count - 1] = cell;
            changeFlg = true;

        }
        private int getCommentId()
        {
            int id = 1;
            if (dgvIchiran.Rows.Count != 0)
            {
                for (int i = 0; i < dgvIchiran.Rows.Count; i++)
                {
                    if (id < int.Parse(dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString()))
                    {
                        id = int.Parse(dgvIchiran[(int)column.COMMENT_ID, i].Value.ToString());
                    }
                }
                id = id + 1;
            }
            return id;
        }

        /// <summary>
        /// 行削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowDelete_Click(object sender, EventArgs e)
        {

            int selectedRow = -1;
            if (dgvIchiran.CurrentCell != null)
            {
                selectedRow = dgvIchiran.CurrentCell.RowIndex;
            }
            if (selectedRow == -1)
            {
                MessageBox.Show("明細を選択してください", "エラー");
                return;
            }
            if (!dgvIchiran[(int)column.EMPLOYEE_ID, selectedRow].Value.ToString().Equals(user.Id))
            {
                MessageBox.Show("他ユーザーのコメントは削除できません", "エラー");
                return;
            }
            if (rowDeleteCheck())
            {
                //削除するコメントをIDに格納
                if ((String)dgvIchiran[(int)column.STETUS, selectedRow].Value != "0")
                {
                    delList.Add(dgvIchiran[(int)column.COMMENT_ID, selectedRow].Value.ToString());
                }
                dgvIchiran.Rows.RemoveAt(selectedRow);
                changeFlg = true;
            }

        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToroku_Click(object sender, EventArgs e)
        {
            //明細の変更チェック
            if (!insertInputCheckM())
            {
                return;
            }
            //メニューでメンターを選択した場合
            if (_mode == (int)mode.SUISHINBU)
            {
                //コメントの有無チェック
                if (!insertInputCheckComment())
                {
                    return;
                }


            }
            if (!diarogCheck("登録"))
            {
                return;
            }
            if (!insertExcute())
            {
                return;
            }
            MessageBox.Show("登録が完了しました", "");
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            this.Close();
        }

        /// <summary>
        /// 報告ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!reportInputCheck())
            {
                return;
            }
            if (!diarogCheck("報告"))
            {
                return;
            }
            if (!reportExcute())
            {
                return;
            }

            MessageBox.Show("報告が完了しました", "");
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            this.Close();
        }

        /// <summary>
        /// 一時保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!saveInputCheck())
            {
                return;
            }
            if (!diarogCheck("保存"))
            {
                return;
            }
            if (!saveExecute())
            {
                return;
            }

            MessageBox.Show("保存が完了しました", "");
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            this.Close();
        }

        /// <summary>
        /// 差し戻しボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemand_Click(object sender, EventArgs e)
        {
            //if (!remandInputCheck())
            //{
            //    return;
            //}
            MH0041 frm = new MH0041();
            frm.ShowDialog();
            if (!frm.inputFlg)
            {
                return;
            }
            if (!diarogCheck("差戻し"))
            {
                return;
            }
            //差戻理由追加
            rowInsertFlg = true;
            DataTable dta = (DataTable)dgvIchiran.DataSource;
            dta.Rows.Add(getCommentId(), false, false, user.Id, user.Name, "差戻理由:" + frm.reason, "", null, 0);
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            dgvIchiran[(int)column.CORRECT_FLG, dgvIchiran.Rows.Count - 1] = cell;
            if (!remandExcute())
            {
                return;
            }

            MessageBox.Show("差戻しが完了しました", "");
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            this.Close();
        }

        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (!diarogCheck("削除"))
            {
                return;
            }
            if (!deleteExcute())
            {
                return;
            }
            MessageBox.Show("削除が完了しました", "");
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            this.Close();
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MH0040_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changeDetection())
            {
                e.Cancel = true;
            }

            if (!_mentorResultId.Equals(""))
            {
                if (shokaiMode)
                {
                    return;
                }
                //排他トラン削除
                if (!comU.DeleteHaitaTrn(_mentorResultId))
                {
                    return;
                }

            }
        }
        /// <summary>
        /// 変更検知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool changeDetection()
        {

            if (!torokuFlg)
            {

            }
            if (changeFlg)
            {
                DialogResult result = MessageBox.Show("内容が変更されています。\n\r変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    changeFlg = false;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// ←ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDn_Click(object sender, EventArgs e)
        {
            if (changeDetection())
            {
                return;
            }
            string lastResultId = _resultIdList.Last();
            //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
            if (_mentorResultId.Equals(""))
            {
                this.Hide();
                MH0040 mh0040 = new MH0040(user, _resultIdList, lastResultId, _mode);
                mh0040.ShowDialog();
                this.torokuFlg = mh0040.torokuFlg;
            }
            else
            {
                //メンター実績ID配列内にある引数の実績IDのひとつ前のメンターID
                int index = _resultIdList.IndexOf(_mentorResultId);
                string id = _resultIdList[index - 1];
                this.Hide();
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId))
                    {
                        return;
                    }
                }
                MH0040 mh0040 = new MH0040(user, _resultIdList, id, _mode);
                mh0040.ShowDialog();
                this.torokuFlg = mh0040.torokuFlg;
            }
        }

        /// <summary>
        /// →ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (changeDetection())
            {
                return;
            }
            string lastResultId = _resultIdList.Last();
            //実績IDがメンター実績ID配列の最終IDと一致する場合
            if (_mentorResultId.Equals(lastResultId))
            {
                this.Hide();
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId))
                    {
                        return;
                    }
                }
                MH0040 mh0040 = new MH0040(user, _resultIdList);
                mh0040.ShowDialog();
                this.torokuFlg = mh0040.torokuFlg;
            }
            else
            {
                //メンター実績ID配列内にある引数の実績IDのひとつ前のメンターID
                int index = _resultIdList.IndexOf(_mentorResultId);
                string id = _resultIdList[index + 1];
                this.Hide();
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId))
                    {
                        return;
                    }
                }
                MH0040 mh0040 = new MH0040(user, _resultIdList, id, _mode);
                mh0040.ShowDialog();
                this.torokuFlg = mh0040.torokuFlg;
            }
        }



        /// <summary>
        /// メンターコンボボックス変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMentee_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        /// <summary>
        /// 実施開始時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStartH_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        /// <summary>
        /// 実施開始時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStartM_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        /// <summary>
        /// 実施終了時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEndH_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        /// <summary>
        /// 実施終了時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEndM_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }



        private void cboPlanStartH_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        private void cboPlanStartM_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        private void cboPlanEndH_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        private void cboPlanEndM_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///     文字列が数値であるかどうかを返します。</summary>
        /// <param name="stTarget">
        ///     検査対象となる文字列。<param>
        /// <returns>
        ///     指定した文字列が数値であれば true。それ以外は false。</returns>
        /// -----------------------------------------------------------------------------
        private bool IsNumeric(string stTarget)
        {
            double dNullable;

            return double.TryParse(
                stTarget,
                System.Globalization.NumberStyles.Any,
                null,
                out dNullable
            );
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                int selection = txtPrice.SelectionStart;
                int length = txtPrice.Text.Length;
                changeFlg = true;
                if (!string.IsNullOrEmpty(txtPrice.Text))
                {
                    //数値以外入力不可
                    if (!IsNumeric(txtPrice.Text.Replace(",", "")))
                    {
                        txtPrice.Text = "";
                        return;
                    }
                    //マイナス入力不可
                    if (int.Parse(txtPrice.Text.Replace(",", "")) < 0)
                    {
                        txtPrice.Text = "";
                        return;
                    }
                    //5桁以上入力不可
                    if (int.Parse(txtPrice.Text.Replace(",", "")) > 99999)
                    {
                        txtPrice.Text = "";
                        return;
                    }
                    txtPrice.Text = int.Parse(txtPrice.Text.Replace(",", "")).ToString("#,0");
                    if (length < txtPrice.Text.Length)
                    {
                        selection = selection + 1;
                    }
                    else if (length > txtPrice.Text.Length)
                    {
                        if (selection > 0)
                        {
                            selection = selection - 1;
                        }
                    }


                }
                this.txtPrice.Select(selection, 0);
                return;
            }
        }

        private void txtReport_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }




        private void dgvIchiran_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIchiran[(int)column.STETUS, e.RowIndex].Value.ToString() != "0")
            {

                if ((dgvIchiran[(int)column.CONTENT, e.RowIndex].Value.ToString().Equals(dgvIchiran[(int)column.CONTENT_OLD, e.RowIndex].Value.ToString())) &&
                    (dgvIchiran[(int)column.CORRECT_FLG, e.RowIndex].Value.ToString().Equals(dgvIchiran[(int)column.CORRECT_FLG_OLD, e.RowIndex].Value.ToString())))
                {
                    dgvIchiran[(int)column.STETUS, e.RowIndex].Value = "";
                }
                else
                {
                    dgvIchiran[(int)column.STETUS, e.RowIndex].Value = "1";
                    if (_mode == (int)mode.SUISHINBU)
                    {
                        dgvIchiran[(int)column.CORRECT_FLG, e.RowIndex].Value = false;
                    }
                    changeFlg = true;
                }
            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && (Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                e.Handled = true;
            }
        }

        private void dtpDatePlan_ValueChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }

        private void dtpExecDate_ValueChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                changeFlg = true;
            }
        }
    }
}
