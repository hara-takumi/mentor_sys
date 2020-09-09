using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menter
{
    public class Mode
    {
        #region メンバー変数
        private int mId;
        private string mName;
        #endregion

        #region コンストラクタ
        public Mode(int id , string name)
        {
            mId = id;
            mName = name;
        }
        #endregion

        #region プロパティ
        public int Id { get => mId; set => mId = value; }
        public string Name { get => mName; set => mName = value; }
        #endregion
    }
}
