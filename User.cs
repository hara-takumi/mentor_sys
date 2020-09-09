using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menter
{
    public class User
    {
        #region メンバー変数
        private string mId;
        private string mName;
        private string mTeamKbn;
        private string mKeiriKbn;
        #endregion

        #region コンストラクタ
        public User(string id, string name)
        {
            mId = id;
            mName = name;
        }
        public User(string id, string name, string teamKbn, string keiriKbn)
        {
            mId = id;
            mName = name;
            mTeamKbn = teamKbn;
            mKeiriKbn = keiriKbn;
        }
        #endregion

        #region プロパティ
        public string Name { get => mName; set => mName = value; }
        public string Id { get => mId; set => mId = value; }
        public string TeamKbn { get => mTeamKbn; set => mTeamKbn = value; }
        public string KeiriKbn { get => mKeiriKbn; set => mKeiriKbn = value; }
        #endregion
    }
}
