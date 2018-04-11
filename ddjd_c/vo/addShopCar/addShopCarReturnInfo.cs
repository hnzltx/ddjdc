using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.addShopCar
{
    /// <summary>
    /// 添加商品进入购物车返回的状态信息
    /// </summary>
    class addShopCarReturnInfo
    {

        private addShopCarGoods goodsInfo;
        private addShopCarStatuInfo result;

        internal addShopCarGoods GoodsInfo { get => goodsInfo; set => goodsInfo = value; }
        internal addShopCarStatuInfo Result { get => result; set => result = value; }
    }
}
