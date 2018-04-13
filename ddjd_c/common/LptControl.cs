using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common
{
    class LptControl
    {
        //默认并口号
        private string LptStr = db.SetPrint.SetPrint.lptStr;

        //打开钱箱的字符串
        private string openQxStr = ((char)27).ToString() + "p" + ((char)0).ToString() + ((char)128).ToString() + ((char)128).ToString();

        #region 打印定义； 这里面的尽量不改
        [StructLayout(LayoutKind.Sequential)]
        private struct OVERLAPPED
        {
            int Internal;
            int InternalHigh;
            int Offset;
            int OffSetHigh;
            int hEvent;
        }


        //调用DLL.
        [DllImport("kernel32.dll")]
        private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
        [DllImport("kernel32.dll")]
        private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(int hObject);
        private int iHandle;



        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        private bool Open()
        {
            iHandle = CreateFile(LptStr, 0x40000000, 0, 0, 3, 0, 0);
            // iHandle = CreateFile(LptStr, GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (iHandle != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 打印字符串，通过调用该方法可以打印需要的字符串
        /// </summary>
        /// <param name="Mystring"></param>
        /// <returns></returns>
        private bool Write(String Mystring)
        {
            //如果端口为打开，则提示，打开，则打印
            if (iHandle != -1)
            {
                OVERLAPPED x = new OVERLAPPED();
                int i = 0;
                //byte[] mybyte = System.Text.Encoding.Default.GetBytes(Mystring);
                byte[] mybyte = Encoding.GetEncoding("GB2312").GetBytes(Mystring);
                bool b = WriteFile(iHandle, mybyte, mybyte.Length, ref i, ref x);
                return b;
            }
            else
            {
                throw new Exception("不能连接到打印机!");
            }
        }
        /// <summary>
        /// 打印命令，通过参数，可以打印小票打印机的一些命令，比如换行，行间距，打印位图等。
        /// </summary>
        /// <param name="mybyte"></param>
        /// <returns></returns>
        private bool Write(byte[] mybyte)
        {
            //如果端口为打开，则提示，打开，则打印
            if (iHandle != -1)
            {
                OVERLAPPED x = new OVERLAPPED();
                int i = 0;
                return WriteFile(iHandle, mybyte, mybyte.Length, ref i, ref x);
            }
            else
            {
                throw new Exception("不能连接到打印机!");
            }
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <returns></returns>
        private bool Close()
        {
            return CloseHandle(iHandle);
        }

        #endregion



        #region 直接可调用打开钱箱； 不需要另外调用打开端口等等
        /// <summary>
        /// 直接打开钱箱
        /// </summary>
        /// <returns></returns>
        public string openQX()
        {
            if (Open())
            {
                if (Write(openQxStr))
                {
                    Close();
                    return "success";
                }
                else
                {
                    return "打开失败！请检查打印机或钱箱！";
                }
            }
            else
            {
                return "没有连接打印机或者打印机端口设置错误！请检查打印机设置";
            }
        }
        #endregion
        


        #region 打印任意字符串
        /// <summary>
        /// 打印任意字符串
        /// </summary>
        /// <param name="Mystring"></param>
        /// <returns></returns>
        public string pringStr(String Mystring)
        {
            if (Open())
            {
                if (Write(Mystring))
                {
                    Close();
                    return "success";
                }
                else
                {
                    return "打印失败！请检查打印机！";
                }
            }
            else
            {
                return "没有连接打印机或者打印机端口设置错误！请检查打印机设置";
            }
        }
        #endregion



        #region 打印订单信息
        /// <summary>
        /// 打印订单信息
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public string printOrderInfo(string orderId)
        {

            if (Open())
            {
                JObject json = service.order_service.orderService.queryStoreOrderInfoDetails(orderId);
                if (json["orderInfoDetails"] != null)
                {
                    model.order.order order = common.JsonHelper.DeserializeJsonToObject<model.order.order>(json["orderInfoDetails"].ToString());
                    List<vo.order.orderInfoGoodsDetails> orderDetailList = common.JsonHelper.DeserializeJsonToList<vo.order.orderInfoGoodsDetails>(json["orderInfoGoodsListDetails"].ToString());

                    if (order != null || orderDetailList.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("");
                        sb.AppendLine("    点单相邻 - 销售清单      ");
                        sb.AppendLine("*****************************");
                        sb.AppendLine(order.AddTime);
                        //sb.AppendLine("金额:￥" + order.OrderPrice + "元");
                        //sb.AppendLine("（原价￥" + order.OrderOriginalPrice + "元）");
                        sb.AppendLine("*****************************");

                        sb.AppendLine("商品名          数量/KG  金额");
                        foreach (vo.order.orderInfoGoodsDetails od in orderDetailList)
                        {
                            //最终商品名显示
                            string goodsName = "";
                            if (od.GoodsStutas == 1)
                            {
                                goodsName = od.GoodsName;
                            }
                            else if (od.GoodsStutas == 3)
                            {
                                goodsName = od.GoodsName + "【" + od.PromotionMsg + "】";
                            }

                            //商品名是否大于12个字符
                            bool isN = false;
                            if (goodsName.Length > 10)
                            {
                                isN = true;
                            }

                            //最终数量KG显示
                            string numKg = "";
                            if (double.Parse(od.Weight) > 0)
                            {
                                numKg = od.Weight + od.GoodsUnit;
                            }
                            else
                            {
                                numKg = od.GoodsCount + od.GoodsUnit;
                            }

                            //如果商品名大于12个字符，商品名独占一行
                            if (isN)
                            {
                                sb.AppendLine(goodsName);
                                sb.AppendLine("                " + numKg + "     " + od.GoodsSumMoney);
                            }
                            else
                            {
                                //否则显示在一行内
                                sb.AppendLine(goodsName + "  " + numKg + "     " + od.GoodsSumMoney);
                            }

                            sb.AppendLine("-----------------------------");

                        }
                        sb.AppendLine("总计： " + order.OrderPrice + "元");
                        sb.AppendLine("（原价 " + order.OrderOriginalPrice + "元）");
                        sb.AppendLine("by - " + GlobalsInfo.storeName);

                        //底部增加换行符
                        for (int i = 0; i < db.SetPrint.SetPrint.lineCount; i++)
                        {
                            sb.AppendLine("");
                        }

                        //sb.AppendLine("");

                        //执行打印

                        if (Write(sb.ToString()))
                        {
                            //打印小票完成后，如果需要打开钱箱
                            if (db.SetPrint.SetPrint.openQX) {
                                Write(openQxStr);
                            }
                            Close();
                            return "success";
                        }
                        else
                        {
                            return "打印失败！请检查打印机！";
                        }

                    }
                    else
                    {
                        return "没有查询到此订单的详细数据!";
                    }
                }
                else
                {
                    return "没有查询到此订单的详细数据!";
                }
            }
            else
            {
                return "没有连接打印机或者打印机端口设置错误！请检查打印机设置";
            }
        }

        #endregion


    }
}
