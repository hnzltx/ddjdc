using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.service;
using Newtonsoft.Json.Linq;

namespace ddjd_c.ct.good
{
    public partial class AddPromotiongoodForm : Form
    {
        private int? storeAndGoodsId;
        public AddPromotiongoodForm(int? storeAndGoodsId)
        {
            this.storeAndGoodsId = storeAndGoodsId;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string promotionMsg = this.txtInfo.Text;
            string promotionStock = this.txtStock.Text;
            string promotionStartTime = this.dtStartTime.Text;
            string promotionEndTime = this.dtEndTime.Text;
            Dictionary<string,object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId", storeAndGoodsId);
            dic.Add("storeId",GlobalsInfo.storeId);
            dic.Add("promotionStartTime", promotionStartTime);
            dic.Add("promotionEndTime", promotionEndTime);
            dic.Add("promotionMsg", promotionMsg);
            dic.Add("promotionStock", promotionStock);
            JObject obj = service.good.goodService.AddPromotiongoods(dic);
            string success = obj["success"].ToString();

        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
    }
}
