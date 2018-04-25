﻿using Newtonsoft.Json;
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
using System.Collections.Specialized;

namespace ddjd_c.http
{
    class baseHttp
    {
        private static baseHttp _Singleton = null;
        private static object Singleton_Lock = new object();

        #region 异常处理
        //委托
        public  delegate void ScanerDelegate(exInfo ex);
        //事件
        public static event ScanerDelegate ScanerEvent;


        /// <summary>
        /// 启动事件调用
        /// </summary>
        /// <param name="exMsg">异常信息</param>
        ///<param name="httpName">请求接口</param>
        private static void start(string exMsg,string httpName) {
            
            exInfo ex = new exInfo();
            ex.ExMsg = exMsg;
            ex.HttpName = httpName;

            ScanerEvent(ex);
        }

        //private static exInfo ex = new exInfo();

        //protected  void OnNumChanged()
        //{
        //    if (ScanerEvent != null)
        //    {
        //        ScanerEvent(ex); /* 事件被触发 */
        //    }
        //}

        ////启动事件
        //public  void start() {

        //    OnNumChanged();
        //}

        /// <summary>
        /// 异常信息类
        /// </summary>
        public class exInfo{
            private string exMsg;
            private string httpName;

            public string ExMsg { get => exMsg; set => exMsg = value; }
            public string HttpName { get => httpName; set => httpName = value; }
        }
        #endregion


        //线上地址
        private static String ddjdcUrl = "http://c.hnddjd.com/";

        //本地地址
        //private static String ddjdcUrl = "http://192.168.199.215/";

        ///保存返回结果
        private static ResponseResult responseResult;

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
            string retString = "";
            try
            {
                string serviceAddress = ddjdcUrl + httpName;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception exception)
            {
                start(exception.Message, httpName);
            }
            
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
            string result = "";
            try
            {
                string serviceAddress = ddjdcUrl + httpName;
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
            catch (Exception exception)
            {
                start(exception.Message, httpName);

            }
            return result;

        }
        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="httpName">请求方法名；</param>
        /// <param name="dic">参数对象</param>
        /// <param name="response">返回结果委托</param>
        public static void PostStrFunction(string httpName, Dictionary<string, object> dic,ResponseResultDelegate response)
        {
            Action<Dictionary<string,object>> action = PostRequest;
            Dictionary<string, object> dicVale = new Dictionary<string, object>
            {
                { "url", httpName },
                { "dic", dic }
            };
            action(dicVale);
            //发起异步请求
            action.BeginInvoke(dicVale, new AsyncCallback(CallBackMethod), response);
            // 捕捉调用线程的同步上下文派生对象
            sc = System.Threading.SynchronizationContext.Current;
            
        }
        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="dic">参数</param>
        private static void PostRequest(Dictionary<string,object> objDic)
        {
            string url = objDic["url"].ToString();
            var dic = (Dictionary<string, object>)objDic["dic"];
            responseResult = new ResponseResult();
            if (Internet.IsConnectInternet())//检查是否可以连接互联网
            {
                try
                {
                    string serviceAddress = ddjdcUrl + url;
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
                        responseResult.JsonStr = reader.ReadToEnd();
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
        public static void GetStrFunction(String httpName, ResponseResultDelegate response)
        {

            Action<Dictionary<string, object>> action = GetRequest;
            Dictionary<string, object> dicVale = new Dictionary<string, object>();
            dicVale.Add("url", httpName);
            action(dicVale);
            //发起异步请求
            action.BeginInvoke(dicVale, new AsyncCallback(CallBackMethod), response);
            // 捕捉调用线程的同步上下文派生对象
            sc = System.Threading.SynchronizationContext.Current;
        }
        
        /// <summary>
        /// 网络异步get请求
        /// </summary>
        /// <param name="url"></param>
        private static void GetRequest(Dictionary<string, object> dic)
        {
            var url = dic["url"].ToString();
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
            Action<Dictionary<string, object>> dn = (Action<Dictionary<string, object>>)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;
            ///拿到结果返回委托
            ResponseResultDelegate action = (ResponseResultDelegate)ar.AsyncState;
            //返回结果
            action(responseResult,sc);
            //关闭异步调用 
            dn.EndInvoke(ar);
            
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string fileKeyName,
                                    string filePath, NameValueCollection stringDict)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            // 边界符  
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符  
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符  
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

            // 设置属性  
            webRequest.Method = "POST";
            webRequest.Timeout = 300000;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            
            // 写入文件  
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, filePath);
            var headerbytes = Encoding.UTF8.GetBytes(header);

            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0  

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            // 写入字符串的Key  
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in stringDict.Keys
                                             select string.Format(stringKeyHeader, key, stringDict[key])
                                                 into formitem
                                             select Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // 写入最后的结束边界符  
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

            using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                            Encoding.GetEncoding("utf-8")))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }

            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();

            return responseContent;
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
