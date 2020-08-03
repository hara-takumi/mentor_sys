using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Menter
{
    class DBManager
    {
        private MySqlConnection sqlConnection;
        private MySqlTransaction sqlTransaction;

        private bool failFlg;

        public bool FailFlg { get => failFlg; set => failFlg = value; }


        /// <summary>
        /// コンストラクタ（DB接続）
        /// </summary>
        public DBManager()
        {

            // 接続文字列を生成
            var connectString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

            // SqlConnection の新しいインスタンスを生成 (接続文字列を指定)
            this.sqlConnection = new MySqlConnection(connectString);


            // データベース接続を開く
            sqlConnection.Open();

        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void Close()
        {
            this.sqlConnection.Close();
            this.sqlConnection.Dispose();
        }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        public void BeginTran()
        {
            this.sqlTransaction = this.sqlConnection.BeginTransaction();
        }

        /// <summary>
        /// トランザクション　コミット
        /// </summary>
        public void CommitTran()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Commit();
                this.sqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// トランザクション　ロールバック
        /// </summary>
        public void RollBack()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Rollback();
                this.sqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// 検索結果を返す
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQuery(string sql, DataSet ds)
        {

            // 実行するSQLの準備
            var command = new MySqlCommand();
            command.Connection = this.sqlConnection;
            command.CommandText = sql;

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            adapter.Fill(dt);

            command.Dispose();

            ds.Tables.Add(dt);

            return ds;
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目なし)
        /// <para name="query">SQL文</para>
        /// </summary>
        public void ExecuteNonQuery(string query)
        {
            MySqlCommand sqlCom = new MySqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = this.sqlConnection;
            sqlCom.Transaction = this.sqlTransaction;

            sqlCom.CommandText = query;

            // SQLを実行
            sqlCom.ExecuteNonQuery();
        }
    }
}
