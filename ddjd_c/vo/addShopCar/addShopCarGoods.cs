using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.addShopCar
{

    /// <summary>
    /// 店铺购物车商品数据
    /// </summary>
    class addShopCarGoods
    {

        private string weight;
        private string promotionStartTime;
        private int? isBulkCargo;
        private int? goodsFlag;
        private int? storeShoppingcarId;
        private string promotionMsg;
        private int? promotionGoodsId;
        private int? sCategoryId;
        private int? goodsStutas;
        private int? flag;
        private int? stock;
        private string storeGoodsPrice;
        private int? promotionStock;
        private string promotionEndTime;
        private string goodsUnit;
        private string goodsName;
        private int? storeAndGoodsId;
        private int? goodsCount;

        public string Weight { get => weight; set => weight = value; }
        public string PromotionStartTime { get => promotionStartTime; set => promotionStartTime = value; }
        public int? IsBulkCargo { get => isBulkCargo; set => isBulkCargo = value; }
        public int? GoodsFlag { get => goodsFlag; set => goodsFlag = value; }
        public int? StoreShoppingcarId { get => storeShoppingcarId; set => storeShoppingcarId = value; }
        public string PromotionMsg { get => promotionMsg; set => promotionMsg = value; }
        public int? PromotionGoodsId { get => promotionGoodsId; set => promotionGoodsId = value; }
        public int? SCategoryId { get => sCategoryId; set => sCategoryId = value; }
        public int? GoodsStutas { get => goodsStutas; set => goodsStutas = value; }
        public int? Flag { get => flag; set => flag = value; }
        public int? Stock { get => stock; set => stock = value; }
        public string StoreGoodsPrice { get => storeGoodsPrice; set => storeGoodsPrice = value; }
        public int? PromotionStock { get => promotionStock; set => promotionStock = value; }
        public string PromotionEndTime { get => promotionEndTime; set => promotionEndTime = value; }
        public string GoodsUnit { get => goodsUnit; set => goodsUnit = value; }
        public string GoodsName { get => goodsName; set => goodsName = value; }
        public int? StoreAndGoodsId { get => storeAndGoodsId; set => storeAndGoodsId = value; }
        public int? GoodsCount { get => goodsCount; set => goodsCount = value; }
    }
}
