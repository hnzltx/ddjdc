using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.AllRequest
{
    /// <summary>
    /// 收银相关请求
    /// </summary>
    class scanCodeRequest
    {


        #region 给收银查询自定义商品列表
        private static string  queryGoodsWithCustomGoods = "code/queryGoodsWithCustomGoods";
        /// <summary>
        /// 给收银查询自定义商品列表
        /// </summary>
        public static string QueryGoodsWithCustomGoods { get => queryGoodsWithCustomGoods; }
        #endregion


        #region 查询输入或扫描的条码，并加入店铺购物车
        private static string queryGoodsInfoByGoodsCode = "code/queryGoodsInfoByGoodsCode";
        /// <summary>
        /// 查询输入或扫描的条码，并加入店铺购物车
        /// </summary>
        public static string QueryGoodsInfoByGoodsCode { get => queryGoodsInfoByGoodsCode; }
        #endregion


        #region 查询店铺的购物车
        private static string queryStoreshoppingcar = "code/queryStoreshoppingcar";
        /// <summary>
        /// 查询店铺的购物车
        /// </summary>
        public static string QueryStoreshoppingcar { get => queryStoreshoppingcar;}
        #endregion


        #region 清空店铺的购物车
        private static string deleteStoreshoppingcarAll = "code/deleteStoreshoppingcarAll";
        /// <summary>
        /// 清空店铺的购物车
        /// </summary>
        public static string DeleteStoreshoppingcarAll { get => deleteStoreshoppingcarAll;}
        #endregion

    }
}
