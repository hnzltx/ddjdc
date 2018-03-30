using Newtonsoft.Json.Linq;
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

namespace ddjd_c.ct.store
{
    public partial class frmStoreInfo : Form
    {
        public frmStoreInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载后显示店铺信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStoreInfo_Load(object sender, EventArgs e)
        {
            model.store.storeInfo store = new model.store.storeInfo();
            store = service.store_service.storeInfoService.queryStoreInfo();
            if (null != store)
            {
                this.storeName.Text = store.StoreName;
                this.storeType.Text = store.StoreType == 1 ? "直营" : "加盟";
                this.address.Text = store.Address;
                this.storeQRcode.Image = Image.FromStream(WebRequest.Create(http.baseHttp.getDdjdcUrl() + store.StoreQRcode).GetResponse().GetResponseStream());

                this.tel.Text = store.Tel;
                this.memberDiscount.Text = store.MemberDiscount.ToString();
                this.distributionScope.Text = store.DistributionScope.ToString();
                this.lowestMoney.Text = store.LowestMoney.ToString();
            }
            else {
                MessageBox.Show("没有查询到店铺信息!");
            }
        }
    }
}
