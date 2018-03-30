using ddjd_c.vo.login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.common;
using ddjd_c.http;
using Newtonsoft.Json.Linq;

namespace ddjd_c
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// 收银登录； 只能店铺账号登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginClick_Click(object sender, EventArgs e)
        {
            string userAccount = this.userAccount.Text;
            string userPossword = this.userPossword.Text;
            //登录
            if (userAccount == "" || userPossword == "")
            {
                MessageBox.Show("请输入账号或密码!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("userAccount", userAccount);
            d.Add("userPossword", userPossword);
            loginReturnInfo loginInfo = new loginReturnInfo();
            loginInfo = service.login_service.loginService.loginValidate(d);

            //JObject j = service.login_service.loginService.loginValidate2(d);
           
            if (null != loginInfo) {
                string success = loginInfo.Success;
                if (success.Equals("success")) {
                    //将登录后的信息放到全局信息中
                    GlobalsInfo.storeId = loginInfo.StoreId;
                    GlobalsInfo.storeName = loginInfo.StoreName;
                    GlobalsInfo.storeType = loginInfo.StoreType;

                    //跳转首页
                    indexName index = new indexName();
                    index.Show();
                    this.Visible = false;

                    
                }
                else if (success.Equals("valueNull"))
                {
                    MessageBox.Show("登录失败!");
                }
                else if (success.Equals("error")) {
                    MessageBox.Show("账号密码错误!");
                }
                else if (success.Equals("haveNoRight")) {
                    MessageBox.Show("当前登录不是店铺!");
                }
                else if (success.Equals("flagError")) {
                    MessageBox.Show("您暂时无法登录!");
                }
            }
            else {
                MessageBox.Show("登录失败!");
            }


            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
