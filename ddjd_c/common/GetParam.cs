using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common
{
    class GetParam
    {

        /// <summary>
        /// 将所有参数拼装成符合get请求的字符串 ; 如/xxx=?qw=1&we=2
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string GetStrParam(Dictionary<string, object> dic) {
            StringBuilder builder = new StringBuilder("?");
            foreach (var item in dic)
            {
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                builder.Append("&");
            }
            return builder.ToString();
        }

    }
}
