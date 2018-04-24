using ddjd_c.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.common.extension;

namespace ddjd_c.ct.good
{
    public partial class UpLoadGoodCodeVerifyForm : Form
    {
        //定义键盘钩子 ； 用来无焦点状态下获取扫描枪扫描的条码
        private KeyboardHookLib listener = new KeyboardHookLib();

        public UpLoadGoodCodeVerifyForm()
        {
            InitializeComponent();
            listener.ScanerEvent += Listener_ScanerEvent;
        }

        private void Listener_ScanerEvent(KeyboardHookLib.ScanerCodes codes)
        {
            //键盘钩子获取的条码，赋值到文本框中
            txtCode.Text = codes.Result;

        }

       

        private void UpLoadGoodForm_Load(object sender, EventArgs e)
        {
            this.txtCode.Focus(); ;
            //加载键盘钩子
            listener.Start();
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
                case Keys.Enter:
                    QueryGoodsCodeIsExist();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        /// <summary>
        /// 扫码验证或查询商品
        /// </summary>
        private void QueryGoodsCodeIsExist()
        {
            var code=this.txtCode.Text;
            if (code.StrIsNull())
            {
                MessageBox.Show("请输入或扫描条码!");
                return;
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("goodsCode",code);
            dic.Add("storeId",GlobalsInfo.storeId);
            var obj = service.good.goodService.QueryGoodsCodeIsExist(dic);
            string success = obj["success"]?.ToString();
            bool exist;
            bool.TryParse(obj["exist"]?.ToString(),out exist);
            if(success != null)
            {
                switch (success)
                {
                    case "notExist":
                        PushUpLoadGood();
                        return;
                    case "examineExist":
                        MessageBox.Show("此商品正在审核中");
                        return;

                }
            }
            //关闭键盘钩子
            listener.Stop();
            SetTextCode();
            ResponseResult result = new ResponseResult();
            if (exist)//店铺已拥有
            {
                result.JsonStr=obj["querySag"].ToString();
                var goodEntity = result.ToEntity<model.good.goodEntity>();
                if(MessageBox.Show("该商品已经在您的商品库了","提示:点击确定可以直接查看商品",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    goodDetail detail = new goodDetail(goodEntity.StoreAndGoodsId,0);
                    detail.Name = "修改商品信息";
                    detail.ShowDialog();
                }
            }
            else //未拥有
            {
                result.JsonStr = obj["queryGoodsInfo"].ToString();
                var goodEntity = result.ToEntity<model.good.goodEntity>();
                PublicGoodLibraryDetailForm frm = new PublicGoodLibraryDetailForm();
                frm.Tag = goodEntity.GoodsId;
                frm.ShowDialog();
            }
            
        }
        /// <summary>
        /// 跳转到商品上传页面
        /// </summary>
        private void PushUpLoadGood()
        {
            
            UpdateExamineGoodInfoForm frm = new UpdateExamineGoodInfoForm();
            frm.Tag = this.txtCode.Text;
            frm.ShowDialog();
            SetTextCode();
        }
        private void SetTextCode()
        {
            this.txtCode.Text = "";
        }
        /// <summary>
        /// 页面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLoadGoodForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭键盘钩子
            listener.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            QueryGoodsCodeIsExist();
        }
    }
}
