using Newtonsoft.Json.Linq;
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


        /// <summary>
        /// 查询输入或扫描的条码，并加入店铺购物车
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static JObject queryGoodsInfoByGoodsCode(string code) {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("goodsCode", code);
            return common.JsonHelper.getJObject(http.baseHttp.GetStrFunction(
                common.AllRequest.scanCodeRequest.QueryGoodsInfoByGoodsCode + common.GetParam.GetStrParam(dic)));
        }


        /// <summary>
        /// 查询店铺的购物车数据
        /// </summary>
        /// <returns></returns>
        public static List<vo.addShopCar.addShopCarGoods> queryStoreshoppingcar() {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            return common.JsonHelper.DeserializeJsonToList<vo.addShopCar.addShopCarGoods>(http.baseHttp.GetStrFunction(
                common.AllRequest.scanCodeRequest.QueryStoreshoppingcar + common.GetParam.GetStrParam(dic)));
        }


        /// <summary>
        /// 清空店铺购物车
        /// </summary>
        /// <returns></returns>
        public static string deleteStoreshoppingcarAll() {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            return http.baseHttp.PostStrFunction(common.AllRequest.scanCodeRequest.DeleteStoreshoppingcarAll, dic);
        }


    }
}
