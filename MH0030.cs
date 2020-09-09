using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0030 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DBUtli dbUtil = new DBUtli();
        List<string> resultIdList = new List<string>();
        private bool initialFlg = false;
        private bool returnFlg = true;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MH0030()
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
        private void MH0020_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// メンターコンボ変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMentor_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            if (initialFlg)
            {
                //メンターに紐づくメンティ―をコンボボックスに設定
                SetMentee();
            }
        }

        /// <summary>
        /// セル押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //選択ボタン押下
            if (dgv.Columns[e.ColumnIndex].Name.Equals("SENTAKU"))
            {
                //メンター活動実績入力画面に遷移
                ShowMH0040(e);
            }
        }

        /// <summary>
        /// ダブルクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            //メンター活動実績入力画面に遷移
            ShowMH0040(e);
        }

        /// <summary>
        /// 実施開始日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            //実施開始日とメンターに紐づくメンティ―をコンボボックスに設定
            SetMentee();
        }

        /// <summary>
        /// 実施終了日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            //実施終了日とメンターに紐づくメンティ―をコンボボックスに設定
            SetMentee();
        }

        /// <summary>
        /// 実施開始日変更時の処理(推進部の場合)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartSuisnb_ValueChanged(object sender, EventArgs e)
        {
            //実施開始日に紐づくメンターとメンティ―をコンボボックスに設定
            SetMentor();
            SetMentee();
        }

        /// <summary>
        /// 実施終了日変更時の処理(推進部の場合)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndSuisnb_ValueChanged(object sender, EventArgs e)
        {
            //実施終了日に紐づくメンターとメンティ―をコンボボックスに設定
            SetMentor();
            SetMentee();
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

            //メンターの場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                //メンター用の検索条件を表示
                pnlMentor.Visible = true;
                pnlSuisinb.Visible = false;
                //一覧のメンターとメンティ―名を非表示
                dgvIchiran.Columns["MENTOR_NAME"].Visible = false;
                dgvIchiran.Columns["MENTEE_NAME"].Visible = false;

                //メンティ―コンボにデータをセット
                SetMentee();
            }
            //推進チームの場合
            else
            {
                //推進チーム用検索条件を表示
                pnlSuisinb.Visible = true;
                pnlMentor.Visible = false;
                //新規登録ボタンを非表示
                btnInsert.Visible = false;
                //メンターコンボにデータをセット
                SetMentor();
                //メンティ―コンボにデータをセット
                SetMentee();
            }
            //初期表示フラグ
            initialFlg = true;
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
            var cboSelectMentor = cboMentor.SelectedValue;
            DataRow row = dataSet.Tables[0].NewRow();
            row["MST_SHAIN_CODE"] = "0";
            row["MST_SHAIN_NAME"] = "すべて";
            dataSet.Tables[0].Rows.InsertAt(row, 0);
            // コンボボックスにデータテーブルをセット
            cboMentor.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentor.DisplayMember = "MST_SHAIN_NAME";
            // データ用の列を設定
            cboMentor.ValueMember = "MST_SHAIN_CODE";
            //メンターコンボが空白の場合
            if (cboSelectMentor == null)
            {
                cboMentor.SelectedIndex = 0;
                return;
            }
            //メンターコンボで選択されているメンターが取得結果に含まれている場合
            var shainList = dataSet.Tables[0].AsEnumerable().Where(shainData => shainData.Field<string>("MST_SHAIN_CODE").Equals(cboSelectMentor)).FirstOrDefault();
            if (shainList != null)
            {
                //メンターコンボで選択したメンターが表示
                cboMentor.SelectedValue = shainList.Field<string>("MST_SHAIN_CODE");
            }
        }

        /// <summary>
        /// コンボボックスセット(メンティ―)
        /// </summary>
        private void SetMentee()
        {
            DataSet dataSet = new DataSet();
            //メンティ―を取得
            if (!Mentee(ref dataSet))
            {
                Close();
                return;
            }
            //メンターの場合
            if(Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                var cboSelectedMentee = cboMentee.SelectedValue;
                string initSelected = null;
                //メンティ―コンボが空白の場合
                if (cboSelectedMentee == null)
                {
                    initSelected = dataSet.Tables[0].AsEnumerable()
                            .Where(shainData => shainData.Field<DateTime>("TEKIYO_START_DATE") <= DateTime.Now.Date && shainData.Field<DateTime>("TEKIYO_END_DATE") > DateTime.Now.Date)
                            .Select(shainData => shainData.Field<string>("MST_SHAIN_CODE")).FirstOrDefault().ToString();
                }
                // 検索結果が0件以上の場合
                if (dataSet.Tables[0].Rows.Count != 0)
                {
                    cboMentee.DataSource = dataSet.Tables[0].AsEnumerable().GroupBy(shainData => shainData.Field<string>("MST_SHAIN_CODE")).Select(shainData => shainData.First()).CopyToDataTable();
                }
                else
                {
                    cboMentee.DataSource = null;
                }
                // 表示用の列を設定
                cboMentee.DisplayMember = "MST_SHAIN_NAME";
                //// データ用の列を設定
                cboMentee.ValueMember = "MST_SHAIN_CODE";
                //メンティ―コンボが空白以外の場合
                if (initSelected != null)
                {
                    cboMentee.SelectedValue = initSelected;
                }
                //メンティ―コンボが0件以上の場合
                else if (cboMentee.Items.Count != 0)
                {
                    //メンティ―コンボにすべてを表示
                    cboMentee.SelectedIndex = 0;
                }
                //メンティ―コンボが空白以外の場合
                if (cboSelectedMentee != null)
                {
                    var shainList = dataSet.Tables[0].AsEnumerable().Where(shainData => shainData.Field<string>("MST_SHAIN_CODE").Equals(cboSelectedMentee)).FirstOrDefault();
                    if (shainList != null)
                    {
                        cboMentee.SelectedValue = shainList.Field<string>("MST_SHAIN_CODE");
                    }
                }
            }
            //推進部の場合
            else
            {
                var cboSelectedValueSuisinb = cboMenteeSuisinb.SelectedValue;
                string initSelected = null;
                DataRow dr = dataSet.Tables[0].NewRow();
                dr["MST_SHAIN_CODE"] = "0";
                dr["MST_SHAIN_NAME"] = "すべて";
                dataSet.Tables[0].Rows.InsertAt(dr, 0);
                // 検索結果が0件以上の場合
                if (dataSet.Tables[0].Rows.Count != 0)
                {
                    cboMenteeSuisinb.DataSource = dataSet.Tables[0].AsEnumerable().GroupBy(shainData => shainData.Field<string>("MST_SHAIN_CODE")).Select(shainData => shainData.First()).CopyToDataTable();
                }
                else
                {
                    cboMenteeSuisinb.DataSource = null;
                }
                // 表示用の列を設定
                cboMenteeSuisinb.DisplayMember = "MST_SHAIN_NAME";
                //// データ用の列を設定
                cboMenteeSuisinb.ValueMember = "MST_SHAIN_CODE";
                //メンティ―コンボが空白以外の場合
                if (initSelected != null)
                {
                    cboMenteeSuisinb.SelectedValue = initSelected;
                }
                //メンティ―コンボが0件以上の場合
                else if (cboMenteeSuisinb.Items.Count != 0)
                {
                    cboMenteeSuisinb.SelectedIndex = 0;
                }
                //メンティ―コンボが空白以外の場合
                if (cboSelectedValueSuisinb != null)
                {
                    var shainList = dataSet.Tables[0].AsEnumerable().Where(shainData => shainData.Field<string>("MST_SHAIN_CODE").Equals(cboSelectedValueSuisinb)).FirstOrDefault();
                    if (shainList != null)
                    {
                        cboMenteeSuisinb.SelectedValue = shainList.Field<string>("MST_SHAIN_CODE");
                    }
                }
            }
        }

        /// <summary>
        /// メンター取得
        /// </summary>
        /// <returns></returns>
        private bool Mentor(ref DataSet ds)
        {
            string start;
            string end;

            //メンターの場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                start = comU.GetDateTimePick(dtpStart.Value);
                end = comU.GetDateTimePick(dtpEnd.Value);
            }
            //推進部の場合
            else
            {
                start = comU.GetDateTimePick(dtpStartSuisnb.Value);
                end = comU.GetDateTimePick(dtpEndSuisnb.Value);
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append(" WHERE 1=1 ");
            //実施開始日が入力されている場合
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND TEKIYO_END_DATE >= {start}");
            }
            //実施終了日が入力されている場合
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND TEKIYO_START_DATE <= {end}");
            }
            //実施日が入力されている場合
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                sql.Append($" AND  {start} <= {end}");
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
        /// メンティ―取得
        /// </summary>
        /// <returns></returns>
        private bool Mentee(ref DataSet ds)
        {
            string start;
            string end;

            //メンターの場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                start = comU.GetDateTimePick(dtpStart.Value);
                end = comU.GetDateTimePick(dtpEnd.Value);
            }
            //推進部の場合
            else
            {
                start = comU.GetDateTimePick(dtpStartSuisnb.Value);
                end = comU.GetDateTimePick(dtpEndSuisnb.Value);
            }

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
            //開始日が空欄以外の場合
            if (!string.IsNullOrEmpty(start))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= {start}");
                sql.Append($" AND TEKIYO_END_DATE >= {start}");
            }
            //終了日が空欄以外の場合
            if (!string.IsNullOrEmpty(end))
            {
                sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= {end}");
                sql.Append($" AND TEKIYO_START_DATE <= {end}");
            }
            //メンターの場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                sql.Append($" AND MENTOR_ID = '{User.Id}'");
            }
            //コンボメンターがすべて以外の場合
            if (cboMentor.SelectedIndex > 0)
            {
                sql.Append($" AND MENTOR_ID = '{cboMentor.SelectedValue}'");
            }
            //開始日・終了日が空欄以外の場合
            if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end))
            {
                sql.Append($" AND  {start} <= {end}");
            }

            sql.Append(" ORDER BY MST_SHAIN_CODE ");

            //SQL処理
            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_004);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 登録入力チェック
        /// </summary>
        /// <returns></returns>
        private bool InputCheckEntry()
        {
            //メンターの場合
            if(Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                //実施開始日・終了日が入力されている場合
                if (dtpStart.Value != null & dtpEnd.Value != null)
                {
                    string yyyyMMfrom = ((DateTime)dtpStart.Value).ToString("yyyyMMdd");
                    string yyyyMMto = ((DateTime)dtpEnd.Value).ToString("yyyyMMdd");
                    //実施日の逆転チェック
                    if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                    {
                        MessageBox.Show(MSG.MSG007_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                //メンターコンボが空白の場合
                if (cboMentee.SelectedValue.Equals(""))
                {
                    MessageBox.Show(MSG.MSG004_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //推進部の場合
            else
            {
                //実施開始日・終了日が入力されている場合
                if (dtpStartSuisnb.Value != null & dtpEndSuisnb.Value != null)
                {
                    string yyyyMMfrom = ((DateTime)dtpStartSuisnb.Value).ToString("yyyyMMdd");
                    string yyyyMMto = ((DateTime)dtpEndSuisnb.Value).ToString("yyyyMMdd");
                    //実施日の逆転チェック
                    if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                    {
                        MessageBox.Show(MSG.MSG007_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                //メンターコンボが空白の場合
                if (cboMenteeSuisinb.SelectedValue.Equals(""))
                {
                    MessageBox.Show(MSG.MSG004_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string start;
            string end;

            //メンターの場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                start = comU.GetDateTimePick(dtpStart.Value);
                end = comU.GetDateTimePick(dtpEnd.Value);
            }
            //推進部の場合
            else
            {
                start = comU.GetDateTimePick(dtpStartSuisnb.Value);
                end = comU.GetDateTimePick(dtpEndSuisnb.Value);
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      TRN_MENTOR_RESULT.MENTOR_RESULT_ID");
            sql.Append("     ,EXEC_DATE ");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME AS MENTOR_NAME");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME AS MENTEE_NAME");
            sql.Append("     ,CASE STATUS WHEN 0 THEN '未報告'  WHEN 1 THEN '報告済み' ELSE '差し戻し' END AS STATUS");
            sql.Append("     ,REPORT_DT");
            sql.Append("     ,CASE MIN(CORRECT_FLG) WHEN 0 THEN 'あり' ELSE '-' END AS CORRECT_FLG");
            sql.Append("     ,MAX(CORRECT_DT) AS CORRECT_DT");
            sql.Append("   FROM TRN_MENTOR_RESULT ");
            sql.Append("   LEFT JOIN TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append("     ON TRN_MENTOR_RESULT.MENTOR_RESULT_ID = TRN_MENTOR_RESULT_PROMOTE.MENTOR_RESULT_ID ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTOR ");
            sql.Append("     ON MENTOR_ID = MENTOR.MST_SHAIN_CODE ");
            sql.Append("   LEFT JOIN MST_SHAIN MENTEE ");
            sql.Append("     ON MENTEE_ID = MENTEE.MST_SHAIN_CODE ");
            sql.Append(" WHERE 1=1");
            //メンター推進チームの場合
            if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
            {
                //適用開始日空以外
                if (dtpStartSuisnb.Value != null)
                {
                    sql.Append($"   AND EXEC_DATE >= {start}");
                }
                //適用終了日空以外
                if (dtpEndSuisnb.Value != null)
                {
                    sql.Append($"   AND EXEC_DATE <= {end}");
                }
                sql.Append("   AND STATUS != 0 ");
                //メンターコンボがすべて以外
                if (!cboMentor.SelectedValue.Equals("0"))
                {
                    sql.Append($"   AND MENTOR.MST_SHAIN_CODE = '{cboMentor.SelectedValue}'");
                }
                //メンティ―コンボがすべて以外
                if (!cboMenteeSuisinb.SelectedValue.Equals("0"))
                {
                    sql.Append($"   AND MENTEE.MST_SHAIN_CODE = '{cboMenteeSuisinb.SelectedValue}'");
                }
            }
            //メンターの場合
            else
            {
                //適用開始日空以外
                if (dtpStart.Value != null)
                {
                    sql.Append($"   AND EXEC_DATE >= {start}");
                }
                //適用終了日空以外
                if (dtpEnd.Value != null)
                {
                    sql.Append($"   AND EXEC_DATE <= {end}");
                }
                //メンティ―コンボがすべて以外
                if (!cboMentee.SelectedValue.Equals("0"))
                {
                    sql.Append($"   AND MENTEE.MST_SHAIN_CODE = '{cboMentee.SelectedValue}'");
                }
            }
            
            sql.Append(" GROUP BY TRN_MENTOR_RESULT.MENTOR_RESULT_ID ");
            
            //メンター用の場合
            if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
            {
                //コメント未確認にチェックが入っている場合
                if (chkCorrect.Checked)
                {
                    sql.Append(" HAVING MIN(CORRECT_FLG) = 0 ");
                }
                sql.Append(" ORDER BY EXEC_DATE DESC");
            }
            //推進部の場合
            else
            {
                //コメント未確認にチェックが入っている場合
                if (chkCorrectSuisnb.Checked)
                {
                    sql.Append(" HAVING MIN(CORRECT_FLG) = 0 ");
                }
                sql.Append(" ORDER BY REPORT_DT DESC");
            }

            DataSet ds = new DataSet();

            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //エラーの場合
            if (ds == null) return;

            //検索結果が0件の場合
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(MSG.MSG007_002);
            }

            //セルボタン作成
            DataGridViewButtonColumn dgvbtn = new DataGridViewButtonColumn();
            dgvbtn.Name = "選択";
            dgvbtn.HeaderText = "";
            dgvbtn.Text = "選択";
            dgvbtn.UseColumnTextForButtonValue = true;
            dgvbtn.Width = 75;

            //一覧に検索結果を表示
            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(idx => ds.Tables[0].Rows[idx] as DataRow).ToList()
                .ForEach(dr =>
                {
                    dgvIchiran.Rows.Add();
                    int indx = dgvIchiran.Rows.Count -1;
                    dgvIchiran.Rows[indx].Cells["SENTAKU"].Value = dgvbtn.Name;
                    dgvIchiran.Rows[indx].Cells["MENTOR_RESULT_ID"].Value = dr["MENTOR_RESULT_ID"].ToString();
                    dgvIchiran.Rows[indx].Cells["EXEC_DATE"].Value = Convert.ToDateTime(dr["EXEC_DATE"].ToString()).ToString("yyyy/MM/dd");
                    dgvIchiran.Rows[indx].Cells["MENTOR_NAME"].Value = dr["MENTOR_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["MENTEE_NAME"].Value = dr["MENTEE_NAME"].ToString();
                    dgvIchiran.Rows[indx].Cells["STATUS"].Value = dr["STATUS"].ToString();
                    //報告日が空白以外の場合
                    if (!dr["REPORT_DT"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["REPORT_DT"].Value = Convert.ToDateTime(dr["REPORT_DT"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                    dgvIchiran.Rows[indx].Cells["CORRECT_FLG"].Value = dr["CORRECT_FLG"].ToString();
                    //最終確認日時が空白以外の場合
                    if (!dr["CORRECT_DT"].ToString().Equals(""))
                    {
                        dgvIchiran.Rows[indx].Cells["CORRECT_DT"].Value = Convert.ToDateTime(dr["CORRECT_DT"].ToString()).ToString("yyyy/MM/dd HH:mm");
                    }
                });

            //メンター実績IDのリストを取得
            resultIdList = ds.Tables[0].AsEnumerable().Select(MENTOR_RESULT_ID => MENTOR_RESULT_ID.Field<decimal>("MENTOR_RESULT_ID").ToString()).ToList();
        }

        /// <summary>
        /// メンター活動実績入力画面に遷移
        /// </summary>
        /// <param name="e"></param>
        private void ShowMH0040(DataGridViewCellEventArgs e)
        {
            String mentorResultId = dgvIchiran["MENTOR_RESULT_ID", e.RowIndex].Value.ToString();
            //メンター活動実績入力画面に遷移
            MH0040 mh0040 = new MH0040(resultIdList, mentorResultId);
            ShowDialog(mh0040);
            //メンター報告が行われた場合
            if (mh0040.TorokuFlg)
            {
                //一覧を再検索
                Result();
            }
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
            resultIdList.Clear();
            //入力チェック
            if (!InputCheckEntry()) return;
            //検索結果を表示
            Result();
        }

        /// <summary>
        /// 新規登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //メンター活動実績入力画面に遷移
            MH0040 mh0040 = new MH0040(resultIdList);
            ShowDialog(mh0040);
            //メンター報告が行われた場合
            if (mh0040.TorokuFlg)
            {
                //一覧を再検索
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
            Close();
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            //検索条件と一覧を初期化
            dgvIchiran.Rows.Clear();
            resultIdList.Clear();
            dtpStart.Value = null;
            dtpEnd.Value = null;
            dtpStartSuisnb.Value = null;
            dtpEndSuisnb.Value = null;
            chkCorrect.Checked = false;
            chkCorrectSuisnb.Checked = false;

            //推進部の場合
            if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
            {
                cboMentor.SelectedIndex = 0;
                cboMenteeSuisinb.SelectedIndex = 0;
            }
            //メンターの場合
            else
            {
                cboMentee.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
