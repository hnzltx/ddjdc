using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.good
{
    public partial class ExamineGoodtForm : Form
    {
        //1. 审核中 2. 审核失败 3 审核成功
        private int examineGoodsFlag = 1;
        public ExamineGoodtForm()
        {
            InitializeComponent();
        }

        private void AudiGoodtForm_Load(object sender, EventArgs e)
        {
            ///默认选择第一个
            this.tabControl1.SelectedTab = this.tabItem1;
            LoadForm();
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
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("examineGoodsFlag", examineGoodsFlag);
            dic.Add("pageNumber", this.ct_pageNumber);
            dic.Add("pageSize", this.ct_pageSize);

            ResponseResultDelegate action = RequestGoodListCallback;
            service.good.goodService.QueryExamineGoodsByStoreId(action, dic);

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
            vo.pageInfo<model.good.goodEntity> pg = result.ToEntity<vo.pageInfo<model.good.goodEntity>>();
            //分页配置
            pageInfoConfig(pg);
            //赋值给BindingList
            BList = new BindingList<model.good.goodEntity>(pg.List);
            //显示数据
            commDgv.DataSource = BList;
        }

        /// <summary>
        /// tab切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            this.examineGoodsFlag = this.tabControl1.SelectedTabIndex + 1;
            if (this.examineGoodsFlag == 2)//如果是审核失败中显示失败原因
            {
                this.dataGridViewX1.Columns[6].Visible = true;
            }
            else //其他隐藏
            {
                this.dataGridViewX1.Columns[6].Visible = false;
            }
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


        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                if (e.Value == null)
                {
                    return;
                }
                if (e.Value.Equals(1))
                {
                    e.Value = "审核中";
                }
                else if (e.Value.Equals(2))
                {
                    e.Value = "审核失败";
                }
                else
                {
                    e.Value = "审核成功";
                }
            }
            
        }

        /// <summary>
        /// row双击时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            model.good.goodEntity good = BList[e.RowIndex];
            UpdateExamineGoodInfoForm frm = new UpdateExamineGoodInfoForm(good,e.RowIndex);
            frm.action = UpdateExamineGoodInfoCallback;
            frm.ShowDialog();
        }
        /// <summary>
        /// 修改审核失败商品提交成功结果回调
        /// </summary>
        /// <param name="rowIndex"></param>
        private void UpdateExamineGoodInfoCallback(int rowIndex)
        {
            //删除修改成功的行
            if (this.dataGridViewX1.Rows.Count > 0)
            {
                BList.RemoveAt(rowIndex);
                this.dataGridViewX1.Rows.RemoveAt(rowIndex);
            }
            
        }
    }
}
