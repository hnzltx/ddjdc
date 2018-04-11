using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.extension
{
	public static class ExtensionString
	{
		/// <summary>
		/// 验证string是否为空  true为空:false
		/// </summary>
		/// <param name="str">传入字符串</param>
		/// <returns>返回true是 false不是</returns>
		public static bool StrIsNull(this String str)
		{
			var flag = false;
			if (str == null || str.Length == 0 || str == "") {
				flag = true;
			}
			return flag;
		}

		/// <summary>
		/// 将字符串转换为Int
		/// </summary>
		/// <param name="t"></param>
		/// <returns>当转换失败时返回0</returns>
		public static int ToInt(this string t)
		{
			int id;
			int.TryParse(t, out id);//这里当转换失败时返回的id为0
			return id;
		}
        /// <summary>
        /// 将字符串转换为double
        /// </summary>
        /// <param name="t"></param>
        /// <returns>当转换失败时返回0</returns>
        public static double ToDouble(this string t)
        {
            double d;
            double.TryParse(t, out d);
            return d;
        }
        /// <summary>
        /// 验证是否是数字 true是 false不是
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(this string input)
        {
            double d = 0;
            if (double.TryParse(input, out d)) // TryParse返回true说明是数值
                return true;
            else // 不是数值
                return false;
        }
        /// <summary>
        /// 生成get请求url
        /// </summary>
        /// <param name="t"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ToGetRequestURL(this string t,Dictionary<string,object> dic=null)
        {
            if(dic == null)
            {
                return t;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(t);
            builder.Append("?");
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            return builder.ToString();
        }
	}
}
