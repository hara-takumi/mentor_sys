using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0050 : Form
    {

        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        DateTime dt = System.DateTime.Now;
        private User user;
        private bool flg = false;

        public enum column
        {
            EXEC_DATE,
            MENTOR_NAME,
            MENTEE_NAME,
            PRICE,
            MONTH_PRICE,
            PLACE
        }

        public MH0050(User user)
        {
            this.user = user;
            InitializeComponent();

        }

        private void MH0050_Load(object sender, EventArgs e)
        {

            Initialization();
        }


        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialization()
        {
            //セルの内容に合わせて、行の高さが自動的に調節されるようにする
            dgvIchiran.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvIchiran.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIchiran.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //ユーザー名表示
            lblUser.Text = user.Name;

            //コンボボックス設定(年月)
            cboYearFrom.DataSource = comU.CYear(true).ToArray();
            cboYearFrom.Text = dt.ToString("yyyy");
            cboMonthFrom.DataSource = comU.CMonth(true).ToArray();
            cboMonthFrom.Text = dt.ToString("MM");
            cboYearTo.DataSource = comU.CYear(true).ToArray();
            cboYearTo.Text = dt.ToString("yyyy");
            cboMonthTo.DataSource = comU.CMonth(true).ToArray();
            cboMonthTo.Text = dt.ToString("MM");

            SetMentor();

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

            if (flg)
            {

                var list = dataSet.Tables[0].AsEnumerable().Where(x => x.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
                if (list != null)
                {
                    cboMentor.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
                }

                //foreach (DataRow ds in dataSet.Tables[0].Rows)
                //{
                //    if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
                //    {
                //        cboMentor.SelectedValue = selectedValue;
                //        break;
                //    }
                //}
            }

            flg = true;
        }

        /// <summary>
        /// メンターコンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool mentor(ref DataSet ds)
        {
            string yyyyMMfrom = cboYearFrom.Text + cboMonthFrom.Text;
            string yyyyMMto = cboYearTo.Text + cboMonthTo.Text;

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1 ");
            //画面.年From、画面.月Fromの両方が入力されている場合
            if (!cboYearFrom.Text.Equals("") & !cboMonthFrom.Text.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(MST_SHAIN_TEKIYO_DATE_END, '%Y%m')  >= '{yyyyMMfrom}'");
                sql.Append($" AND DATE_FORMAT(TEKIYO_END_DATE, '%Y%m') >= '{yyyyMMfrom}'");
            }
            //画面.年To、画面.月Toの両方が入力されている場合
            if (!cboYearTo.Text.Equals("") & !cboMonthTo.Text.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(MST_SHAIN_TEKIYO_DATE_STR, '%Y%m') <= '{yyyyMMto}'");
                sql.Append($" AND DATE_FORMAT(TEKIYO_START_DATE, '%Y%m') <= '{yyyyMMto}'");
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
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        public bool check()
        {
            //年月
            if (!cboYearFrom.Text.Equals("") & cboMonthFrom.Text.Equals(""))
            {
                MessageBox.Show("年を選択した場合は月を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMonthFrom;
                return false;
            }
            if (cboYearFrom.Text.Equals("") & !cboMonthFrom.Text.Equals(""))
            {
                MessageBox.Show("月を選択した場合は年を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboYearFrom;
                return false;
            }
            if (!cboYearTo.Text.Equals("") & cboMonthTo.Text.Equals(""))
            {
                MessageBox.Show("年を選択した場合は月を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMonthTo;
                return false;
            }
            if (cboYearTo.Text.Equals("") & !cboMonthTo.Text.Equals(""))
            {
                MessageBox.Show("月を選択した場合は年を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboYearTo;
                return false;
            }

            //日付逆転チェック
            string yyyyMMfrom = cboYearFrom.Text + cboMonthFrom.Text;
            string yyyyMMto = cboYearTo.Text + cboMonthTo.Text;
            if (yyyyMMfrom != "" && yyyyMMto != "")
            {
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show("年月が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = cboYearFrom;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 検索結果表示
        /// </summary>
        public void Result()
        {
            dgvIchiran.Columns.Clear();

            string yyyyMMfrom = cboYearFrom.Text + cboMonthFrom.Text;
            string yyyyMMto = cboYearTo.Text + cboMonthTo.Text;

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     TRN_MENTOR_RESULT.EXEC_DATE");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME");
            sql.Append("     ,PRICE");
            sql.Append("     ,MONTH_PRICE");
            sql.Append("     ,PLACE");
            sql.Append(" FROM TRN_MENTOR_RESULT");
            sql.Append(" LEFT JOIN MST_SHAIN MENTOR");
            sql.Append("   ON MENTOR_ID = MENTOR.MST_SHAIN_CODE");
            sql.Append(" LEFT JOIN MST_SHAIN MENTEE");
            sql.Append("   ON MENTEE_ID = MENTEE.MST_SHAIN_CODE");
            sql.Append(" LEFT JOIN");
            sql.Append("     (SELECT ");
            sql.Append("       EXEC_DATE,");
            sql.Append("       SUM(PRICE) AS MONTH_PRICE,");
            sql.Append("       MENTOR_ID");
            sql.Append("      FROM TRN_MENTOR_RESULT");
            sql.Append("      WHERE STATUS=1");
            sql.Append("      GROUP BY DATE_FORMAT(EXEC_DATE, '%Y%m'),MENTOR_ID) AS SUM_PRICE");
            sql.Append("   ON DATE_FORMAT(SUM_PRICE.EXEC_DATE, '%Y%m') = DATE_FORMAT(TRN_MENTOR_RESULT.EXEC_DATE, '%Y%m')");
            sql.Append("  AND MENTOR.MST_SHAIN_CODE = SUM_PRICE.MENTOR_ID");
            sql.Append(" WHERE STATUS=1");
            //画面.年月Fromが入力されている場合
            if (!yyyyMMfrom.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(TRN_MENTOR_RESULT.EXEC_DATE, '%Y%m') >= '{yyyyMMfrom}'");
            }
            //画面.年月Toが入力されている場合
            if (!yyyyMMto.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(TRN_MENTOR_RESULT.EXEC_DATE, '%Y%m') <= '{yyyyMMto}'");
            }
            //画面.メンターコンボボックスで"すべて"以外を選択した場合
            if (cboMentor.SelectedIndex != 0)
            {
                sql.Append($"   AND TRN_MENTOR_RESULT.MENTOR_ID = '{cboMentor.SelectedValue}'");
            }
            sql.Append(" ORDER BY EXEC_DATE DESC");

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

            dgvIchiran.Columns[(int)column.EXEC_DATE].HeaderText = "実施日";
            dgvIchiran.Columns[(int)column.MENTOR_NAME].HeaderText = "メンター";
            dgvIchiran.Columns[(int)column.MENTEE_NAME].HeaderText = "メンティー";
            dgvIchiran.Columns[(int)column.PRICE].HeaderText = "経費（円）";
            dgvIchiran.Columns[(int)column.MONTH_PRICE].HeaderText = "月合計（円）";
            dgvIchiran.Columns[(int)column.PLACE].HeaderText = "実施場所";


            dgvIchiran.Columns[(int)column.EXEC_DATE].Width = 200;
            dgvIchiran.Columns[(int)column.MENTOR_NAME].Width = 130;
            dgvIchiran.Columns[(int)column.MENTEE_NAME].Width = 130;
            dgvIchiran.Columns[(int)column.PRICE].Width = 150;
            dgvIchiran.Columns[(int)column.MONTH_PRICE].Width = 130;
            dgvIchiran.Columns[(int)column.PLACE].Width = 260;

            dgvIchiran.Columns[(int)column.PRICE].DefaultCellStyle.Format = "#,0";
            dgvIchiran.Columns[(int)column.MONTH_PRICE].DefaultCellStyle.Format = "#,0";
            dgvIchiran.Columns[(int)column.PRICE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIchiran.Columns[(int)column.MONTH_PRICE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn column in this.dgvIchiran.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }
            dgvIchiran.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;


        }

        /// <summary>
        /// クリア処理
        /// </summary>
        public void Clear()
        {
            dgvIchiran.Columns.Clear();
            flg = false;
            Initialization();
        }

        /// <summary>
        /// 年From変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYearFrom_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                SetMentor();
            }
        }

        /// <summary>
        /// 月From変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonthFrom_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                SetMentor();
            }
        }

        /// <summary>
        /// 年To変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYearTo_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                SetMentor();
            }
        }

        /// <summary>
        /// 月To変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonthTo_TextChanged(object sender, EventArgs e)
        {
            if (flg)
            {
                SetMentor();
            }
        }

        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                return;
            }
            Result();
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
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
