using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    /// <summary>
    /// 管理店铺相关功能所有请求；
    /// </summary>
    class storeRequest
    {
        /// <summary>
        /// 查询店铺信息请求
        /// </summary>
        private static string queryStoreInfo = "front/storeInfo/queryStoreInfo";
        public static string QueryStoreInfo { get => queryStoreInfo; }


		/// <summary>
		/// 修改店铺信息
		/// </summary>
		private static string updateStoreInfo = "front/storeInfo/updateStoreInfo";
		public static string UpdateStoreInfo { get => updateStoreInfo; }
	
	}
}
