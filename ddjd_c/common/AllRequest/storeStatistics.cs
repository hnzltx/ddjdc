using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    class storeStatistics
    {
        #region 查询店铺收入明细（转账明细）记录
        /// <summary>
        /// 查询店铺收入明细（转账明细）记录
        /// </summary>
        private string queryStoreTransferaccountsrecord = "front/storeStatistics/queryStoreTransferaccountsrecord";

        public string QueryStoreTransferaccountsrecord { get => queryStoreTransferaccountsrecord; }

        #endregion


        #region 查询年月日营业额
        /// <summary>
        ///  查询年月日营业额
        ///  /// </summary>
        private string queryStoreTurnover = "front/storeStatistics/queryStoreTurnover";
        public string QueryStoreTurnover { get => queryStoreTurnover; }
        #endregion

    }
}
