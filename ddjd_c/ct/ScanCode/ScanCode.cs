using ddjd_c.service.scanCode_service;
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
            addListView(this.tabGoodscategory.CreateTab("常用"),null);

            //查询分类集合
            List<model.goodscategory> goodsCategoryList =  service.goodsCategory_service.goodsCategoryService.queryGoodsCateGoryForOne();

            if (goodsCategoryList.Count > 0) {
                foreach (model.goodscategory g in goodsCategoryList) {
                    TabItem t =  this.tabGoodscategory.CreateTab(g.GoodsCategoryName);
                    t.Name = "goodscategory_" + g.GoodsCategoryId;
                    t.Click += new System.EventHandler(this.goodscategory_click);
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
            string[] strArray = t.Name.Split('_');
            addListView(t, int.Parse(strArray[1]));
        }




        /// <summary>
        /// 为TabItem添加listView
        /// </summary>
        /// <param name="item"></param>
        private void addListView(TabItem item,int? goodsCategoryId) {
            ListView lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.Click += new System.EventHandler(this.goodsListView_click);

            //每个listView显示的图片
            ImageList il = new ImageList();
            il.ImageSize = new Size(100, 100);
            
            //设置listView显示的图片
            lv.LargeImageList = il;

            Dictionary<String, object> d = new Dictionary<string, object>();
            if (null != goodsCategoryId) {
                //添加分类ID
                d.Add("fCategoryId", goodsCategoryId);
            }
            //查询此分类下的商品
            List<vo.goods.scanCodeGoods> listGoods = scanCodeService.queryGoodsWithCustomGoods(d);

            //商品数量大于0，进行遍历
            if (listGoods.Count > 0) {
                int i = 0;
                foreach (var goods in listGoods) {
                    Image img = Image.FromStream(WebRequest.Create(http.baseHttp.getDdjdcUrl() + goods.GoodsPic).GetResponse().GetResponseStream());

                    il.Images.Add(img);
                    lv.Items.Add(System.IO.Path.GetFileName(i.ToString()), i);
                    lv.Items[i].ImageIndex = i;
                    lv.Items[i].Name = goods.GoodsCode;
                    lv.Items[i].Text = goods.GoodsName;

                    i++;
                }
            }
            item.AttachedControl.Controls.Add(lv);

        }


        /// <summary>
        /// 为每个分类下面的商品添加点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goodsListView_click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            int selectCount = lv.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                addGoods(lv.SelectedItems[0].SubItems[0].Text,1,"10.55");
            }
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
                    addGoods("ceshi",1,"11");
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



        /// <summary>
        /// 添加商品 -  加入购物车
        /// </summary>
        protected void addGoods(string goodsName,int num,string money)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvShopcar);

            row.Cells[0].Value = goodsName;
            row.Cells[1].Value = num;
            row.Cells[2].Value = money;
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
