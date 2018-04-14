using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.service.good;
using ddjd_c.common.extension;

namespace ddjd_c.ct.good
{
    /// <summary>
    /// 更新商品list
    /// </summary>
    /// <param name="goodFlag"></param>
    public delegate void UpdateGoodListDelegate(int goodFlag,int rowIndex);
    public partial class goodDetail : Form
    {
        public event UpdateGoodListDelegate UpdateGoodList;
        private int? storeAndGoodsId;
        private int rowIndex;
        public goodDetail(int? id,int rowIndex)
        {
            this.storeAndGoodsId = id;
            this.rowIndex = rowIndex;
            InitializeComponent();
        }

        private void goodDetail_Load(object sender, EventArgs e)
        {
            RequestGoodDetail();
        }

        /// <summary>
        /// 请求商品详情
        /// </summary>
        private void RequestGoodDetail()
        {
            
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("storeAndGoodsId",this.storeAndGoodsId);
            dic.Add("storeId", ddjd_c.GlobalsInfo.storeId);
            
            Action<ResponseResult, System.Threading.SynchronizationContext> action = Callback;
            goodService.QueryStoreAndGoodsDetail(action,dic);
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
            dic.Add("storeAndGoodsId", this.storeAndGoodsId);
            dic.Add("goodsFlag", goodsFlag);
            dic.Add("storeGoodsPrice", storeGoodsPrice);
            dic.Add("stock", stock);
            dic.Add("offlineStock", offlineStock);
            dic.Add("purchasePrice", purchasePrice);
            
            HttpUpdateGoodDetail(dic);
        }

        private void HttpUpdateGoodDetail(Dictionary<string, object> dic)
        {
            JObject obj = goodService.UpdateGoodsByStoreAndGoodsId(dic);
            string success = obj["success"].ToString();
            switch (success)
            {
                case "success":
                    if (MessageBox.Show("修改成功", "确定", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        UpdateGoodList(dic["goodsFlag"].ToString().ToInt(),rowIndex);
                        this.Close();
                    }
                    break;
                case "error":
                    MessageBox.Show("进货价,零售价,库存,库存下限小于或等于0");
                    break;
                case "offlineStockMaxError":
                    MessageBox.Show("库存下限填写的数量不能等于或超过库存");
                    break;

                default:
                    MessageBox.Show("修改失败");
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
