using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using ddjd_c.common;
using ddjd_c.common.extension;
using ddjd_c.common.AllRequest;
using ddjd_c.service;

namespace ddjd_c.ct.good
{
    public partial class goodManagement : Form
    {
        //默认等于1
        private int pageNumber = 1;
        //每页展示20条数据
        private int pageSize = 20;
        ///默认查询 上架商品 1上架 2下架 3审核中 4审核失败
        private int goodsFlag = 1;
        //商品数据源
        private List<model.good.goodEntity> list = new List<model.good.goodEntity>();
        //分类数据源
        private List<model.goodscategory> goodscategoriesList = new List<model.goodscategory>();
        //保存每次选择的2级分类
        private List<model.goodscategory> goodscategoriesList2;

        public goodManagement()
        {
            InitializeComponent();

        }


        private void goodManagement_Load(object sender, EventArgs e)
        {
            ///默认选择第一个
            this.tab.SelectedTab = this.tabItem1;
            ///隐藏数据源自动绑定列
            this.dataGridViewX1.AutoGenerateColumns = false;
            ///加载分类数据
            LoadCategory();
            ///加载数据
            LoadData(this.pageNumber, this.pageSize, null);


        }

        /// <summary>
        /// 加载商品数据
        /// </summary>
        private void LoadData(int pageNumber, int pageSize, int? tCategoryId = null, string goodsName = null)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("goodsFlag", this.goodsFlag);
            dic.Add("pageNumber", pageNumber);
            dic.Add("pageSize", pageSize);
            if (tCategoryId != null)
            {
                dic.Add("tCategoryId", tCategoryId);
            }
            else
            {
                if (goodsName.StrIsNull() == false)
                {
                    dic.Add("goodsName", goodsName);
                }
            }
            JObject obj = service.good.goodService.QueryStoreAndGoodsList(dic);
            this.list.AddRange(JsonHelper.DeserializeJsonToList<model.good.goodEntity>(obj["list"].ToString()));
            this.dataGridViewX1.DataSource = null;
            this.dataGridViewX1.DataSource = this.list;
        }

        /// <summary>
        /// 加载分类数据
        /// </summary>
        private void LoadCategory()
        {
            //查询分类集合
            JArray obj = service.goodsCategory_service.goodsCategoryService.queryGoodsAllCateGory();
            //拿到一级分类
            this.goodscategoriesList.AddRange(JsonHelper.DeserializeJsonToList<model.goodscategory>(obj.ToString()));

            ///显示的值
            this.cbx1.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx1.ValueMember = "GoodsCategoryId";

            this.cbx1.DataSource = this.goodscategoriesList;


            ///给23级分类赋值
            for (var i = 0; i < goodscategoriesList.Count; i++)
            {
                JObject j = JObject.Parse(obj[i].ToString());
                this.goodscategoriesList[i].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(j["list"].ToString());

                for (var ii = 0; ii < this.goodscategoriesList[i].List.Count; ii++)
                {
                    JObject jj = JObject.Parse(JArray.Parse(j["list"].ToString())[ii].ToString());
                    this.goodscategoriesList[i].List[ii].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(jj["list"].ToString());

                }
            }




        }


        /// <summary>
        /// tab切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            this.goodsFlag = this.tab.SelectedTabIndex + 1;
            ClearList();
            ///加载数据
            LoadData(this.pageNumber, this.pageSize, null);
        }

        /// <summary>
        /// 数据错误处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ///添加行数
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string goodName = this.txtSearch.Text;
            ClearList();
            ///加载数据
            LoadData(this.pageNumber, this.pageSize, null, goodName);
        }

        /// <summary>
        /// 删除数据数据 重新加载数据
        /// </summary>
        private void ClearList()
        {
            ///清除数组
            this.list.Clear();
            ///从第一页开始
            this.pageNumber = 1;
        }

        /// <summary>
        /// 根据3级分类查询商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreening_Click(object sender, EventArgs e)
        {
            int tCategoryId = int.Parse(cbx3.SelectedValue.ToString());
            ClearList();
            ///加载数据
            LoadData(this.pageNumber, this.pageSize, tCategoryId);

        }
        private void cbx1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //查询当前分类id下面对应的2级分类
            var list =
                 from value in this.goodscategoriesList
                 where value.GoodsCategoryId == int.Parse(cbx1.SelectedValue.ToString())
                 select value;
            this.goodscategoriesList2 = list.FirstOrDefault().List;
            this.cbx2.DataSource = this.goodscategoriesList2;
            ///显示的值
            this.cbx2.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx2.ValueMember = "GoodsCategoryId";
        }

        private void cbx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //查询当前分类id下面对应的2级分类
            var list =
                 from value in this.goodscategoriesList2
                 where value.GoodsCategoryId == int.Parse(cbx2.SelectedValue.ToString())
                 select value;
            this.cbx3.DataSource = list.FirstOrDefault().List;
            ///显示的值
            this.cbx3.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx3.ValueMember = "GoodsCategoryId";
        }




        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.Write("fjsdjfajhfhahlf");
            ct.good.goodDetail frm = new ct.good.goodDetail();

            frm.ShowDialog();

        }
    }
}
