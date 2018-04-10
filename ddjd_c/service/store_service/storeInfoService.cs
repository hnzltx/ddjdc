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

namespace ddjd_c.service.store_service
{
    class storeInfoService
    {
        /// <summary>
        /// 查询店铺信息。
        /// </summary>
        /// <returns>返回店铺信息对象</returns>
        public static storeInfo queryStoreInfo()
        {
            return JsonHelper.DeserializeJsonToObject<storeInfo>(baseHttp.GetStrFunction(storeRequest.QueryStoreInfo + "?storeId="+ GlobalsInfo.storeId));
        }

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
		public static JObject UpdateStoreInfoService(Dictionary<string, object> dic)
		{
			return JsonHelper.getJObject(baseHttp.PostStrFunction(storeRequest.UpdateStoreInfo, dic));
		}




	}
}
