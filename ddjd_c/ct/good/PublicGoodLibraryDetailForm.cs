using ddjd_c.common.extension;
using ddjd_c.service.good;
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
    public partial class PublicGoodLibraryDetailForm : Form
    {
        /// <summary>
        /// 加入门店成功回调
        /// </summary>
        public Action action;
        public PublicGoodLibraryDetailForm()
        {
            InitializeComponent();
        }

        private void PublicGoodLibraryDetailForm_Load(object sender, EventArgs e)
        {
            RequestGoodDetail();
        }
        /// <summary>
        /// 请求商品详情
        /// </summary>
        private void RequestGoodDetail()
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("goodsId",this.Tag);
            ResponseResultDelegate action = Callback;
            goodService.QueryGoodsInfoByGoodsId_store(action, dic);
        }
        /// <summary>
        /// 网络请求回调
        /// </summary>
        /// <param name="result"></param>
        public void Callback(ResponseResult result, System.Threading.SynchronizationContext context)
        {
            if (result.Error != null)
            {
                MessageBox.Show(result.Error);
                return;
            }
            context.Post(ShowState, result);

        }
        private void ShowState(object result)
        {
            ddjd_c.model.good.goodEntity entity = ((ResponseResult)result).ToEntity<model.good.goodEntity>();
            if (entity != null)
            {
                this.txtPurchasePrice.Text = entity.PurchasePrice.ToString();
                this.txtOfflineStock.Text = entity.OfflineStock.ToString();
                this.txtStock.Text = entity.Stock.ToString();
                this.txtStoreGoodsPrice.Text = entity.StoreGoodsPrice.ToString();
                this.lblBrand.Text = entity.Brand;
                this.lblGoodName.Text = entity.GoodsName;
                this.lblGoodsCategoryName.Text = entity.GoodsCategoryName;
                this.lblGoodsCode.Text = entity.GoodsCode;
                this.lblGoodsLift.Text = entity.GoodsLift.ToString() + "天";
                this.lblGoodsMixed.Text = entity.GoodsMixed;
                this.lblGoodUcode.Text = entity.GoodUcode;
                this.lblGoodUnit.Text = entity.GoodsUnit;
                this.cbxGoodFlag.SelectedIndex = entity.GoodsFlag == 1 ? this.cbxGoodFlag.SelectedIndex = 0 : this.cbxGoodFlag.SelectedIndex = 1;
                this.pbGoodPic.Image = ddjd_c.common.extension.ExtensionImage.HttpGetImage(ddjd_c.http.baseHttp.getDdjdcUrl() + entity.GoodsPic, common.extension.DefaultImgType.Good);
            }

        }
        /// <summary>
        /// 加入门店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            var goodsFlag = this.cbxGoodFlag.SelectedIndex == 0 ? 1 : 2;
            var storeGoodsPrice = this.txtStoreGoodsPrice.Text;
            var stock = this.txtStock.Text;
            var offlineStock = this.txtOfflineStock.Text;
            var purchasePrice = this.txtPurchasePrice.Text;
            if (storeGoodsPrice.StrIsNull())
            {
                MessageBox.Show("商品零售价不能为空");
                return;
            }
            if (purchasePrice.StrIsNull())
            {
                MessageBox.Show("商品进货价不能为空");
                return;
            }
            if (stock.StrIsNull())
            {
                MessageBox.Show("库存不能为空");
                return;
            }
            if (offlineStock.StrIsNull())
            {
                MessageBox.Show("库存下限不能为空");
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeId",GlobalsInfo.storeId);
            dic.Add("goodsId",this.Tag);
            dic.Add("goodsFlag", goodsFlag);
            dic.Add("storeGoodsPrice", storeGoodsPrice);
            dic.Add("stock", stock);
            dic.Add("offlineStock", offlineStock);
            dic.Add("purchasePrice", purchasePrice);

            HttpUpdateGoodDetail(dic);
        }

        private void HttpUpdateGoodDetail(Dictionary<string, object> dic)
        {
            var obj = goodService.AddGoodsInfoGoToStoreAndGoods_detail(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    if (MessageBox.Show("加入门店成功", "确定", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        action();
                        this.Close();
                    }
                    break;
                case "storeGoodsPrice_error ":
                    MessageBox.Show("价格错误；（零售价或进价）");
                    break;
                case "offlineStockMaxError":
                    MessageBox.Show("库存下限填写的数量不能等于或超过库存");
                    break;
                case "exist":
                    MessageBox.Show("已经分配过了");
                    break;
                default:
                    MessageBox.Show("加入门店失败");
                    break;
            }
        }
        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void TxtDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 0x08) && (e.KeyChar != 46) && (e.KeyChar < 0x30 || e.KeyChar > 0x39))
            {
                e.KeyChar = (char)0;
            }
            try
            {
                string content = ((TextBox)sender).Text;
                if (content != "")
                {
                    if ((e.KeyChar.ToString() == "."))
                    {
                        string num = content + ".";
                        Convert.ToDouble(num);
                    }
                }
            }
            catch
            {
                e.KeyChar = (char)0;
            }

        }
    }
}
