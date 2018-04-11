using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.model.order
{
    /// <summary>
    /// 订单实体
    /// </summary>
    class order
    {
        private int orderId;
        private string orderSN;
        private int? storeId;
        private int? memberId;
        private string orderPrice;
        private string orderOriginalPrice;
        private int? goodsAmount;
        private int? orderStatus;
        private string addTime;
        private string payTime;
        private string shipTime;
        private string finishedTime;
        private string payMessage;
        private int? platform;
        private int? payType;
        private int? settlementStatu;
        private string shipaddress;
        private string shippName;
        private string tel;
        private string invalidTime;
        private int? orderType;
        private int? partnerPayStatu;
        private string partnerPayMoney;
        private int? substationId;
        private string lat;
        private string lon;

        public int OrderId { get => orderId; set => orderId = value; }
        public string OrderSN { get => orderSN; set => orderSN = value; }
        public int? StoreId { get => storeId; set => storeId = value; }
        public int? MemberId { get => memberId; set => memberId = value; }
        public string OrderPrice { get => orderPrice; set => orderPrice = value; }
        public string OrderOriginalPrice { get => orderOriginalPrice; set => orderOriginalPrice = value; }
        public int? GoodsAmount { get => goodsAmount; set => goodsAmount = value; }
        public int? OrderStatus { get => orderStatus; set => orderStatus = value; }
        public string AddTime { get => addTime; set => addTime = value; }
        public string PayTime { get => payTime; set => payTime = value; }
        public string ShipTime { get => shipTime; set => shipTime = value; }
        public string FinishedTime { get => finishedTime; set => finishedTime = value; }
        public string PayMessage { get => payMessage; set => payMessage = value; }
        public int? Platform { get => platform; set => platform = value; }
        public int? PayType { get => payType; set => payType = value; }
        public int? SettlementStatu { get => settlementStatu; set => settlementStatu = value; }
        public string Shipaddress { get => shipaddress; set => shipaddress = value; }
        public string ShippName { get => shippName; set => shippName = value; }
        public string Tel { get => tel; set => tel = value; }
        public string InvalidTime { get => invalidTime; set => invalidTime = value; }
        public int? OrderType { get => orderType; set => orderType = value; }
        public int? PartnerPayStatu { get => partnerPayStatu; set => partnerPayStatu = value; }
        public string PartnerPayMoney { get => partnerPayMoney; set => partnerPayMoney = value; }
        public int? SubstationId { get => substationId; set => substationId = value; }
        public string Lat { get => lat; set => lat = value; }
        public string Lon { get => lon; set => lon = value; }
    }
}
