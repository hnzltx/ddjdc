using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.ct;
using System.Collections;

namespace ddjd_c
{
    public partial class indexName : Form
    {
        public indexName()
        {
            InitializeComponent();
        }

        private void indexName_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " --【" + GlobalsInfo.storeName + "】";
            //lblDate.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日 HH:mm:ss");

            ///隐藏最大化和关闭按钮
            ArrayList items = ribbonControl1.RibbonStrip.GetItems("", typeof(SystemCaptionItem));
            foreach (SystemCaptionItem sci in items)
            {
                if (!sci.IsSystemIcon)
                {

                    //sci.MinimizeVisible = false;
                    sci.RestoreMaximizeVisible = false;
                    sci.CloseVisible = false;
                    break;
                }
            }


            loadAppConfig();
        }

        


        /// <summary>
        /// 检测要打开的tab
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;

            foreach (TabItem tab in tabMain.Tabs)
            {
                if (tab.Name == tabName.Trim())
                {
                    isOpened = true;
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
            return isOpened;
        }


        /// <summary>
        /// 打开窗体，加入tab
        /// </summary>
        /// <param name="frm">窗体</param>
        /// <param name="Name">窗体的name</param>
        /// <param name="isRefresh">是否是刷新窗体</param>
        /// <param name="isRefreshStr">如果是刷新窗体，可以带上一段描述</param>
        public void openWindow(Form frm, string Name,bool isRefresh = false,string isRefreshStr = "")
        {
            //如果当前窗体已经打开
            if (IsOpenTab(Name)) {
                //刷新状态为 true
                if (isRefresh)
                {
                    //移除当前窗体
                    TabItem tb = tabMain.SelectedTab;
                    tabMain.Tabs.Remove(tb);
                }
            }

            DevComponents.DotNetBar.TabItem tp = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tcp = new DevComponents.DotNetBar.TabControlPanel();
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            tcp.Location = new System.Drawing.Point(0, 0);

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Name = Name;

            if (isRefresh)
                tp.Text = frm.Text + " -- " + isRefreshStr;
            else
                tp.Text = frm.Text;

            if (!IsOpenTab(Name))
            {
                tcp.TabItem = tp;
                tp.AttachedControl = tcp;
                tabMain.Controls.Add(tcp);
                tabMain.Tabs.Add(tp);
                tabMain.SelectedTab = tp;
            }
            tabMain.Refresh();

            
        }


        private void tp_MouseDown(object sender, MouseEventArgs e)
        {
            tabMain.SelectedTab = (TabItem)sender;
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            TabItem tb = tabMain.SelectedTab;
            tabMain.Tabs.Remove(tb);
        }

        

        private void buttonItem2_Click(object sender, EventArgs e)
        {

        }
        

        private void btnMCloseAll_Click_1(object sender, EventArgs e)
        {
            tabMain.Tabs.Clear();
        }

        private void btnMCloseOther_Click(object sender, EventArgs e)
        {
            do
            {
                if (tabMain.SelectedTab != tabMain.Tabs[0])
                {
                    tabMain.Tabs.RemoveAt(0);
                }
                else
                {
                    tabMain.Tabs.RemoveAt(1);
                }

            } while (tabMain.Tabs.Count != 1);

            tabMain.Refresh();
        }


        private void tabMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void tabMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        /// <summary>
        /// 点击跳转到店铺信息界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStoreInfo_Click(object sender, EventArgs e)
        {
            ct.store.frmStoreInfo frm = new ct.store.frmStoreInfo();
            openWindow(frm, frm.Name);
        }


        /// <summary>
        /// 跳转到收银界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScanCode_Click(object sender, EventArgs e)
        {
            ct.ScanCode.frmScanCode frm = new ct.ScanCode.frmScanCode();
            frm.Show();
            //openWindow(frm, frm.Name);
        }

        /// <summary>
        /// 跳转到关于我们界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            ct.AboutUs.frmAboutUs frm = new ct.AboutUs.frmAboutUs();
            openWindow(frm,frm.Name);
        }


       /// <summary>
       /// 跳转到收银秤设置界面
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnSetCashierScale_Click(object sender, EventArgs e)
        {
            ct.Set.frmSetCashierScale frm = new ct.Set.frmSetCashierScale();
            openWindow(frm, frm.Name);
        }

        /// <summary>
        /// 左上角退出程序按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出本程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        /// <summary>
        /// 加载一些配置文件
        /// </summary>
        private void loadAppConfig() {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 订单待发货按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder1_Click(object sender, EventArgs e)
        {
            ct.Order.frmOrder frm = new ct.Order.frmOrder(2);
            openWindow(frm, frm.Name,true,"待发货");
        }
        

        private void btnOrder2_Click(object sender, EventArgs e)
        {
            ct.Order.frmOrder frm = new ct.Order.frmOrder(3);
            openWindow(frm, frm.Name, true, "已发货");
        }

        private void btnOrder3_Click(object sender, EventArgs e)
        {
            ct.Order.frmOrder frm = new ct.Order.frmOrder(4);
            openWindow(frm, frm.Name, true, "已完成");
        }

        /// <summary>
        /// 跳转到所有商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllGood_Click(object sender, EventArgs e)
        {
            ct.good.goodManagement frm = new ct.good.goodManagement();
            openWindow(frm, frm.Name);
        }

        /// <summary>
        /// 跳转打印机设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            ct.Set.frmSetPrint frm = new ct.Set.frmSetPrint();
            openWindow(frm, frm.Name);
        }



        #region 退出程序
        
        /// <summary>
        /// 退出程序按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出本程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void tabItemClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出本程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        #endregion



        #region 页面键盘捕捉
        /// <summary>
        /// 页面键盘捕捉
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出本程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    return true;
                case Keys.Enter:
                    
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion


        
        /// <summary>
        /// 跳转到审核商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExamine_Click(object sender, EventArgs e)
        {
            ct.good.ExamineGoodtForm frm = new ct.good.ExamineGoodtForm();
            openWindow(frm, frm.Name);
        }
        /// <summary>
        /// 跳转到商品上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoodUpload_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 跳转到公共商品库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublicGoodLibrary_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 跳转到首页推荐区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIndexRecommendGood_Click(object sender, EventArgs e)
        {
            ct.good.IndexRecommendGoodForm frm = new ct.good.IndexRecommendGoodForm();
            openWindow(frm, frm.Name);
        }

        /// <summary>
        /// 跳转到促销区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPromotion_Click(object sender, EventArgs e)
        {
            ct.good.PromotionGoodForm frm = new ct.good.PromotionGoodForm();
            openWindow(frm,frm.Name);
        }
    }
}
