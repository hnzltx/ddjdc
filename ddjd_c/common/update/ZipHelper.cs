﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.common.update
{
    public class ZipHelper
    {
        public static void Unzip(string fileName)
        {
            string _appPath = new DirectoryInfo(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName).Parent.FullName;
            
            
            System.Diagnostics.Process pNew = new System.Diagnostics.Process();

            
            pNew.StartInfo.FileName = _appPath +  @"\7-Zip\7z.exe";
            pNew.StartInfo.Arguments = string.Format(" x \"{0}\\{1}\" -y -o\"{0}\"", _appPath, fileName);
            //x "1" -y -o"2" 这段7z命令的意思： x是解压的意思 "{0}"的位置写要解压文件路径"{1}"这个1的位置写要解压的文件名 -y是覆盖的意思 -o是要解压的位置
            pNew.Start();
            //等待完成
            pNew.WaitForExit();
            //删除压缩包
            File.Delete(_appPath + @"\" + fileName);

        }
    }
}
