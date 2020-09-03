using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MS0020 : Form
    {
        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        private User user;
        private const int MODE = 0;
        public bool torokuFlg = false;
        DateTime dt = System.DateTime.Now;

        string _mentorId;
        string _mentorNm;
        string _menteeId;
        string _menteeNm;
        string _startDate;
        string _endDate;

        public enum mode
        {
            INSERT,
            UPDATE
        }

        int gmode;
        string programId = "MS0020";

        public MS0020(User user)
        {
            this.user = user;
            InitializeComponent();
            gmode = (int)mode.INSERT;
        }

        public MS0020(User user, string mentorId, string mentorNm, string menteeId, string menteeNm, string start, string end)
        {
            this.user = user;
            _mentorId = mentorId;
            _mentorNm = mentorNm;
            _menteeId = menteeId;
            _menteeNm = menteeNm;
            _startDate = start;
            _endDate = end;

            InitializeComponent();
            gmode = (int)mode.UPDATE;
        }

        private void MS0020_Load(object sender, EventArgs e)
        {
            lblUser.Text = user.Name;
            //新規の場合
            if (gmode == (int)mode.INSERT)
            {
                pnlUpdate.Visible = false;
                btnInsertUpdate.Text = "登録";
                btnDelete.Visible = false;
                SetMentor();
                SetMentee();
                dtpStart.Value = dt;
                dtpEnd.CustomFormat = " ";
                this.ActiveControl = cboMenta;
            }
            else
            {
                DateTime startDate = DateTime.Parse(_startDate);

                pnlUpdate.Visible = true;
                btnInsertUpdate.Text = "更新";
                btnDelete.Visible = true;
                lblMentorNm.Text = _mentorNm;
                lblMenteeNm.Text = _menteeNm;
                lblStart.Text = startDate.ToShortDateString();
                if (_endDate.Equals(""))
                {
                    dtpEnd.CustomFormat = " ";
                }
                else
                {
                    dtpEnd.Value = Convert.ToDateTime(_endDate);
                }
                this.ActiveControl = dtpEnd;
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
        /// コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool setShainCbo(ref DataSet ds)
        {


            //if (!string.IsNullOrEmpty(dtpStart.Value.ToString()))
            //{
            //    DateTime startDate = DateTime.Parse(dtpStart.Value.ToString());
            //    start = startDate.Year.ToString() + String.Format("{0:D2}", startDate.Month) + String.Format("{0:D2}", startDate.Day);
            //}
            //if (!string.IsNullOrEmpty(dtpEnd.Value.ToString()))
            //{
            //    DateTime endDate = DateTime.Parse(dtpEnd.Value.ToString());
            //    end = endDate.Year.ToString() + String.Format("{0:D2}", endDate.Month) + String.Format("{0:D2}", endDate.Day);
            //}
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_SHAIN");
            sql.Append(" WHERE MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
            sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");

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
                MessageBox.Show("社員マスタの取得に失敗しました", "エラー");
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
        private void MS0020_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!torokuFlg & changeDetection())
            {
                DialogResult result = MessageBox.Show("内容が変更されています。\n\r変更は破棄されますが、よろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                }
                else
                {
                    e.Cancel = true;
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
            bool changeFlg = false;
            //新規の場合
            if (gmode == (int)mode.INSERT)
            {
                if (cboMenta.SelectedIndex != -1)
                {
                    changeFlg = true;
                }
                if (cboMentee.SelectedIndex != -1)
                {
                    changeFlg = true;
                }
                if (!dtpStart.Text.Equals(dt.Date.ToString("yyyy/MM/dd")))
                {
                    changeFlg = true;
                }
                if (!dtpEnd.Text.Equals(""))
                {
                    changeFlg = true;
                }
            }
            else
            {
                if (!dtpEnd.Text.Equals(_endDate))
                {
                    changeFlg = true;
                }
            }

                return changeFlg;
        }

        /// <summary>
        /// 登録・更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            
            //新規の場合
            if (gmode == (int)mode.INSERT)
            {
                if (!checkI())
                {
                    return;
                }
                if (!existence())
                {
                    this.ActiveControl = cboMenta;
                    return;
                }
                if(!insertCheck())
                {
                    return;
                }
                
                MessageBox.Show("登録が完了しました。", "");
                torokuFlg = true;
                this.Close();
            }
            else
            {
                if (!checkU())
                {
                    return;
                }
                if (!existence(true))
                {
                    this.ActiveControl = dtpEnd;
                    return;
                }
                if (!updateCheck())
                {
                    return;
                }
                MessageBox.Show("更新が完了しました。", "");
                torokuFlg = true;
                this.Close();
            }
        }

        /// <summary>
        /// 登録入力チェック
        /// </summary>
        /// <returns></returns>
        public bool checkI()
        {
            if (cboMenta.Text.Equals(""))
            {
                MessageBox.Show("メンターを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMenta;
                return false;
            }
            if (cboMentee.Text.Equals(""))
            {
                MessageBox.Show("メンティ―を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMentee;
                return false;
            }
            if (cboMenta.Text.Equals(cboMentee.Text))
            {
                MessageBox.Show("メンターとメンティーは別ユーザーを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = cboMenta;
                return false;
            }
            if (dtpStart.Text.Equals(""))
            {
                MessageBox.Show("適用開始日を入力して下さい", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = dtpStart;
                return false;
            }

            if (!dtpEnd.Text.Equals(""))
            {
                string yyyyMMfrom = dtpStart.Text;
                string yyyyMMto = dtpEnd.Text;
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show("適用日が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = dtpStart;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 更新入力チェック
        /// </summary>
        /// <returns></returns>
        public bool checkU()
        {
            string yyyyMMfrom = lblStart.Text;
            string yyyyMMto = dtpEnd.Value.ToString();
            if (!dtpEnd.Text.Equals(""))
            {
                if (yyyyMMfrom.CompareTo(yyyyMMto) == 1)
                {
                    MessageBox.Show("適用日が逆転しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = dtpEnd;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 存在チェック
        /// </summary>
        /// <returns></returns>
        public bool existence(bool updFlg = false)
        {
            string start;
            string end;
            string menta;
            string mentee;
            if (dtpEnd.Text.Equals(""))
            {
                end = "99991231";
            }
            else
            {
                end = getDateTimePick(dtpEnd.Value);
            }
            if (gmode == (int)mode.INSERT)
            {
                start = getDateTimePick(dtpStart.Value);

                menta = cboMenta.SelectedValue.ToString();
                mentee = cboMentee.SelectedValue.ToString();

            }
            else
            {
                start = comU.CReplace(_startDate);
                menta = _mentorId;
                mentee = _menteeId;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     COUNT(*)");
            sql.Append(" FROM MST_MENTOR_MENTEE");

            sql.Append($" WHERE TEKIYO_END_DATE >= '{start}'");
            if (dtpEnd.Text != " ")
            {
                sql.Append($"   AND  TEKIYO_START_DATE <= '{end}'");
            }
            sql.Append($"   AND MENTOR_ID = '{menta}'");
            sql.Append($"   AND MENTEE_ID = '{mentee}'");
            //自分は含めない
            if (updFlg)
            {
                sql.Append($"   AND  (MENTOR_ID != '{menta}'");
                sql.Append($"    OR  MENTEE_ID != '{mentee}'");
                sql.Append($"    OR  TEKIYO_START_DATE != '{start}')");
            }

            StringBuilder sqlOther = new StringBuilder();
            sqlOther.Append(" SELECT ");
            sqlOther.Append("     COUNT(*)");
            sqlOther.Append(" FROM MST_MENTOR_MENTEE");

            sqlOther.Append($" WHERE TEKIYO_END_DATE >= '{start}'");
            if (dtpEnd.Text != " ")
            {
                sqlOther.Append($"   AND  TEKIYO_START_DATE <= '{end}'");
            }
            sqlOther.Append($"   AND (MENTOR_ID = '{menta}'");
            sqlOther.Append($"   OR MENTOR_ID = '{mentee}'");
            sqlOther.Append($"   OR MENTEE_ID = '{menta}'");
            sqlOther.Append($"   OR MENTEE_ID = '{mentee}')");
            //自分は含めない
            if (updFlg)
            {
                sqlOther.Append($"   AND  (MENTOR_ID != '{menta}'");
                sqlOther.Append($"    OR  MENTEE_ID != '{mentee}'");
                sqlOther.Append($"    OR  TEKIYO_START_DATE != '{start}')");
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
                return false;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
                dBManager.ExecuteQuery(sqlOther.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("SQLの実行に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            long count = (long)ds.Tables["Table1"].Rows[0]["COUNT(*)"];
            long countOther = (long)ds.Tables["Table2"].Rows[0]["COUNT(*)"];

            if (count > 0)
            {
                MessageBox.Show("入力したメンターメンティーマスタは既に登録されています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else if (countOther > 0)
            {
                MessageBox.Show("入力した適用日内に既にメンターまたは、メンティーが登録されています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }


        /// <summary>
        /// 登録チェック
        /// </summary>
        /// <returns></returns>
        public bool insertCheck()
        {
            DialogResult result = MessageBox.Show("登録を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (MInsert())
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
        /// 更新チェック
        /// </summary>
        /// <returns></returns>
        public bool updateCheck()
        {
            DialogResult result = MessageBox.Show("更新を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (MUpdate())
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
        private bool MInsert()
        {
            string start = getDateTimePick(dtpStart.Value);
            string end = "99991231";
            if (!dtpEnd.Text.Equals(""))
            {
                end = getDateTimePick(dtpEnd.Value);
            }


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
            sql.Append($"    ('{cboMenta.SelectedValue}' ");
            sql.Append($"    ,'{cboMentee.SelectedValue}' ");
            sql.Append($"    ,{start}");
            sql.Append($"    ,{end} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{comU.CAddQuotation(user.Id)} ");
            sql.Append($"    ,{comU.CAddQuotation(programId)}) ");

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
                dBManager.BeginTran();
                dBManager.ExecuteNonQuery(sql.ToString());
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンティー・メンターマスタメンテナンスの登録処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 更新処理
        /// </summary>
        /// <returns></returns>
        private bool MUpdate()
        {
            //string start;
            //if (dtpStart.Text.Equals(""))
            //{
            //    start = "";
            //}
            //else
            //{
            //    DateTime startDate = DateTime.Parse(dtpStart.Text);
            //    start = startDate.Year.ToString() + String.Format("{0:D2}", startDate.Month) + String.Format("{0:D2}", startDate.Day);
            //}

            string end;
            if (dtpEnd.Text.Equals(""))
            {
                end = "99991231";
            }
            else
            {
                end = getDateTimePick(dtpEnd.Value);
            }
            
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE MST_MENTOR_MENTEE ");

            sql.Append($"    SET  TEKIYO_END_DATE = {end}");
            sql.Append("     ,    UPD_DT = now() ");
            sql.Append($"    ,    UPD_USER = {comU.CAddQuotation(user.Id)}  ");
            sql.Append($"    ,    UPD_PGM = {comU.CAddQuotation(programId)}  ");
            sql.Append($" WHERE MENTOR_ID = '{_mentorId}'");
            sql.Append($"  AND MENTEE_ID = '{_menteeId}'");
            sql.Append($"  AND TEKIYO_START_DATE = '{_startDate}'");

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
                dBManager.BeginTran();
                dBManager.ExecuteNonQuery(sql.ToString());
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンティー・メンターマスタメンテナンスの更新処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!deleteCheck())
            {
                return;
            }
            MessageBox.Show("削除が完了しました。", "");
            torokuFlg = true;
            this.Close();
        }

        /// <summary>
        /// 削除チェック
        /// </summary>
        /// <returns></returns>
        public bool deleteCheck()
        {
            DialogResult result = MessageBox.Show("削除を行います。よろしいでしょうか。", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (MDelete())
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
        private bool MDelete()
        {
            DateTime startDate = DateTime.Parse(_startDate);

            string start = startDate.Year.ToString() + String.Format("{0:D2}", startDate.Month) + String.Format("{0:D2}", startDate.Day);

            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM MST_MENTOR_MENTEE ");
            sql.Append($" WHERE MENTOR_ID = '{_mentorId}'");
            sql.Append($" AND MENTEE_ID = '{_menteeId}'");
            sql.Append($" AND TEKIYO_START_DATE = '{start}'");

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
                dBManager.BeginTran();
                dBManager.ExecuteNonQuery(sql.ToString());
                dBManager.CommitTran();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("メンティー・メンターマスタメンテナンスの削除処理に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public void SetMentee()
        {
            DataSet dataSet = new DataSet();
            if (!setShainCbo(ref dataSet))
            {
                this.Close();
                return;
            }
            var selectedValue = cboMentee.SelectedValue;
            // コンボボックスにデータテーブルをセット
            this.cboMentee.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cboMentee.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMentee.ValueMember = "MST_SHAIN_CODE";
            if (selectedValue == null)
            {
                cboMentee.SelectedValue = -1;
                return;
            }
            bool existFlg = false;

            var list = dataSet.Tables[0].AsEnumerable().Where(x => x.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
                existFlg = true;
            }

            //foreach (DataRow ds in dataSet.Tables[0].Rows)
            //{
            //    if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
            //    {
            //        cboMentee.SelectedValue = selectedValue;
            //        existFlg = true;
            //        break;
            //    }
            //}
            if (!existFlg)
            {
                cboMentee.SelectedValue = -1;
            }

        }

        public void SetMentor()
        {
            DataSet dataSet = new DataSet();
            if (!setShainCbo(ref dataSet))
            {
                this.Close();
                return;
            }
            var selectedValue = cboMenta.SelectedValue;
            // コンボボックスにデータテーブルをセット
            this.cboMenta.DataSource = dataSet.Tables[0];
            // 表示用の列を設定
            this.cboMenta.DisplayMember = "MST_SHAIN_NAME";
            //// データ用の列を設定
            this.cboMenta.ValueMember = "MST_SHAIN_CODE";
            if (selectedValue ==null)
            {
                cboMenta.SelectedValue = -1;
                return;
            }
            bool existFlg = false;

            var list = dataSet.Tables[0].AsEnumerable().Where(x => x.Field<string>("MST_SHAIN_CODE").Equals(selectedValue)).FirstOrDefault();
            if (list != null)
            {
                cboMentee.SelectedValue = list.Field<string>("MST_SHAIN_CODE");
                existFlg = true;
            }

            //foreach (DataRow ds in dataSet.Tables[0].Rows)
            //{
            //    if (selectedValue.Equals(ds["MST_SHAIN_CODE"]))
            //    {
            //        cboMenta.SelectedValue = selectedValue;
            //        existFlg = true;
            //        break;
            //    }
            //}
            if (!existFlg)
            {
                cboMenta.SelectedValue = -1;
            }
        }

    }
}
