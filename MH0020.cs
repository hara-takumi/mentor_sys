using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0020 : BaseForm
    {
        #region メンバー変数
        private readonly DBUtli dbUtil = new DBUtli();
        private bool errorFlg = true;
        private bool returnFlg = true;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MH0020()
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
        #endregion

        #region メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialization()
        {
            //ログインユーザーがメンター登録されていない場合
            if (!GetMentor())
            {
                if (errorFlg)
                {
                    //メンター活動実績入力画面遷移ボタンを非表示
                    btnIchiranMentor.Visible = false;
                }
            }
            //メンター推進チーム区分が空白または、0の場合
            if (string.IsNullOrEmpty(User.TeamKbn) || User.TeamKbn == CommonConstants.ModeKbn.MENTOR_ID.ToString())
            {
                //メンター活動実績確認画面遷移ボタンを非表示
                //メンター・メンティーマスタメンテナンスボタンを非表示
                btnIchiranTeam.Visible = false;
                btnMasta.Visible = false;
            }
            //経理担当区分が空白または、0の場合
            if (string.IsNullOrEmpty(User.KeiriKbn) || User.KeiriKbn == CommonConstants.ModeKbn.MENTOR_ID.ToString())
            {
                //メンター活動経費照会画面遷移ボタンを非表示
                btnKrihiShokai.Visible = false;
            }
        }

        /// <summary>
        /// ログインユーザーのメンターを取得
        /// </summary>
        /// <returns></returns>
        private bool GetMentor()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append($" WHERE MENTOR_ID = '{User.Id}'");

            DataSet ds = dbUtil.OperationDB(sql.ToString(), MSG.MSG003_001);
            //SQL実行エラーの場合
            returnFlg = ds != null ? true : false;
            errorFlg = returnFlg;
            //取得結果が0件の場合
            if (returnFlg)
            {
                returnFlg = ds.Tables[0].Rows.Count != 0 ? true : false;
            }

            return returnFlg;
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// メンター活動実績入力画面遷移ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIchiranMentor_Click(object sender, EventArgs e)
        {
            Mode = new Mode(CommonConstants.ModeKbn.MENTOR_ID, CommonConstants.ModeKbn.MENTOR_NAME);
            MH0030 mh0030 = new MH0030();
            Show(mh0030);
        }

        /// <summary>
        /// メンター活動実績確認画面遷移ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIchiranTeam_Click(object sender, EventArgs e)
        {
            Mode = new Mode(CommonConstants.ModeKbn.SUISINBU_ID, CommonConstants.ModeKbn.SUISINBU_NAME);
            MH0030 mh0030 = new MH0030();
            Show(mh0030);
        }

        /// <summary>
        /// メンター活動経費照会画面遷移ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKrihiShokai_Click(object sender, EventArgs e)
        {
            MH0050 mh0050 = new MH0050();
            Show(mh0050);
        }

        /// <summary>
        /// ログアウトボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MH0010 mh0010 = new MH0010();
            mh0010.Show();
            Close();
        }

        /// <summary>
        /// メンター・メンティーマスタメンテナンス遷移ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMasta_Click(object sender, EventArgs e)
        {
            MS0010 ms0010 = new MS0010();
            Show(ms0010);
        }
        #endregion
    }
}
