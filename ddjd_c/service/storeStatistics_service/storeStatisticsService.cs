using ddjd_c.common.AllRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.service.storeStatistics_service
{
    class storeStatisticsService
    {

        /// <summary>
        /// 查询店铺收入明细（转账明细）记录
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public vo.pageInfo<vo.storeStatistics.queryStoreTransferaccountsrecord> queryStoreTransferaccountsrecord(Dictionary<string, object> dic) {
            dic.Add("storeId", GlobalsInfo.storeId);

            return common.JsonHelper.DeserializeJsonToObject<vo.pageInfo<vo.storeStatistics.queryStoreTransferaccountsrecord>>
                (http.baseHttp.GetStrFunction(new storeStatistics().QueryStoreTransferaccountsrecord + common.GetParam.GetStrParam(dic)));

        }


        /// <summary>
        /// 查询年月日营业额
        /// </summary>
        /// <returns></returns>
        public vo.storeStatistics.queryStoreTurnover queryStoreTurnover() {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);

            return common.JsonHelper.DeserializeJsonToObject<vo.storeStatistics.queryStoreTurnover>
                (http.baseHttp.GetStrFunction(new storeStatistics().QueryStoreTurnover + common.GetParam.GetStrParam(dic)));
        }

    }
}
