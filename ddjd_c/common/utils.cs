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


    }
}
