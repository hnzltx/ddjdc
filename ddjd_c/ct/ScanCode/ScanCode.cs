using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.ScanCode
{
    public partial class frmScanCode : Form
    {
        public frmScanCode()
        {
            InitializeComponent();
        }



        private void frmScanCode_Load(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width1 = ScreenArea.Width;
            int height1 = ScreenArea.Height;
            this.Width = width1;
            this.Height = height1;
            this.Top = 0;
            this.Left = 0;
            this.TopMost = true;

            //输入条码框获取焦点
            this.textCode.Focus();

            //添加默认常用选项 ,并添加listview
            addListView(this.tabGoodscategory.CreateTab("常用"));

            //查询分类集合
            List<model.goodscategory> goodsCategoryList =  service.goodsCategory_service.goodsCategoryService.queryGoodsCateGoryForOne();

            if (goodsCategoryList.Count > 0) {
                foreach (model.goodscategory g in goodsCategoryList) {
                    TabItem t =  this.tabGoodscategory.CreateTab(g.GoodsCategoryName);
                    t.Name = "goodscategory" + g.GoodsCategoryId;
                    t.Click += new System.EventHandler(this.goodscategory_click);

                    Label l = new Label();
                    l.Text = "面板" + g.GoodsCategoryId;
                    t.AttachedControl.Controls.Add(l);
                }
            }


        }

        /// <summary>
        ///  分类的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goodscategory_click(object sender, EventArgs e)
        {
            TabItem t = (TabItem)sender;
            MessageBox.Show(t.Name);
        }



        /// <summary>
        ///  分类中商品的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goodsList_click(object sender, EventArgs e)
        {
            TabItem t = (TabItem)sender;
            MessageBox.Show(t.Name);
        }


        /// <summary>
        /// 为TabItem添加listView
        /// </summary>
        /// <param name="item"></param>
        private void addListView(TabItem item) {
            ListView lv = new ListView();
            lv.Dock = DockStyle.Fill;

            ImageList il = new ImageList();
            il.ImageSize = new Size(100, 100);

            lv.LargeImageList = il;

            for (int i = 0; i < 10; i++) {
                Image img = Image.FromStream(WebRequest.Create(http.baseHttp.getDdjdcUrl() + "/statics/upload/storeQrcode/2017-11/zltx_store_18.png").GetResponse().GetResponseStream());
               
                il.Images.Add(img);

                lv.Items.Add(System.IO.Path.GetFileName(i.ToString()), i);
                lv.Items[i].ImageIndex = i;
                lv.Items[i].Name = "商品" + i;
            }
            
            
            item.AttachedControl.Controls.Add(lv);

        }



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
                    if (MessageBox.Show("确认退出收银界面?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    return true;
                case Keys.Enter:
                    addGoods();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



        /// <summary>
        /// 添加商品 -  加入购物车
        /// </summary>
        protected void addGoods()
        {

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvShopcar);

            row.Cells[0].Value = "商品一";
            row.Cells[1].Value = "3";
            row.Cells[2].Value = "20";
            dgvShopcar.Rows.Add(row);
            row.Selected = true;
            this.textCode.Text = "";

        }


        /// <summary>
        /// 显示当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
