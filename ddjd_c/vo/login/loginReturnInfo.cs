using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.login
{
    /// <summary>
    /// 
    /// 登录后，api返回的信息
    /// </summary>
    class loginReturnInfo
    {
        private int storeId;    //店铺ID
        private string storeName;   //店铺名称
        private int storeType;  //店铺类型 1. 直营 2. 加盟

        private string success; //登录状态信息

        public int StoreId { get => storeId; set => storeId = value; }
        public string StoreName { get => storeName; set => storeName = value; }
        public int StoreType { get => storeType; set => storeType = value; }
        public string Success { get => success; set => success = value; }
    }
}
