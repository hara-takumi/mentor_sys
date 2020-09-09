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
    public partial class MH0050 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DBUtli dbUtil = new DBUtli();
        private readonly DateTime dt = DateTime.Now;
        private bool initialFlg = false;
        private bool returnFlg = true;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MH0050()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント処理
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MH0050_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// 年From変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYearFrom_TextChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            if (initialFlg)
            {
                //コンボボックスにメンターを設定
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
            //初期表示時は通らない
            if (initialFlg)
            {
                //コンボボックスにメンターを設定
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
            //初期表示時は通らない
            if (initialFlg)
            {
                //コンボボックスにメンターを設定
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
            //初期表示時は通らない
            if (initialFlg)
            {
                //コンボボックスにメンターを設定
                SetMentor();
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            //ユーザー名表示
            lblUser.Text = User.Name;

            //コンボボックス設定(年月)
            cboYearFrom.DataSource = comU.CYear(true).ToArray();
            cboYearFrom.Text = dt.ToString("yyyy");
            cboMonthFrom.DataSource = comU.CMonth(true).ToArray();
            cboMonthFrom.Text = dt.ToString("MM");
            cboYearTo.DataSource = comU.CYear(true).ToArray();
            cboYearTo.Text = dt.ToString("yyyy");
            cboMonthTo.DataSource = comU.CMonth(true).ToArray();
            cboMonthTo.Text = dt.ToString("MM");

            //コンボボックスにメンターを設定
            SetMentor();
        }

        /// <summary>
        /// コンボボックスセット(メンタ―)
        /// </summary>
        private void SetMentor()
        {
            DataSet dataSet = new DataSet();
            //メンターを取得
            if (!Mentor(ref dataSet))
            {
                Close();
                return;
            }
            //コンボで選択したメンター
            var cboSelectMentor = cboMentor.SelectedValue;
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            //コンボボックス先頭に"すべて"を設定
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            cboMentor.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentor.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            cboMentor.ValueMember = "MST_SHAIN_CODE";

            //初期表示時は通らない
            if (initialFlg)
            {
                var shainList = dataSet.Tables[0].AsEnumerable().Where(shainData => shainData.Field<string>("MST_SHAIN_CODE").Equals(cboSelectMentor)).FirstOrDefault();
                if (shainList != null)
                {
                    cboMentor.SelectedValue = shainList.Field<string>("MST_SHAIN_CODE");
                }
            }
            //初期表示フラグ
            initialFlg = true;
        }

        /// <summary>
        /// メンターコンボボックス設定
        /// </summary>
        /// <returns></returns>
        private bool Mentor(ref DataSet ds)
        {
            //適用開始日・終了日
            string yyyyMMfrom = cboYearFrom.SelectedValue.ToString() + cboMonthFrom.SelectedValue.ToString();
            string yyyyMMto = cboYearTo.SelectedValue.ToString() + cboMonthTo.SelectedValue.ToString();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1 ");
            //画面.年From、画面.月Fromの両方が入力されている場合
            if (!cboYearFrom.SelectedValue.Equals("") & !cboMonthFrom.SelectedValue.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(MST_SHAIN_TEKIYO_DATE_END, '%Y%m')  >= {yyyyMMfrom}");
                sql.Append($" AND DATE_FORMAT(TEKIYO_END_DATE, '%Y%m') >= {yyyyMMfrom}");
            }
            //画面.年To、画面.月Toの両方が入力されている場合
            if (!cboYearTo.SelectedValue.Equals("") & !cboMonthTo.SelectedValue.Equals(""))
            {
                sql.Append($" AND DATE_FORMAT(MST_SHAIN_TEKIYO_DATE_STR, '%Y%m') <= {yyyyMMto}");
                sql.Append($" AND DATE_FORMAT(TEKIYO_START_DATE, '%Y%m') <= {yyyyMMto}");
            }

            sql.Append(" GROUP BY MST_SHAIN_CODE ");
            sql.Append(" ORDER BY MST_SHAIN_CODE ");

            //SQL処理
            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_003);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInsert()
        {
            //開始年が選択され、開始月が空白の場合
            if (!cboYearFrom.SelectedValue.Equals("") & cboMonthFrom.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG007_004, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMonthFrom;
                return false;
            }
            //開始年が空白で、開始月が選択されている場合
            if (cboYearFrom.SelectedValue.Equals("") & !cboMonthFrom.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG007_005, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboYearFrom;
                return false;
            }
            //終了年が選択され、終了月が空白の場合
            if (!cboYearTo.SelectedValue.Equals("") & cboMonthTo.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG007_004, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMonthTo;
                return false;
            }
            //終了年が空白で、終了月が選択されている場合
            if (cboYearTo.SelectedValue.Equals("") & !cboMonthTo.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG007_005, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboYearTo;
                return false;
            }

            //日付逆転チェック
            string yyyyMMfrom = cboYearFrom.SelectedValue.ToString() + cboMonthFrom.SelectedValue.ToString();
            string yyyyMMto = cboYearTo.SelectedValue.ToString() + cboMonthTo.SelectedValue.ToString();
            //開始日と終了日が入力されている場合
            if (!yyyyMMfrom.Equals("") && !yyyyMMto.Equals(""))
            {
                //終了日が開始日より前の日付の場合
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show(MSG.MSG007_006, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = cboYearFrom;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 検索結果表示
        /// </summary>
        private void Result()
        {
            dgvIchiran.Rows.Clear();

            string yyyyMMfrom = cboYearFrom.SelectedValue.ToString() + cboMonthFrom.SelectedValue.ToString();
            string yyyyMMto = cboYearTo.SelectedValue.ToString() + cboMonthTo.SelectedValue.ToString();

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     TRN_MENTOR_RESULT.EXEC_DATE");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME AS MENTOR_NAME");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME AS MENTEE_NAME");
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
            if (!string.IsNullOrEmpty(yyyyMMfrom))
            {
                sql.Append($" AND DATE_FORMAT(TRN_MENTOR_RESULT.EXEC_DATE, '%Y%m') >= {yyyyMMfrom}");
            }
            //画面.年月Toが入力されている場合
            if (!string.IsNullOrEmpty(yyyyMMto))
            {
                sql.Append($" AND DATE_FORMAT(TRN_MENTOR_RESULT.EXEC_DATE, '%Y%m') <= {yyyyMMto}");
            }
            //画面.メンターコンボボックスで"すべて"以外を選択した場合
            if (cboMentor.SelectedIndex != 0)
            {
                sql.Append($"   AND TRN_MENTOR_RESULT.MENTOR_ID = '{cboMentor.SelectedValue}'");
            }
            sql.Append(" ORDER BY EXEC_DATE DESC");

            //SQL処理
            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //実行エラー時
            if (ds == null)
            {
                return;
            }

            //検索結果が0件の場合
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(MSG.MSG007_002);
            }

            //取得データを一覧表示
            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(idx => ds.Tables[0].Rows[idx] as DataRow).ToList()
                .ForEach(dr => {
                    dgvIchiran.Rows.Add();
                    int indx = dgvIchiran.Rows.Count - 1;
                    dgvIchiran.Rows[indx].Cells["EXEC_DATE"].Value = Convert.ToDateTime(dr["EXEC_DATE"].ToString()).ToString("yyyy/MM/dd");
                    dgvIchiran.Rows[indx].Cells["MENTOR_NAME"].Value = dr["MENTOR_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["MENTEE_NAME"].Value = dr["MENTEE_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["PRICE"].Value = dr["PRICE"].ToString();
                    dgvIchiran.Rows[indx].Cells["MONTH_PRICE"].Value = dr["MONTH_PRICE"].ToString();
                    dgvIchiran.Rows[indx].Cells["PLACE"].Value = dr["PLACE"].ToString();
                });


            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dgvIchiran.Rows.Add();
            //    dgvIchiran.Rows[i].Cells[(int)Column.EXEC_DATE].Value = ((DateTime) ds.Tables[0].Rows[i][(int)Column.EXEC_DATE]).ToString("yyyy/MM/dd");
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTOR_NAME].Value = ds.Tables[0].Rows[i][(int)Column.MENTOR_NAME].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTEE_NAME].Value = ds.Tables[0].Rows[i][(int)Column.MENTEE_NAME].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.PRICE].Value = ds.Tables[0].Rows[i][(int)Column.PRICE].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.MONTH_PRICE].Value = ds.Tables[0].Rows[i][(int)Column.MONTH_PRICE].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.PLACE].Value = ds.Tables[0].Rows[i][(int)Column.PLACE].ToString();
            //}
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        private void Clear()
        {
            dgvIchiran.Rows.Clear();
            initialFlg = false;
            //初期化処理
            Initialization();
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!CheckInsert())
            {
                return;
            }
            //検索結果表示
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
            Close();
        }
        #endregion
    }
}
