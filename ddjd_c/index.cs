﻿using DevComponents.DotNetBar;
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
        public void openWindow(Form frm, string Name)
        {
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
            tp.Text = frm.Text;
            tp.Name = Name;

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
    }
}
