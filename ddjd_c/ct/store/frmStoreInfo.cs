using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
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
            ///查询店铺信息
            HttpQeryStoreInfo();
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
            string startTime = this.dtStart.Text;
            string endTime = this.dtEnd.Text;
            Console.Write(this.dtStart.Text);
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
            if (memberDiscount.StrIsNull() == true)
            {
                MessageBox.Show("会员折扣不能为空");
                return;
            } 
            if (memberDiscount.ToInt() < 10 || memberDiscount.ToInt() > 100)
            {
                MessageBox.Show("会员折扣不能小于10大于100");
                return;
            }
            if(lowestMoney.StrIsNull() == true)
            {
                MessageBox.Show("最低起送额不能为空");
                return;
            }
            if (lowestMoney.ToInt() < 1)
            {
                MessageBox.Show("最低起送额必须大于1元");
                return;
            }
            if (startTime.StrIsNull())
            {
                MessageBox.Show("配送开始不能为空");
                return;
            }
            if (endTime.StrIsNull())
            {
                MessageBox.Show("配送结束时间不能为空");
                return;
            }
            Dictionary<string,object> d = new Dictionary<string,object>();
            d.Add("storeId", GlobalsInfo.storeId);
            d.Add("distributionScope", distributionScope.ToInt());
            d.Add("tel", tel);
            d.Add("lowestMoney", lowestMoney.ToInt());
            d.Add("distributionStartTime", startTime);
            d.Add("distributionEndTime", endTime);
            HttpUpdateStoreInfo(d);

        }

        /**********************网络请求************************/

        /// <summary>
        /// 查询店铺信息
        /// </summary>
        private void HttpQeryStoreInfo()
        {
            model.store.storeInfo store = new model.store.storeInfo();
            store = service.store_service.storeInfoService.queryStoreInfo();
      
            if (null != store)
            {
                this.storeName.Text = store.StoreName;
                this.storeType.Text = store.StoreType == 1 ? "直营" : "加盟";
                this.address.Text = store.Address;
                this.storeQRcode.Image = ExtensionImage.HttpGetImage(baseHttp.getDdjdcUrl() + store.StoreQRcode, DefaultImgType.Logo);
                this.txtTel.Text = store.Tel;
               
                this.txtMemberDiscount.Text = store.MemberDiscount.ToString();
                this.txtDistributionScope.Text = store.DistributionScope.ToString();
                this.txtLowestMoney.Text = store.LowestMoney.ToString();

                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyyMMdd HH:mm:ss";
                this.dtStart.Value = Convert.ToDateTime(store.DistributionStartTime, dtFormat);
                this.dtEnd.Value = Convert.ToDateTime(store.DistributionEndTime, dtFormat);

                this.cbxIsOrderReceivingState.SelectedIndex = store.State == 1 ?  0 : 1;
            }
            else
            {
                MessageBox.Show("没有查询到店铺信息!");
            }
        }
        private void HttpUpdateStoreInfo(Dictionary<string,object> dic)
        {

            JObject obj = service.store_service.storeInfoService.UpdateStoreInfoService(dic);
            Console.Write(obj);
            string success = obj["success"].ToString();
            switch (success){
                case "success":
                    ///重新加载店铺数据
                    HttpQeryStoreInfo();
                    MessageBox.Show("修改成功");
                    break;
                case "memberDiscountMaxOrMin":
                    MessageBox.Show("填写的折扣数不能大于100 或小于 10");
                    break;
                case "z_indexError":
                    MessageBox.Show("折扣不是正整数");
                    break;
                default:break;
            }
       
        }


        /******************end***************************/

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

    }
}
