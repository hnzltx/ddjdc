using System;
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
    }
}
