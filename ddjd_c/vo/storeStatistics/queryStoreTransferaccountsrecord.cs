using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.storeStatistics
{
    /// <summary>
    /// 转账记录； 店铺收入记录
    /// </summary>
    class queryStoreTransferaccountsrecord
    {
        private string transferAccountsRecordType;
        private int? transferAccountsRecordId;
        private int? transferAccountsRecordStoreId;
        private string transferAccountsRecordAmount;
        private string transferAccountsRecordPayDate;
        
        public int? TransferAccountsRecordId { get => transferAccountsRecordId; set => transferAccountsRecordId = value; }
        public int? TransferAccountsRecordStoreId { get => transferAccountsRecordStoreId; set => transferAccountsRecordStoreId = value; }
        public string TransferAccountsRecordPayDate { get => transferAccountsRecordPayDate; set => transferAccountsRecordPayDate = value; }
        public string TransferAccountsRecordType { get => transferAccountsRecordType; set => transferAccountsRecordType = value.Equals("1") ? "微信" : "支付宝"; }
        public string TransferAccountsRecordAmount { get => transferAccountsRecordAmount; set => transferAccountsRecordAmount = string.Format("  {0:C2}", int.Parse(value) / 100); }
    }
}
