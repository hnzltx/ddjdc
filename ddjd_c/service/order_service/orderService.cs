using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.service.order_service
{
    class orderService
    {
        /// <summary>
        /// 查询订单列表
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static vo.pageInfo<vo.order.order>  QueryStoreSystem_orderInfo_winform(Dictionary<string,object> dic) {
            dic.Add("storeId", GlobalsInfo.storeId);
            return common.JsonHelper.DeserializeJsonToObject<vo.pageInfo<vo.order.order>>(http.baseHttp.PostStrFunction(common.AllRequest.orderInfoRequest.QueryStoreSystem_orderInfo_winform, dic));
        }


        /// <summary>
        /// 修改店铺的订单信息的订单状态为已发货   ； 店铺发货功能
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject updateStoreOrderInfoTheOrderStatus(Dictionary<string, object> dic) {
            dic.Add("storeId", GlobalsInfo.storeId);
            return common.JsonHelper.getJObject(http.baseHttp.PostStrFunction(common.AllRequest.orderInfoRequest.UpdateStoreOrderInfoTheOrderStatus, dic));
        }


        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static JObject queryStoreOrderInfoDetails(string orderId) {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("orderId",orderId);
            return common.JsonHelper.getJObject(
                http.baseHttp.GetStrFunction(
                    common.AllRequest.orderInfoRequest.QueryStoreOrderInfoDetails + common.GetParam.GetStrParam(dic)));
        }


    }
}
