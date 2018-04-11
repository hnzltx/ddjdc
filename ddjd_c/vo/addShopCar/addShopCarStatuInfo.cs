using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.vo.addShopCar
{
    /// <summary>
    /// 加入购物车返回的状态信息
    /// </summary>
    class addShopCarStatuInfo
    {

        private int? goodsStutas;
        private int? flag;
        private int? goodsPalyStatus;
        private int? addOrUpdate;
        private int? storeShoppingcarId;
        private string success;

        public int? GoodsStutas { get => goodsStutas; set => goodsStutas = value; }
        public int? Flag { get => flag; set => flag = value; }
        public int? GoodsPalyStatus { get => goodsPalyStatus; set => goodsPalyStatus = value; }
        public int? AddOrUpdate { get => addOrUpdate; set => addOrUpdate = value; }
        public int? StoreShoppingcarId { get => storeShoppingcarId; set => storeShoppingcarId = value; }
        public string Success { get => success; set => success = value; }
    }
}
