using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.Order
{
    public partial class frmOrder : Form
    {

        //订单类型； 2 未发货； 3 已发货； 4 已完成
        int orderStatus = 0;

        public frmOrder()
        {
            InitializeComponent();
        }

        public frmOrder(int orderStatus_p) {
            InitializeComponent();
            orderStatus = orderStatus_p;
        }

        

        private void frmOrder_Load(object sender, EventArgs e)
        {
            //将本窗体的DataGridView传递给公共的dgv
            commDgv = this.dgvOrderInfo;

            //页面条数显示框默认显示条数
            this.cmbSelect.Text = ct_pageSize.ToString();    

            //绑定页面显示条数设置控件的TextChanged事件
            this.cmbSelect.SelectedIndexChanged += new EventHandler(cmbSelect_TextChanged);

            //禁用自动拼装所有实体对象
            commDgv.AutoGenerateColumns = false;

            if (orderStatus != 2)
            {
                //如果订单类型不是待发货，隐藏发货按钮
                this.btnDeliverGoods.Visible = false;
            }

            commQueryPageInfo();
            
        }



        /// <summary>
        /// 删除选中行
        /// </summary>
        private void deleteSelectedRow()
        {
            if (commDgv.SelectedRows.Count > 0)
            {
                this.BList.RemoveAt(commDgv.CurrentRow.Index);

                //如果当前显示的数据总数大于0，减去1
                int lblCount = int.Parse(this.lblCount.Text);
                if (lblCount > 0)
                {
                    this.lblCount.Text = (lblCount - 1) + "";
                }
            }
        }


        /// <summary>
        /// 查询数据并配置分页
        /// </summary>
        /// <param name="searchDic">传了search的情况下，可以根据条件搜索。</param>
        private void commQueryPageInfo(Dictionary<string, object> searchDic = null) {
            vo.pageInfo<vo.order.order> pg = new vo.pageInfo<vo.order.order>();

            //本次查询数据需要的参数
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("orderStatus", orderStatus);
            dic.Add("pageSize", ct_pageSize);
            dic.Add("pageNumber", ct_pageNumber);

            if (searchDic != null) {
                //将搜索参数添加到查询参数中
                foreach (var item in searchDic)
                {
                    dic.Add(item.Key, item.Value);
                }
            }

            //查询分页数据
            pg = service.order_service.orderService.QueryStoreSystem_orderInfo_winform(dic);

            //分页配置
            pageInfoConfig(pg);
            //赋值给BindingList
            BList = new BindingList<vo.order.order>(pg.List);
            //显示数据
            commDgv.DataSource = BList;
        }
        

        #region 分页代码
        /** 目前分页需要改动的只有泛型对象， 
         * 按道理将所有model都继承一个baseModel，稍作改动即可使分页更加通用，暂时记着，以后看改不改 —_—*/

        //公共的DataGridView；为了分页通用，在窗体加载时，将需要分页的DataGridView传递给此对象；
        DataGridView commDgv;
        //数据绑定到dataGridView的泛型集合，方便后期操作；   -- 此处的 T 需要改成你需要的对象
        BindingList<vo.order.order> BList;      
        //当前窗体的每页查询条数
        int ct_pageSize = GlobalsInfo.pageSize;
        //当前窗体已经查询到第几页
        int ct_pageNumber = GlobalsInfo.pageNumber;
        //数据总页数
        int ct_totalPage = 1;

        /// <summary>
        /// 分页控件配置
        /// </summary>
        /// <param name="pg"></param>
        private void pageInfoConfig(vo.pageInfo<vo.order.order> pg)
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
            else {
                btnNextPage.Enabled = true;
                btnEndPage.Enabled = true;
            }
            
            if (pg.FirstPage)
            {
                //如果是第一页，禁用首页和上一页
                btnHomePage.Enabled = false;
                btnPreviousPage.Enabled = false;
            }
            else {
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
            if (selectPageSize >= int.Parse(this.lblCount.Text)) {
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



        #region 发货功能
        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeliverGoods_Click(object sender, EventArgs e)
        {
            if (commDgv.SelectedRows.Count > 0)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("orderId", commDgv.SelectedRows[0].Cells[0].Value);
                JObject json = service.order_service.orderService.updateStoreOrderInfoTheOrderStatus(dic);
                if (null != json)
                {
                    if (json["success"].ToString().Equals(GlobalsInfo.success))
                    {
                        deleteSelectedRow();
                        if (MessageBox.Show("发货成功，是否打印小票？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            MessageBox.Show("打印成功!");
                        }
                    }
                    else if (json["success"].ToString().Equals("notExist"))
                    {
                        deleteSelectedRow();
                        MessageBox.Show("订单不存在了!");
                    }
                    else if (json["success"].ToString().Equals("orderStatusError"))
                    {
                        deleteSelectedRow();
                        MessageBox.Show("订单状态错误，不能发货!");
                    }
                    else
                    {
                        MessageBox.Show("发货失败，请稍后再试!");
                    }
                }
                else
                {
                    MessageBox.Show("发货失败，请稍后再试!");
                }
            }
            else
            {
                MessageBox.Show("没有选中订单!");
            }
        }



        #endregion



        #region 订单详情部分
        /// <summary>
        /// 双击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrderInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            openOrderDetail();
        }


        /// <summary>
        /// 详情按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            openOrderDetail();
        }



        /// <summary>
        /// 打开订单详情页面操作
        /// </summary>
        private void openOrderDetail()
        {
            if (commDgv.SelectedRows.Count > 0)
            {

                //打开详情窗口
                OrderDetail od = new OrderDetail();
                od.TopMost = true;
                od.Tag = commDgv.SelectedRows[0].Cells[0].Value.ToString();
                od.ShowDialog();

            }
            else
            {
                MessageBox.Show("没有选中订单!");
            }
        }


        #endregion



        #region 打印功能

        


        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (commDgv.SelectedRows.Count > 0)
            {

                common.LptControl lpt = new common.LptControl();
                string printStatu = lpt.printOrderInfo(commDgv.SelectedRows[0].Cells[0].Value.ToString());
                if (!printStatu.Equals("success")) {
                    MessageBox.Show(printStatu);
                }

            }
            else
            {
                MessageBox.Show("没有选中订单!");
            }
            
        }



        #endregion



        #region 订单搜索功能

        /// <summary>
        /// 点击搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeatchOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> search = new Dictionary<string, object>();
            search.Add("startTime",dtStartTime.Text);
            search.Add("endTime",dtEndTime.Text);
            commQueryPageInfo(search);
        }


        /// <summary>
        /// 显示全部按钮； 从第一页开始重新查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAllOrder_Click(object sender, EventArgs e)
        {
            ct_pageNumber = 1;
            commQueryPageInfo();
        }


        #endregion
        
    }
}
