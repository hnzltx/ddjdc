using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common
{

    /// <summary>
    /// 打印处理
    /// </summary>
    class Print
    {
        

        //并口号，此收银机的端口貌似是写死的。 所以这里也暂时写死； 
        static string prnPort = "LPT1";

        const int OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(string lpFileName,
        int dwDesiredAccess,
        int dwShareMode,
        int lpSecurityAttributes,
        int dwCreationDisposition,
        int dwFlagsAndAttributes,
        int hTemplateFile);


        /// <summary>
        /// 执行打印 。 直接将字符发给打印机
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PrintLine(string str)
        {
            IntPtr iHandle = CreateFile(prnPort, 0x50000000, 0, 0, OPEN_EXISTING, 0, 0);
            if (iHandle.ToInt32() == -1)
            {
                
                return "没有连接打印机或者打印机端口不是LPT1";
            }
            else
            {
                FileStream fs = new FileStream(iHandle, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                //StreamWriter sw = new StreamWriter(fs,Encoding.GetEncoding("gb2312"));
                sw.Write(str);
                
                sw.Close();
                fs.Close();
                return "success";
            }
        }
    }
}
