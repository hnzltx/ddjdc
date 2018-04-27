using ddjd_c.common.update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace update
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }




        //下载之后的命名
        string newFileName = "test.zip";

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            //下载
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileAsync(new Uri("http://192.168.199.215/test.zip"), newFileName);//要下载文件的路径,下载之后的命名
        }
        //  int index = 0;
        void wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            Action act = () =>
            {
                this.progressBarX1.Value = e.ProgressPercentage;
                this.labelX1.Text = e.ProgressPercentage + "%";

            };
            this.Invoke(act);

            if (e.ProgressPercentage == 100)
            {
                

                //下载完成之后开始覆盖

                //这个exe程序一直覆盖不了，直接删除；
                //先记录一下， 删除也没权限。。。
                //string ddjdcExe = Application.StartupPath + @"\ddjd_c.exe";
                //if (File.Exists(ddjdcExe)) {
                //    File.Delete(ddjdcExe);
                //}

                //System.IO.FileInfo file = new System.IO.FileInfo(Application.StartupPath + @"\ddjd_c.exe");
                //if (file.Exists)
                //{
                //    file.Delete();
                //}

                ZipHelper.Unzip(newFileName);//调用解压的类

                //此处更新完成；

                
                

                //重新打开ddjd_c.exe
                System.Diagnostics.Process.Start(Application.StartupPath + @"\ddjd_c.exe", System.IO.Directory.GetCurrentDirectory());

                //结束主线程
                System.Environment.Exit(System.Environment.ExitCode);   
            }
        }
    }
    
}
