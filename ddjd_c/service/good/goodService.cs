using ddjd_c.common;
using ddjd_c.common.AllRequest;
using ddjd_c.http;
using ddjd_c.model.store;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddjd_c.model.good;
using ddjd_c.common.extension;

namespace ddjd_c.service.good
{
    /// <summary>
    /// 商品
    /// </summary>
    class goodService
    {
        /// <summary>
        /// 查询店铺商品
        /// </summary>
        /// <param name="dic">参数</param>
        /// 
        public static void QueryStoreAndGoodsList(ResponseResultDelegate resultDelegate, Dictionary<string,object> dic=null)
        {

            baseHttp.GetStrFunction(goodRequest.QueryStoreAndGoodsList.ToGetRequestURL(dic), resultDelegate);
        }

        /// <summary>
        /// 查询商品详情
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static void QueryStoreAndGoodsDetail(ResponseResultDelegate resultDelegate, Dictionary<string, object> dic = null)
        {
            baseHttp.GetStrFunction(goodRequest.QueryStoreAndGoodsDetail.ToGetRequestURL(dic), resultDelegate);
        }

        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject UpdateGoodsByStoreAndGoodsId(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.UpdateGoodsByStoreAndGoodsId,dic));
        }

        /// <summary>
        /// 添加促销商品
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject AddPromotiongoods(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.AddPromotiongoods, dic));
        }

        /// <summary>
        /// 删除促销商品
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject RemovePromotiongoods(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.RemovePromotiongoods, dic));
        }
        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject UpdateGoodsFlagByStoreAndGoodsId(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.UpdateGoodsFlagByStoreAndGoodsId, dic));
        }

        /// <summary>
        /// 删除首页推荐商品
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject RemoveIndexGoods(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.RemoveIndexGoods, dic));
        }
        /// <summary>
        /// 添加首页推荐商品
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static JObject AddIndexGoods(Dictionary<string, object> dic)
        {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(goodRequest.AddIndexGoods, dic));
        }
        /// <summary>
        /// 查询首页推荐商品
        /// </summary>
        /// <param name="resultDelegate"></param>
        /// <param name="dic"></param>
        public static void IndexGoodsList(ResponseResultDelegate resultDelegate, Dictionary<string, object> dic)
        {
            baseHttp.GetStrFunction(goodRequest.IndexGoodsList.ToGetRequestURL(dic),resultDelegate);
        }

        /// <summary>
        /// 查询促销商品
        /// </summary>
        /// <param name="resultDelegate"></param>
        /// <param name="dic"></param>
        public static void QueryPromotiongoodsPaginateStore(ResponseResultDelegate resultDelegate, Dictionary<string, object> dic)
        {
            baseHttp.GetStrFunction(goodRequest.QueryPromotiongoodsPaginateStore.ToGetRequestURL(dic), resultDelegate);
        }

        /// <summary>
        /// 查询店铺各种审核状态的商品
        /// </summary>
        /// <param name="resultDelegate"></param>
        /// <param name="dic"></param>
        public static void QueryExamineGoodsByStoreId(ResponseResultDelegate resultDelegate, Dictionary<string, object> dic)
        {
            baseHttp.GetStrFunction(goodRequest.QueryExamineGoodsByStoreId.ToGetRequestURL(dic), resultDelegate);
        }

        /// <summary>
        /// 审核失败，修改审核商品
        /// </summary>
        /// <param name="resultDelegate"></param>
        /// <param name="dic"></param>
        public static void UpdateExamineGoodsByStoreId(ResponseResultDelegate resultDelegate, Dictionary<string, object> dic){
            baseHttp.PostStrFunction(goodRequest.UpdateExamineGoodsByStoreId,dic,resultDelegate);
        }
    }
}
