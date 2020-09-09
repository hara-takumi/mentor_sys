using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menter
{
    public static class CommonConstants
    {
        /// <summary>
        /// 画面モード
        /// </summary>
        public static class ModeKbn
        {
            /// <summary>
            /// メンター
            /// </summary>
            public static readonly int MENTOR_ID = 0;
            public static readonly string MENTOR_NAME = "MENTOR";

            /// <summary>
            /// 推進チーム
            /// </summary>
            public static readonly int SUISINBU_ID = 1;
            public static readonly string SUISINBU_NAME = "SUISINBU";
        }

        /// <summary>
        /// ステータス
        /// </summary>
        public static class Status
        {
            /// <summary>
            /// 未報告
            /// </summary>
            public static readonly string MIHOUKOKU = "0";

            /// <summary>
            /// 報告済み
            /// </summary>
            public static readonly string HOUKOKUZUMI = "1";

            /// <summary>
            /// 差し戻し
            /// </summary>
            public static readonly string SASIMODOSI = "2";
        }

        /// <summary>
        /// フラグ
        /// </summary>
        public static class Flg
        {
            /// <summary>
            /// チェックなし
            /// </summary>
            public static readonly string OFF = "0";

            /// <summary>
            /// チェックあり
            /// </summary>
            public static readonly string ON = "1";
        }
    }
}
