using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.ScanCode
{
    public partial class frmGuadan : Form
    {
        public frmGuadan()
        {
            InitializeComponent();
        }


        //接收上个窗体对象
        frmScanCode frm = null;
        public frmGuadan( frmScanCode frmScanCode)
        {
            InitializeComponent();
            frm = frmScanCode;
        }


        private void frmGuadan_Load(object sender, EventArgs e)
        {
            ///隐藏数据源自动绑定列
            this.dgvAllGuadan.AutoGenerateColumns = false;
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
