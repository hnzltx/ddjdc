using ddjd_c.service.scanCode_service;
using Newtonsoft.Json.Linq;
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
    public partial class frmSubmitOrder : Form
    {
        public frmSubmitOrder()
        {
            InitializeComponent();
        }

        //接收上个窗体对象
        frmScanCode frm = null;
        public frmSubmitOrder(string str, frmScanCode frmScanCode)
        {
            InitializeComponent();
            //应收金额
            this.yingshou.Text = str;
            frm = frmScanCode;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn8.Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn9.Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn0.Text);
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            shishouFun(this.btn00.Text);
        }

        private void btnDian_Click(object sender, EventArgs e)
        {
            shishouFun(this.btnDian.Text);
        }




        //是否点击的小数点
        bool isDian = false;
        //是否禁用小键盘
        bool isDisable = false;
        /// <summary>
        /// 增加实收金额
        /// </summary>
        /// <param name="number">点击的小键盘金额</param>
        /// <param name="isFixed">是否为点击的固定金额；带￥的金额；  是的传true，默认可以不传</param>
        public void shishouFun(string number,bool isFixed = false)
        {
            //如果是点击的固定金额，直接将实收金额修改为此金额；
            if (isFixed) {
                this.shishou.Text = number;
                zhaolingFun();
                return;
            }
            
            //如果按钮已经被禁用，直接返回
            if (isDisable) { return; }

            if (isDian)
            {
                //如果上步是点击的小数点
                this.shishou.Text = this.shishou.Text.Split('.')[0] + "." + number + "0";

                //将小键盘禁用
                isDisable = true;

                zhaolingFun();
                return;
            }

            if (number.Equals("."))
            {
                //如果点击的小数点，将状态设为true；
                isDian = true;
                return;
            }

            if (double.Parse(this.shishou.Text) <= 0)
            {
                this.shishou.Text = number + ".00";
            }
            else {
                this.shishou.Text =  this.shishou.Text.Split('.')[0] + number +  ".00";
            }
            
            zhaolingFun();
        }


        /// <summary>
        /// 找零
        /// </summary>
        public void zhaolingFun()
        {

            decimal zhaolingMoney = new decimal(double.Parse(this.shishou.Text)) - new decimal(double.Parse(this.yingshou.Text));
            if (zhaolingMoney <= 0)
            {
                this.zhaoling.Text = "0.00";
            }
            else
            {
                this.zhaoling.Text = zhaolingMoney.ToString();
            }

        }


        /// <summary>
        /// 清空实收和找零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            isDian = false;
            isDisable = false;

            this.shishou.Text = "0.00";
            this.zhaoling.Text = "0.00";
        }

        /// <summary>
        /// 一位位减少实收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            isDian = false;
            isDisable = false;
            string shishouStr = this.shishou.Text;
            if (shishouStr != "") {
                
                var dianFrontLength = shishouStr.Split('.')[0].Length;
                //如果实收后面有小数点，并大于0 ，将小数点金额修改为00
                if (double.Parse(shishouStr.Split('.')[1]) > 0) {
                    this.shishou.Text = shishouStr.Split('.')[0] + ".00";
                }

                if (double.Parse(shishouStr.Split('.')[1]) == 0)
                {
                    if (dianFrontLength == 1)
                    {
                        this.shishou.Text = "0.00";
                    }
                    else {
                        this.shishou.Text = shishouStr.Substring(0, dianFrontLength - 1) + ".00";
                    }
                }

            }

            decimal zhaolingMoney = new decimal(double.Parse(this.shishou.Text)) - new decimal(double.Parse(this.yingshou.Text));

            zhaolingFun();
        }


        private void btn100_Click(object sender, EventArgs e)
        {
            shishouFun("100",true);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            shishouFun("50", true);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            shishouFun("20", true);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            shishouFun("10", true);
        }


        /// <summary>
        /// 确认提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //找零金额
            double zhaolingMoney = double.Parse(this.zhaoling.Text);
            if (zhaolingMoney < 0) {
                showMessage("少收钱了吧？");
                return;
            }

            //应收金额
            decimal yinshouMoney = new decimal(double.Parse(this.yingshou.Text));
            if (yinshouMoney <= 0) {
                showMessage("购物车中没商品，不能下单哦!");
                return;
            }

            //实收金额
            decimal shishouMoney = new decimal(double.Parse(this.shishou.Text));
            if (shishouMoney <= 0) {
                showMessage("还没收钱吧？");
                return;
            }
            
            //开始提交订单
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("payType", 3);
            dic.Add("moblieSumPrice", yinshouMoney);
            JObject json = scanCodeService.saveOrder(dic);
            if (null != json)
            {
                if (json["success"].ToString().Equals(GlobalsInfo.success))
                {
                    frm.emptyOther();
                    
                    if (MessageBox.Show("下单成功，是否打印小票？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else {
                        this.Close();
                    }
                }
                else if (json["success"].ToString().Equals("valueNull"))
                {
                    showMessage("订单信息错误!");
                }
                else if (json["success"].ToString().Equals("sumPriceDifferent"))
                {
                    showMessage("金额有误!");
                }
                else if (json["success"].ToString().Equals("underStock"))
                {
                    showMessage("有商品库存不足! 商品为：" + json["underStockGoodsInfo"]["goodsName"].ToString());
                }
                else if (json["success"].ToString().Equals("notZhiying"))
                {
                    showMessage("您不是自营店，不能使用此方式下订单!");
                }

                else
                {
                    showMessage("提交订单失败!");
                }
            }
            else
            {
                showMessage("提交订单失败!");
            }
        }


        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        public void showMessage(string msg)
        {
            MessageBox.Show(msg);
        }

    }
}
