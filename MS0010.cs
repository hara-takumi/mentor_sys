using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MS0010 : Form
    {
        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        private bool flg = true;
        DateTime dt = System.DateTime.Now;

        public enum column
        {
            SENTAKU,
            MENTOR_ID,
            MENTOR_NAME,
            MENTEE_ID,
            MENTEE_NAME,
            TEKIYO_START_DATE,
            TEKIYO_END_DATE
        }

        private User user;
        public MS0010(User user)
        {
            this.user = user;
            InitializeComponent();



        }
        private void MS0010_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
        {
            dgvIchiran.RowTemplate.Height = 30;
            dgvIchiran.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIchiran.AllowUserToAddRows = false;
            dgvIchiran.RowHeadersVisible = false;
            dgvIchiran.AllowUserToResizeColumns = false;
            dgvIchiran.AllowUserToResizeRows = false;

            lblUser.Text = user.Name;
            dtpStart.Value = dt;
            dtpEnd.Value = dt;

            //SetMentor();
            //SetMentee();
            //changeCboMentor();
            //changeCboMentee();
        }


        /// <summary>
        /// メンターコンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool Mentor(ref DataSet ds)
        {
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);


            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
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
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンターコンボボックスの取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool Mentee(ref DataSet ds, bool flg)
        {
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);


            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTEE_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
            sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");
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
            if (flg)
            {
                if (!cboMenta.Text.Equals("すべて"))
                {
                    sql.Append($" AND MENTOR_ID = '{cboMenta.SelectedValue}'");
                }
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
                MessageBox.Show("DB接続に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンティ―コンボボックスの取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }


            return true;

        }

        public void setCboMentee()
        {
            DataSet dataSet = new DataSet();
            if (!Mentee(ref dataSet, true))
            {
                this.Close();
                return;
            }
            var selectedValue = cboMentee.SelectedValue;
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            this.cboMentee.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cboMentee.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMentee.ValueMember = "MST_SHAIN_CODE";
            if (selectedValue == null)
            {
                cboMentee.SelectedValue = 0;
                return;
            }

            var list = dataSet.Tables[0].AsEnumerable().Where(x => x.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
            }

            //foreach (DataRow ds in dataSet.Tables[0].Rows)
            //{
            //    if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
            //    {
            //        cboMentee.SelectedValue = selectedValue;
            //        break;
            //    }
            //}
        }

        public void setCboMentor()
        {
            DataSet dataSet = new DataSet();
            if (!Mentor(ref dataSet))
            {
                this.Close();
                return;
            }
            var selectedValue = cboMenta.SelectedValue;
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            this.cboMenta.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cboMenta.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMenta.ValueMember = "MST_SHAIN_CODE";
            if (selectedValue == null)
            {
                cboMenta.SelectedValue = 0;
                return;
            }

            var list = dataSet.Tables[0].AsEnumerable().Where(x => x.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMenta.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
            }

            //foreach (DataRow ds in dataSet.Tables[0].Rows)
            //{
            //    if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
            //    {
            //        cboMenta.SelectedValue = selectedValue;
            //        break;
            //    }
            //}
        }

        private void cboMenta_TextChanged(object sender, EventArgs e)
        {
            setCboMentee();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

            setCboMentor();
        }
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

            setCboMentor();
        }


        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                return;
            }
            Result();

        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        public bool check()
        {
            string yyyyMMfrom = dtpStart.Value.ToString();
            string yyyyMMto = dtpEnd.Value.ToString();
            if (string.IsNullOrEmpty(yyyyMMfrom) || string.IsNullOrEmpty(yyyyMMto))
            {
                return true;
            }
            if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
            {
                MessageBox.Show("適用日が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
        /// 検索結果表示
        /// </summary>
        public void Result()
        {
            dgvIchiran.Columns.Clear();
            string start = getDateTimePick(dtpStart.Value);
            string end = getDateTimePick(dtpEnd.Value);


            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MENTOR_ID");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME");
            sql.Append("     ,MENTEE_ID");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME");
            sql.Append("     ,TEKIYO_START_DATE");
            sql.Append("     ,CASE TEKIYO_END_DATE WHEN '9999-12-31' THEN NULL ELSE TEKIYO_END_DATE END");

            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" INNER JOIN MST_SHAIN MENTOR");
            sql.Append("   ON MENTOR_ID = MENTOR.MST_SHAIN_CODE");
            sql.Append(" INNER JOIN MST_SHAIN MENTEE");
            sql.Append("   ON MENTEE_ID = MENTEE.MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MENTOR.MST_SHAIN_TEKIYO_DATE_END >= '{start}'");
                sql.Append($" AND MENTEE.MST_SHAIN_TEKIYO_DATE_END >= '{start}'");
                sql.Append($" AND TEKIYO_END_DATE >= '{start}'");
            }
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MENTOR.MST_SHAIN_TEKIYO_DATE_STR <= '{end}'");
                sql.Append($" AND MENTEE.MST_SHAIN_TEKIYO_DATE_STR <= '{end}'");
                sql.Append($" AND TEKIYO_START_DATE <= '{end}'");
            }
            if (cboMenta.SelectedIndex != 0)
            {
                sql.Append($"   AND MENTOR_ID = '{cboMenta.SelectedValue}'");
            }
            if (cboMentee.SelectedIndex != 0)
            {
                sql.Append($"   AND MENTEE_ID = '{cboMentee.SelectedValue}'");
                sql.Append(" ORDER BY TEKIYO_START_DATE DESC");
            }
            else
            {
                sql.Append(" ORDER BY MENTOR_ID,TEKIYO_START_DATE DESC");
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
                return;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("SQLの実行に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            dgvIchiran.Columns[(int)column.MENTOR_ID].HeaderText = "メンターID";
            dgvIchiran.Columns[(int)column.MENTOR_NAME].HeaderText = "メンター";
            dgvIchiran.Columns[(int)column.MENTEE_ID].HeaderText = "メンティ―ID";
            dgvIchiran.Columns[(int)column.MENTEE_NAME].HeaderText = "メンティ―";
            dgvIchiran.Columns[(int)column.TEKIYO_START_DATE].HeaderText = "適用開始日";
            dgvIchiran.Columns[(int)column.TEKIYO_END_DATE].HeaderText = "適用終了日";

            dgvIchiran.Columns[(int)column.MENTOR_ID].ReadOnly = true;
            dgvIchiran.Columns[(int)column.MENTOR_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.MENTEE_ID].ReadOnly = true;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].ReadOnly = true;
            dgvIchiran.Columns[(int)column.TEKIYO_START_DATE].ReadOnly = true;
            dgvIchiran.Columns[(int)column.TEKIYO_END_DATE].ReadOnly = true;

            dgvIchiran.Columns[(int)column.MENTOR_ID].Visible = false;
            dgvIchiran.Columns[(int)column.MENTOR_NAME].Visible = true;
            dgvIchiran.Columns[(int)column.MENTEE_ID].Visible = false;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].Visible = true;
            dgvIchiran.Columns[(int)column.TEKIYO_START_DATE].Visible = true;
            dgvIchiran.Columns[(int)column.TEKIYO_END_DATE].Visible = true;

            dgvIchiran.Columns[(int)column.MENTOR_NAME].Width = 130;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].Width = 130;
            dgvIchiran.Columns[(int)column.TEKIYO_START_DATE].Width = 200;
            dgvIchiran.Columns[(int)column.TEKIYO_END_DATE].Width = 200;

            dgvIchiran.DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;


        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        public void Clear()
        {
            dgvIchiran.Columns.Clear();
            dtpStart.Value = dt;
            dtpEnd.Value = dt;
            cboMenta.SelectedIndex = 0;
            cboMentee.SelectedIndex = 0;
        }

        /// <summary>
        /// 新規登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            MS0020 ms0020 = new MS0020(user);
            ms0020.ShowDialog();
            if (ms0020.torokuFlg)
            {
                Result();
            }
        }

        /// <summary>
        /// 選択ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "選択")
            {
                String mentorId = (String)dgvIchiran[(int)column.MENTOR_ID, e.RowIndex].Value;
                String mentorNm = (String)dgvIchiran[(int)column.MENTOR_NAME, e.RowIndex].Value;
                String menteeId = (String)dgvIchiran[(int)column.MENTEE_ID, e.RowIndex].Value;
                String menteeNm = (String)dgvIchiran[(int)column.MENTEE_NAME, e.RowIndex].Value;
                string startDate = ((DateTime)dgvIchiran[(int)column.TEKIYO_START_DATE, e.RowIndex].Value).ToString("yyyy/MM/dd");
                string EndDate = "";
                if (!string.IsNullOrEmpty(dgvIchiran[(int)column.TEKIYO_END_DATE, e.RowIndex].Value.ToString() ))
                {
                    EndDate = ((DateTime)dgvIchiran[(int)column.TEKIYO_END_DATE, e.RowIndex].Value).ToString("yyyy/MM/dd");
                }
                MS0020 ms0020 = new MS0020(user, mentorId, mentorNm, menteeId, menteeNm, startDate, EndDate);
                ms0020.ShowDialog();
                if (ms0020.torokuFlg)
                {
                    Result();
                }
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
        /// ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex== -1)
            {
                return;
            }
            String mentorId = (String)dgvIchiran[(int)column.MENTOR_ID, e.RowIndex].Value;
            String mentorNm = (String)dgvIchiran[(int)column.MENTOR_NAME, e.RowIndex].Value;
            String menteeId = (String)dgvIchiran[(int)column.MENTEE_ID, e.RowIndex].Value;
            String menteeNm = (String)dgvIchiran[(int)column.MENTEE_NAME, e.RowIndex].Value;
            string startDate = ((DateTime)dgvIchiran[(int)column.TEKIYO_START_DATE, e.RowIndex].Value).ToString("yyyy/MM/dd");
            string EndDate = "";
            if (!string.IsNullOrEmpty(dgvIchiran[(int)column.TEKIYO_END_DATE, e.RowIndex].Value.ToString()))
            {
                EndDate = ((DateTime)dgvIchiran[(int)column.TEKIYO_END_DATE, e.RowIndex].Value).ToString("yyyy/MM/dd");
            }
            MS0020 ms0020 = new MS0020(user, mentorId, mentorNm, menteeId, menteeNm, startDate, EndDate);
            ms0020.ShowDialog();
            if (ms0020.torokuFlg)
            {
                Result();
            }
        }


    }
}
