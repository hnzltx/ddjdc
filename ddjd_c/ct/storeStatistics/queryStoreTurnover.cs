using ddjd_c.service.storeStatistics_service;
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

namespace ddjd_c.ct.storeStatistics
{
    public partial class frmQueryStoreTurnover : Form
    {
        public frmQueryStoreTurnover()
        {
            InitializeComponent();
        }


        private void frmQueryStoreTurnover_Load(object sender, EventArgs e)
        {

            //将本窗体的DataGridView传递给公共的dgv
            commDgv = this.dgvStoreStatistics;

            loagPageConfig();

            //查询年月日金额
            vo.storeStatistics.queryStoreTurnover turnover = new storeStatisticsService().queryStoreTurnover();
            if (turnover != null) {
                this.today.Text = turnover.Today;
                this.month.Text = turnover.Month;
                this.year.Text = turnover.Year;
                this.sumPrice.Text = turnover.SumPrice;
            }

            //禁用自动拼装所有实体对象
            commDgv.AutoGenerateColumns = false;


            //默认查询全部的收入明细
            selectQuery(0);
        }



        #region 分页代码
        /** 目前分页需要改动的只有泛型对象， 
         * 按道理将所有model都继承一个baseModel，稍作改动即可使分页更加通用，暂时记着，以后看改不改 —_—*/

        /// <summary>
        /// searchDic
        /// 公共的搜索参数； 如果分页需要加入搜索条件，就增加此项的参数；
        /// 如:  searchDic = new Dictionary<string, object>();
        ///      searchDic.Add("startTime",dtStartTime.Text);
        ///      searchDic.Add("endTime",dtEndTime.Text);
        ///      commQueryPageInfo();
        /// </summary>
        Dictionary<string, object> searchDic = null;

        //公共的DataGridView；为了分页通用，在窗体加载时，将需要分页的DataGridView传递给此对象；
        DataGridView commDgv;
        //数据绑定到dataGridView的泛型集合，方便后期操作；   -- 此处的 T 需要改成你需要的对象
        BindingList<vo.storeStatistics.queryStoreTransferaccountsrecord> BList;
        //当前窗体的每页查询条数
        int ct_pageSize = GlobalsInfo.pageSize;
        //当前窗体已经查询到第几页
        int ct_pageNumber = GlobalsInfo.pageNumber;
        //数据总页数
        int ct_totalPage = 1;


        /// <summary>
        /// 查询数据并配置分页 --   此方法一般在窗体加载时和搜索后调用
        /// </summary>
        /// <param name="searchDic">传了search的情况下，可以根据条件搜索。</param>
        private void commQueryPageInfo()
        {
            vo.pageInfo<vo.storeStatistics.queryStoreTransferaccountsrecord> pg = new vo.pageInfo<vo.storeStatistics.queryStoreTransferaccountsrecord>();

            //本次查询数据需要的参数
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pageSize", ct_pageSize);
            dic.Add("pageNumber", ct_pageNumber);

            if (searchDic != null)
            {
                //将搜索参数添加到查询参数中
                foreach (var item in searchDic)
                {
                    dic.Add(item.Key, item.Value);
                }
            }

            //查询分页数据
            pg = new storeStatisticsService().queryStoreTransferaccountsrecord(dic);

            //分页配置
            pageInfoConfig(pg);
            //赋值给BindingList
            BList = new BindingList<vo.storeStatistics.queryStoreTransferaccountsrecord>(pg.List);
            //显示数据
            commDgv.DataSource = BList;
        }




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
        private void pageInfoConfig(vo.pageInfo<vo.storeStatistics.queryStoreTransferaccountsrecord> pg)
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
            commQueryPageInfo();
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
            commQueryPageInfo();

        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber - 1;
            commQueryPageInfo();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber + 1;
            commQueryPageInfo();
        }


        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_totalPage;
            commQueryPageInfo();
        }




        #endregion



        private void rbWeixin_CheckedChanged(object sender, EventArgs e)
        {
            //查询微信收入明细
            selectQuery(1);
        }

        private void rbAli_CheckedChanged(object sender, EventArgs e)
        {
            //查询支付宝收入明细
            selectQuery(2);
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            //查询全部的收入明细
            selectQuery(0);
        }



        /// <summary>
        /// 根据选择的状态查询收入明细；  0 查询全部； 1 查询微信； 2 查询支付宝
        /// </summary>
        /// <param name="selectType"></param>
        private void selectQuery(int selectType) {

            //每次切换回到第一页
            ct_pageNumber = 1;

            //执行查询
            searchDic = new Dictionary<string, object>();
            searchDic.Add("queryStatu", selectType);
            commQueryPageInfo();
        }


    }
}
