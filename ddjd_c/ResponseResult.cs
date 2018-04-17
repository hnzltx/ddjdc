using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ddjd_c.common;

namespace ddjd_c
{
    /// <summary>
    /// 响应结果委托
    /// </summary>
    /// <param name="result"></param>
    /// <param name="sc"></param>
    public delegate void ResponseResultDelegate(ResponseResult result, System.Threading.SynchronizationContext sc);
    /// <summary>
    /// 网络请求响应结果
    /// </summary>
    public struct ResponseResult
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 返回的json字符串
        /// </summary>
        public string JsonStr { get; set; }

        /// <summary>
        /// 返回对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ToEntity<T>() where T : class
        {
            
            return JsonHelper.DeserializeJsonToObject<T>(JsonStr);
        }
        /// <summary>
        /// 返回list对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> ToListEntity<T>() where T : class
        {
           
            return JsonHelper.DeserializeJsonToList<T>(JsonStr);
        }
        
        
        /// <summary>
        /// 返回JObject直接用xxx["参数名"]
        /// </summary>
        /// <returns></returns>
        public JObject ToObj()
        {
            return JsonHelper.getJObject(JsonStr);
        }

    }
}
