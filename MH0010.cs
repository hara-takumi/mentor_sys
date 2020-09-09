using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0010 : BaseForm
    {
        #region メンバー変数
        private readonly CommonUtil comU = new CommonUtil();
        private readonly DBUtli dbUtil = new DBUtli();
        private readonly Logger log = new Logger();
        private bool initialFlg = true;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MH0010()
        {
            InitializeComponent();
            txtUserCd.Text = "1111";
            txtPw.Text = "6666666666";
            log.Display("処理開始");
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// ログインボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //ログインCDが空欄の場合
            if (string.IsNullOrEmpty(txtUserCd.Text))
            {
                MessageBox.Show(MSG.MSG002_001, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(MSG.MSG002_001);
                txtUserCd.Focus();
                return;
            }
            //パスワードが空欄の場合
            else if (string.IsNullOrEmpty(txtPw.Text))
            {
                MessageBox.Show(MSG.MSG002_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(MSG.MSG002_002);
                txtPw.Focus();
                return;
            }
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     MST_SHAIN_CODE");
                sql.Append("    ,MST_SHAIN_NAME");
                sql.Append("    ,MST_SHAINPW_PASSWORD");
                sql.Append("    ,MST_SHAIN_MENTOR_TEAM_KBN");
                sql.Append("    ,MST_SHAIN_KEIRI_TANTO_KBN");
                sql.Append(" FROM mst_shain");
                sql.Append(" LEFT JOIN mst_shainpw");
                sql.Append("   ON MST_SHAIN_CODE = MST_SHAINPW_CODE");
                sql.Append($" WHERE MST_SHAIN_CODE = '{txtUserCd.Text}'");
                sql.Append(" AND MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
                sql.Append(" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");
                sql.Append($" AND MST_SHAINPW_GENERAITON = (select MAX(MST_SHAINPW_GENERAITON) from mst_shainpw WHERE MST_SHAINPW_CODE = '{txtUserCd.Text}')");

                //SQL処理
                DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
                //実行エラー時
                if(ds == null) return;
                //ユーザーを取得した場合
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string id = "";
                    string name = "";
                    string teamKbn = "";
                    string keiriKbn = "";
                    //パスワードハッシュ化
                    string hash = comU.GetHashedPassword(txtPw.Text);
                    //登録されているパスワードとハッシュ化したパスワードが一致する場合
                    Enumerable.Range(0, ds.Tables[0].Rows.Count).Select(idx => ds.Tables[0].Rows[idx] as DataRow)
                        .Where(dr => dr["MST_SHAINPW_PASSWORD"].Equals(hash)).ToList()
                        .ForEach(dr => {
                            id = dr["MST_SHAIN_CODE"].ToString();
                            name = dr["MST_SHAIN_NAME"].ToString();
                            teamKbn = dr["MST_SHAIN_MENTOR_TEAM_KBN"].ToString();
                            keiriKbn = dr["MST_SHAIN_KEIRI_TANTO_KBN"].ToString();
                        });
                    User = new User(id, name, teamKbn, keiriKbn);
                    //メニュー画面に遷移
                    MH0020 frm = new MH0020();
                    Show(frm);
                    Hide();
                }
                else
                {
                    MessageBox.Show(MSG.MSG002_003, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Display(MSG.MSG002_003);
                }
            }
        }

        /// <summary>
        /// ✕ボタンの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MH0010_FormClosing(object sender, FormClosingEventArgs e)
        {
            //初期化時は通らない
            if (initialFlg)
            {
                log.Display("処理終了\n");
                initialFlg = false;
                Application.Exit();
            }
        }
        #endregion
    }
}
