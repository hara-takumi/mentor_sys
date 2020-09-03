using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0010 : UserForm
    {
        CommonUtil comU = new CommonUtil();
        DBManager dBManager;
        public MH0010()
        {
            InitializeComponent();
            txtPw.PasswordChar = '●';
            txtUserCd.Text = "1805";
            txtPw.Text = "2222222222";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserCd.Text))
            {
                MessageBox.Show("ユーザーCDを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserCd.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPw.Text))
            {
                MessageBox.Show("パスワードを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DataSet ds = new DataSet();
                try
                {
                    //DB接続
                    dBManager = new DBManager();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("DB接続に失敗しました。", "エラー");
                    return;
                }
                try
                {
                    dBManager.ExecuteQuery(sql.ToString(), ds);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("SQLの実行に失敗しました。", "エラー");
                    return;
                }
                finally
                {
                    //DBクローズ
                    dBManager.Close();
                }


                if (ds.Tables[0].Rows.Count != 0)
                {
                    //for (int i = 0; i < ds.Tables["Table1"].Rows.Count; i++)
                    //{
                    //    //パスワードハッシュ化
                    //    string hash = comU.GetHashedPassword(txtPw.Text);
                    //    if (ds.Tables["Table1"].Rows[i]["MST_SHAINPW_PASSWORD"].ToString().Equals(hash))
                    //    {
                    //        string id = ds.Tables["Table1"].Rows[i]["MST_SHAIN_CODE"].ToString();
                    //        string name = ds.Tables["Table1"].Rows[i]["MST_SHAIN_NAME"].ToString();
                    //        string teamKbn = ds.Tables["Table1"].Rows[i]["MST_SHAIN_MENTOR_TEAM_KBN"].ToString();
                    //        string keiriKbn = ds.Tables["Table1"].Rows[i]["MST_SHAIN_KEIRI_TANTO_KBN"].ToString();
                    //        User user = new User(id, name, teamKbn, keiriKbn);

                    //        //排他トラン削除
                    //        if (!comU.DeleteHaitaUser(id))
                    //        {
                    //            return;
                    //        }

                    //        MH0020 frm = new MH0020(user);
                    //        frm.Show();
                    //        this.Hide();
                    //        return;
                    //    }
                    //}
                    //パスワードハッシュ化
                    string hash = comU.GetHashedPassword(txtPw.Text);
                    var dataRow = ds.Tables[0].AsEnumerable().Where(r =>r["MST_SHAINPW_PASSWORD"].ToString().Equals(hash)).FirstOrDefault();
                    if(dataRow != null)
                    {
                        string id = dataRow.Field<string>("MST_SHAIN_CODE").ToString();
                        string name = dataRow.Field<string>("MST_SHAIN_NAME").ToString();
                        string teamKbn = dataRow.Field<string>("MST_SHAIN_MENTOR_TEAM_KBN").ToString();
                        string keiriKbn = dataRow.Field<string>("MST_SHAIN_KEIRI_TANTO_KBN").ToString();
                        this.User = new User(id, name, teamKbn, keiriKbn);

                        //排他トラン削除
                        if (!comU.DeleteHaitaUser(id))
                        {
                            return;
                        }

                        MH0020 frm = new MH0020();
                        Send(frm);
                        frm.Show();
                        this.Hide();
                        return;
                    }

                }
                MessageBox.Show("ユーザーCDまたはパスワードが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MH0010_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
