using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menter
{
    class DBUtli
    {
        #region メンバー変数
        DBManager dBManager;
        readonly Logger log = new Logger();
        #endregion

        #region メソッド
        /// <summary>
        /// DBに接続を行う
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet OperationDB(string sql, string msg)
        {
            DataSet ds = new DataSet();
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(msg);
                return null;
            }
            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(msg, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
                return null;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
            return ds;
        }

        /// <summary>
        /// DBに接続を行う
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool OperationDBTran(string sql, string msg)
        {
            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
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
                MessageBox.Show(msg, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Display(ex.ToString());
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
        #endregion
    }
}
