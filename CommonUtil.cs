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
        #region メンバー変数
        DBManager dBManager;
        #endregion

        #region メソッド
        /// <summary>
        /// 時間を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CHour()
        {
            List<string>  listHour = Enumerable.Range(0, 24).Select(hour => hour.ToString()).ToList();
            listHour.Insert(0, "");
            return listHour;
        }

        /// <summary>
        /// 分を取得
        /// </summary>
        /// <returns></returns>
        public List<string> CMinute()
        {
            //List<string> listMinute = Enumerable.Range(0, 60).Where(Minute => Minute % 15 == 0)
            //    .Select(Minute => Minute.ToString()).ToList();
            //listMinute.Insert(0, "");
            List<string> listMinute = new List<string>();
            listMinute.Add("");
            for (int i = 0; i < 60; i = i + 15)
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
            DateTime dt = DateTime.Now;
            List<string> listYear = Enumerable.Range(dt.Year - 10, dt.Year + 1)
                .Select(year => year.ToString()).Take(12).ToList();
            //List<string> listYear = new List<string>();
            //DateTime dt = DateTime.Now;
            //string str;
            //for (int i = dt.Year - 10; i <= dt.Year + 1; i++)
            //{
            //    str = Convert.ToString(i);
            //    listYear.Add(str);
            //}
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
            listMonth = Enumerable.Range(1, 12).Select(Month => Month.ToString()).ToList();

            //List<string> listMonth = new List<string>();
            //string str;
            //for (int i = 1; i < 13; i++)
            //{
            //    if (i < 10)
            //    {
            //        str = Convert.ToString(i).PadLeft(2, '0');
            //    }
            //    else
            //    {
            //        str = Convert.ToString(i);
            //    }
            //    listMonth.Add(str);
            //}
            if (brankFlg)
            {
                listMonth.Insert(0, "");
            }
            return listMonth;
        }

        /// <summary>
        /// 文字列を'でくくる
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CAddQuotation(string str) => "'" + str + "'";

        /// <summary>
        /// 文字列の/を削除
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string CReplace(string str) => str.Replace("/", "");

        /// <summary>
        /// DateTimePickerの値から日付を取得
        /// </summary>
        public string GetDateTimePick(DateTime? dateTime)
        {
            //取得した日付がnull以外の場合、年月日を取得
            string result = null;
            result = !string.IsNullOrEmpty(dateTime.ToString())
                ? ((DateTime)dateTime).ToString("yyyyMMdd") : result;

            return result;
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
            catch (MySqlException)
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002);
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
            catch (MySqlException)
            {
                MessageBox.Show(MSG.MSG003_001, MSG.MSG001_002);
                return false;
            }
            finally
            {
                //DBクローズ
                dBManager.Close();
            }

            if (ds.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show(MSG.MSG007_012, MSG.MSG001_002);
                return false;
            }

            try
            {
                //DB接続
                dBManager = new DBManager();
            }
            catch
            {
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002);
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
                MessageBox.Show(MSG.MSG007_012, MSG.MSG001_002);
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
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002);
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
                MessageBox.Show(MSG.MSG007_013, MSG.MSG001_002);
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
                MessageBox.Show(MSG.MSG003_002, MSG.MSG001_002);
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
                MessageBox.Show(MSG.MSG007_013, MSG.MSG001_002);
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

        /// <summary>
        ///     文字列が数値であるかどうかを返します。</summary>
        /// <param name="stTarget">
        ///     検査対象となる文字列。<param>
        /// <returns>
        ///     指定した文字列が数値であれば true。それ以外は false。</returns>
        public bool IsNumeric(string stTarget)
        {
            double dNullable;

            return double.TryParse(
                stTarget,
                System.Globalization.NumberStyles.Any,
                null,
                out dNullable
            );
        }
        #endregion
    }
}