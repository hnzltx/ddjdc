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
using ddjd_c.common;
using ddjd_c.http;
using ddjd_c.common.extension;
using ddjd_c.service.store_service;


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

                this.txtTel.Text = store.Tel;
                this.txtMemberDiscount.Text = store.MemberDiscount.ToString();
                this.txtDistributionScope.Text = store.DistributionScope.ToString();
                this.txtLowestMoney.Text = store.LowestMoney.ToString();
            }
            else {
                MessageBox.Show("没有查询到店铺信息!");
            }
        }
		/// <summary>
		/// 修改保存店铺信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveStoreInfo_Click(object sender, EventArgs e)
		{
			string tel = this.txtTel.Text;
			string distributionScope=this.txtDistributionScope.Text;
			string memberDiscount = this.txtMemberDiscount.Text;
			string lowestMoney = this.txtLowestMoney.Text;
			if (tel.StrIsNull() == true) 
			{
				MessageBox.Show("手机号码不能为空");
				return;
			}
			if (tel.Length != 11)
			{
				MessageBox.Show("请输入正确的手机号码");
				return;
			}
			if (distributionScope.StrIsNull() == true)
			{
				MessageBox.Show("配送范围不能为空");
				return;
			}
			if (distributionScope.ToInt() < 1)
			{
				MessageBox.Show("配送范围不能小于1公里");
				return;
			}
			//Dictionary<string,object> d = new Dictionary<string,object>();
			//JObject obj=service.store_service.storeInfoService.UpdateStoreInfoService()
		}

	}
}
