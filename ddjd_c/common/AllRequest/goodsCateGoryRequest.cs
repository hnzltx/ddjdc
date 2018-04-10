using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{

    /// <summary>
    /// 商品分类所有相关请求
    /// </summary>
    class goodsCateGoryRequest
    {
        /// <summary>
        /// 查询所有的一级分类
        /// </summary>front/goodsCateGory/queryGoodsCateGoryForOne
        private static string queryGoodsCateGoryForOne = "front/goodsCateGory/queryGoodsCateGoryForOne";
        public static string QueryGoodsCateGoryForOne { get => queryGoodsCateGoryForOne; }
        

        /// <summary>
        /// 查询所有分类
        /// </summary>
        private static string queryGoodsCateGoryList = "front/goodsCateGory/queryGoodsCateGoryList";
        public static string QueryGoodsCateGoryList { get => queryGoodsCateGoryList; }
    }
}
