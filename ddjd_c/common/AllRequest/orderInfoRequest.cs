using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    /// <summary>
    /// 订单相关请求
    /// </summary>
    class orderInfoRequest
    {

        #region 根据订单状态查询订单简介
        private static string queryStoreSystem_orderInfo_winform = "storeSystem/orderInfo/queryStoreSystem_orderInfo_winform";
        /// <summary>
        /// 根据订单状态查询订单简介
        /// </summary>
        public static string QueryStoreSystem_orderInfo_winform { get => queryStoreSystem_orderInfo_winform; }

        #endregion


        #region 修改店铺的订单信息的订单状态为已发货   ； 店铺发货功能
        private static string updateStoreOrderInfoTheOrderStatus = "front/storeAndOrderInfo/updateStoreOrderInfoTheOrderStatus";
        /// <summary>
        /// 修改店铺的订单信息的订单状态为已发货   ； 店铺发货功能
        /// </summary>
        public static string UpdateStoreOrderInfoTheOrderStatus { get => updateStoreOrderInfoTheOrderStatus; }
        
        #endregion


        #region 查询订单的详情
        private static string queryStoreOrderInfoDetails = "front/storeAndOrderInfo/queryStoreOrderInfoDetails";
        /// <summary>
        /// 查询订单的详情
        /// </summary>
        public static string QueryStoreOrderInfoDetails { get => queryStoreOrderInfoDetails;}
        #endregion
    }
}
