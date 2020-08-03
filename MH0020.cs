using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0020 : Form
    {
        private User user;
        DBManager dBManager;
        public MH0020(User user)
        {
            this.user = user;
            InitializeComponent();

        }
        private void Initialization()
        {
            if (!isMentor())
            {
                btnIchiranMentor.Visible = false;
            }
            if (string.IsNullOrEmpty(user.TeamKbn) || user.TeamKbn == "0")
            {
                btnIchiranTeam.Visible = false;
                btnMasta.Visible = false;
            }
            if (string.IsNullOrEmpty(user.KeiriKbn) || user.KeiriKbn == "0")
            {
                btnKrihiShokai.Visible = false;
            }
        }

        public bool isMentor()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     MST_SHAIN_CODE");
            sql.Append("     ,MST_SHAIN_NAME");
            sql.Append(" FROM MST_MENTOR_MENTEE");
            sql.Append(" LEFT JOIN mst_shain");
            sql.Append("   ON MENTOR_ID = MST_SHAIN_CODE");
            sql.Append($" WHERE MENTOR_ID = '{user.Id}'");

            //sql.Append($" AND MST_SHAIN_TEKIYO_DATE_END >= CURDATE()");
            //sql.Append($" AND TEKIYO_END_DATE >= CURDATE()");
            //sql.Append($" AND MST_SHAIN_TEKIYO_DATE_STR <= CURDATE()");
            //sql.Append($" AND TEKIYO_START_DATE <= CURDATE()");

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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("SQLの取得に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            if(ds.Tables["Table1"].Rows.Count == 0)
            {
                return false;
            }

            return true;
        }


        private void btnIchiranMentor_Click(object sender, EventArgs e)
        {
            int teamMode = 0;
            MH0030 frm = new MH0030(user, teamMode);
            frm.Show();
        }
        private void btnMenta_Click(object sender, EventArgs e)
        {
            MS0010 frm = new MS0010(user);
            frm.Show();
        }


        private void btnIchiranTeam_Click(object sender, EventArgs e)
        {
            int teamMode = 1;
            MH0030 frm = new MH0030(user, teamMode);
            frm.Show();
        }

        private void btnKrihiShokai_Click(object sender, EventArgs e)
        {
            MH0050 frm = new MH0050(user);
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MH0010 frm = new MH0010();
            frm.Show();
            this.Close();
        }

        private void MH0020_Load(object sender, EventArgs e)
        {

            Initialization();
        }
    }
}
