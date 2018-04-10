using ddjd_c.common;
using ddjd_c.common.AllRequest;
using ddjd_c.http;
using ddjd_c.model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.service.goodsCategory_service
{
    /// <summary>
    /// 商品分类
    /// </summary>
    class goodsCategoryService
    {

        /// <summary>
        /// 查询所有的一级分类
        /// </summary>
        /// <returns></returns>
        public static List<goodscategory> queryGoodsCateGoryForOne() {
            return JsonHelper.DeserializeJsonToList<goodscategory>(baseHttp.GetStrFunction(goodsCateGoryRequest.QueryGoodsCateGoryForOne));
        }
        /// <summary>
        /// 查询所有分类
        /// </summary>
        /// <returns></returns>
        public static JArray queryGoodsAllCateGory()
        {
            return JsonHelper.getJArray(baseHttp.GetStrFunction(goodsCateGoryRequest.QueryGoodsCateGoryList));
        }
    }
}
