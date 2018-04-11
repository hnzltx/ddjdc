using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.model.good
{
    /// <summary>
    /// 商品表
    /// </summary>
    class goodEntity
    {

        private int? goodsId;
        private string goodsName; //‘商品名称’,
        private string goodsUnit; //‘商品单位’,
        private string goodsMixed; //‘商品配料’,
        private int? goodsLift; //‘保质期（天）’,
        private string goodsCode; //‘商品条码’,
        private string emark;  //‘商品描述富文本描述’,
        private int? fCategoryId; //‘一级分类(关联商品分类的一个Id)’,
        private int? sCategoryId; //‘二级分类(关联商品分类的一个Id)’,
        private int? tCategoryId; //‘三级分类(关联商品分类的一个Id)’,
        private string goodsCategoryName; //分类名称
        private string goodsPic;//‘商品展示首图（即封面图片）’,
        private string ctime; //‘商品上传时间’,
        private int? goodsFlag;//‘1：上架，2 下架 3. 审核中 4. 审核失败’,
        private string goodUcode; //‘商品规格’,
        private double? goodsPrice; //‘商品价格；参考价’,
        private string weigh; //‘重量’,
        private string brand; // ‘商品品牌’,
        private int? stock; //线上库存
        private int? offlineStock; //线下库存
        private int? salesCount; //销量
        private bool? collectionStatu; //是否收藏  true收藏了 false 没有
        private double? storeGoodsPrice; //店铺商品价格
        private double? goodsMoney; //订单商品价格
        private int? indexGoodsId; //不为空就表示该商品已经加入了首页商品
        private int? goodsStutas; //3促销 1普通 2特价
        private int? promotionStock; //促销库存
        private string promotionMsg; //促销信息
        private string promotionStartTime;//促销开始时间
        private string promotionEndTime; //促销结束时间
        private int? promotionEndTimeSeconds; //促销结束时间秒
        private double? purchasePrice;//店铺进货价
        private int? storeAndGoodsId; //店铺商品id


        public int? GoodsId { get => goodsId; set => goodsId = value; }
        public string GoodsName { get => goodsName; set => goodsName = value; }
        public string GoodsUnit { get => goodsUnit; set => goodsUnit = value; }
        public string GoodsMixed { get => goodsMixed; set => goodsMixed = value; }
        public int? GoodsLift { get => goodsLift; set => goodsLift = value; }
        public string GoodsCode { get => goodsCode; set => goodsCode = value; }
        public string Emark { get => emark; set => emark = value; }
        public int? FCategoryId { get => fCategoryId; set => fCategoryId = value; }
        public int? SCategoryId { get => sCategoryId; set => sCategoryId = value; }
        public int? TCategoryId { get => tCategoryId; set => tCategoryId = value; }
        public string GoodsCategoryName { get => goodsCategoryName; set => goodsCategoryName = value; }
        public string GoodsPic { get => goodsPic; set => goodsPic = value; }
        public string Ctime { get => ctime; set => ctime = value; }
        public int? GoodsFlag { get => goodsFlag; set => goodsFlag = value; }
        public string GoodUcode { get => goodUcode; set => goodUcode = value; }
        public double? GoodsPrice { get => goodsPrice; set => goodsPrice = value; }
        public string Weigh { get => weigh; set => weigh = value; }
        public string Brand { get => brand; set => brand = value; }
        public int? Stock { get => stock; set => stock = value; }
        public int? OfflineStock { get => offlineStock; set => offlineStock = value; }
        public int? SalesCount { get => salesCount; set => salesCount = value; }
        public bool? CollectionStatu { get => collectionStatu; set => collectionStatu = value; }
        public double? StoreGoodsPrice { get => storeGoodsPrice; set => storeGoodsPrice = value; }
        public double? GoodsMoney { get => goodsMoney; set => goodsMoney = value; }
        public int? IndexGoodsId { get => indexGoodsId; set => indexGoodsId = value; }
        public int? GoodsStutas { get => goodsStutas; set => goodsStutas = value; }
        public int? PromotionStock { get => promotionStock; set => promotionStock = value; }
        public string PromotionMsg { get => promotionMsg; set => promotionMsg = value; }
        public string PromotionStartTime { get => promotionStartTime; set => promotionStartTime = value; }
        public string PromotionEndTime { get => promotionEndTime; set => promotionEndTime = value; }
        public int? PromotionEndTimeSeconds { get => promotionEndTimeSeconds; set => promotionEndTimeSeconds = value; }
        public double? PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public int? StoreAndGoodsId { get => storeAndGoodsId; set => storeAndGoodsId = value; }
    }
}
