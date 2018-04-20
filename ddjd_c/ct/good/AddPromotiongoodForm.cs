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
using ddjd_c.common.extension;

namespace ddjd_c.ct.good
{
    public partial class AddPromotiongoodForm : Form
    {
        private int? storeAndGoodsId;
        private int rowIndex;
        public UpdateGoodListDelegate UpdateGoodList;
        public AddPromotiongoodForm(int? storeAndGoodsId,int rowIndex)
        {
            this.rowIndex = rowIndex;
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
            if (promotionStartTime.StrIsNull())
            {
                MessageBox.Show("促销开始时间不能为空");
                return;
            }
            if (promotionEndTime.StrIsNull())
            {
                MessageBox.Show("促销结束时间不能为空");
                return;
            }
            if (promotionStock.StrIsNull())
            {
                MessageBox.Show("促销库存不能空");
                return;
            }
            if (promotionMsg.StrIsNull())
            {
                MessageBox.Show("促销信息不能为空");
                return;
            }
            if (DateTime.Compare(this.dtStartTime.Value,this.dtEndTime.Value) > 0)
            {
                MessageBox.Show("促销开始时间不能大于结束时间");
                return;
            }
            JObject obj = service.good.goodService.AddPromotiongoods(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    if (MessageBox.Show("添加成功", "确定", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        UpdateGoodList(1, rowIndex);
                        this.Close();
                    }
                    break;
                case "notExist":
                    MessageBox.Show("商品不存在");
                    break;
                case "exist":
                    MessageBox.Show("商品已加入促销");
                    break;
                case "underStock":
                    MessageBox.Show("库存不足");
                    break;
                default:
                    MessageBox.Show("添加失败");
                    break;
            }
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

        private void txtInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtInfo.Text.Length > 100)
            {
                e.Handled = true;
            }
        }
    }
}
