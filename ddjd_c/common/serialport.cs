using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common
{
    class serialport
    {

        /// <summary>
        /// 获取当前所有的串口号
        /// </summary>
        /// <returns></returns>
        public static string[] getAllPortList() {
            return SerialPort.GetPortNames();
        }
    }
}
