using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0030 : Form
    {
        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        private User user;
        List<string> resultIdList = new List<string>();

        public bool changeFlg = false;
        public int _mode;

        private enum mode
        {
            MENTA,
            SUISHINBU
        }

        public enum column
        {
            SENTAKU,
            MENTOR_RESULT_ID,
            EXEC_DATE,
            MENTOR_NAME,
            MENTEE_NAME,
            STATUS,
            REPORT_DT,
            CORRECT_FLG,
            CORRECT_DT
        }

        public MH0030(User user, int mode)
        {
            this.user = user;
            _mode = mode;
            InitializeComponent();
        }

        private void MH0020_Load(object sender, EventArgs e)
        {
            Initialization();

        }
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            dgvIchiran.RowTemplate.Height = 30;
            dgvIchiran.AllowUserToAddRows = false;
            dgvIchiran.RowHeadersVisible = false;
            dgvIchiran.AllowUserToResizeColumns = false;
            dgvIchiran.AllowUserToResizeRows = false;

            lblUser.Text = user.Name;


            if (_mode == (int)mode.MENTA)
            {
                cboMentee.TabIndex = 1;
                lblMenta.Visible = false;
                cboMentor.Visible = false;

                lblMenty.Location = new System.Drawing.Point(10, 19);
                cboMentee.Location = new System.Drawing.Point(102, 15);

                lblExecDate.Location = new System.Drawing.Point(10, 64);
                dtpStart.Location = new System.Drawing.Point(102, 60);
                lblDash.Location = new System.Drawing.Point(314, 64);
                dtpEnd.Location = new System.Drawing.Point(352, 60);

                SetMentee();
            }
            else
            {
                btnInsert.Visible = false;
                SetMentor();
                SetMentee();
            }
        }

        /// <summary>
        /// コンボボックスセット(メンタ―)
        /// </summary>
        public void SetMentor()
        {
            DataSet dataSet = new DataSet();
            if (!mentor(ref dataSet))
            {
                this.Close();
                return;
            }
            var selectedValue = cboMentor.SelectedValue;
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            this.cboMentor.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cboMentor.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMentor.ValueMember = "MST_SHAIN_CODE";

            if (selectedValue == null)
            {
                cboMentor.SelectedValue = 0;
                return;
            }
            foreach (DataRow ds in dataSet.Tables[0].Rows)
            {
                if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
                {
                    cboMentor.SelectedValue = selectedValue;
                    break;
                }
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
            var selectedValue = cboMentee.SelectedValue;
            string initSelected = null;
            if (_mode == (int)mode.SUISHINBU)
            {
                DataRow row = dataSet.Tables[0].NewRow();
                row["MST_SHAIN_CODE"] = "0";
                row["MST_SHAIN_NAME"] = "すべて";
                dataSet.Tables[0].Rows.InsertAt(row, 0);

            }
            if (selectedValue == null)
            {
                if (_mode == (int)mode.MENTA)
                {

                    foreach (DataRow ds in dataSet.Tables[0].Rows)
                    {
                        if ((DateTime)ds["TEKIYO_START_DATE"] <= System.DateTime.Now.Date && (DateTime)ds["TEKIYO_END_DATE"] >= System.DateTime.Now.Date)
                        {
                            initSelected = ds["MST_SHAIN_CODE"].ToString();
                        }
                    }
                }
            }
            // コンボボックスにデータテーブルをセット
            //this.cboMentee.DataSource = dataSet.Tables[0].DefaultView.ToTable(true, "MST_SHAIN_CODE", "MST_SHAIN_NAME");
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                this.cboMentee.DataSource = dataSet.Tables[0].AsEnumerable().GroupBy(r => r.Field<string>("MST_SHAIN_CODE")).Select(g => g.First()).CopyToDataTable();
                // 表示用の列を設定
                this.cboMentee.DisplayMember = "MST_SHAIN_NAME";
                //// データ用の列を設定
                this.cboMentee.ValueMember = "MST_SHAIN_CODE";
                if (initSelected != null)
                {
                    cboMentee.SelectedValue = initSelected;
                }
                else if (cboMentee.Items.Count != 0)
                {
                    cboMentee.SelectedIndex = 0;
                }

                if (selectedValue != null)
                {
                    foreach (DataRow ds in dataSet.Tables[0].Rows)
                    {
                        if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
                        {
                            cboMentee.SelectedValue = selectedValue;
                            break;
                        }
                    }
                }
            }
            else
            {
                this.cboMentee.DataSource = null;
            }


        }
        /// <summary>
        /// DateTimePickerの値から日付を取得
        /// </summary>
        private string getDateTimePick(DateTime? dateTime)
        {
            string result = null;

            if (!string.IsNullOrEmpty(dateTime.ToString()))
            {
                result = ((DateTime)dateTime).Year.ToString() + String.Format("{0:D2}", ((DateTime)dateTime).Month) + String.Format("{0:D2}", ((DateTime)dateTime).Day);
            }

            return result;
        }

        /// <summary>
        /// メンターコンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool mentor(ref DataSet ds)
        {
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= '{start}'");
                sql.Append($" AND TEKIYO_END_DATE >= '{start}'");
            }
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= '{end}'");
                sql.Append($" AND TEKIYO_START_DATE <= '{end}'");
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {

                sql.Append($" AND  '{start}' <= '{end}'");
            }

            sql.Append(" GROUP BY MST_SHAIN_CODE ");
            sql.Append(" ORDER BY MST_SHAIN_CODE ");

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
                MessageBox.Show("メンターコンボボックスの取得に失敗しました", "エラー");
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
        /// メンティ―コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool mentee(ref DataSet ds)
        {
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append("     ,TEKIYO_START_DATE");
            sql.Append("     ,TEKIYO_END_DATE");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTEE_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= '{start}'");
                sql.Append($" AND TEKIYO_END_DATE >= '{start}'");
            }
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= '{end}'");
                sql.Append($" AND TEKIYO_START_DATE <= '{end}'");
            }
            if (!cboMentor.Text.Equals("すべて"))
            {
                if (_mode == (int)mode.MENTA)
                {
                    sql.Append($" AND MENTOR_ID = '{user.Id}'");
                }
                else
                {
                    sql.Append($" AND MENTOR_ID = '{cboMentor.SelectedValue}'");
                }
            }
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {

                sql.Append($" AND  '{start}' <= '{end}'");
            }

            //sql.Append(" GROUP BY MST_SHAIN_CODE ");
            sql.Append(" ORDER BY MST_SHAIN_CODE ");

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
        /// 登録入力チェック
        /// </summary>
        /// <returns></returns>
        public bool check()
        {
            if (!dtpStart.Text.Equals("") & !dtpEnd.Text.Equals(""))
            {
                string yyyyMMfrom = dtpStart.Text;
                string yyyyMMto = dtpEnd.Text;
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show("適用日が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (cboMentee.SelectedIndex == -1)
            {
                MessageBox.Show("メンティーを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        /// <summary>
        /// 検索結果表示
        /// </summary>
        public void Result()
        {
            dgvIchiran.Columns.Clear();
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      TRN_MENTOR_RESULT.MENTOR_RESULT_ID");
            sql.Append("     ,EXEC_DATE ");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME");
            sql.Append("     ,CASE STATUS WHEN 0 THEN '未報告'  WHEN 1 THEN '報告済み' ELSE '差し戻し' END '状況'");
            sql.Append("     ,REPORT_DT");
            sql.Append("     ,CASE MIN(CORRECT_FLG) WHEN 0 THEN 'あり' ELSE '-' END '未確認コメント'");
            sql.Append("     ,MAX(CORRECT_DT) '最終確認日時'");
            sql.Append("   FROM TRN_MENTOR_RESULT ");
            sql.Append("   LEFT JOIN TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append("     ON TRN_MENTOR_RESULT.MENTOR_RESULT_ID = TRN_MENTOR_RESULT_PROMOTE.MENTOR_RESULT_ID ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTOR ");
            sql.Append("     ON MENTOR_ID = MENTOR.MST_SHAIN_CODE ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTEE ");
            sql.Append("     ON MENTEE_ID = MENTEE.MST_SHAIN_CODE ");
            sql.Append(" WHERE 1=1");
            //適用開始日空以外
            if (!dtpStart.Text.Equals(""))
            {
                sql.Append($"   AND EXEC_DATE >= '{start}'");
            }
            //適用終了日空以外
            if (!dtpEnd.Text.Equals(""))
            {
                sql.Append($"   AND EXEC_DATE <= '{end}'");
            }
            //メンター推進チームの場合
            if (_mode == (int)mode.SUISHINBU)
            {
                sql.Append("   AND STATUS != 0 ");
                //メンターコンボがすべて以外
                if (!cboMentor.Text.Equals("すべて"))
                {
                    sql.Append($"   AND MENTOR.MST_SHAIN_CODE = '{cboMentor.SelectedValue}'");
                }
            }
            //メンティ―コンボがすべて以外
            if (!cboMentee.Text.Equals("すべて"))
            {
                sql.Append($"   AND MENTEE.MST_SHAIN_CODE = '{cboMentee.SelectedValue}'");
            }

            sql.Append(" GROUP BY TRN_MENTOR_RESULT.MENTOR_RESULT_ID ");
            //コメント未確認にチェックが入っている場合
            if (chkCorrect.Checked)
            {
                sql.Append(" HAVING MIN(CORRECT_FLG) = '0' ");
            }
            //メンター用の場合
            if (_mode == (int)mode.MENTA)
            {
                sql.Append(" ORDER BY EXEC_DATE DESC");
            }
            else
            {
                sql.Append(" ORDER BY REPORT_DT DESC");
            }


            DataSet ds = new DataSet();
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
                MessageBox.Show("SQLの実行に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("対象がありません");
            }

            dgvIchiran.DataSource = ds.Tables[0];

            //セルボタン作成
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.Name = "選択";
            dgvbtn.HeaderText = "";
            dgvbtn.Text = "選択";
            dgvbtn.UseColumnTextForButtonValue = true;
            dgvbtn.Width = 75;
            dgvIchiran.Columns.Insert(0, dgvbtn);

            dgvIchiran.Columns[(int)column.MENTOR_RESULT_ID].HeaderText = "メンター実績ID";
            dgvIchiran.Columns[(int)column.EXEC_DATE].HeaderText = "実施日";
            dgvIchiran.Columns[(int)column.MENTOR_NAME].HeaderText = "メンター";
            dgvIchiran.Columns[(int)column.MENTEE_NAME].HeaderText = "メンティー";
            dgvIchiran.Columns[(int)column.STATUS].HeaderText = "状況";
            dgvIchiran.Columns[(int)column.REPORT_DT].HeaderText = "報告日時";
            dgvIchiran.Columns[(int)column.CORRECT_FLG].HeaderText = "メンター確認コメント";
            dgvIchiran.Columns[(int)column.CORRECT_DT].HeaderText = "最終確認日時";

            dgvIchiran.Columns[(int)column.MENTOR_RESULT_ID].ReadOnly = true;
            dgvIchiran.Columns[(int)column.EXEC_DATE].ReadOnly = true;
            dgvIchiran.Columns[(int)column.MENTOR_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.STATUS].ReadOnly = true;
            dgvIchiran.Columns[(int)column.REPORT_DT].ReadOnly = true;
            dgvIchiran.Columns[(int)column.CORRECT_FLG].ReadOnly = true;
            dgvIchiran.Columns[(int)column.CORRECT_DT].ReadOnly = true;

            dgvIchiran.Columns[(int)column.MENTOR_RESULT_ID].Visible = false;
            dgvIchiran.Columns[(int)column.EXEC_DATE].Visible = true;
            //メンター用画面の場合
            if (_mode == (int)mode.MENTA)
            {
                dgvIchiran.Columns[(int)column.MENTOR_NAME].Visible = false;
                dgvIchiran.Columns[(int)column.MENTEE_NAME].Visible = false;
            }

            dgvIchiran.Columns[(int)column.EXEC_DATE].Width = 150;
            dgvIchiran.Columns[(int)column.MENTOR_NAME].Width = 120;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].Width = 120;
            dgvIchiran.Columns[(int)column.STATUS].Width = 110;
            dgvIchiran.Columns[(int)column.REPORT_DT].Width = 195;
            dgvIchiran.Columns[(int)column.CORRECT_FLG].Width = 130;
            dgvIchiran.Columns[(int)column.CORRECT_DT].Width = 195;

            dgvIchiran.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIchiran.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                resultIdList.Add((string)ds.Tables[0].Rows[i]["MENTOR_RESULT_ID"].ToString());
            }
            foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {

            resultIdList.Clear();
            //入力チェック
            if (!check())
            {
                return;
            }

            Result();

        }

        /// <summary>
        /// 新規登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            MH0040 mh0040 = new MH0040(user, resultIdList);
            mh0040.ShowDialog();
            if (mh0040.torokuFlg)
            {
                Result();
            }
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
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvIchiran.Columns.Clear();
            resultIdList.Clear();
            dtpStart.Value = null;
            dtpEnd.Value = null;
            chkCorrect.Checked = false;
            if (_mode == (int)mode.SUISHINBU)
            {
                cboMentor.SelectedIndex = 0;

            }
            cboMentee.SelectedIndex = 0;
        }



        /// <summary>
        /// メンターコンボ変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMentor_TextChanged(object sender, EventArgs e)
        {

            SetMentee();
        }


        /// <summary>
        /// 選択ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "選択")
            {
                String mentorResultId = (String)dgvIchiran[(int)column.MENTOR_RESULT_ID, e.RowIndex].Value.ToString();
                MH0040 mh0040 = new MH0040(user, resultIdList, mentorResultId, _mode);
                mh0040.ShowDialog();
                if (mh0040.torokuFlg)
                {
                    Result();
                }
            }
        }

        /// <summary>
        /// ダブルクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            String mentorResultId = (String)dgvIchiran[(int)column.MENTOR_RESULT_ID, e.RowIndex].Value.ToString();
            MH0040 mh0040 = new MH0040(user, resultIdList, mentorResultId, _mode);
            mh0040.Show();
            if (mh0040.torokuFlg)
            {
                Result();
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (_mode == (int)mode.SUISHINBU)
            {
                SetMentor();
            }
            SetMentee();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (_mode == (int)mode.SUISHINBU)
            {
                SetMentor();
            }

            SetMentee();
        }

    }
}
