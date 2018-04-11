using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.order
{

    /// <summary>
    /// 订单的商品详情
    /// </summary>
    class orderInfoGoodsDetails
    {
        private string goodsName;
        private string goodsUnit;
        private string goodUcode;
        private string goodsCount;
        private string goodsMoney;
        private string goodsSumMoney;
        private string weight;

        public string GoodsName { get => goodsName; set => goodsName = value; }
        public string GoodsUnit { get => goodsUnit; set => goodsUnit = value; }
        public string GoodUcode { get => goodUcode; set => goodUcode = value; }
        public string GoodsCount { get => goodsCount; set => goodsCount = value; }
        public string GoodsMoney { get => goodsMoney; set => goodsMoney = value; }
        public string GoodsSumMoney { get => goodsSumMoney; set => goodsSumMoney = value; }
        public string Weight { get => weight; set => weight = value; }
    }
}
