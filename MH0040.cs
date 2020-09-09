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
    public partial class MH0040 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        private readonly DBUtli dbUtil = new DBUtli();
        private readonly Logger log = new Logger();
        private readonly string programId = "MH0040";
        private bool torokuFlg = false;
        private bool initialFlg = false;
        private bool changeFlg = false;
        private bool returnFlg = true;
        private bool shokaiMode = false;
        private readonly List<String> delList = new List<string>();
        private readonly List<string> _resultIdList;
        private readonly string _mentorResultId;
        DataSet dsComent = new DataSet();
        #endregion

        #region プロパティ
        /// <summary>
        /// 再検索用
        /// </summary>
        public bool TorokuFlg { get => torokuFlg; set => torokuFlg = value; }
        #endregion

        #region コンストラクタ
        //MH0030から遷移時のコンストラクタ
        public MH0040(List<string> list)
        {
            _resultIdList = list;
            _mentorResultId = "";
            InitializeComponent();
        }

        /// <summary>
        /// 矢印ボタン押下時のコンストラクタ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mentorResultId"></param>
        public MH0040(List<string> list, string mentorResultId)
        {
            _resultIdList = list;
            _mentorResultId = mentorResultId;
            InitializeComponent();
        }
        #endregion

        #region イベント処理
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form4_Load(object sender, EventArgs e)
        {
            Initialization();
        }

        /// <summary>
        /// メンティ―コンボ変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMentee_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施開始時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStartH_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施開始時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStartM_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施終了時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEndH_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施終了時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEndM_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施予定開始時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlanStartH_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施予定開始時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlanStartM_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施予定終了時間変更処理(時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlanEndH_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施予定終了時間変更処理(分)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPlanEndM_SelectedValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施場所変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 経費変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            if (initialFlg)
            {
                int selection = txtPrice.SelectionStart;
                int changeBeforelength = txtPrice.Text.Length;
                changeFlg = true;
                //経費が空白以外の場合
                if (!string.IsNullOrEmpty(txtPrice.Text))
                {
                    //数値以外入力不可
                    if (!comU.IsNumeric(txtPrice.Text.Replace(",", "")))
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
                    //変更前の経費より変更後の経費の桁が大きい場合
                    if (changeBeforelength < txtPrice.Text.Length)
                    {
                        selection += 1;
                    }
                    //変更前の経費より変更後の経費の桁が小さい場合
                    else if (changeBeforelength > txtPrice.Text.Length)
                    {
                        //桁数が0より大きい場合
                        selection = selection > 0 ? selection -= 1 : selection;
                    }
                }

                txtPrice.Select(selection, 0);
                return;
            }
        }

        /// <summary>
        /// 報告変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReport_TextChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// セルクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIchiran_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //初期表示時は通らない
            if (initialFlg)
            {
                //未報告以外の場合
                if (dgvIchiran["STETUS", e.RowIndex].Value.ToString() != CommonConstants.Status.MIHOUKOKU)
                {
                    //コメント・チェックボックスが変更されていない場合
                    if (dgvIchiran["CONTENT", e.RowIndex].Value.ToString().Equals(dgvIchiran["CONTENT_OLD", e.RowIndex].Value.ToString()) &&
                        dgvIchiran["CORRECT_FLG", e.RowIndex].Value.ToString().Equals(dgvIchiran["CORRECT_FLG_OLD", e.RowIndex].Value.ToString()))
                    {
                        dgvIchiran["STETUS", e.RowIndex].Value = "0";
                    }
                    else
                    {
                        dgvIchiran["STETUS", e.RowIndex].Value = CommonConstants.Status.HOUKOKUZUMI;
                        //推進部の場合
                        if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
                        {
                            dgvIchiran["CORRECT_FLG", e.RowIndex].Value = false;
                        }
                        changeFlg = true;
                    }
                }
            }
        }

        /// <summary>
        /// 数字のみ入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && (Control.ModifierKeys & Keys.Control) != Keys.Control)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 実施予定日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDatePlan_ValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            changeFlg = initialFlg ? true : false;
        }

        /// <summary>
        /// 実施日変更時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpExecDate_ValueChanged(object sender, EventArgs e)
        {
            //初期表示時は通らない
            if (initialFlg)
            {
                changeFlg = true;
                //コンボボックスをセット
                SetCbo();
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// コンボセット
        /// </summary>
        private void SetCbo()
        {
            //実施時間を設定
            cboStartH.DataSource = comU.CHour().ToArray();
            cboEndH.DataSource = comU.CHour().ToArray();
            cboStartM.DataSource = comU.CMinute().ToArray();
            cboEndM.DataSource = comU.CMinute().ToArray();
            //実施予定時間を設定
            cboPlanStartH.DataSource = comU.CHour().ToArray();
            cboPlanEndH.DataSource = comU.CHour().ToArray();
            cboPlanStartM.DataSource = comU.CMinute().ToArray();
            cboPlanEndM.DataSource = comU.CMinute().ToArray();
            //メンターに紐づくメンティ―を設定
            SetMentee();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            //ログインユーザー表示
            lblUser.Text = User.Name;

            //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
            if (string.IsNullOrEmpty(_mentorResultId))
            {
                //実施日を現在日表示
                //選択可能な最大実施日を現在日時に設定
                dtpExecDate.Value = DateTime.Now;
                dtpExecDate.MaxDate = DateTime.Now;
                //コンボボックス設定
                SetCbo();

                //コントロール設定
                btnUp.Enabled = false;
                pnlPromote.Visible = false;
                lblMenta.Visible = false;
                lblMentor.Visible = false;
                btnRowInsert.Visible = false;
                btnRowDelete.Visible = false;
                btnToroku.Visible = false;
                btnRemand.Visible = false;
                btnDelete.Visible = false;

                //実施時間・予定時間コンボの初期表示を空白に設定
                cboStartH.SelectedIndex = 0;
                cboStartM.SelectedIndex = 0;
                cboEndH.SelectedIndex = 0;
                cboEndM.SelectedIndex = 0;
                cboPlanStartH.SelectedIndex = 0;
                cboPlanStartM.SelectedIndex = 0;
                cboPlanEndH.SelectedIndex = 0;
                cboPlanEndM.SelectedIndex = 0;
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
                if (!GetComent()) return;

                DataSet ds = new DataSet();
                //メンター実績取得
                GetResult(ref ds);
                DataRow dr = ds.Tables[0].AsEnumerable().First();

                string status = dr["STATUS"].ToString();

                //推進チーム用の場合
                if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
                {
                    //一時保存・削除ボタンを非表示
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    //報告済みデータを表示
                    DispReported(dr);
                    //最終行の場合"→"非活性
                    if (_mentorResultId.Equals(_resultIdList.Last()))
                    {
                        btnUp.Enabled = false;
                    }
                    //差戻の場合、差戻ボタン非表示
                    if (status.Equals(CommonConstants.Status.SASIMODOSI))
                    {
                        btnRemand.Visible = false;
                    }
                    lblComment.Visible = false;
                    lblTitle.Text = "メンター活動実績確認";
                }
                //メンター用の場合
                else
                {
                    //未報告の場合
                    if (status.Equals(CommonConstants.Status.MIHOUKOKU))
                    {
                        //初期値を表示
                        DispNotReported(dr);
                    }
                    //差し戻しの場合
                    else if (status.Equals(CommonConstants.Status.SASIMODOSI))
                    {
                        //差し戻しデータを表示
                        DispNotReported(dr);
                        btnSave.Visible = false;
                    }
                    //報告済みの場合
                    else
                    {
                        //報告済みデータを表示
                        DispReported(dr);
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

            //初期表示フラグ
            initialFlg = true;
        }

        /// <summary>
        /// 取得した時刻をラベルへセット
        /// </summary>
        private void SetTimeLbl(string startTime, string endTime, Label setLbl)
        {
            string startTimeH = "";
            string startTimeM = "";
            string endTimeH = "";
            string endTimeM = "";
            //開始時刻が入力されている場合
            if (!string.IsNullOrEmpty(startTime))
            {
                startTimeH = startTime.Substring(0, 2) + "：";
                startTimeM = startTime.Substring(2, 2);
            }
            //終了時刻が入力されている場合
            if (!string.IsNullOrEmpty(endTime))
            {
                endTimeH = endTime.Substring(0, 2) + "：";
                endTimeM = endTime.Substring(2, 2);
            }
            //開始時刻と終了時刻が入力されている場合
            setLbl.Text = !string.IsNullOrEmpty(startTime) || !string.IsNullOrEmpty(endTime) ?
                startTimeH + startTimeM + "～" + endTimeH + endTimeM : "";
        }

        /// <summary>
        /// 報告済みデータ表示(更新で遷移した場合)
        /// </summary>
        private void DispReported(DataRow dr)
        {
            //メンター・メンティ―を表示
            lblMentor.Text = dr["MENTOR_NM"].ToString();
            lblMentee.Text = dr["MENTEE_NM"].ToString();

            //実施日を表示
            DateTime execDate = DateTime.Parse(dr["EXEC_DATE"].ToString());
            lblExecDate.Text = execDate.ToShortDateString();

            //実施時刻セット
            string startTime = dr["START_TIME"].ToString();
            string endTime = dr["END_TIME"].ToString();
            SetTimeLbl(startTime, endTime, lblExecTime);

            //実施場所・経費を表示
            lblPlace.Text = dr["PLACE"].ToString();
            lblPrice.Text = ToManey(dr["PRICE"]) + "円";

            //予定実施日を表示
            string strDatePlan = dr["DATE_PLAN"].ToString();
            //予定実施日が選択されている場合
            lblDatePlan.Text = !string.IsNullOrEmpty(strDatePlan) ?
                DateTime.Parse(strDatePlan).ToShortDateString() : "";

            //予定時間を表示
            string startPlanTime = dr["START_PLAN_TIME"].ToString();
            string endPlanTime = dr["END_PLAN_TIME"].ToString();
            SetTimeLbl(startPlanTime, endPlanTime, lblPlanTime);

            //実施予定場所を表示
            lblPlanPlace.Text = dr["PLAN_PLACE"].ToString();

            //報告内容を表示
            txtReport.Text = dr["OTHER"].ToString();

            //報告内容を編集できないように設定
            txtReport.ReadOnly = true;
            txtReport.BackColor = SystemColors.ButtonFace;
            //削除・一時保存ボタンを非表示
            btnDelete.Visible = true;
            btnSave.Visible = false;
            pnlPromote.Visible = true;
        }

        /// <summary>
        /// 取得した時刻をコンボボックスへセット
        /// </summary>
        private void SetTimeCbo(string startTime, string endTime, ComboBox comboStartH, ComboBox comboStartM, ComboBox comboEndH, ComboBox comboEndM)
        {
            //開始時刻が入力されている場合
            if (!string.IsNullOrEmpty(startTime))
            {
                string startTimeH = startTime.Substring(0, 2);
                //開始時間の先頭文字が0の場合、2文字目を取得
                startTimeH = startTimeH.Substring(0, 1).Equals("0") ?
                    startTimeH.Substring(1, 1) : startTimeH;
                string startTimeM = startTime.Substring(2, 2);
                //コンボボックスに開始時分を表示
                comboStartH.Text = startTimeH;
                comboStartM.Text = startTimeM;
            }
            //開始時間が入力されていない場合
            else
            {
                //コンボボックスに空白を表示
                comboStartH.SelectedIndex = 0;
                comboStartM.SelectedIndex = 0;
            }
            //終了時刻が入力されている場合
            if (!string.IsNullOrEmpty(endTime))
            {
                string endTimeH = endTime.Substring(0, 2);
                //終了時間の先頭文字が0の場合、2文字目を取得
                endTimeH = endTimeH.Substring(0, 1).Equals("0") ?
                    endTimeH.Substring(1, 1) : endTimeH;
                string endTimeM = endTime.Substring(2, 2);
                //コンボボックスに終了時分を表示
                comboEndH.Text = endTimeH;
                comboEndM.Text = endTimeM;
            }
            //終了時刻が入力されていない場合
            else
            {
                //コンボボックスに空白を表示
                comboEndH.SelectedIndex = 0;
                comboEndM.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 未報告・差戻データ表示
        /// </summary>
        private void DispNotReported(DataRow dr)
        {
            //実施日の最大日時を設定
            dtpExecDate.MaxDate = DateTime.Now;

            //実施日を表示
            dtpExecDate.Value = Convert.ToDateTime(dr["EXEC_DATE"].ToString());

            //コンボボックス設定
            SetCbo();

            //メンティ―を表示
            cboMentee.SelectedValue = dr["MENTEE_ID"].ToString();

            string startTime = dr["START_TIME"].ToString();
            string endTime = dr["END_TIME"].ToString();
            //実施時間をコンボへセット
            SetTimeCbo(startTime, endTime, cboStartH, cboStartM, cboEndH, cboEndM);

            //実施場所・費用を表示
            txtPlace.Text = dr["PLACE"].ToString();
            txtPrice.Text = ToManey(dr["PRICE"]);

            //実施予定日を表示
            dtpDatePlan.Text = dr["DATE_PLAN"].ToString();

            string startPlanTime = dr["START_PLAN_TIME"].ToString();
            string endPlanTime = dr["END_PLAN_TIME"].ToString();
            //予定時刻をコンボへセット
            SetTimeCbo(startPlanTime, endPlanTime, cboPlanStartH, cboPlanStartM, cboPlanEndH, cboPlanEndM);

            //実施予定場所を表示
            txtPlanPlace.Text = dr["PLAN_PLACE"].ToString();

            //報告内容を表示
            txtReport.Text = dr["OTHER"].ToString();

            //登録ボタンを非表示
            btnToroku.Visible = false;
        }

        /// <summary>
        /// メンター実績取得
        /// </summary>
        public void GetResult(ref DataSet ds)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("      MENTOR_ID");
            sql.Append("     ,MENTOR.MST_SHAIN_NAME AS MENTOR_NM ");
            sql.Append("     ,MENTEE_ID");
            sql.Append("     ,MENTEE.MST_SHAIN_NAME AS MENTEE_NM ");
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

            //SQL処理
            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_005);
            //実行エラー時
            if (ds == null) return;
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
            sql.Append("     ,CORRECT_FLG AS CORRECT_FLG_OLD");
            sql.Append("     ,EMPLOYEE_ID ");
            sql.Append("     ,MST_SHAIN_NAME AS EMPLOYEE_NM");
            sql.Append("     ,COMMENT");
            sql.Append("     ,COMMENT AS COMMENT_OLD");
            sql.Append("     ,INSERT_DATE AS WRITER_DATE");
            sql.Append("   FROM TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append("   LEFT JOIN MST_SHAIN ");
            sql.Append("     ON EMPLOYEE_ID = MST_SHAIN_CODE ");
            sql.Append($" WHERE MENTOR_RESULT_ID = {_mentorResultId}");

            //SQL処理
            dsComent = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_006);
            //SQL実行エラーの場合
            returnFlg = dsComent != null ? true : false;

            //STATUS列追加
            dsComent.Tables[0].Columns.Add();

            dgvIchiran.Rows.Clear();
            Enumerable.Range(0, dsComent.Tables[0].Rows.Count).Select(idx => dsComent.Tables[0].Rows[idx] as DataRow).ToList()
                .ForEach(dr => {
                    dgvIchiran.Rows.Add();
                    int idx = dgvIchiran.Rows.Count - 1;
                    dgvIchiran.Rows[idx].Cells["COMMENT_ID"].Value = dr["COMMENT_ID"].ToString();
                    dgvIchiran.Rows[idx].Cells["CORRECT_FLG"].Value = dr["CORRECT_FLG"].ToString();
                    dgvIchiran.Rows[idx].Cells["CORRECT_FLG_OLD"].Value = dr["CORRECT_FLG_OLD"].ToString();
                    dgvIchiran.Rows[idx].Cells["EMPLOYEE_ID"].Value = dr["EMPLOYEE_ID"].ToString();
                    dgvIchiran.Rows[idx].Cells["EMPLOYEE_NM"].Value = dr["EMPLOYEE_NM"].ToString();
                    dgvIchiran.Rows[idx].Cells["CONTENT"].Value = dr["COMMENT"].ToString();
                    dgvIchiran.Rows[idx].Cells["CONTENT_OLD"].Value = dr["COMMENT_OLD"].ToString();
                    dgvIchiran.Rows[idx].Cells["WRITER_DATE"].Value = dr["WRITER_DATE"].ToString();
                    dgvIchiran.Rows[idx].Cells["STETUS"].Value = dr["Column1"].ToString();
                });

            //推進部の場合
            if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
            {
                dgvIchiran.Columns["CORRECT_FLG"].ReadOnly = true;
            }
            //メンターの場合
            else
            {
                dgvIchiran.Columns["CONTENT"].ReadOnly = true;
            }

            //コメント入力文字数制限
            ((DataGridViewTextBoxColumn)dgvIchiran.Columns["CONTENT"]).MaxInputLength = 512;

            Enumerable.Range(0, dsComent.Tables[0].Rows.Count).Select(idx => dsComent.Tables[0].Rows[idx] as DataRow).ToList()
                 .ForEach(dr =>
                {
                    int idx = dgvIchiran.Rows.Count - 1;
                    //他者のコメントは編集不可
                    if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID 
                    && !dr["EMPLOYEE_ID"].ToString().Equals(User.Id))
                    {
                        //ログインユーザーのIDとコメント記入者のIDが一致しない場合、コメント編集不可
                        dgvIchiran.Rows[idx].Cells["CONTENT"].ReadOnly = true;
                    }
                });

            //セルを選択不可
            dgvIchiran.CurrentCell = null;
            //複数行選択不可
            dgvIchiran.MultiSelect = false;

            return returnFlg;
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        private void TorokuHaita()
        {
            if (!comU.InsertHaitaTrn(_mentorResultId, User.Id, programId))
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
            //メンティ―を取得
            if (!Mentee(ref dataSet))
            {
                Close();
                return;
            }

            //メンティ―コンボで選択したメンティ―が検索結果に含まれている場合
            //検索結果の先頭メンティーを格納
            string initSelected = null;
            initSelected = dataSet.Tables[0].AsEnumerable()
                .Where(TEKIYO_DATE => TEKIYO_DATE.Field<DateTime>("TEKIYO_START_DATE") <= DateTime.Now.Date && TEKIYO_DATE.Field<DateTime>("TEKIYO_END_DATE") >= DateTime.Now.Date)
                .Select(SHAIN_CODE => SHAIN_CODE.Field<string>("MST_SHAIN_CODE")).FirstOrDefault().ToString();

            // コンボボックスにデータテーブルをセット
            cboMentee.DataSource = dataSet.Tables[0].DefaultView.ToTable(true, "MST_SHAIN_CODE", "MST_SHAIN_NAME");
            // 表示用の列を設定
            cboMentee.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            cboMentee.ValueMember = "MST_SHAIN_CODE";
            //検索結果でメンティ―を取得した場合
            if (initSelected != null)
            {
                cboMentee.SelectedValue = initSelected;
            }
        }

        /// <summary>
        /// メンティ―コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool Mentee(ref DataSet ds)
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
            sql.Append($"   AND MENTOR_ID = {User.Id}");
            sql.Append(" ORDER BY TEKIYO_START_DATE ASC ");

            //SQL処理
            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_004);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 最大実績ID取得
        /// </summary>
        /// <returns></returns>
        public int MentorResultCount()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MAX(MENTOR_RESULT_ID)");
            sql.Append(" FROM TRN_MENTOR_RESULT");

            int count = -1;

            //SQL処理
            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //実行エラー時
            if (ds == null) return count;

            DataRow dr = ds.Tables[0].AsEnumerable().First();

            //取得したメンターリザルトIDがnull以外の場合、取得したIDを格納
            count = dr["MAX(MENTOR_RESULT_ID)"] != DBNull.Value
                ? Convert.ToInt32(dr["MAX(MENTOR_RESULT_ID)"].ToString()) :
                count;

            return count;
        }

        /// <summary>
        /// 行削除チェック
        /// </summary>
        /// <returns></returns>
        public bool DeleteCheckRow()
        {
            DialogResult result = MessageBox.Show(MSG.MSG005_003, MSG.MSG001_001, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            returnFlg = result == DialogResult.Yes ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 時刻チェック
        /// </summary>
        /// <returns></returns>
        public bool CheckTime()
        {
            //開始時が選択され、開始分が空欄の場合
            if (!cboStartH.SelectedValue.Equals("") & cboStartM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_003, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboStartM;
                return false;
            }
            //開始時が空欄で、開始分が入力されている場合
            if (cboStartH.SelectedValue.Equals("") & !cboStartM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_004, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboStartH;
                return false;
            }
            //終了時が選択され、終了分が空欄の場合
            if (!cboEndH.SelectedValue.Equals("") & cboEndM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_005, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboEndM;
                return false;
            }
            //終了時が空欄で、終了分が入力されている場合
            if (cboEndH.SelectedValue.Equals("") & !cboEndM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_006, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboEndH;
                return false;
            }

            //実施時間のチェック
            //開始時が選択され、開始分が選択されている場合
            string startTime = !cboStartH.SelectedValue.Equals("") && !cboStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboStartH.Text.PadLeft(2, '0') + cboStartM.Text.PadLeft(2, '0')) 
                : "Null";
            //終了時が選択され、終了分が選択されている場合
            string endTime = !cboEndH.SelectedValue.Equals("") && !cboEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboEndH.Text.PadLeft(2, '0') + cboEndM.Text.PadLeft(2, '0'))
                : "Null";

            //実施開始時間と終了時間が入力されている場合
            if(!startTime.Equals("Null") && !endTime.Equals("Null"))
            {
                //開始時間が終了時間より後の場合
                if (string.Compare(startTime, endTime) == 1)
                {
                    MessageBox.Show(MSG.MSG004_007, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //開始時間と終了時間が同じ場合
                else if (string.Compare(startTime, endTime) == 0)
                {
                    MessageBox.Show(MSG.MSG004_008, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //開始予定時が選択され、開始予定分が空欄の場合
            if (!cboPlanStartH.SelectedValue.Equals("") & cboPlanStartM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_012, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboPlanStartM;
                return false;
            }
            //開始予定時が空欄で、開始予定分が選択されている場合
            if (cboPlanStartH.SelectedValue.Equals("") & !cboPlanStartM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_013, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboPlanStartH;
                return false;
            }
            //終了予定時が選択され、終了予定分が空欄の場合
            if (!cboPlanEndH.SelectedValue.Equals("") & cboPlanEndM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_014, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboPlanEndM;
                return false;
            }
            //終了予定時が空欄で、終了予定分が選択されている場合
            if (cboPlanEndH.SelectedValue.Equals("") & !cboPlanEndM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_015, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboPlanEndH;
                return false;
            }

            //予定実施時間のチェック
            //開始予定時が選択され、開始予定分が選択されている場合
            string startPlanTime = !cboPlanStartH.SelectedValue.Equals("") && !cboPlanStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanStartH.Text.PadLeft(2, '0') + cboPlanStartM.Text.PadLeft(2, '0'))
                :"Null";
            //終了予定時が選択され、終了予定分が選択されている場合
            string endPlanTime = !cboPlanEndH.SelectedValue.Equals("") && !cboPlanEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanEndH.Text.PadLeft(2, '0') + cboPlanEndM.Text.PadLeft(2, '0'))
                : "Null";

            //開始予定時間と終了予定時間が入力されている場合
            if (!startPlanTime.Equals("Null") && !endPlanTime.Equals("Null"))
            {
                //予定開始時間が予定終了時間より後の場合
                if (string.Compare(startPlanTime, endPlanTime) == 1)
                {
                    MessageBox.Show(MSG.MSG004_016, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //予定開始時間と予定終了時間が同じ場合
                else if (string.Compare(startPlanTime, endPlanTime) == 0)
                {
                    MessageBox.Show(MSG.MSG004_017, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 適用日の期間内にメンティ―が登録されているかチェック
        /// </summary>
        /// <returns></returns>
        public bool CheckMentee()
        {
            string exec = comU.GetDateTimePick(dtpExecDate.Value);
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     COUNT(MENTEE_ID)");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append($" WHERE MENTOR_ID = '{User.Id}'");
            sql.Append($" AND TEKIYO_START_DATE <= {exec}");
            sql.Append($" AND TEKIYO_END_DATE >= {exec}");
            sql.Append($" AND MENTEE_ID = '{cboMentee.SelectedValue}'");

            //SQL処理
            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            //SQL実行エラーでない場合
            if(returnFlg)
            {
                //取得結果がnull以外かつ取得結果が0以外の場合
                DataRow dr = ds.Tables[0].AsEnumerable().First();
                returnFlg = !string.IsNullOrEmpty(dr["COUNT(MENTEE_ID)"].ToString())
                    && Convert.ToInt32(dr["COUNT(MENTEE_ID)"].ToString()) != 0
                    ? true : false;
            }

            return returnFlg;
        }

        /// <summary>
        /// 一時保存入力チェック
        /// </summary>
        /// <returns></returns>
        public bool InputCheckSave()
        {
            //コンボメンティ―が空欄の場合
            if (cboMentee.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentee;
                return false;
            }
            //メンティ―チェック
            if (!CheckMentee())
            {
                MessageBox.Show(MSG.MSG004_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentee;
                return false;
            }
            //実施日と実施予定日が空欄以外の場合
            if (dtpExecDate.Value != null && dtpDatePlan.Value != null)
            {
                //実施予定日よりも実施日が後の日付の場合
                if (dtpExecDate.Value >= dtpDatePlan.Value)
                {
                    MessageBox.Show(MSG.MSG004_011, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = dtpDatePlan;
                    return false;
                }
            }
            //時刻チェック
            if (!CheckTime()) return false;

            return true;
        }

        /// <summary>
        /// 一時保存チェック
        /// </summary>
        /// <returns></returns>
        public bool ExecuteSave()
        {
            string procName = "";
            string targetTable = "メンター実績";
            try
            {
                //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
                if (string.IsNullOrEmpty(_mentorResultId))
                {
                    procName = "登録";
                    InsertMentorResult(CommonConstants.Status.MIHOUKOKU);
                }
                else
                {
                    procName = "更新";
                    UpdateMentorResult(CommonConstants.Status.MIHOUKOKU);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{targetTable}テーブルの{procName}処理に失敗しました。", MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                dBManager.RollBack();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 報告入力チェック
        /// </summary>
        /// <returns></returns>
        public bool InputCheckReport()
        {
            //メンティ―が空欄の場合
            if (cboMentee.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentee;
                return false;
            }
            //メンティ―チェック
            if (!CheckMentee())
            {
                MessageBox.Show(MSG.MSG004_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentee;
                return false;
            }
            //開始時が空欄の場合
            if (cboStartH.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_004, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboStartH;
                return false;
            }
            //開始分が空欄の場合
            if (cboStartM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_003, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboStartM;
                return false;
            }
            //終了時が空欄の場合
            if (cboEndH.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_006, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboEndH;
                return false;
            }
            //終了分が空欄の場合
            if (cboEndM.SelectedValue.Equals(""))
            {
                MessageBox.Show(MSG.MSG004_005, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboEndM;
                return false;
            }
            //実施場所が空欄の場合
            if (string.IsNullOrEmpty(txtPlace.Text))
            {
                MessageBox.Show(MSG.MSG004_009, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txtPlace;
                return false;
            }
            //費用が空欄の場合
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show(MSG.MSG004_010, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txtPrice;
                return false;
            }
            //報告が空欄の場合
            if (string.IsNullOrEmpty(txtReport.Text))
            {
                MessageBox.Show(MSG.MSG004_018, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = txtReport;
                return false;
            }
            //実施日と実施予定日が空欄以外の場合
            if (dtpExecDate.Value != null && dtpDatePlan.Value != null)
            {
                //実施予定日が実施日より後の日付の場合
                if (dtpExecDate.Value > dtpDatePlan.Value)
                {
                    MessageBox.Show(MSG.MSG004_011, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = dtpDatePlan;
                    return false;
                }
            }
            //時刻チェック
            if (!CheckTime()) return false;

            return true;
        }

        /// <summary>
        /// 報告実行
        /// </summary>
        /// <returns></returns>
        public bool ExcuteReport()
        {
            string procName = "";
            string targetTable = "";
            try
            {
                //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
                if (string.IsNullOrEmpty(_mentorResultId))
                {
                    targetTable = "メンター実績";
                    procName = "登録";
                    InsertMentorResult(CommonConstants.Status.HOUKOKUZUMI);
                }
                else
                {
                    targetTable = "メンター実績";
                    procName = "更新";
                    UpdateMentorResult(CommonConstants.Status.HOUKOKUZUMI);
                    targetTable = "推進チームコメント";

                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    dgvIchiran.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.HOUKOKUZUMI).ToList()
                        .ForEach(row => UpdateComment(row));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{targetTable}テーブルの{procName}処理に失敗しました。", MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                dBManager.RollBack();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 登録実行
        /// </summary>
        /// <returns></returns>
        public bool ExcuteInsert()
        {
            string procName = "";
            try
            {
                //メンター用
                if (Mode.Id == CommonConstants.ModeKbn.MENTOR_ID)
                {
                    procName = "更新";

                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    dgvIchiran.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.HOUKOKUZUMI).ToList()
                        .ForEach(row => UpdateComment(row));
                }
                //推進チーム用
                else
                {
                    procName = "削除";
                    DeleteComment();

                    //値の変更を行った明細の数だけ繰り返し処理を行う
                    dgvIchiran.Rows.Cast<DataGridViewRow>().ToList()
                    .ForEach(row =>
                    {
                        //新しいコメントを登録する場合
                        if (row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.MIHOUKOKU)
                        {
                            procName = "登録";
                            InsertComment(row);
                        }
                        //コメントを更新する場合
                        else if (row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.HOUKOKUZUMI)
                        {
                            procName = "更新";
                            row.Cells["WRITER_DATE"].Value = DateTime.Now;
                            UpdateCommentPromoto(row);
                        }
                    });
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"推進チームコメントテーブルの{procName}処理に失敗しました。", MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                dBManager.RollBack();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登録入力チェック(明細変更)
        /// </summary>
        /// <returns></returns>
        public bool InputCheckMInsert()
        {
            returnFlg = true;
            //明細が変更されていない場合エラー
            if (dgvIchiran.Rows.Count == 0)
            {
                MessageBox.Show(MSG.MSG006_001, MSG.MSG001_002);
                returnFlg = false;
            }
            //削除行がない場合エラー
            //Enumerable.Range(0, dgvIchiran.Rows.Count).ToList()
            //    .Where(dr => delList.Count == 0).ToList()
            //    .ForEach(dr =>
            //    {
            //        MessageBox.Show(MSG.MSG006_001, MSG.MSG001_002);
            //        returnFlg = false;
            //    });

            return returnFlg;
        }

        /// <summary>
        /// 登録入力チェック(コメント)
        /// </summary>
        /// <returns></returns>
        public bool InputCheckCommentInsert()
        {
            returnFlg = true;
            //コメントが空白の場合エラー
            Enumerable.Range(0, dgvIchiran.Rows.Count).Select(idx => dgvIchiran.Rows[idx])
                .Where(dr => dr.Cells["CONTENT"].Value.ToString() == "").ToList()
                .ForEach(row => {
                    MessageBox.Show(MSG.MSG006_002, MSG.MSG001_002);
                    returnFlg = false;
                });

            return returnFlg;
        }

        /// <summary>
        /// 削除実行
        /// </summary>
        /// <returns></returns>
        private bool ExcuteDelete()
        {
            string procName = "";
            string targetTable = "";
            try
            {
                targetTable = "メンター実績";
                procName = "削除";
                //メンター実施テーブルデータ削除処理
                DeleteMentorResult();
                targetTable = "推進チームコメント";
                AllDeleteComment();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{targetTable}テーブルの{procName}処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                dBManager.RollBack();
                return false;
            }

            return true;
        }

        /// <summary>
        /// ダイアログチェック
        /// </summary>
        /// <returns></returns>
        public bool CheckDiarog(string processing)
        {
            DialogResult result = MessageBox.Show($"{processing}を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            returnFlg = result == DialogResult.Yes ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 差し戻し実行
        /// </summary>
        /// <returns></returns>
        private bool ExcuteRemand()
        {
            string procName = "";
            string targetTable = "";
            try
            {
                targetTable = "推進チームコメント";
                procName = "削除";
                DeleteComment();

                //値の変更を行った明細の数だけ繰り返し処理を行う
                dgvIchiran.Rows.Cast<DataGridViewRow>().ToList()
                    .ForEach(row =>
                    {
                        //新しいコメントを登録する場合
                        if (row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.MIHOUKOKU)
                        {
                            procName = "登録";
                            InsertComment(row);
                        }
                        //コメントを更新する場合
                        else if (row.Cells["STETUS"].Value.ToString() == CommonConstants.Status.HOUKOKUZUMI)
                        {
                            procName = "更新";
                            row.Cells["WRITER_DATE"].Value = DateTime.Now;
                            UpdateCommentPromoto(row);
                        }
                    });
                targetTable = "メンター実績";
                procName = "更新";
                //差戻処理
                UpdateRemand();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{targetTable}テーブルの{procName}処理に失敗しました。", MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                dBManager.RollBack();
                return false;
            }

            return true;
        }

        /// <summary>
        /// メンター実績登録処理
        /// </summary>
        /// <returns></returns>
        private void InsertMentorResult(string status)
        {
            string exec = comU.GetDateTimePick(dtpExecDate.Value);
            string plan = comU.GetDateTimePick(dtpDatePlan.Value);

            string startTime = "Null";
            string endTime = "Null";
            //開始時が選択され、開始分が選択されている場合
            startTime = !cboStartH.SelectedValue.Equals("") && !cboStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboStartH.Text.PadLeft(2, '0') + cboStartM.Text.PadLeft(2, '0'))
                : startTime;
            //終了時が選択され、終了分が選択されている場合
            endTime = !cboEndH.SelectedValue.Equals("") && !cboEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboEndH.Text.PadLeft(2, '0') + cboEndM.Text.PadLeft(2, '0'))
                : endTime;

            string price = "Null";
            //費用が入力されている場合
            price = !string.IsNullOrEmpty(txtPrice.Text)
                ? txtPrice.Text.Replace(",", "")
                : price;

            //予定日をnull
            plan = string.IsNullOrEmpty(plan) ? "Null" : plan;

            string startPlanTime = "Null";
            //開始予定時が選択され、開始予定分が選択されている場合
            startPlanTime = !cboPlanStartH.SelectedValue.Equals("") && !cboPlanStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanStartH.Text.PadLeft(2, '0') + cboPlanStartM.Text.PadLeft(2, '0'))
                : startPlanTime;

            string endPlanTime = "Null";
            //終了予定時が選択され、終了予定分が選択されている場合
            endPlanTime = !cboPlanEndH.SelectedValue.Equals("") && !cboPlanEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanEndH.Text.PadLeft(2, '0') + cboPlanEndM.Text.PadLeft(2, '0'))
                : endPlanTime;

            int recordCount = MentorResultCount();
            if(recordCount == -1) return;

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
            //最大実績IDが0以外の場合
            if (recordCount != 0)
            {
                sql.Append($"    '{recordCount + 1}' ");
            }
            else
            {
                sql.Append("    1 ");
            }
            sql.Append($"    ,{exec} ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,'{cboMentee.SelectedValue}'");
            sql.Append($"    ,{status} ");
            //状況が未報告の場合
            if (status == CommonConstants.Status.MIHOUKOKU)
            {
                sql.Append("    ,Null ");
            }
            else
            {
                sql.Append("    ,now() ");
            }
            sql.Append($"    ,{startTime} ");
            sql.Append($"    ,{endTime} ");
            //実施場所が空欄以外の場合
            if (!string.IsNullOrEmpty(txtPlace.Text))
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
            //実施予定場所が空欄以外の場合
            if (!string.IsNullOrEmpty(txtPlanPlace.Text))
            {
                sql.Append($"    ,{comU.CAddQuotation(txtPlanPlace.Text)} ");
            }
            else
            {
                sql.Append("    ,Null ");
            }
            //報告が入力されている場合
            if (!string.IsNullOrEmpty(txtReport.Text))
            {
                sql.Append($"    ,{comU.CAddQuotation(txtReport.Text)} ");
            }
            else
            {
                sql.Append("    ,Null ");
            }
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 推進チームコメント登録
        /// </summary>
        /// <returns></returns>
        private void InsertComment(DataGridViewRow row)
        {
            row.Cells["WRITER_DATE"].Value = DateTime.Now;
            string id = row.Cells["COMMENT_ID"].Value.ToString();
            string content = row.Cells["CONTENT"].Value.ToString();
            string writeDate = row.Cells["WRITER_DATE"].Value.ToString();
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
            sql.Append($"    ,{comU.CAddQuotation(User.Id)}");
            sql.Append($"    ,{comU.CAddQuotation(writeDate)} ");
            sql.Append($"    ,{comU.CAddQuotation(content)} ");
            sql.Append("    ,'0' ");
            sql.Append("    ,Null ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// メンター実績更新処理
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private void UpdateMentorResult(string status)
        {
            string exec = comU.GetDateTimePick(dtpExecDate.Value);
            string plan = comU.GetDateTimePick(dtpDatePlan.Value);

            string startTime = "Null";
            //開始時が選択され、開始分が選択されている場合
            startTime = !cboStartH.SelectedValue.Equals("") && !cboStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboStartH.Text.PadLeft(2, '0') + cboStartM.Text.PadLeft(2, '0'))
                : startTime;

            string endTime = "Null";
            //終了時が選択され、終了分が選択されている場合
            endTime = !cboEndH.SelectedValue.Equals("") && !cboEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboEndH.Text.PadLeft(2, '0') + cboEndM.Text.PadLeft(2, '0'))
                : endTime;

            string price = "Null";
            //費用が入力されている場合
            price = !string.IsNullOrEmpty(txtPrice.Text)
                ? txtPrice.Text.Replace(",", "")
                : price;

            string startPlanTime = "Null";
            //開始予定時が選択され、開始予定分が選択されている場合
            startPlanTime = !cboPlanStartH.SelectedValue.Equals("") && !cboPlanStartM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanStartH.Text.PadLeft(2, '0') + cboPlanStartM.Text.PadLeft(2, '0'))
                : startPlanTime;

            string endPlanTime = "Null";
            //終了予定時が選択され、終了予定分が選択されている場合
            endPlanTime = !cboPlanEndH.SelectedValue.Equals("") && !cboPlanEndM.SelectedValue.Equals("")
                ? comU.CAddQuotation(cboPlanEndH.Text.PadLeft(2, '0') + cboPlanEndM.Text.PadLeft(2, '0'))
                : endPlanTime;

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT ");
            sql.Append($"    SET  EXEC_DATE = {exec} ");
            sql.Append($"     ,    MENTOR_ID = {comU.CAddQuotation(User.Id)} ");
            sql.Append($"     ,    MENTEE_ID = '{cboMentee.SelectedValue}' ");
            sql.Append($"     ,    STATUS = {status} ");
            //状況が未報告の場合
            if (status == CommonConstants.Status.MIHOUKOKU)
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
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(User.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// コメント更新(メンター用)
        /// </summary>
        /// <returns></returns>
        private void UpdateComment(DataGridViewRow row)
        {
            string id = row.Cells["COMMENT_ID"].Value.ToString();
            string correctFlg = row.Cells["CORRECT_FLG"].Value.ToString();
            string check;
            //チェックボックスにチェックが入っている場合、チェックON
            check = correctFlg == "True" ? CommonConstants.Flg.ON : CommonConstants.Flg.OFF;

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append($"    SET  CORRECT_FLG = {check} ");
            //チェックされていない場合
            if (check.Equals(CommonConstants.Flg.OFF))
            {
                sql.Append("     ,    CORRECT_DT = null ");
            }
            else
            {
                sql.Append($"     ,    CORRECT_DT = now() ");
            }
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(User.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
            sql.Append($"   AND COMMENT_ID = '{id}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// コメント更新(推進チーム用)
        /// </summary>
        /// <returns></returns>
        private void UpdateCommentPromoto(DataGridViewRow row)
        {
            string id = row.Cells["COMMENT_ID"].Value.ToString();
            string content = row.Cells["COMMENT"].Value.ToString();
            string writeDate = row.Cells["WRITER_DATE"].Value.ToString();
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT_PROMOTE ");
            sql.Append($"    SET  COMMENT = {comU.CAddQuotation(content)} ");
            sql.Append($"      ,INSERT_DATE = {comU.CAddQuotation(writeDate)}  ");
            sql.Append("      ,CORRECT_FLG = 0 ");
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(User.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
            sql.Append($"   AND COMMENT_ID = '{id}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 推進チームコメント削除
        /// </summary>
        private void DeleteComment()
        {
            Enumerable.Range(0, delList.Count).ToList()
                .ForEach(row =>
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" DELETE FROM TRN_MENTOR_RESULT_PROMOTE ");
                    sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");
                    sql.Append($"   AND COMMENT_ID = '{delList[0]}'");

                    dBManager.ExecuteNonQuery(sql.ToString());
                });
        }

        /// <summary>
        /// 差し戻し更新
        /// </summary>
        /// <returns></returns>
        private void UpdateRemand()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE TRN_MENTOR_RESULT ");
            sql.Append("    SET  STATUS = '2' ");
            sql.Append("      ,    UPD_DT = now() ");
            sql.Append($"     ,    UPD_USER = {comU.CAddQuotation(User.Id)}  ");
            sql.Append($"     ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// 削除処理(推進チームコメントテーブル)
        /// </summary>
        /// <returns></returns>
        private void AllDeleteComment()
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
        private void DeleteMentorResult()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_MENTOR_RESULT ");
            sql.Append($" WHERE MENTOR_RESULT_ID = '{_mentorResultId}'");

            dBManager.ExecuteNonQuery(sql.ToString());
        }

        /// <summary>
        /// コメントID取得
        /// </summary>
        /// <returns></returns>
        private int GetCommentId()
        {
            int id = 1;
            //1件以上のデータが存在する場合
            if (dgvIchiran.Rows.Count != 0)
            {
                Enumerable.Range(0, dsComent.Tables[0].Rows.Count).Select(idx => dsComent.Tables[0].Rows[idx] as DataRow).ToList()
                    .ForEach(dr => id = Convert.ToInt32(dr["COMMENT_ID"].ToString()));
                id += 1;
            }

            return id;
        }

        /// <summary>
        /// 変更検知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool DetectionChange()
        {
            returnFlg = false;
            //変更されている場合
            if (changeFlg)
            {
                DialogResult result = MessageBox.Show(MSG.MSG005_004, MSG.MSG001_001, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                returnFlg = result != DialogResult.Yes ? true : false;
                changeFlg = returnFlg;
            }
            return returnFlg;
        }

        /// <summary>
        /// 3桁ごとにカンマ表示
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string ToManey(object price) => String.Format("{0:#,0}", price);
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 行追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            dgvIchiran.Rows.Add(GetCommentId(), false, false, User.Id, User.Name, "", "", null, 0);
            changeFlg = true;
        }

        /// <summary>
        /// 行削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            //選択した明細行を取得
            int selectedRow = dgvIchiran.CurrentCell != null ? dgvIchiran.CurrentCell.RowIndex : -1;
            //行を選択していない場合エラー
            if (selectedRow == -1)
            {
                MessageBox.Show(MSG.MSG006_003, MSG.MSG001_002);
                return;
            }
            //ログインユーザーとコメント記入者が一致しない場合
            if (!dgvIchiran["EMPLOYEE_ID", selectedRow].Value.ToString().Equals(User.Id))
            {
                MessageBox.Show(MSG.MSG006_004, MSG.MSG001_002);
                return;
            }
            //行削除チェック
            if (DeleteCheckRow())
            {
                //削除するコメントIDをリストに格納
                delList.Add(dgvIchiran["COMMENT_ID", selectedRow].Value.ToString());
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
            try
            {
                //DB接続
                dBManager = new DBManager();

                //明細の変更チェック
                if (!InputCheckMInsert()) return;

                //メニューで推進部を選択した場合
                if (Mode.Id == CommonConstants.ModeKbn.SUISINBU_ID)
                {
                    //コメントの有無チェック
                    if (!InputCheckCommentInsert()) return;
                }
                //ダイアログ
                if (!CheckDiarog("登録")) return;

                //トランザクション開始
                dBManager.BeginTran();

                //登録処理
                if (!ExcuteInsert()) return;

                //コミット
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            MessageBox.Show(MSG.MSG006_005, MSG.MSG001_001);
            log.Display(MSG.MSG006_005);
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            Close();
        }

        /// <summary>
        /// 報告ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                //DB接続
                dBManager = new DBManager();

                //報告入力チェック
                if (!InputCheckReport()) return;

                //ダイアログ
                if (!CheckDiarog("報告")) return;

                //トランザクション開始
                dBManager.BeginTran();

                //報告処理
                if (!ExcuteReport()) return;

                //コミット
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            MessageBox.Show(MSG.MSG006_006, MSG.MSG001_001);
            log.Display(MSG.MSG006_006);
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            Close();
        }

        /// <summary>
        /// 一時保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //DB接続
                dBManager = new DBManager();

                //一時保存チェック
                if (!InputCheckSave()) return;

                //ダイアログ
                if (!CheckDiarog("保存")) return;

                //トランザクション開始
                dBManager.BeginTran();

                //一時保存処理
                if (!ExecuteSave()) return;

                //コミット
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            MessageBox.Show(MSG.MSG006_007, MSG.MSG001_001);
            log.Display(MSG.MSG006_007);
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            Close();
        }

        /// <summary>
        /// 差し戻しボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemand_Click(object sender, EventArgs e)
        {
            try
            {
                //DB接続
                dBManager = new DBManager();

                //差し戻し画面に遷移
                MH0041 frm = new MH0041();
                frm.ShowDialog();
                if (!frm.InputFlg) return;

                //ダイアログ
                if (!CheckDiarog("差戻し")) return;

                //差戻理由追加
                dgvIchiran.Rows.Add(GetCommentId(), false, false, User.Id, User.Name, "差戻理由:" + frm.Reason, "", null, 0);
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                dgvIchiran["CORRECT_FLG", dgvIchiran.Rows.Count - 1] = cell;

                dBManager.BeginTran();
                //差し戻し処理
                if (!ExcuteRemand()) return;

                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            MessageBox.Show(MSG.MSG006_008, MSG.MSG001_001);
            log.Display(MSG.MSG006_008);
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            Close();
        }

        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //DB接続
                dBManager = new DBManager();

                //ダイアログ
                if (!CheckDiarog("削除")) return;

                //トランザクション開始
                dBManager.BeginTran();

                //削除処理
                if (!ExcuteDelete()) return;

                //コミット
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            MessageBox.Show(MSG.MSG006_009, MSG.MSG001_001);
            log.Display(MSG.MSG006_009);
            torokuFlg = true;
            changeFlg = false;
            _resultIdList.Clear();
            Close();
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
        /// 終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MH0040_FormClosing(object sender, FormClosingEventArgs e)
        {
            //変更検知
            if (DetectionChange())
            {
                e.Cancel = true;
            }

            //メンター実績IDがnull以外
            if (!string.IsNullOrEmpty(_mentorResultId))
            {
                //照会モードの場合
                if (shokaiMode) return;
                
                //排他トラン削除
                if (!comU.DeleteHaitaTrn(_mentorResultId)) return;
            }
        }

        /// <summary>
        /// ←ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDn_Click(object sender, EventArgs e)
        {
            //変更検知
            if (DetectionChange()) return;

            string lastResultId = _resultIdList.Last();
            //新規(遷移元から引数としてメンター実績IDを取得していない)の場合
            if (string.IsNullOrEmpty(_mentorResultId))
            {
                Hide();
                //１つ前の報告書に遷移
                MH0040 mh0040 = new MH0040(_resultIdList, lastResultId);
                ShowDialog(mh0040);
                torokuFlg = mh0040.torokuFlg;
            }
            else
            {
                //メンター実績ID配列内にある引数の実績IDのひとつ前のメンターID
                int index = _resultIdList.IndexOf(_mentorResultId);
                string id = _resultIdList[index - 1];
                Hide();
                //照会モード以外
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId)) return;
                }
                //１つ前の報告書に遷移
                MH0040 mh0040 = new MH0040(_resultIdList, id);
                ShowDialog(mh0040);
                torokuFlg = mh0040.torokuFlg;
            }
        }

        /// <summary>
        /// →ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            //変更検知
            if (DetectionChange()) return;

            string lastResultId = _resultIdList.Last();
            //実績IDがメンター実績ID配列の最終IDと一致する場合
            if (_mentorResultId.Equals(lastResultId))
            {
                Hide();
                //照会モード以外
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId)) return;
                }
                //１つ後の報告書に遷移
                MH0040 mh0040 = new MH0040(_resultIdList);
                ShowDialog(mh0040);
                torokuFlg = mh0040.torokuFlg;
            }
            else
            {
                //メンター実績ID配列内にある引数の実績IDのひとつ前のメンターID
                int index = _resultIdList.IndexOf(_mentorResultId);
                string id = _resultIdList[index + 1];
                Hide();
                //照会モード以外
                if (!shokaiMode)
                {
                    //排他トラン削除
                    if (!comU.DeleteHaitaTrn(_mentorResultId)) return;
                }
                //１つ後の報告書に遷移
                MH0040 mh0040 = new MH0040(_resultIdList, id);
                ShowDialog(mh0040);
                torokuFlg = mh0040.torokuFlg;
            }
        }
        #endregion
    }
}
