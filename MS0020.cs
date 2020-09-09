using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MS0020 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DBUtli dbUtil = new DBUtli();
        private bool torokuFlg = false;
        private bool returnFlg = true;
        private readonly string mode;
        private readonly string programId = "MS0020";
        private readonly string _mentorId;
        private readonly string _mentorNm;
        private readonly string _menteeId;
        private readonly string _menteeNm;
        private readonly string _startDate;
        private readonly string _endDate;
        #endregion

        #region プロパティ
        /// <summary>
        /// 再検索用
        /// </summary>
        public bool TorokuFlg { get => torokuFlg; set => torokuFlg = value; }
        #endregion

        #region 定数
        public enum SyoriMode
        {
            INSERT,
            UPDATE
        }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ(新規)
        /// </summary>
        public MS0020()
        {
            InitializeComponent();
            mode = SyoriMode.INSERT.ToString();
        }

        /// <summary>
        /// コンストラクタ(更新)
        /// </summary>
        /// <param name="mentorId"></param>
        /// <param name="mentorNm"></param>
        /// <param name="menteeId"></param>
        /// <param name="menteeNm"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public MS0020(string mentorId, string mentorNm, string menteeId, string menteeNm, string start, string end)
        {
            _mentorId = mentorId;
            _mentorNm = mentorNm;
            _menteeId = menteeId;
            _menteeNm = menteeNm;
            _startDate = start;
            _endDate = end;

            InitializeComponent();
            mode = SyoriMode.UPDATE.ToString();
        }
        #endregion

        #region イベント処理
        /// <summary>
        /// 初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MS0020_Load(object sender, EventArgs e)
        {
            //ログインユーザー表示
            lblUser.Text = User.Name;

            //新規の場合
            if (mode.Equals(SyoriMode.INSERT.ToString()))
            {
                pnlUpdate.Visible = false;
                btnInsertUpdate.Text = "登録";
                btnDelete.Visible = false;
                //メンターコンボ設定
                SetMentor();
                //メンティ―コンボ設定
                SetMentee();
                //適用開始日を現在日
                dtpStart.Value = DateTime.Now;
                ActiveControl = cboMentor;
            }
            //更新の場合
            else
            {
                DateTime startDate = DateTime.Parse(_startDate);

                pnlUpdate.Visible = true;
                btnInsertUpdate.Text = "更新";
                btnDelete.Visible = true;
                lblMentorNm.Text = _mentorNm;
                lblMenteeNm.Text = _menteeNm;
                lblStart.Text = startDate.ToShortDateString();
                //適用終了日が設定されている場合、適用終了日項目に表示
                if (!string.IsNullOrEmpty(_endDate))
                {
                    dtpEnd.Value = Convert.ToDateTime(_endDate);
                }
                ActiveControl = dtpEnd;
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// メンティ―ンボボックス設定
        /// </summary>
        /// <returns></returns>
        private bool SetMentee(ref DataSet ds)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_SHAIN");
            sql.Append(" WHERE MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
            sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");

            ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_007);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;

            return returnFlg;
        }

        /// <summary>
        /// 変更検知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool ChangeDetection()
        {
            bool changeFlg;
            //新規の場合
            if (mode.Equals(SyoriMode.INSERT.ToString()))
            {
                DateTime dt = DateTime.Now;
                //適用開始日が空白以外の場合
                string yyyyMMfrom = dtpStart.Value != null ?
                    ((DateTime)dtpStart.Value).ToString("yyyyMMdd") : "";
                changeFlg =
                    //メンターコンボ変更時
                    cboMentor.SelectedValue != null ||
                    //メンティ―コンボ変更時
                    cboMentee.SelectedValue != null ||
                    //適用開始日と現在日が一致しない場合
                    !yyyyMMfrom.Equals(((DateTime)dt).ToString("yyyyMMdd")) ||
                    //適用終了日が空白以外の場合
                    dtpEnd.Value != null
                    ? true : false;
            }
            //更新の場合
            else
            {
                //適用終了日が変更されている場合
                changeFlg = !dtpEnd.Text.Equals(_endDate) ? true : false;
            }

            return changeFlg;
        }

        /// <summary>
        /// 登録入力チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInsert()
        {
            //メンターが空白の場合
            if (cboMentor.SelectedValue == null)
            {
                MessageBox.Show(MSG.MSG004_000, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentor;
                return false;
            }
            //メンティ―が空白の場合
            if (cboMentee.SelectedValue == null)
            {
                MessageBox.Show(MSG.MSG004_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentee;
                return false;
            }
            //メンターコンボとメンティ―コンボが同じ場合
            if (cboMentor.SelectedValue.Equals(cboMentee.SelectedValue))
            {
                MessageBox.Show(MSG.MSG007_007, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = cboMentor;
                return false;
            }
            //適用開始日が空白の場合
            if (dtpStart.Value == null)
            {
                MessageBox.Show(MSG.MSG007_008, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = dtpStart;
                return false;
            }
            //適用終了日が空白以外の場合
            if (dtpEnd.Value != null)
            {
                string yyyyMMfrom = ((DateTime)dtpStart.Value).ToString("yyyyMMdd");
                string yyyyMMto = ((DateTime)dtpEnd.Value).ToString("yyyyMMdd");
                //適用開始日が適用終了日より後の日付の場合
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show(MSG.MSG007_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = dtpStart;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 更新入力チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckUpdate()
        {
            //適用終了日が空白以外の場合
            if (dtpEnd.Value != null)
            {
                string yyyyMMfrom = comU.CReplace(lblStart.Text);
                string yyyyMMto = ((DateTime)dtpEnd.Value).ToString("yyyyMMdd");
                //適用開始日が適用終了日より後の日付の場合
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show(MSG.MSG007_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ActiveControl = dtpEnd;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 存在チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckExistence(bool updFlg = false)
        {
            string start;
            string mentor;
            string mentee;
            //適用終了日が入力されている場合
            string end = dtpEnd.Value != null
                ? comU.GetDateTimePick(dtpEnd.Value)
                : "99991231";

            //登録の場合
            if (mode.Equals(SyoriMode.INSERT.ToString()))
            {
                start = comU.GetDateTimePick(dtpStart.Value);
                mentor = cboMentor.SelectedValue.ToString();
                mentee = cboMentee.SelectedValue.ToString();
            }
            //更新の場合
            else
            {
                start = comU.CReplace(_startDate);
                mentor = _mentorId;
                mentee = _menteeId;
            }

            //既に登録されているメンターメンティ―の数を取得
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     COUNT(*)");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append($" WHERE TEKIYO_END_DATE >= {start}");
            //適用終了日が入力されている場合
            if (dtpEnd.Value != null)
            {
                sql.Append($"   AND  TEKIYO_START_DATE <= {end}");
            }
            sql.Append($"   AND MENTOR_ID = '{mentor}'");
            sql.Append($"   AND MENTEE_ID = '{mentee}'");
            //自分は含めない
            if (updFlg)
            {
                sql.Append($"   AND  (MENTOR_ID != '{mentor}'");
                sql.Append($"    OR  MENTEE_ID != '{mentee}'");
                sql.Append($"    OR  TEKIYO_START_DATE != {start})");
            }

            //入力した適用日が登録されている適用日に一致している日数を取得
            StringBuilder sqlOther = new StringBuilder();
            sqlOther.Append(" SELECT ");
            sqlOther.Append("     COUNT(*)");
            sqlOther.Append(" FROM MST_MENTOR_MENTEE");
            sqlOther.Append($" WHERE TEKIYO_END_DATE >= {start}");
            //適用終了日が入力されている場合
            if (dtpEnd.Value != null)
            {
                sqlOther.Append($"   AND  TEKIYO_START_DATE <= {end}");
            }
            sqlOther.Append($"   AND (MENTOR_ID = '{mentor}'");
            sqlOther.Append($"   OR MENTOR_ID = '{mentee}'");
            sqlOther.Append($"   OR MENTEE_ID = '{mentor}'");
            sqlOther.Append($"   OR MENTEE_ID = '{mentee}')");
            //自分は含めない
            if (updFlg)
            {
                sqlOther.Append($"   AND  (MENTOR_ID != '{mentor}'");
                sqlOther.Append($"    OR  MENTEE_ID != '{mentee}'");
                sqlOther.Append($"    OR  TEKIYO_START_DATE != {start})");
            }

            //SQL処理
            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            DataSet dsOther = dbUtil.OperationDB(sqlOther.ToString(), MSG.MSG003_001);

            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;
            DataRow dr = ds.Tables[0].AsEnumerable().First();
            //SQL実行エラーの場合
            returnFlg = dsOther != null ? true : false;
            DataRow drOther = dsOther.Tables[0].AsEnumerable().First();

            long count = (long)dr["COUNT(*)"];
            long countOther = (long)drOther["COUNT(*)"];
            //一致したメンターメンティ―の数が0以上の場合
            if (count > 0)
            {
                MessageBox.Show(MSG.MSG007_009, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //一致した適用日の数が0以上の場合
            else if (countOther > 0)
            {
                MessageBox.Show(MSG.MSG007_010, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登録判定
        /// </summary>
        /// <returns></returns>
        private bool JudgmentInsert()
        {
            DialogResult result = MessageBox.Show("登録を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //登録処理
                if (InsertMaster())
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新判定
        /// </summary>
        /// <returns></returns>
        private bool JudgmentUpdate()
        {
            DialogResult result = MessageBox.Show("更新を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //更新処理
                if (UpdateMaster())
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <returns></returns>
        private bool InsertMaster()
        {
            string start = comU.GetDateTimePick(dtpStart.Value);
            //適用終了日が入力されている場合
            string end = dtpEnd.Value != null
                ? comU.GetDateTimePick(dtpEnd.Value)
                : "99991231";

            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO MST_MENTOR_MENTEE ");
            sql.Append("    (MENTOR_ID ");
            sql.Append("    ,MENTEE_ID ");
            sql.Append("    ,TEKIYO_START_DATE ");
            sql.Append("    ,TEKIYO_END_DATE ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES ");
            sql.Append($"    ('{cboMentor.SelectedValue}' ");
            sql.Append($"    ,'{cboMentee.SelectedValue}' ");
            sql.Append($"    ,{start}");
            sql.Append($"    ,{end} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(User.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

            //実行エラー時
            if (dbUtil.OperationDBTran(sql.ToString(), MSG.MSG003_008) == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <returns></returns>
        private bool UpdateMaster()
        {
            //適用終了日が空白以外の場合
            string end = dtpEnd.Value != null
                ? comU.GetDateTimePick(dtpEnd.Value)
                : "99991231";

            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE MST_MENTOR_MENTEE ");
            sql.Append($"    SET  TEKIYO_END_DATE = {end}");
            sql.Append("     ,    UPD_DT = now() ");
            sql.Append($"    ,    UPD_USER = {comU.CAddQuotation(User.Id)}  ");
            sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_ID = '{_mentorId}'");
            sql.Append($"  AND MENTEE_ID = '{_menteeId}'");
            sql.Append($"  AND TEKIYO_START_DATE = {comU.CReplace(_startDate)}");

            //エラーの場合
            if (dbUtil.OperationDBTran(sql.ToString(), MSG.MSG003_009) == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 削除判定
        /// </summary>
        /// <returns></returns>
        private bool JudgmentDelete()
        {
            DialogResult result = MessageBox.Show("削除を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //削除処理
                if (DeleteMaster())
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns></returns>
        private bool DeleteMaster()
        {
            string start = comU.CReplace(_startDate);

            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM MST_MENTOR_MENTEE ");
            sql.Append($" WHERE MENTOR_ID = '{_mentorId}'");
            sql.Append($" AND MENTEE_ID = '{_menteeId}'");
            sql.Append($" AND TEKIYO_START_DATE = {start}");

            //エラーの場合
            if (dbUtil.OperationDBTran(sql.ToString(), MSG.MSG003_010) == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// メンティ―コンボを設定
        /// </summary>
        private void SetMentee()
        {
            DataSet dataSet = new DataSet();
            //メンティ―取得
            if (!SetMentee(ref dataSet))
            {
                Close();
                return;
            }
            var selectedValue = cboMentee.SelectedValue;
            // コンボボックスにデータテーブルをセット
            cboMentee.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentee.DisplayMember = "MST_SHAIN_NAME";
            // データ用の列を設定
            cboMentee.ValueMember = "MST_SHAIN_CODE";
            //メンティ―コンボが空白の場合
            if (selectedValue == null)
            {
                cboMentee.SelectedValue = "";
                return;
            }
            bool existFlg = false;

            var list = dataSet.Tables[0].AsEnumerable().Where(SHAIN_CODE => SHAIN_CODE.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
                existFlg = true;
            }

            if (!existFlg)
            {
                cboMentee.SelectedValue = "";
            }
        }

        /// <summary>
        /// メンターコンボを設定
        /// </summary>
        private void SetMentor()
        {
            DataSet dataSet = new DataSet();
            //メンターコンボ設定
            if (!SetMentee(ref dataSet))
            {
                Close();
                return;
            }
            var selectedValue = cboMentor.SelectedValue;
            // コンボボックスにデータテーブルをセット
            cboMentor.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            cboMentor.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            cboMentor.ValueMember = "MST_SHAIN_CODE";
            //メンターコンボが空白の場合
            if (selectedValue == null)
            {
                cboMentor.SelectedValue = "";
                return;
            }
            bool existFlg = false;

            var list = dataSet.Tables[0].AsEnumerable().Where(SHAIN_CODE => SHAIN_CODE.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
                existFlg = true;
            }

            if (!existFlg)
            {
                cboMentor.SelectedValue = "";
            }
        }
        #endregion

        #region ボタンイベント
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
        private void MS0020_FormClosing(object sender, FormClosingEventArgs e)
        {
            //未登録で項目が変更変更されている場合
            if (!torokuFlg & ChangeDetection())
            {
                DialogResult result = MessageBox.Show(MSG.MSG005_004, MSG.MSG001_001, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //はい押下時、変更を削除し、マスター一覧画面に戻る
                e.Cancel = result == DialogResult.Yes ? false : true;
            }
        }

        /// <summary>
        /// 登録・更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            //新規の場合
            if (mode.Equals(SyoriMode.INSERT.ToString()))
            {
                //登録チェック
                if (!CheckInsert())
                {
                    return;
                }
                //存在チェック
                if (!CheckExistence())
                {
                    ActiveControl = cboMentor;
                    return;
                }
                //登録判定
                if(!JudgmentInsert())
                {
                    return;
                }
                
                MessageBox.Show(MSG.MSG006_005, MSG.MSG001_001);
                torokuFlg = true;
                Close();
            }
            //更新の場合
            else
            {
                //更新チェック
                if (!CheckUpdate())
                {
                    return;
                }
                //存在チェック
                if (!CheckExistence(true))
                {
                    ActiveControl = dtpEnd;
                    return;
                }
                //更新判定
                if (!JudgmentUpdate())
                {
                    return;
                }
                MessageBox.Show(MSG.MSG006_010, MSG.MSG001_001);
                torokuFlg = true;
                Close();
            }
        }

        /// <summary>
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //削除判定
            if (!JudgmentDelete())
            {
                return;
            }
            MessageBox.Show(MSG.MSG006_009, MSG.MSG001_001);
            torokuFlg = true;
            Close();
        }
        #endregion
    }
}
