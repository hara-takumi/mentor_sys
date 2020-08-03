using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menter
{
    class CommonUtil
    {
        DBManager dBManager;





        /// <summary>
        /// 時間を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CHour()
        {
            List<string> listHour = new List<string>();
            listHour.Add("");
            for (int i = 0; i < 24; i++)
            {
                listHour.Add(i.ToString());
            }

            return listHour;
        }

        /// <summary>
        /// 分を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CMinute()
        {
            List<string> listMinute = new List<string>();
            listMinute.Add("");
            for (int i = 0; i < 60; i= i+15)
            {
                listMinute.Add(i.ToString("D2"));
            }

            return listMinute;
        }

        /// <summary>
        /// 年を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CYear(bool brankFlg)
        {
            List<string> listYear = new List<string>();
            DateTime dt = System.DateTime.Now;
            string str;
            for (int i = dt.Year - 10; i <= dt.Year + 1; i++)
            {
                str = Convert.ToString(i);
                listYear.Add(str);
            }
            if (brankFlg)
            {
                listYear.Insert(0, "");
            }
            return listYear;
        }

        /// <summary>
        /// 月を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CMonth(bool brankFlg)
        {
            List<string> listMonth = new List<string>();
            string str;
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    str = Convert.ToString(i).PadLeft(2, '0');
                }
                else
                {
                    str = Convert.ToString(i);
                }
                listMonth.Add(str);
            }
            if (brankFlg)
            {
                listMonth.Insert(0, "");
            }
            return listMonth;
        }

        /// <summary>
        /// 業務コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool CGyomu(ref DataSet ds, bool allFlg)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     CD");
                sql.Append("    ,NAME");
                sql.Append(" FROM mst_gyomu");
                sql.Append(" WHERE ");
                sql.Append(" DEL_FLG = 0 ");
                sql.Append(" ORDER BY ");
                sql.Append(" HYOJI_JUN ");
                var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

                // データベース接続の準備
                var connection = new MySqlConnection(connectionString);

                // データベースの接続開始
                connection.Open();

                // 実行するSQLの準備
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = sql.ToString();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(dt);

                command.Dispose();

                connection.Close();
                connection.Dispose();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("業務マスタが登録されていません。\n\r業務マスタの登録を行ってください。", "エラー");
                    return false;
                }

                if (allFlg)
                {

                    DataRow row = dt.NewRow();
                    row["CD"] = "0";
                    row["NAME"] = "すべて";
                    dt.Rows.InsertAt(row, 0);
                }

                ds.Tables.Add(dt);

                return true;

            }
            catch (MySqlException me)
            {
                MessageBox.Show("DBの接続に失敗しました。", "エラー");
                return false;
            }
        }


        /// <summary>
        /// 作業コンボボックス設定
        /// </summary>
        /// <returns></returns>
        public bool CSagyo(ref DataSet ds, string gyomuCd)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ");
                sql.Append("     CD");
                sql.Append("    ,NAME");
                sql.Append(" FROM mst_SAGYO");
                sql.Append(" WHERE ");
                sql.Append(" DEL_FLG = 0 ");
                sql.Append(" AND ");
                sql.Append($" GYOMU_CD = {gyomuCd} ");
                sql.Append(" ORDER BY ");
                sql.Append(" HYOJI_JUN ");
                var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

                // データベース接続の準備
                var connection = new MySqlConnection(connectionString);

                // データベースの接続開始
                connection.Open();

                // 実行するSQLの準備
                var command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = sql.ToString();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(dt);

                command.Dispose();

                connection.Close();
                connection.Dispose();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("作業マスタが登録されていません。\n\r作業マスタの登録を行ってください。", "エラー");
                    return false;
                }


                ds.Tables.Add(dt);

                return true;

            }
            catch (MySqlException me)
            {
                MessageBox.Show("DBの接続に失敗しました。", "エラー");
                return false;
            }
        }




        /// <summary>
        /// 文字列を'でくくる
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CAddQuotation(string str)
        {
            return "'" + str + "'";
        }

        /// <summary>
        /// 文字列の/を削除
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CReplace(string str)
        {
            return str.Replace("/", "");
        }

        /// <summary>
        /// 排他登録
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uId"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public bool InsertHaitaTrn(string id, string uId,string pId)
        {
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

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ");
            sql.Append("     *");
            sql.Append(" FROM trn_haita");
            sql.Append($" WHERE MENTOR_RESULT_ID = {id}");
            DataSet ds = new DataSet();

            try
            {
                dBManager.ExecuteQuery(sql.ToString(), ds);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("SQLの実行に失敗しました。", "エラー");
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            if (ds.Tables["Table1"].Rows.Count != 0)
            {
                MessageBox.Show("他のユーザーが編集中です。", "エラー");
                return false;
            }

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー");
                return false;
            }

            sql = new StringBuilder();
            sql.Append(" INSERT INTO TRN_HAITA ");
            sql.Append("    (MENTOR_RESULT_ID ");
            sql.Append("    ,USER ");
            sql.Append("    ,INS_DT ");
            sql.Append("    ,INS_USER ");
            sql.Append("    ,INS_PGM ");
            sql.Append("    ,UPD_DT ");
            sql.Append("    ,UPD_USER ");
            sql.Append("    ,UPD_PGM) ");
            sql.Append(" VALUES ");
            sql.Append($"    ('{id}' ");
            sql.Append($"    ,{uId} ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{uId} ");
            sql.Append($"    ,'{pId}' ");
            sql.Append("    ,now() ");
            sql.Append($"    ,{uId} ");
            sql.Append($"    ,'{pId}') ");

            try
            {
                //SQL実行
                dBManager.ExecuteNonQuery(sql.ToString());
                return true;
            }
            catch
            {
                MessageBox.Show("他のユーザーが編集中です。", "エラー");
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
        }

        /// <summary>
        /// 削除排他
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteHaitaTrn(string id)
        {

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー");
                return false;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_HAITA ");
            sql.Append($" WHERE MENTOR_RESULT_ID = {id}");
            try
            {
                //SQL実行
                dBManager.ExecuteNonQuery(sql.ToString());
                return true;
            }
            catch
            {
                MessageBox.Show("排他テーブルの削除に失敗しました。", "エラー");
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
        }

        /// <summary>
        /// ユーザー排他削除
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="command"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteHaitaUser(string user)
        {


            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch
            {
                MessageBox.Show("DB接続に失敗しました。", "エラー");
                return false;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM TRN_HAITA ");
            sql.Append($" WHERE USER = '{user}'");
            try
            {
                //SQL実行
                dBManager.ExecuteNonQuery(sql.ToString());
                return true;
            }
            catch
            {
                MessageBox.Show("排他テーブルの削除に失敗しました。", "エラー");
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }
        }

        /// <summary>
        /// パスワードハッシュ化
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetHashedPassword(string passwd)
        {
            // パスワードをUTF-8エンコードでバイト配列として取り出す
            byte[] byteValues = Encoding.UTF8.GetBytes(passwd);

            // SHA256のハッシュ値を計算する
            SHA256 crypto256 = new SHA256CryptoServiceProvider();
            byte[] hash256Value = crypto256.ComputeHash(byteValues);

            // SHA256の計算結果をUTF8で文字列として取り出す
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < hash256Value.Length; i++)
            {
                // 16進の数値を文字列として取り出す
                buf.AppendFormat("{0:X2}", hash256Value[i]);
            }
            return buf.ToString();

        }
    }
}