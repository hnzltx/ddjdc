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
using System.Diagnostics;

namespace ddjd_c
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            //baseHttp.ScanerDelegate s = new baseHttp.ScanerDelegate(Listener_ScanerEvent);
            baseHttp.ScanerEvent += Listener_ScanerEvent;
        }


        private void Listener_ScanerEvent(baseHttp.exInfo ex)
        {
            if (ex != null) {

                if (MessageBox.Show(ex.ExMsg + "【"+ex.HttpName+"】" + ",是否退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        //记住密码的文件
        string accInfo = "accInfo.json";

        private void login_Load(object sender, EventArgs e)
        {
            //验证记住密码文件是否存在。如果存在就将账号密码拿出来
            if (utils.FileExists(accInfo)) {
                JObject json =  utils.getFile(accInfo);
                this.userAccount.Text = json["userAccount"].ToString();
                this.userPossword.Text = json["userPossword"].ToString();
                this.cbPs.Checked = true;
            }
        }

        /// <summary>
        /// 页面键盘捕捉
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出登录界面?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    return true;
                case Keys.Enter:
                    _Login();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }




        private void _Login() {
            

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

            if (null != loginInfo)
            {
                string success = loginInfo.Success;
                if (success.Equals("success"))
                {
                    //将登录后的信息放到全局信息中
                    GlobalsInfo.storeId = loginInfo.StoreId;
                    GlobalsInfo.storeName = loginInfo.StoreName;
                    GlobalsInfo.storeType = loginInfo.StoreType;

                    //是否记住密码操作
                    cbPassword(userAccount, userPossword);


                    baseHttp.ScanerEvent -= Listener_ScanerEvent;

                    //跳转首页
                    indexName index = new indexName();
                    index.Show();
                    this.Visible = false;


                }
                else if (success.Equals("valueNull"))
                {
                    MessageBox.Show("登录失败!");
                }
                else if (success.Equals("error"))
                {
                    MessageBox.Show("账号密码错误!");
                }
                else if (success.Equals("haveNoRight"))
                {
                    MessageBox.Show("当前登录不是店铺!");
                }
                else if (success.Equals("flagError"))
                {
                    MessageBox.Show("您暂时无法登录!");
                }
            }
            else
            {
                MessageBox.Show("登录失败!");
            }



        }



        /// <summary>
        /// 收银登录； 只能店铺账号登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginClick_Click(object sender, EventArgs e)
        {
            _Login();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出登录界面?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        /// <summary>
        /// 勾选/不勾选记住密码按钮的操作
        /// </summary>
        /// <param name="userAccount"></param>
        /// <param name="userPossword"></param>
        private void cbPassword(string userAccount, string userPossword) {
            //如果选中记住密码
            if (cbPs.Checked)
            {
                //记录下登录信息
                JObject json = new JObject();
                json.Add("userAccount", userAccount);
                json.Add("userPossword", userPossword);

                utils.writeFile(accInfo, json.ToString());
                
            }

            //如果没选中记住密码
            if (!cbPs.Checked)
            {
                //验证文件是否存在，如果存在就删除
                if (utils.FileExists(accInfo))
                {
                    utils.reomveFile(accInfo);
                }
            }
        }


        /// <summary>
        /// 弹出软键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbAccount_Click(object sender, EventArgs e)
        {
            Process kbpr = System.Diagnostics.Process.Start("osk.exe");
        }


    }
}
