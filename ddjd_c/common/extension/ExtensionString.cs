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
		/// 验证string是否为空  
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
	}
}
