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
    public partial class BaseForm : Form
    {
        #region メンバー変数
        private User user;
        private Mode mode;
        #endregion

        #region プロパティ
        public User User { get => user; set => user = value; }
        public Mode Mode { get => mode; set => mode = value; }
        #endregion

        #region コンストラクタ
        public BaseForm()
        {
            InitializeComponent();
        }
        #endregion

        #region メソッド
        public void Show(BaseForm form)
        {
            form.User = this.user;
            form.Mode = this.mode;
            form.Show();
        }
        public void ShowDialog(BaseForm form)
        {
            form.User = this.user;
            form.Mode = this.mode;
            form.ShowDialog();
        }
        #endregion
    }
}
