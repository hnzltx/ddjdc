using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.common;
using ddjd_c.common.extension;
using Newtonsoft.Json.Linq;

namespace ddjd_c.ct.good
{
    public partial class PublicGoodLibraryForm : Form
    {
        ///3级分类id
        private int? tCategoryId;
        //搜索条件
        private string goodsName;
        //分类数据源
        private List<model.goodscategory> goodscategoriesList = new List<model.goodscategory>();
        //保存每次选择的2级分类
        private List<model.goodscategory> goodscategoriesList2;
        ///选中商品id
        private List<String> selectGoodArr = new List<String>();
        public PublicGoodLibraryForm()
        {
            InitializeComponent();
        }

        private void PublicGoodLibraryForm_Load(object sender, EventArgs e)
        {
            ///禁用加入门店按钮
            btnAddStore.Enabled = false;
            //将本窗体的DataGridView传递给公共的dgv
            commDgv = this.dataGridViewX1;
            //禁用自动拼装所有实体对象
            commDgv.AutoGenerateColumns = false;
            loagPageConfig();
            LoadData();
            LoadCategory();
        }
        #region 加载商品数据
        /// <summary>
        /// 数据加载
        /// </summary>
        private void LoadData()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("pageNumber", this.ct_pageNumber);
            dic.Add("pageSize", this.ct_pageSize);
            if (this.tCategoryId != null)
            {
                dic.Add("tCategoryId", this.tCategoryId);
            }
            else
            {
                if (this.goodsName.StrIsNull() == false)
                {
                    dic.Add("goodsName", this.goodsName);
                }
            }
            ResponseResultDelegate action = RequestGoodListCallback;
            service.good.goodService.QueryGoodsInfoList_store(action, dic);

        }
        /// <summary>
        /// 商品请求回调
        /// </summary>
        private void RequestGoodListCallback(ResponseResult result, System.Threading.SynchronizationContext sc)
        {

            if (result.Error != null)
            {
                MessageBox.Show(result.Error);
                return;
            }
            sc.Post(RequestGoodListPostCallback, result);

        }
        /// <summary>
        /// 异步线程同步
        /// </summary>
        /// <param name="obj"></param>
        private void RequestGoodListPostCallback(object obj)
        {
            ResponseResult result = (ResponseResult)obj;
            //result.JsonStr = result.ToObj()["goodsList"].ToString();
            vo.pageInfo<model.good.goodEntity> pg = result.ToEntity<vo.pageInfo<model.good.goodEntity>>();
            //分页配置
            pageInfoConfig(pg);
            //赋值给BindingList
            BList = new BindingList<model.good.goodEntity>(pg.List);
            //显示数据
            commDgv.DataSource = BList;
        }
        #endregion

        #region 加载分类
        /// <summary>
        /// 加载分类数据
        /// </summary>
        private void LoadCategory()
        {
            ResponseResultDelegate action = CategoryCallback;
            //查询分类集合
            service.goodsCategory_service.goodsCategoryService.queryGoodsAllCateGory(action);
        }

        /// <summary>
        /// 分类请求回调
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sc"></param>
        private void CategoryCallback(ResponseResult result, System.Threading.SynchronizationContext sc)
        {

            if (result.Error != null)
            {
                MessageBox.Show(result.Error);
                return;
            }
            sc.Post(CategoryPostCallback, result);

        }
        /// <summary>
        /// 异步线程同步
        /// </summary>
        /// <param name="obj"></param>
        private void CategoryPostCallback(object obj)
        {
            ResponseResult result = (ResponseResult)obj;
            JArray ja = JArray.Parse(result.JsonStr);
            //拿到一级分类
            this.goodscategoriesList.AddRange(JsonHelper.DeserializeJsonToList<model.goodscategory>(ja.ToString()));

            ///显示的值
            this.cbx1.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx1.ValueMember = "GoodsCategoryId";

            this.cbx1.DataSource = this.goodscategoriesList;


            ///给23级分类赋值
            for (var i = 0; i < goodscategoriesList.Count; i++)
            {
                JObject j = JObject.Parse(ja[i].ToString());
                this.goodscategoriesList[i].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(j["list"].ToString());
                if (this.goodscategoriesList[i].List != null)
                {
                    for (var ii = 0; ii < this.goodscategoriesList[i].List.Count; ii++)
                    {
                        JObject jj = JObject.Parse(JArray.Parse(j["list"].ToString())[ii].ToString());
                        this.goodscategoriesList[i].List[ii].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(jj["list"].ToString());

                    }
                }

            }
        }
        #endregion
        #region 分页代码
        /** 目前分页需要改动的只有泛型对象， 
         * 按道理将所有model都继承一个baseModel，稍作改动即可使分页更加通用，暂时记着，以后看改不改 —_—*/

        //公共的DataGridView；为了分页通用，在窗体加载时，将需要分页的DataGridView传递给此对象；
        DataGridView commDgv;
        //数据绑定到dataGridView的泛型集合，方便后期操作；   -- 此处的 T 需要改成你需要的对象
        BindingList<model.good.goodEntity> BList;
        //当前窗体的每页查询条数
        int ct_pageSize = 20;
        //当前窗体已经查询到第几页
        int ct_pageNumber = 1;
        //数据总页数
        int ct_totalPage = 1;
        /// <summary>
        /// 绑定分页控件和事件代码的关系；  在窗体加载时调用
        /// </summary>
        private void loagPageConfig()
        {
            //尾页事件
            this.btnEndPage.Click += new EventHandler(this.btnEndPage_Click);
            //首页事件
            this.btnHomePage.Click += new EventHandler(this.btnHomePage_Click);
            //下一页事件
            this.btnNextPage.Click += new EventHandler(this.btnNextPage_Click);
            //上一页事件
            this.btnPreviousPage.Click += new EventHandler(this.btnPreviousPage_Click);
            //页面条数显示框默认显示条数
            this.cmbSelect.Text = ct_pageSize.ToString();
            //绑定页面显示条数设置控件的TextChanged事件
            this.cmbSelect.SelectedIndexChanged += new EventHandler(cmbSelect_TextChanged);
        }
        /// <summary>
        /// 分页控件配置
        /// </summary>
        /// <param name="pg"></param>
        private void pageInfoConfig(vo.pageInfo<model.good.goodEntity> pg)
        {

            //数据总数
            this.lblCount.Text = pg.TotalRow.ToString();
            //总页数
            ct_totalPage = pg.TotalPage.Value;

            if (pg.LastPage)
            {
                //如果是最后一页，禁用下一页和尾页
                btnNextPage.Enabled = false;
                btnEndPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
                btnEndPage.Enabled = true;
            }

            if (pg.FirstPage)
            {
                //如果是第一页，禁用首页和上一页
                btnHomePage.Enabled = false;
                btnPreviousPage.Enabled = false;
            }
            else
            {
                btnHomePage.Enabled = true;
                btnPreviousPage.Enabled = true;
            }

        }


        /// <summary>
        /// 首页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHomePage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = 1;
            LoadData();
        }

        /// <summary>
        /// 每页多少条的选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelect_TextChanged(object sender, EventArgs e)
        {
            //当前选择的每页多少条
            int selectPageSize = int.Parse(this.cmbSelect.SelectedItem.ToString());
            //设置公共每页多少条
            ct_pageSize = selectPageSize;
            //如果当前选择的数量  大于或等于 总的数据条数
            if (selectPageSize >= int.Parse(this.lblCount.Text))
            {
                //回到第一页
                ct_pageNumber = 1;
            }
            LoadData();

        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber - 1;
            LoadData();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber + 1;
            LoadData();
        }


        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_totalPage;
            LoadData();
        }



        #endregion

        //#region 页面事件
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ///添加行数
            using (SolidBrush b = new SolidBrush(this.dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }
        /// <summary>
        /// 右键单击 弹出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (this.dataGridViewX1.Rows[e.RowIndex].Selected == false)
                    {
                        this.dataGridViewX1.ClearSelection();
                        this.dataGridViewX1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (this.dataGridViewX1.SelectedRows.Count == 1)
                    {
                        this.dataGridViewX1.CurrentCell = this.dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.tCategoryId = null;
            this.goodsName = this.txtSearch.Text;
            ///加载数据
            LoadData();
        }

        /// <summary>
        /// 根据3级分类查询商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreening_Click(object sender, EventArgs e)
        {
            this.goodsName = null;
            this.txtSearch.Text = null;
            this.tCategoryId = int.Parse(cbx3.SelectedValue.ToString());
            ///加载数据
            LoadData();

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
        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            var goodsId = this.dataGridViewX1.Rows[this.dataGridViewX1.CurrentRow.Index].Cells[0].Value.ToString();
            PublicGoodLibraryDetailForm frm = new PublicGoodLibraryDetailForm();
            frm.Tag=goodsId;
            frm.action = AddStoreCallback;
            frm.ShowDialog();
        }
        /// <summary>
        /// 详情单个加入门店成功回调
        /// </summary>
        private void AddStoreCallback(string goodsId)
        {
            selectGoodArr.Remove(goodsId);
            LoadData();
            UpdateSelectedGoodCount();
        }
        /// <summary>
        /// 加入门店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var rowIndex = this.dataGridViewX1.CurrentRow.Index;
            var goodsId = this.dataGridViewX1.Rows[rowIndex].Cells[0].Value.ToString();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId",GlobalsInfo.storeId);
            dic.Add("goodsId", goodsId+",");
            string success = service.good.goodService.AddGoodsInfoGoToStoreAndGood(dic)["success"].ToString();
            contextMenuStrip1.Close();
            if (success.Equals("success"))
            {
                selectGoodArr.Remove(goodsId);
                UpdateSelectedGoodCount();
                LoadData();
                MessageBox.Show("加入成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        /// <summary>
        /// 单击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ///商品id
            var goodsId = this.dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //1选中0没有选中
            var value = this.dataGridViewX1.Rows[e.RowIndex].Cells[1].Value;
            if (value != null)
            {
                if(value.Equals("0"))
                {
                    value = "1";
                    selectGoodArr.Add(goodsId);
                    
                }
                else
                {
                    value = "0"; 
                    selectGoodArr.Remove(goodsId);
                    
                }
            }
            else
            {
                value = "1";
                selectGoodArr.Add(goodsId);
            }
            this.dataGridViewX1.Rows[e.RowIndex].Cells[1].Value = value;
            UpdateSelectedGoodCount();
        }

        /// <summary>
        /// 单元格错误处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
        /// <summary>
        /// 设置单元格显示选中状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ///商品id
            var goodsId = this.dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //查询当前选中数组中是否有对应的goodsId
            var v =
                 from str in this.selectGoodArr
                 where str == goodsId
                 select str;
            var goodId = v.FirstOrDefault() == null?null: v.FirstOrDefault().ToString();
            if (goodsId.Equals(goodId))
            {
                this.dataGridViewX1.Rows[e.RowIndex].Cells[1].Value = 1;
            }
        }

        /// <summary>
        /// 把商品批量加入门店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStore_Click(object sender, EventArgs e)
        {
            StringBuilder goodsId=new StringBuilder();
            foreach (string str in this.selectGoodArr)
            {
                goodsId.Append(str);
                goodsId.Append(",");
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("goodsId", goodsId);
            JObject obj = service.good.goodService.AddGoodsInfoGoToStoreAndGood(dic);
            string success = obj["success"].ToString();
            int isFailCount = obj["isFailCount"].ToString().ToInt();
            contextMenuStrip1.Close();
            if (success.Equals("success"))
            {
                LoadData();
                if (isFailCount > 0)
                {
                    if(MessageBox.Show("有"+isFailCount+"个商品添加失败") == DialogResult.OK)
                    {
                        MessageBox.Show("成功加入"+(selectGoodArr.Count- isFailCount)+"个商品到您的店铺");
                    }
                }
                else
                {
                    MessageBox.Show("成功加入" + (selectGoodArr.Count) + "个商品到您的店铺");
                }
                
                
                selectGoodArr.Clear();
                UpdateSelectedGoodCount();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
        /// <summary>
        /// 更新选中商品数量
        /// </summary>
        private void UpdateSelectedGoodCount()
        {
            this.lblSelectedGoodCount.Text = "已选中" + selectGoodArr.Count + "个商品";
            if (selectGoodArr.Count > 0)//如果有选中商品  加入门店按钮可以点击
            {
                btnAddStore.Enabled = true;
            }
            else
            {
                btnAddStore.Enabled = false;
            }
        }
    }
}
