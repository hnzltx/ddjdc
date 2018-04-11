using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Net;


namespace ddjd_c.common.extension
{
    public class ExtensionImage
    {
        /// <summary>
        /// 根据url获取图片   如果没有返回默认图片
        /// </summary>
        /// <param name="imgUrl">图片路径</param>
        /// <param name="type">返回默认图片类型</param>
        /// <returns>Image</returns>
        public static Image HttpGetImage(string imgUrl,DefaultImgType type)
        {
         
            Stream stream;
            Image image;
            try
            {

                stream = WebRequest.Create(imgUrl).GetResponse().GetResponseStream();
                image=Image.FromStream(stream);

            }
            catch (Exception err)
            {
               
                Console.Write(err.ToString());
    
                switch (type){
                    case DefaultImgType.Classify:
                        image = Properties.Resources.logo;
                        break;
                    case DefaultImgType.Good:
                        image = Properties.Resources.default_icon;
                        break;
                    case DefaultImgType.Order:
                        image = Properties.Resources.logo;
                        break;
                    case DefaultImgType.Logo:
                        image = Properties.Resources.logo;
                        break;
                    default:
                        image = Properties.Resources.logo;
                        break;
                }
            }
            return image;
        }
    }
    /// <summary>
    /// 默认图片类型选择
    /// </summary>
    public enum DefaultImgType
    {
        /// <summary>
        /// 商品图片
        /// </summary>
        Good,
        /// <summary>
        /// 订单图片
        /// </summary>
        Order,
        /// <summary>
        /// 分类图片
        /// </summary>
        Classify,
        /// <summary>
        /// logo 图片
        /// </summary>
        Logo


    }
}
