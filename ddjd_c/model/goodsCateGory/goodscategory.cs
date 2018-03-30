using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.model
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    class goodscategory
    {
        private int? goodsCategoryId;
        private string goodsCategoryName;  //分类名称
        private int? goodsCategoryPid;   //父级ID
        private string goodsCategoryIco;    //分类图片
        private int? goodsCategorySort;  //分类排序
        private int? goodsCategoryFlag;  //是否显示分类； 1显示，2不显示

        public int? GoodsCategoryId { get => goodsCategoryId; set => goodsCategoryId = value; }
        public string GoodsCategoryName { get => goodsCategoryName; set => goodsCategoryName = value; }
        public int? GoodsCategoryPid { get => goodsCategoryPid; set => goodsCategoryPid = value; }
        public string GoodsCategoryIco { get => goodsCategoryIco; set => goodsCategoryIco = value; }
        public int? GoodsCategorySort { get => goodsCategorySort; set => goodsCategorySort = value; }
        public int? GoodsCategoryFlag { get => goodsCategoryFlag; set => goodsCategoryFlag = value; }
    }
}
