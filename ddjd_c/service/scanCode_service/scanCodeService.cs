using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.service.scanCode_service
{
    class scanCodeService
    {
        /// <summary>
        /// 查询店铺收银界面的自定义商品
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static List<vo.goods.scanCodeGoods> queryGoodsWithCustomGoods(Dictionary<string, object> dic) {
            //添加店铺ID
            dic.Add("storeId",GlobalsInfo.storeId);
            return common.JsonHelper.DeserializeJsonToList<vo.goods.scanCodeGoods>(http.baseHttp.PostStrFunction(common.AllRequest.scanCodeRequest.QueryGoodsWithCustomGoods,dic));
        }
    }
}
