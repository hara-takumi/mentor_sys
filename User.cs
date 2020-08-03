using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menter
{
    public class User
    {
        string mId;
        string mName;
        string mTeamKbn;
        string mKeiriKbn;
        public User()
        {
        }
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
        public string Name
        {
            set
            {
                mName = value;
            }
            get
            {
                return mName;
            }
        }

        public string Id
        {
            set
            {
                mId = value;
            }
            get
            {
                return mId;
            }
        }
        public string TeamKbn
        {
            set
            {
                mTeamKbn = value;
            }
            get
            {
                return mTeamKbn;
            }
        }
        public string KeiriKbn
        {
            set
            {
                mKeiriKbn = value;
            }
            get
            {
                return mKeiriKbn;
            }
        }

    }
}
