using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menter
{
    public partial class MH0041 : Form
    {
        #region メンバー変数
        private string reason;
        private bool inputFlg = false;
        #endregion

        #region プロパティ
        /// <summary>
        /// 差し戻しフラグと理由を渡す
        /// </summary>
        public string Reason { get => reason; set => reason = value; }
        public bool InputFlg { get => inputFlg; set => inputFlg = value; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MH0041()
        {
            InitializeComponent();
        }
        #endregion

        #region ボタンイベント
        /// <summary>
        /// 登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToroku_Click(object sender, EventArgs e)
        {
            //報告が入力されていない場合
            if (string.IsNullOrEmpty(txtReason.Text))
            {
                MessageBox.Show(MSG.MSG007_003, MSG.MSG001_002, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inputFlg = true;
            reason = txtReason.Text;
            Close();
        }

        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
