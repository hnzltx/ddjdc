using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.goods
{
    /// <summary>
    /// 展示收银界面的常用商品
    /// </summary>
    class scanCodeGoods
    {
        
        private string goodsName;   //商品名称
        private string goodsCode;   //商品条码
        private string goodsPic;    //商品图片
        private string goodsCodeImg;    //商品条形码图片

        public string GoodsName { get => goodsName; set => goodsName = value; }
        public string GoodsCode { get => goodsCode; set => goodsCode = value; }
        public string GoodsPic { get => goodsPic; set => goodsPic = value; }
        public string GoodsCodeImg { get => goodsCodeImg; set => goodsCodeImg = value; }
    }
}
