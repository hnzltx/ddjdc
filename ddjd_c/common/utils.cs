using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.common
{
    class utils
    {


        /// <summary>
        /// 应该可以存放xml，json数据。 还只测试了存放json数据； 
        /// </summary>
        /// <param name="Catalog">数据文件要存放到db下的哪个目录下</param>
        /// <param name="fileName">文件的名称；  如:  test.json </param>
        /// <param name="data">数据；</param>
        /// <returns></returns>
        public static bool writeFile(string Catalog,string fileName,object data) {

            try
            {
                string url = @"..\..\db\";
                url += Catalog;
                url += @"\";
                url += fileName;
                if (!File.Exists(url))
                {
                    FileStream fs1 = new FileStream(url, FileMode.Create, FileAccess.ReadWrite);
                    fs1.Close();
                }
                File.WriteAllText(url, data.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        /// <summary>
        /// 检查文件是否存在；  没有检查文件夹
        /// </summary>
        /// <param name="Catalog"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool FileExists(string Catalog, string fileName) {
            string url = @"..\..\db\";
            url += Catalog;
            url += @"\";
            url += fileName;
            if (File.Exists(url))
            {
                return true;
            }
            else {
                return false;
            }
        }


        /// <summary>
        /// 读取文件； 返回json格式
        /// </summary>
        /// <param name="Catalog"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static JObject getFile(string Catalog, string fileName) {
            string url = @"..\..\db\";
            url += Catalog;
            url += @"\";
            url += fileName;
            var sourceContent = File.ReadAllText(url);
            return JObject.Parse(sourceContent);
        }



        /// <summary>
        /// 将某金额，截取后保留N位小数点返回  ；  -- 是截取 ，不是四舍五入
        /// </summary>
        /// <param name="d">金额</param>
        /// <param name="n">保留几位</param>
        /// <returns></returns>
        public static decimal CutDecimalWithN(decimal d, int n)
        {
            string strDecimal = d.ToString();
            int index = strDecimal.IndexOf(".");
            if (index == -1 || strDecimal.Length < index + n + 1)
            {
                strDecimal = string.Format("{0:F" + n + "}", d);
            }
            else
            {
                int length = index;
                if (n != 0)
                {
                    length = index + n + 1;
                }
                strDecimal = strDecimal.Substring(0, length);
            }
            return Decimal.Parse(strDecimal);
        }


    }
}
