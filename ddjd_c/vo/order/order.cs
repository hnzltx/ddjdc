using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.order
{
    /// <summary>
    /// 订单基本信息
    /// </summary>
    class order
    {
        private int orderId;
        private string addTime;
        private string orderPrice;
        private string orderOriginalPrice;

        public int OrderId { get => orderId; set => orderId = value; }
        public string AddTime { get => addTime; set => addTime = value; }
        public string OrderPrice { get => orderPrice; set => orderPrice = value; }
        public string OrderOriginalPrice { get => orderOriginalPrice; set => orderOriginalPrice = value; }
    }
}
