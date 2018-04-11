using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c
{
    /// <summary>
    /// 全局配置信息
    /// </summary>
    class GlobalsInfo
    {
        /// <summary>
        /// 为了方便，店铺id暂时写死。 此值登录后改变
        /// </summary>
        public static int storeId = 21; //店铺ID
        public static string storeName;    //店铺名称
        public static int storeType = 2;   //店铺类型 1. 直营 2. 加盟


        //分页，默认每页查询多少条数据
        public static int pageSize = 10;
        //分页，默认查询第几页
        public static int pageNumber = 1;

        /// <summary>
        /// 操作成功的标识
        /// </summary>
        public static string success = "success";
    }
}
