using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.http
{
    class baseHttp
    {

        //线上地址
        //private static String ddjdcUrl = "http://c.hnddjd.com/";

        //本地地址
        private static String ddjdcUrl = "http://localhost/";
        
        /// <summary>
        /// 提供外部访问连接地址；
        /// </summary>
        /// <returns></returns>
        public static String getDdjdcUrl() {
            return ddjdcUrl;
        }

        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <param name="httpName">请求方法名； 如果有参数使用？挂参</param>
        /// <returns>string</returns>
        public static String GetStrFunction(String httpName)
        {

            string serviceAddress = ddjdcUrl + httpName;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }



        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="httpName">请求方法名；</param>
        /// <param name="dic">参数对象</param>
        /// <returns>string</returns>
        public static string PostStrFunction(string httpName, Dictionary<string, string> dic)
        {
            string serviceAddress = ddjdcUrl + httpName;
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serviceAddress);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数  
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }



    }
}
