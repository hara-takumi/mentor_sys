using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MS0010 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DBUtli dbUtil = new DBUtli();
        private bool returnFlg = true;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MS0010()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS0010_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// セル押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //選択ボタンを押下時
            if (dgv.Columns[e.ColumnIndex].Name.Equals("SENTAKU"))
            {
                //メンターメンティ―登録画面に遷移
                ShowMH0040(e);
            }
        }

        /// <summary>
        /// ダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            //メンターメンティ―登録画面に遷移
            ShowMH0040(e);
        }

        /// <summary>
        /// メンターコンボ変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMentor_SelectedValueChanged(object sender, EventArgs e)
        {
            //メンティ―コンボを設定
            SetCboMentee();
        }

        /// <summary>
        /// 適用日開始日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            //メンターコンボを設定
            SetCboMentor();
        }

        /// <summary>
        /// 適用終了日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            //メンターコンボを設定
            SetCboMentor();
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            //ログインユーザー表示
            lblUser.Text = User.Name;

            //適用日に現在日を表示
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }

        /// <summary>
        /// メンターコンボボックス設定
        /// </summary>
        /// <returns></returns>
        private bool Mentor(ref DataSet ds)
        {
            //適用開始日・終了日
            string start = comU.GetDateTimePick(dtpStart.Value);
            string end = comU.GetDateTimePick(dtpEnd.Value);

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
            //適用日開始日が入力されている場合
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND TEKIYO_END_DATE >= {start}");
            }
            //適用日終了日が入力されている場合
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND TEKIYO_START_DATE <= {end}");
            }
            //適用日開始終了が入力されている場合
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                sql.Append($" AND  {start} <= {end}");
            }
            sql.Append(" GROUP BY MST_SHAIN_CODE ");
            sql.Append(" ORDER BY MST_SHAIN_CODE ");

            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_003);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// メンティ―コンボボックス設定
        /// </summary>
        /// <returns></returns>
        private bool Mentee(ref DataSet ds, bool initialFlg)
        {
            //適用開始日・終了日
            string start = comU.GetDateTimePick(dtpStart.Value);
            string end = comU.GetDateTimePick(dtpEnd.Value);

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTEE_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
            sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");
            //適用日開始日が入力されている場合
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND TEKIYO_END_DATE >= {start}");
            }
            //適用日終了日が入力されている場合
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND TEKIYO_START_DATE <= {end}");
            }
            //初期表示時以外
            if (initialFlg)
            {
                //メンターコンボがすべての場合
                if (!cboMentor.Text.Equals("すべて"))
                {
                    sql.Append($" AND MENTOR_ID = '{cboMentor.SelectedValue}'");
                }
            }
            //適用日開始終了が入力されている場合
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                sql.Append($" AND  {start} <= {end}");
            }
            sql.Append(" GROUP BY MST_SHAIN_CODE ");
            sql.Append(" ORDER BY MST_SHAIN_CODE ");

            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_004);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// メンティコンボにメンティをセット
        /// </summary>
        private void SetCboMentee()
        {
            DataSet dataSet = new DataSet();
            //メンテ―取得
            if (!Mentee(ref dataSet, true))
            {
                Close();
                return;
            }
            var selectedValue = cboMentee.SelectedValue;
            //メンティーコンボの先頭にすべてを設定
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            cboMentee.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentee.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            cboMentee.ValueMember = "MST_SHAIN_CODE";
            //メンティ―が選択されていない場合
            if (selectedValue == null)
            {
                cboMentee.SelectedValue = 0;
                return;
            }

            //コンボメンティ―と一致するデータを取得
            var list = dataSet.Tables[0].AsEnumerable().Where(SHAIN_CODE => SHAIN_CODE.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
            }
        }

        /// <summary>
        /// メンターコンボにメンターをセット
        /// </summary>
        private void SetCboMentor()
        {
            DataSet dataSet = new DataSet();
            //メンターを取得
            if (!Mentor(ref dataSet))
            {
                Close();
                return;
            }
            var selectedValue = cboMentor.SelectedValue;
            //メンターコンボの先頭にすべてを設定
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            cboMentor.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentor.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            cboMentor.ValueMember = "MST_SHAIN_CODE";
            //メンターが選択されていない場合
            if (selectedValue == null)
            {
                cboMentor.SelectedValue = 0;
                return;
            }

            //コンボメンターと一致するデータを取得
            var list = dataSet.Tables[0].AsEnumerable().Where(SHAIN_CODE => SHAIN_CODE.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentor.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
            }
        }

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            returnFlg = true;
            //適用開始日・終了日が選択されているか
            if (dtpStart.Value != null & dtpEnd.Value != null)
            {
                string yyyyMMfrom = ((DateTime)dtpStart.Value).ToString("yyyyMMdd");
                string yyyyMMto = ((DateTime)dtpEnd.Value).ToString("yyyyMMdd");
                //適用開始日が終了日よりも後の日付の場合
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show(MSG.MSG007_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    returnFlg = false;
                }
            }

            return returnFlg;
        }

        /// <summary>
        /// 検索結果表示
        /// </summary>
        private void Result()
        {
            dgvIchiran.Rows.Clear();
            string start = comU.GetDateTimePick(dtpStart.Value);
            string end = comU.GetDateTimePick(dtpEnd.Value);

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MENTOR_ID");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME AS MENTOR_NAME");
            sql.Append("     ,MENTEE_ID");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME AS MENTEE_NAME");
            sql.Append("     ,TEKIYO_START_DATE");
            sql.Append("     ,CASE TEKIYO_END_DATE WHEN '9999-12-31' THEN NULL ELSE TEKIYO_END_DATE END AS TEKIYO_END_DATE");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" INNER JOIN MST_SHAIN MENTOR");
            sql.Append("   ON MENTOR_ID = MENTOR.MST_SHAIN_CODE");
            sql.Append(" INNER JOIN MST_SHAIN MENTEE");
            sql.Append("   ON MENTEE_ID = MENTEE.MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1");
            //適用開始日が入力されている場合
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MENTOR.MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND MENTEE.MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND TEKIYO_END_DATE >= '{start}'");
            }
            //適用終了日が入力されている場合
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MENTOR.MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND MENTEE.MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND TEKIYO_START_DATE <= '{end}'");
            }
            //メンターコンボがすべて以外の場合
            if (cboMentor.SelectedIndex != 0)
            {
                sql.Append($"   AND MENTOR_ID = '{cboMentor.SelectedValue}'");
            }
            //メンティ―コンボがすべて以外の場合
            if (cboMentee.SelectedIndex != 0)
            {
                sql.Append($"   AND MENTEE_ID = '{cboMentee.SelectedValue}'");
                sql.Append(" ORDER BY TEKIYO_START_DATE DESC");
            }
            //すべての場合
            else
            {
                sql.Append(" ORDER BY MENTOR_ID,TEKIYO_START_DATE DESC");
            }

            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //エラーの場合
            if (ds == null)
            {
                return;
            }

            //検索結果が0件の場合
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("対象がありません");
            }

            //セルボタン作成
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.Name = "選択";
            dgvbtn.HeaderText = "";
            dgvbtn.Text = "選択";
            dgvbtn.UseColumnTextForButtonValue = true;
            dgvbtn.Width = 75;

            //取得データを一覧表示
            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(idx => ds.Tables[0].Rows[idx] as DataRow).ToList()
                .ForEach(dr =>
                {
                    dgvIchiran.Rows.Add();
                    int indx = dgvIchiran.Rows.Count - 1;
                    dgvIchiran.Rows[indx].Cells["SENTAKU"].Value = dgvbtn.Name;
                    dgvIchiran.Rows[indx].Cells["MENTOR_ID"].Value = dr["MENTOR_ID"].ToString();
                    dgvIchiran.Rows[indx].Cells["MENTOR_NAME"].Value = dr["MENTOR_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["MENTEE_ID"].Value = dr["MENTEE_ID"].ToString();
                    dgvIchiran.Rows[indx].Cells["MENTEE_NAME"].Value = dr["MENTEE_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["TEKIYO_START_DATE"].Value = Convert.ToDateTime(dr["TEKIYO_START_DATE"].ToString()).ToString("yyyy/MM/dd");
                    if (!dr["TEKIYO_END_DATE"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["TEKIYO_END_DATE"].Value = Convert.ToDateTime(dr["TEKIYO_END_DATE"].ToString()).ToString("yyyy/MM/dd");
                    }
                });

            //取得データを一覧表示
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dgvIchiran.Rows.Add();
            //    dgvIchiran.Rows[i].Cells[(int)Column.SENTAKU].Value = dgvbtn.Name;
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTOR_ID].Value = ds.Tables[0].Rows[i][(int)Column.MENTOR_ID - 1].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTOR_NAME].Value = ds.Tables[0].Rows[i][(int)Column.MENTOR_NAME - 1].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTEE_ID].Value = ds.Tables[0].Rows[i][(int)Column.MENTEE_ID - 1].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.MENTEE_NAME].Value = ds.Tables[0].Rows[i][(int)Column.MENTEE_NAME - 1].ToString();
            //    dgvIchiran.Rows[i].Cells[(int)Column.TEKIYO_START_DATE].Value = ((DateTime)ds.Tables[0].Rows[i][(int)Column.TEKIYO_START_DATE - 1]).ToString("yyyy/MM/dd");
            //    //適用終了日が空白以外の場合
            //    if(!ds.Tables[0].Rows[i][(int)Column.TEKIYO_END_DATE - 1].ToString().Equals(""))
            //    {
            //        dgvIchiran.Rows[i].Cells[(int)Column.TEKIYO_END_DATE].Value = ((DateTime)ds.Tables[0].Rows[i][(int)Column.TEKIYO_END_DATE - 1]).ToString("yyyy/MM/dd");
            //    }
            //}
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        private void Clear()
        {
            dgvIchiran.Rows.Clear();
            //適用日開始日・終了日を現在日に設定
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            //メンターコンボの表示をすべてに設定
            cboMentor.SelectedIndex = 0;
            //メンティ―コンボの表示をすべてに設定
            cboMentee.SelectedIndex = 0;
        }

        /// <summary>
        /// メンターメンティ―登録画面に遷移
        /// </summary>
        /// <param name="e"></param>
        private void ShowMH0040(DataGridViewCellEventArgs e)
        {
            String mentorId = dgvIchiran["MENTOR_ID", e.RowIndex].Value.ToString();
            String mentorNm = dgvIchiran["MENTOR_NAME", e.RowIndex].Value.ToString();
            String menteeId = dgvIchiran["MENTEE_ID", e.RowIndex].Value.ToString();
            String menteeNm = dgvIchiran["MENTEE_NAME", e.RowIndex].Value.ToString();
            string startDate = dgvIchiran["TEKIYO_START_DATE", e.RowIndex].Value.ToString();
            //適用終了日が入力されている場合
            string endDate = dgvIchiran["TEKIYO_END_DATE", e.RowIndex].Value != null 
                ? dgvIchiran["TEKIYO_END_DATE", e.RowIndex].Value.ToString() : "";
            MS0020 ms0020 = new MS0020(mentorId, mentorNm, menteeId, menteeNm, startDate, endDate);
            //メンターメンティ―入力画面に遷移
            ShowDialog(ms0020);
            //メンターメンティ―が登録された場合
            if (ms0020.TorokuFlg)
            {
                //一覧を再検索
                Result();
            }
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 新規登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //メンターメンティ―登録画面に遷移
            MS0020 ms0020 = new MS0020();
            ShowDialog(ms0020);
            //登録された場合
            if (ms0020.TorokuFlg)
            {
                //一覧を再検索
                Result();
            }
        }

        /// <summary>
        /// 表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!Check())
            {
                return;
            }
            //検索結果を表示
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
