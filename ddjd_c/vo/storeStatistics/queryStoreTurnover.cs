using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.storeStatistics
{
    /// <summary>
    /// 查询年月日营业额
    /// </summary>
    class queryStoreTurnover
    {
        private string month;
        private string today;
        private string year;
        private string sumPrice;

        public string Month { get => month; set => month = value; }
        public string Today { get => today; set => today = value; }
        public string Year { get => year; set => year = value; }
        public string SumPrice { get => sumPrice; set => sumPrice = value; }
    }
}
