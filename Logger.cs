using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menter
{
    class Logger
    {
        #region メンバー変数
        private readonly string logFilePath = null;
        private readonly object lockObj = new object();
        private StreamWriter stream;
        DateTime dt = DateTime.Now;
        //App.configからファイルパスを取得
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["filepath"].ConnectionString;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Logger()
        {
            string date = dt.ToString("yyyyMMdd");
            logFilePath = date + ".log";

            // ログファイルを生成する
            CreateLogfile(new FileInfo(logFilePath));
        }
        #endregion

        #region メソッド
        /// <summary>
        /// ログを表示する
        /// </summary>
        /// <param name="msg"></param>
        public void Display(string msg)
        {
            string fullMsg = string.Format("[{0}]{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
            lock (lockObj)
            {
                stream = new StreamWriter(connectionString + logFilePath, true, Encoding.UTF8)
                {
                    AutoFlush = false
                };
                stream.WriteLine(fullMsg);
                stream.Close();
            }
        }

        /// <summary>
        /// ログファイルを生成する
        /// </summary>
        /// <param name="logFile">ファイル情報</param>
        private void CreateLogfile(FileInfo logFile)
        {
            if (!File.Exists(connectionString + logFile))
            {
                stream = new StreamWriter(connectionString + logFile, true, Encoding.UTF8)
                {
                    AutoFlush = false
                };
                stream.Close();
            }
        }
        #endregion
    }
}
