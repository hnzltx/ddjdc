using ddjd_c.vo.addShopCar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.ScanCode
{
    public partial class frmGuadan : Form
    {
        public frmGuadan()
        {
            InitializeComponent();
        }


        //接收上个窗体对象
        frmScanCode frm = null;
        public frmGuadan( frmScanCode frmScanCode)
        {
            InitializeComponent();
            frm = frmScanCode;
        }

        BindingList<vo.scanCode.queryGuadanNumber> BList;
        private void frmGuadan_Load(object sender, EventArgs e)
        {
            ///隐藏数据源自动绑定列
            this.dgvAllGuadan.AutoGenerateColumns = false;

            List<vo.scanCode.queryGuadanNumber> listNumber = service.scanCode_service.scanCodeService.queryGuadanNumber();
            BList = new BindingList<vo.scanCode.queryGuadanNumber>(listNumber);
            this.dgvAllGuadan.DataSource = BList;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //用来记录是否重复点击同一个挂单号
        string commGuadanNumber = "";

        //单击挂单号
        private void dgvAllGuadan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAllGuadan.SelectedRows.Count > 0)
            {
                string thisGuadanNumber = this.dgvAllGuadan.SelectedRows[0].Cells["guadanNumber"].Value.ToString();

                //如果挂单号没有改变，不执行查询
                if (thisGuadanNumber.Equals(commGuadanNumber))
                {
                    return;
                }
                else {
                    //如果改变，清空当前的商品
                    dgvGuadanDetail.Rows.Clear();
                }

                commGuadanNumber = thisGuadanNumber;


                List<addShopCarGoods> goodsInfo = service.scanCode_service.scanCodeService.queryGoodsInfoByGuddanNumber(thisGuadanNumber);
                if (goodsInfo != null && goodsInfo.Count > 0)
                {
                    foreach (addShopCarGoods goods in goodsInfo)
                    {
                        //新增购物车数据
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvGuadanDetail);

                        row.Cells[0].Value = goods.GoodsName;
                        //散货使用Weight ，非散户使用GoodsCount
                        if (goods.IsBulkCargo == 1)
                        {
                            row.Cells[1].Value = goods.GoodsCount;
                        }
                        else
                        {
                            row.Cells[1].Value = goods.Weight;
                        }

                        dgvGuadanDetail.Rows.Add(row);
                    }
                 }
                else {
                    MessageBox.Show("没有查询到详情商品!");
                }
            }
            else {
                MessageBox.Show("没有选中行!");
            }
            
        }


        /// <summary>
        /// 
        /// </summary>
        private void emptyThisGuadan() {
            //清空商品详情
            this.dgvGuadanDetail.Rows.Clear();

            //清除选中挂单号
            this.BList.RemoveAt(dgvAllGuadan.CurrentRow.Index);
        }


        /// <summary>
        /// 删除某挂单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteGuadanNumber_Click(object sender, EventArgs e)
        {
            if (this.dgvAllGuadan.SelectedRows.Count > 0)
            {
                string thisGuadanNumber = this.dgvAllGuadan.SelectedRows[0].Cells["guadanNumber"].Value.ToString();

                if (service.scanCode_service.scanCodeService.deleteGuadanNumbe(thisGuadanNumber))
                {

                    emptyThisGuadan();
                    MessageBox.Show("删除成功!");
                }
                else {
                    MessageBox.Show("删除失败!");
                }
            }
            else {
                MessageBox.Show("没有选中行!");
            }

        }

        /// <summary>
        /// 取出某挂单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.dgvAllGuadan.SelectedRows.Count > 0)
            {
                string thisGuadanNumber = this.dgvAllGuadan.SelectedRows[0].Cells["guadanNumber"].Value.ToString();

                if (service.scanCode_service.scanCodeService.getGuadan(thisGuadanNumber))
                {
                    //emptyThisGuadan();
                    //执行主窗体的待结算商品刷新
                    frm.queryStoreshoppingcar_zi();

                    this.Close();
                }
                else {
                    MessageBox.Show("取出失败!(此挂单号没有商品，或者收银界面存在待结算的商品)");
                }
            }
            else
            {
                MessageBox.Show("没有选中行!");
            }
        }
    }
}
