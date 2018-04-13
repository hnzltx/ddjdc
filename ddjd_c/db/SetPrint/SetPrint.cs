using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.db.SetPrint
{
    /// <summary>
    /// 设置打印机
    /// </summary>
    class SetPrint
    {
        public static string lptStr = "LPT1";  //打印机并口号 ； 默认1
        public static int lineCount = 3 ;  //打印完内容后，底部换几行 ； 默认3
        public static bool openQX = true;   //每次打印是否弹出钱箱； 默认是
        
    }
}
