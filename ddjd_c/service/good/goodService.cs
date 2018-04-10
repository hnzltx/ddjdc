using ddjd_c.common;
using ddjd_c.common.AllRequest;
using ddjd_c.http;
using ddjd_c.model.store;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddjd_c.common.extension;

namespace ddjd_c.service.good
{
    /// <summary>
    /// 商品
    /// </summary>
    class goodService
    {
        /// <summary>
        /// 查询店铺商品
        /// </summary>
        /// <param name="dic">参数</param>
        /// <returns></returns>
        public static JObject QueryStoreAndGoodsList(Dictionary<string,object> dic=null)
        {
         
            return JsonHelper.getJObject(baseHttp.GetStrFunction(goodRequest.QueryStoreAndGoodsList.ToGetRequestURL(dic)));
        }
    }
}
