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
    
    class baseHttp
    {
        private static baseHttp _Singleton = null;
        private static object Singleton_Lock = new object();

        //线上地址
        //private static String ddjdcUrl = "http://c.hnddjd.com/";

        //本地地址
        private static String ddjdcUrl = "http://192.168.199.215/";

        ///保存返回结果
        private static  ResponseResult responseResult;

        ///该类记录着线程的同步上下文对象，我们可以通过在GUI线程中调用SynchronizationContext.Current属性来获得GUI线程的同步上下文，然后当线程池线程需要更新窗体时，可以调用保存的SynchronizationContext派生对象的Post方法(Post方法会将回调函数送到GUI线程的队列中，每个线程都有各自的操作队列的，线程的执行都是从这个队列中拿方法去执行)，向Post方法传递要由GUI线程调用的方法(该方法的定义要匹配SendOrPostCallback委托的签名)，还需要想Post方法传递一个要传给回调方法的参数。
        private static System.Threading.SynchronizationContext sc;
        public static baseHttp CreateInstance()
        {
            if (_Singleton == null) //双if +lock
            {
                lock (Singleton_Lock)
                {
                   
                    if (_Singleton == null)
                    {
                        
                        _Singleton = new baseHttp();
                    }
                }
            }
            return _Singleton;
        }
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
        /// 发送post请求
        /// </summary>
        /// <param name="httpName">请求方法名；</param>
        /// <param name="dic">参数对象</param>
        /// <param name="response">返回结果委托</param>
        public static void PostStrFunction(string httpName, Dictionary<string, object> dic, Action<ResponseResult, System.Threading.SynchronizationContext> response)
        {
            Action<string,Dictionary<string,object>> action = PostRequest;
            action(httpName,dic);
            //发起异步请求
            action.BeginInvoke(httpName, dic,new AsyncCallback(CallBackMethod), response);
            // 捕捉调用线程的同步上下文派生对象
            sc = System.Threading.SynchronizationContext.Current;
        }
        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">路径</param>
        /// <param name="dic">参数</param>
        private static void PostRequest(string url, Dictionary<string, object> dic)
        {
            responseResult = new ResponseResult();
            if (Internet.IsConnectInternet())//检查是否可以连接互联网
            {
                try
                {
                    string serviceAddress = ddjdcUrl + url;
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
                }
                catch (Exception e)
                {
                    responseResult.Error = e.Message;
                }
            }
            else
                responseResult.Error = "请检查网络是否连接";
        }
       
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="httpName">路径</param>
        /// <param name="response">返回结果委托</param>
        public static void GetStrFunction(String httpName,Action<ResponseResult,System.Threading.SynchronizationContext> response)
        {
            
            Action<string> action = GetRequest;
            action(httpName);
            //发起异步请求
            action.BeginInvoke(httpName, new AsyncCallback(CallBackMethod), response);
            // 捕捉调用线程的同步上下文派生对象
            sc = System.Threading.SynchronizationContext.Current;
        }
        
        /// <summary>
        /// 网络异步get请求
        /// </summary>
        /// <param name="url"></param>
        private static void GetRequest(string url)
        {

            responseResult = new ResponseResult();
            if (Internet.IsConnectInternet())//检查是否可以连接互联网
            {
                try
                {
                    string serviceAddress = ddjdcUrl + url;
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
                    responseResult.Error = e.Message;
                }

            }
            else
                responseResult.Error = "请检查网络是否连接";

        }
        /// <summary>
        /// 回调方法
        /// </summary>
        /// <param name="ar">异步操作对象</param>
        private static void CallBackMethod(IAsyncResult ar)
        {
            ///拿到异步调用委托
            Action<string> dn = (Action<string>)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;
            ///拿到结果返回委托
            Action<ResponseResult,System.Threading.SynchronizationContext> action=(Action<ResponseResult, System.Threading.SynchronizationContext>)ar.AsyncState;
            //返回结果
            action(responseResult,sc);
            //关闭异步调用 
            dn.EndInvoke(ar);
        }
        
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
