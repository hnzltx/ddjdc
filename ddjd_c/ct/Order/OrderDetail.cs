using Newtonsoft.Json.Linq;
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
    public partial class OrderDetail : Form
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            JObject json =  service.order_service.orderService.queryStoreOrderInfoDetails(this.Tag.ToString());
            if (json["orderInfoDetails"] != null)
            {
                model.order.order order = common.JsonHelper.DeserializeJsonToObject<model.order.order>(json["orderInfoDetails"].ToString());
                List<vo.order.orderInfoGoodsDetails> orderDetailList = common.JsonHelper.DeserializeJsonToList<vo.order.orderInfoGoodsDetails>(json["orderInfoGoodsListDetails"].ToString());
                
                if (order != null || orderDetailList.Count > 0)
                {
                    this.lblAddTime.Text = order.AddTime;
                    this.lblFinishedTime.Text = order.FinishedTime;
                    this.lblShipTime.Text = order.ShipTime;
                    this.lblOrderOriginalPrice.Text = order.OrderOriginalPrice;
                    this.lblOrderPrice.Text = order.OrderPrice;
                    this.lblPayMessage.Text = order.PayMessage;
                    this.lblShipaddress.Text = order.Shipaddress + "(" + order.ShippName + "[" + order.Tel + "])";


                    this.dgvGoodsDetail.AutoGenerateColumns = false;
                    this.dgvGoodsDetail.DataSource = orderDetailList;
                }
                else {
                    MessageBox.Show("没有查询到此订单的数据!");
                    this.Close();
                }
            }
            else {
                MessageBox.Show("没有查询到此订单的数据!");
                this.Close();
            }
        }
    }
}
