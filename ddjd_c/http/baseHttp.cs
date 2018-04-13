using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
namespace ddjd_c.http
{
    /// <summary>
    /// 响应委托
    /// </summary>
    /// <param name="result">结果</param>
    public delegate void ResponseDelegate(ResponseResult result);

    class baseHttp
    {

        //线上地址
        private static String ddjdcUrl = "http://c.hnddjd.com/";

        //本地地址
        //private static String ddjdcUrl = "http://192.168.199.215/";

        ///测试
        private static String ddjdUrl = "123456789";

        /// <summary>
        /// 提供外部访问连接地址；
        /// </summary>
        /// <returns></returns>
        public static String getDdjdcUrl()
        {
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
        public static string PostStrFunction(string httpName, Dictionary<string, object> dic)
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
        /// <summary>
        /// 发送get请求
        /// </summary>
        /// <param name="httpName">请求方法名； 如果有参数使用？挂参</param>
        /// <returns>string</returns>
        public static void GetFunction(String httpName,ResponseDelegate responseDelegate)
        {
            ResponseResult responseResult = new ResponseResult();

            if (Internet.IsConnectInternet())//检查是否可以连接互联网
            {
                IAsyncResult result = responseDelegate.BeginInvoke(responseResult,new AsyncCallback(CallBackMethod), responseResult);
                while(result.IsCompleted == false)
                {
                    try
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
                        responseResult.JsonStr = retString;
                    }
                    catch (Exception e)
                    {
                        responseResult.Error = "服务器异常," + e.Message;
                    }
                }
                   
            }
            else
                responseResult.Error = "请检查网络是否连接";

            responseDelegate(responseResult);
        }
        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="ar">异步操作对象</param>
        private static void CallBackMethod(IAsyncResult ar)
        {
            ResponseDelegate dn = (ResponseDelegate)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;
            //关闭异步调用 
            dn.EndInvoke(ar);
        }
    }
    /// <summary>
    /// 网络请求响应结果
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 返回的json字符串
        /// </summary>
        public string JsonStr { get; set; }
        
        //待添加

    }
    /// <summary>
    /// 检查网络连接
    /// </summary>
    class Internet
      {
          [DllImport("wininet.dll")]
          private extern static bool InternetGetConnectedState(int Description, int ReservedValue);
  
          #region 方法一
          /// <summary>
          /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败 
          /// </summary>
          /// <returns></returns>
          public static bool IsConnectInternet()
          {
              int Description = 0;
              return InternetGetConnectedState(Description, 0);
          }
          #endregion
  
          #region 方法二
         /// <summary>
          /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败 
         /// </summary>
          /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
          /// <returns></returns>
         public static bool PingIpOrDomainName(string strIpOrDName)
         {
             try
              {
                  Ping objPingSender = new Ping();
                  PingOptions objPinOptions = new PingOptions();
                 objPinOptions.DontFragment = true;
                 string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                 int intTimeout = 120;
                  PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                 string strInfo = objPinReply.Status.ToString();
                 if (strInfo == "Success")
                 {
                     return true;
                 }
                  else
                 {
                     return false;
                  }
              }
              catch (Exception)
             {
                 return false;
             }
          }
          #endregion
     }
}
