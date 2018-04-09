using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.Order
{
    public partial class frmOrder : Form
    {

        //订单类型； 1 未发货； 2 已发货； 3 已完成
        int orderType = 0;

        public frmOrder()
        {
            InitializeComponent();
        }

        public frmOrder(int orderType_p) {
            InitializeComponent();
            orderType = orderType_p;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            if (orderType != 1) {
                //如果订单类型不是待发货，隐藏发货按钮
                this.btnDeliverGoods.Visible = false;
            }
            
        }
    }
}
