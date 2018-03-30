using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    /// <summary>
    /// 收银相关请求
    /// </summary>
    class scanCodeRequest
    {
        /// <summary>
        /// 给收银查询自定义商品列表
        /// </summary>
        private static string queryGoodsWithCustomGoods = "code/queryGoodsWithCustomGoods";
        public static string QueryGoodsWithCustomGoods { get => queryGoodsWithCustomGoods; }
    }
}
