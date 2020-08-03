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
        public string reason;
        public bool inputFlg = false;
        public MH0041()
        {
            InitializeComponent();
        }

        private void btnToroku_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReason.Text)){
                MessageBox.Show("差戻し理由を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inputFlg = true;
            reason = txtReason.Text;
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
