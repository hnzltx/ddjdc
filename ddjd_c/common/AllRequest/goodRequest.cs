﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    class goodRequest
    {
        /// <summary>
        /// 查询店铺商品 
        /// </summary>
        private static string queryStoreAndGoodsList = "front/storeAndGoods/queryStoreAndGoodsList";
        public static string QueryStoreAndGoodsList { get => queryStoreAndGoodsList; }


        /// <summary>
        /// 查询店铺商品详情
        /// </summary>
        private static string queryStoreAndGoodsDetail = "front/storeAndGoods/queryStoreAndGoodsDetail";
        public static string QueryStoreAndGoodsDetail { get => queryStoreAndGoodsDetail; }

        /// <summary>
        /// 修改店铺商品信息
        /// </summary>
        private static string updateGoodsByStoreAndGoodsId = "front/storeAndGoods/updateGoodsByStoreAndGoodsId";
        public static string UpdateGoodsByStoreAndGoodsId { get => updateGoodsByStoreAndGoodsId; }


        
        private static string addIndexGoods = "front/storeAndGoods/addIndexGoods";
        /// <summary>
        /// 店铺添加首页商品
        /// </summary>
        public static string AddIndexGoods { get => addIndexGoods; }

        
        private static string removeIndexGoods = "front/storeAndGoods/removeIndexGoods";
        /// <summary>
        /// 店铺移除首页商品
        /// </summary>
        public static string RemoveIndexGoods { get => removeIndexGoods; }

        private static string indexGoodsList = "front/goods/indexGoods";
        /// <summary>
        /// 查询店铺商品list
        /// </summary>
        public static string IndexGoodsList { get => indexGoodsList; }

        private static string removePromotiongoods = "front/promotiongoods/removePromotiongoods";
        /// <summary>
        /// 删除促销商品
        /// </summary>
        public static string RemovePromotiongoods { get => removePromotiongoods; }

        private static string addPromotiongoods = "front/promotiongoods/addPromotiongoods";
        /// <summary>
        /// 添加促销商品
        /// </summary>
        public static string AddPromotiongoods { get => addPromotiongoods; }


        private static string updateGoodsFlagByStoreAndGoodsId = "front/storeAndGoods/updateGoodsFlagByStoreAndGoodsId";
        ///店铺将商品修改为上架或下架
        public static string UpdateGoodsFlagByStoreAndGoodsId { get => updateGoodsFlagByStoreAndGoodsId; }


        private static string queryPromotiongoodsPaginateStore = "front/promotiongoods/queryPromotiongoodsPaginateStore";

        /// <summary>
        /// 查询促销商品
        /// </summary>
        public static string QueryPromotiongoodsPaginateStore { get => queryPromotiongoodsPaginateStore; }


        private static string queryExamineGoodsByStoreId = "front/storeUploadGoods/queryExamineGoodsByStoreId";
        /// <summary>
        /// 查询店铺各种审核状态的商品
        /// </summary>
        public static string QueryExamineGoodsByStoreId { get => queryExamineGoodsByStoreId; }


        private static string updateExamineGoodsByStoreId = "front/storeUploadGoods/updateExamineGoodsByStoreId";
        /// <summary>
        /// 审核失败，修改审核商品
        /// </summary>
        public static string UpdateExamineGoodsByStoreId { get => updateExamineGoodsByStoreId; }
    }
}
