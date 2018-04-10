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
    }
}
