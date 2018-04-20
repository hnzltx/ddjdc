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
        ///3级分类id
        private int? tCategoryId;
        //搜索条件
        private string goodsName;
        ///默认查询 上架商品 1上架 2下架 3审核中 4审核失败
        private int goodsFlag = 1;
        //商品数据源
        private List<model.good.goodEntity> list;
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
            //将本窗体的DataGridView传递给公共的dgv
            commDgv = this.dataGridViewX1;

            //页面条数显示框默认显示条数
            this.cmbSelect.Text = ct_pageSize.ToString();

            //绑定页面显示条数设置控件的TextChanged事件
            this.cmbSelect.SelectedIndexChanged += new EventHandler(cmbSelect_TextChanged);
            ///隐藏数据源自动绑定列
            this.dataGridViewX1.AutoGenerateColumns = false;
            ///加载分类数据
            LoadCategory();
            ///加载数据
            LoadData();


        }

        /// <summary>
        /// 加载商品数据
        /// </summary>
        private void LoadData()
        {
            

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("goodsFlag", this.goodsFlag);
            dic.Add("pageNumber",this.ct_pageNumber);
            dic.Add("pageSize", this.ct_pageSize);
            if (this.tCategoryId != null)
            {
                dic.Add("tCategoryId",this.tCategoryId);
            }
            else
            {
                if (this.goodsName.StrIsNull() == false)
                {
                    dic.Add("goodsName",this.goodsName);
                }
            }
            ResponseResultDelegate action = RequestGoodListCallback;
            service.good.goodService.QueryStoreAndGoodsList(action,dic);
            
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
                sc.Post(RequestGoodListPostCallback,result);
            
        }
        /// <summary>
        /// 异步线程同步
        /// </summary>
        /// <param name="obj"></param>
        private void RequestGoodListPostCallback(object obj)
        {
            vo.pageInfo<model.good.goodEntity> pg = ((ResponseResult)obj).ToEntity<vo.pageInfo<model.good.goodEntity>>();
            this.list = pg.List;
            //分页配置
            pageInfoConfig(pg);
            //赋值给BindingList
            BList = new BindingList<model.good.goodEntity>(pg.List);
            //显示数据
            commDgv.DataSource = BList;
        }
        /// <summary>
        /// 加载分类数据
        /// </summary>
        private void LoadCategory()
        {
            ResponseResultDelegate action=CategoryCallback;
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
            LoadData();
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
            this.tCategoryId = null;
            this.goodsName = this.txtSearch.Text;
            ClearList();
            ///加载数据
            LoadData();
        }

        /// <summary>
        /// 删除数据数据 重新加载数据
        /// </summary>
        private void ClearList()
        {
            
            ///从第一页开始
            this.ct_pageNumber = 1;
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
            ClearList();
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




        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            model.good.goodEntity entity = this.list[e.RowIndex];
            ct.good.goodDetail frm = new ct.good.goodDetail(entity.StoreAndGoodsId,e.RowIndex);
            frm.UpdateGoodList += new UpdateGoodListDelegate(Frm_UpdateGoodList);
            
            frm.ShowDialog();

        }

        /// <summary>
        /// 修改商品成功后执行
        /// </summary>
        /// <param name="goodFlag"></param>
        private void Frm_UpdateGoodList(int goodFlag,int rowIndex)
        {
         
            ///加载数据
            LoadData();
            if(goodFlag == this.goodsFlag)
            {
                GridViewSelectedSpecifiedRow(rowIndex);
            }
       
            

        }
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

       
        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "goodsStutas")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().ToInt() == 3 ? "是" : "否";
                    e.FormattingApplied = true;
                }
                else
                    return;
               

            }
            else
            {
                if (dgv.Columns[e.ColumnIndex].Name == "indexGoodsId")
                {
                    if (e.Value != null)
                    {
                        e.Value = e.Value.ToString().ToInt() > 0 ? "是" : "否";

                    }
                    else
                    {
                        e.Value = "否";
                    }
                    e.FormattingApplied = true;

                }
                else
                    return;
                
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
                    model.good.goodEntity entity = this.list[e.RowIndex];
                    
                    ToolStripMenuItem1.Text = goodsFlag == 1 ? "下架" : "上架";
                    if(goodsFlag == 1)//如果是上架
                    {
                        ToolStripMenuItem2.Visible = true;
                        ToolStripMenuItem3.Visible = true;
                        ToolStripMenuItem2.Text = entity.IndexGoodsId == null ? "加入首页推荐" : "从首页推荐移除";
                        ToolStripMenuItem2.Name = entity.IndexGoodsId.ToString();
                        ToolStripMenuItem3.Text = entity.GoodsStutas == 3 ? "从促销区移除" : "加入促销";
                        ToolStripMenuItem3.Tag = entity.GoodsStutas;
                    }
                    else //如果是下架隐藏
                    {
                        ToolStripMenuItem2.Visible = false;
                        ToolStripMenuItem3.Visible = false;
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        
        /// <summary>
        /// 操作商品上下架  加入促销 移除促销  加入推荐区 移除推荐区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            model.good.goodEntity entity= this.list[this.dataGridViewX1.CurrentCell.RowIndex];
            if (ToolStripMenuItem1.Selected == true)//上下架
            {
                GoodUpAndDownFrame(entity.StoreAndGoodsId, this.goodsFlag == 1 ? 2 : 1);
            }
            if (ToolStripMenuItem2.Selected == true)
            {
                if(entity.IndexGoodsId == null) {//加入首页推荐
                    AddIndexGood(entity.StoreAndGoodsId, this.dataGridViewX1.CurrentCell.RowIndex);
                }
                else //从首页推荐移除
                {
                    DeleteIndexGood(entity.StoreAndGoodsId, this.dataGridViewX1.CurrentCell.RowIndex);
                }
                
            }
            if (ToolStripMenuItem3.Selected == true)
            {
                if(entity.GoodsStutas == 3)//移除促销
                {
                    RemovePromotiongoods(entity.StoreAndGoodsId, this.dataGridViewX1.CurrentCell.RowIndex);
                }
                else //加入促销
                {
                    AddPromotiongood(entity.StoreAndGoodsId, this.dataGridViewX1.CurrentCell.RowIndex);
                }
            }
        }

        #region 商品操作
        /// <summary>
        /// 商品上下架
        /// </summary>
        /// <param name="storeAndGoodsId"></param>
        /// <param name="goodFlag">上下架状态</param>
        private void GoodUpAndDownFrame(int? storeAndGoodsId, int goodFlag)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId", storeAndGoodsId);
            dic.Add("goodsFlag", goodFlag);
            JObject obj = service.good.goodService.UpdateGoodsFlagByStoreAndGoodsId(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                   
                    contextMenuStrip1.Close();
                    MessageBox.Show(goodFlag == 1 ? "上架成功" : "下架成功");
                    LoadData();
                    break;
                case "incomplete":
                    MessageBox.Show("部分参数没有填写或填写的值小于等于0； （零售价，进货价，库存）；不能上下架");
                    break;
                default:
                    MessageBox.Show("操作失败");
                    break;
            }
        }
        /// <summary>
        /// 店铺移除首页推荐商品
        /// </summary>
        /// <param name="storeAndGoodsId"></param>
        private void DeleteIndexGood(int? storeAndGoodsId,int rowIndex)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId", storeAndGoodsId);
            dic.Add("storeId", GlobalsInfo.storeId);
            JObject obj = service.good.goodService.RemoveIndexGoods(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    contextMenuStrip1.Close();
                    MessageBox.Show("移除成功");
                    LoadData();
                    GridViewSelectedSpecifiedRow(rowIndex);
                    break;
                default:
                    MessageBox.Show("操作失败");
                    break;
            }
        }
        /// <summary>
        /// 添加首页推荐商品
        /// </summary>
        /// <param name="storeAndGoodsId"></param>
        
        private void AddIndexGood(int? storeAndGoodsId,int rowIndex)
        {
            inputTxtSort frm = new inputTxtSort(storeAndGoodsId,rowIndex);
            frm.GetInputText += new GetInputTextDelegate(Frm_GetInputText);
            frm.ShowDialog();
        }
        /// <summary>
        /// 获取排序输入值
        /// </summary>
        /// <param name="str"></param>
        private void Frm_GetInputText(string str,int? storeAndGoodsId,int rowIndex)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId", storeAndGoodsId);
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("sort", str);
            JObject obj = service.good.goodService.AddIndexGoods(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    contextMenuStrip1.Close();
                    MessageBox.Show("加入成功");
                    LoadData();
                    GridViewSelectedSpecifiedRow(rowIndex);
                    break;
                case "exist":
                    MessageBox.Show("该商品已经加入到首页推荐区");
                    break;
                default:
                    MessageBox.Show("加入失败");
                    break;
            }
        }

        /// <summary>
        /// 加入促销
        /// </summary>
        private void AddPromotiongood(int? storeAndGoodsId, int rowIndex)
        {
            AddPromotiongoodForm frm = new AddPromotiongoodForm(storeAndGoodsId,rowIndex);
            frm.UpdateGoodList = Frm_UpdateGoodList;
            frm.ShowDialog();
        }
        /// <summary>
        /// 移除促销商品
        /// </summary>
        /// <param name="storeAndGoodsId"></param>
        /// <param name="rowIndex"></param>
        private void RemovePromotiongoods(int? storeAndGoodsId, int rowIndex)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId", storeAndGoodsId);
            dic.Add("storeId", GlobalsInfo.storeId);
            JObject obj = service.good.goodService.RemovePromotiongoods(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    contextMenuStrip1.Close();
                    MessageBox.Show("移除成功");
                    LoadData();
                    GridViewSelectedSpecifiedRow(rowIndex);
                    break;
                case "notExist":
                    MessageBox.Show("商品不存在");
                    break;
                case "storeDifferent":
                    MessageBox.Show("商品不是这个店铺的，不能移除");
                    break;
                case "notcuxiao":
                    MessageBox.Show("商品不是搞促销的，不能移除");
                    break;
                default:
                    MessageBox.Show("移除促销商品失败");
                    break;
            }
        }
        /// <summary>
        /// GridView选中指定行
        /// </summary>
        private void GridViewSelectedSpecifiedRow(int rowIndex)
        {
            this.commDgv.Rows[rowIndex].Selected = true;
            this.commDgv.FirstDisplayedScrollingRowIndex = rowIndex;
        }
        #endregion
    }
}
