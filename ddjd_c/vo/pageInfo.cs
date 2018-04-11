using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo
{

    /// <summary>
    /// 分页page
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class pageInfo<T>
    {

        private bool firstPage;     //是否第一页
        private bool lastPage;      //是否最后一页
        private int? pageSize;   //每页多少条
        private int? pageNumber;    //第几页
        private int? totalRow;      //数据总行数
        private int? totalPage;     //总共多少页
        private List<T> list;   //商品数据


        public bool FirstPage { get => firstPage; set => firstPage = value; }
        public bool LastPage { get => lastPage; set => lastPage = value; }
        public int? PageSize { get => pageSize; set => pageSize = value; }
        public int? PageNumber { get => pageNumber; set => pageNumber = value; }
        public int? TotalRow { get => totalRow; set => totalRow = value; }
        public int? TotalPage { get => totalPage; set => totalPage = value; }
        public List<T> List { get => list; set => list = value; }
    }
}
