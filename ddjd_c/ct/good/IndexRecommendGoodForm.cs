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
using ddjd_c.common.extension;

namespace ddjd_c.ct.good
{
    public partial class IndexRecommendGoodForm : Form
    {
      
        public IndexRecommendGoodForm()
        {
            InitializeComponent();
        }
        private void LoadForm()
        {
            //将本窗体的DataGridView传递给公共的dgv
            commDgv = this.dataGridViewX1;
            //禁用自动拼装所有实体对象
            commDgv.AutoGenerateColumns = false;
            loagPageConfig();
            LoadData();
        }
        /// <summary>
        /// 数据加载
        /// </summary>
        private void LoadData()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("bindstoreId", GlobalsInfo.storeId);
            dic.Add("pageNumber", this.ct_pageNumber);
            dic.Add("pageSize", this.ct_pageSize);
            
            ResponseResultDelegate action = RequestGoodListCallback;
            service.good.goodService.IndexGoodsList(action, dic);

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

        private void IndexRecommendGoodForm_Load(object sender, EventArgs e)
        {
            LoadForm();
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
        //移除推荐商品
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var rowIndex = this.dataGridViewX1.CurrentCell.RowIndex;
            var storeAndGoodsId = this.dataGridViewX1.Rows[rowIndex].Cells[0].Value.ToString().ToInt();
            DeleteIndexGood(storeAndGoodsId);
        }
        /// <summary>
        /// 店铺移除首页推荐商品
        /// </summary>
        /// <param name="storeAndGoodsId"></param>
        private void DeleteIndexGood(int storeAndGoodsId)
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
                    break;
                default:
                    MessageBox.Show("操作失败");
                    break;
            }
        }
    }
}
