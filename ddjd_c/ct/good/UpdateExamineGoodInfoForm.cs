using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ddjd_c.model.good;
using ddjd_c.common;
using ddjd_c.common.extension;
using ddjd_c.service;
using Newtonsoft.Json.Linq;

namespace ddjd_c.ct.good
{
    public partial class UpdateExamineGoodInfoForm : Form
    {
        //保存entity
        private goodEntity entity;
        ///保存分类数据
        private List<model.goodscategory> goodscategoriesList=new List<model.goodscategory>();
        //保存每次选择的2级分类
        private List<model.goodscategory> goodscategoriesList2;
        public UpdateExamineGoodInfoForm(goodEntity entity)
        {
            this.entity=entity;
            InitializeComponent();
        }

        private void UpdateExamineGoodInfoForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadData();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            this.lblGoodsCategoryName.Text = entity.GoodsCategoryName;
            this.lblGoodsCode.Text = entity.GoodsCode;
            this.txtBrand.Text = entity.Brand;
            this.txtGoodName.Text = entity.GoodsName;
            this.txtGoodsLift.Text = entity.GoodsLift.ToString();
            this.txtGoodsMixed.Text = entity.GoodsMixed;
            this.txtGoodUnit.Text = entity.GoodsUnit;
            this.txtOfflineStock.Text = entity.OfflineStock.ToString();
            this.txtPurchasePrice.Text = entity.PurchasePrice.ToString();
            this.txtStock.Text = entity.Stock.ToString();
            this.txtStoreGoodsPrice.Text = entity.StoreGoodsPrice.ToString();
            this.txtUcode.Text = entity.GoodUcode;
            this.cbxGoodFlag.SelectedIndex = entity.GoodsFlag == 1 ? this.cbxGoodFlag.SelectedIndex = 0 : this.cbxGoodFlag.SelectedIndex = 1;
            this.pbGoodPic.Image = ddjd_c.common.extension.ExtensionImage.HttpGetImage(ddjd_c.http.baseHttp.getDdjdcUrl() + entity.GoodsPic, common.extension.DefaultImgType.Good);
        }

        #region 网络请求
        /// <summary>
        /// 加载分类数据
        /// </summary>
        private void LoadCategory()
        {
            ResponseResultDelegate action = CategoryCallback;
            //查询分类集合
            service.goodsCategory_service.goodsCategoryService.queryGoodsAllCateGory(action);
        }

        /// <summary>
        /// 分类请求回调
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sc"></param>
        private void CategoryCallback(ResponseResult result, System.Threading.SynchronizationContext sc)
        {

            if (result.Error != null)
            {
                MessageBox.Show(result.Error);
                return;
            }
            sc.Post(CategoryPostCallback, result);

        }
        /// <summary>
        /// 异步线程同步
        /// </summary>
        /// <param name="obj"></param>
        private void CategoryPostCallback(object obj)
        {
            ResponseResult result = (ResponseResult)obj;
            JArray ja = JArray.Parse(result.JsonStr);
            //拿到一级分类
            this.goodscategoriesList.AddRange(JsonHelper.DeserializeJsonToList<model.goodscategory>(ja.ToString()));

            ///显示的值
            this.cbx1.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx1.ValueMember = "GoodsCategoryId";

            this.cbx1.DataSource = this.goodscategoriesList;


            ///给23级分类赋值
            for (var i = 0; i < goodscategoriesList.Count; i++)
            {
                JObject j = JObject.Parse(ja[i].ToString());
                this.goodscategoriesList[i].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(j["list"].ToString());
                if (this.goodscategoriesList[i].List != null)
                {
                    for (var ii = 0; ii < this.goodscategoriesList[i].List.Count; ii++)
                    {
                        JObject jj = JObject.Parse(JArray.Parse(j["list"].ToString())[ii].ToString());
                        this.goodscategoriesList[i].List[ii].List = JsonHelper.DeserializeJsonToList<model.goodscategory>(jj["list"].ToString());

                    }
                }

            }
        }
        #endregion
        
        #region 分类选择
        /// <summary>
        /// 1级分类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //查询当前分类id下面对应的2级分类
            var list =
                 from value in this.goodscategoriesList
                 where value.GoodsCategoryId == int.Parse(cbx1.SelectedValue.ToString())
                 select value;
            this.goodscategoriesList2 = list.FirstOrDefault().List;
            this.cbx2.DataSource = this.goodscategoriesList2;
            ///显示的值
            this.cbx2.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx2.ValueMember = "GoodsCategoryId";
            
        }
        /// <summary>
        /// 2级分类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //查询当前分类id下面对应的2级分类
            var list =
                 from value in this.goodscategoriesList2
                 where value.GoodsCategoryId == int.Parse(cbx2.SelectedValue.ToString())
                 select value;
            this.cbx3.DataSource = list.FirstOrDefault().List;
            ///显示的值
            this.cbx3.DisplayMember = "GoodsCategoryName";
            ///value 值
            this.cbx3.ValueMember = "GoodsCategoryId";
        }
        /// <summary>
        /// 选择3级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblGoodsCategoryName.Text = cbx3.Text;
            this.entity.FCategoryId = int.Parse(cbx1.SelectedValue.ToString());
            this.entity.SCategoryId = int.Parse(cbx2.SelectedValue.ToString());
            this.entity.TCategoryId = int.Parse(cbx3.SelectedValue.ToString());
        }
        #endregion

        /// <summary>
        /// 图片点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbGoodPic_Click(object sender, EventArgs e)
        {

        }
        #region 提交修改信息
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string goodsName = this.txtGoodName.Text;
            string goodsUnit = this.txtGoodUnit.Text;
            string goodsLift = this.txtGoodsLift.Text;
            string goodUcode = this.txtUcode.Text;
            string brand = this.txtBrand.Text;
            string goodsPrice = this.txtStoreGoodsPrice.Text;
            int goodsFlag = this.cbxGoodFlag.SelectedIndex + 1;
            string stock = this.txtStock.Text;
            string offlineStock = this.txtOfflineStock.Text;
            string purchasePrice = this.txtPurchasePrice.Text;

            if (goodsName.StrIsNull())
            {
                MessageBox.Show("商品名称不能为空");
                return;
            }
            if (goodsUnit.StrIsNull())
            {
                MessageBox.Show("商品单位不能为空");
                return;
            }
            if (goodsLift.StrIsNull())
            {
                MessageBox.Show("商品保质期不能为空");
                return;
            }
            if (goodUcode.StrIsNull())
            {
                MessageBox.Show("商品规格不能为空");
                return;
            }
            if (brand.StrIsNull())
            {
                MessageBox.Show("商品品牌不能为空");
                return;
            }
            if (goodsPrice.StrIsNull())
            {
                MessageBox.Show("商品零售价不能为空");
                return;
            }
            if (goodsPrice.ToDouble() <= 0)
            {
                MessageBox.Show("商品零售价必须大于0");
                return;
            }
            if (purchasePrice.StrIsNull())
            {
                MessageBox.Show("商品进货价不能为空");
                return;
            }
            if (purchasePrice.ToDouble() <= 0)
            {
                MessageBox.Show("商品进货价必须大于0");
                return;
            }
            if (goodsPrice.ToDouble() < purchasePrice.ToDouble())
            {
                MessageBox.Show("商品零售价小于进货价","知道了",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            dic.Add("examineGoodsId", entity.ExamineGoodsId);
            dic.Add("goodsCode", entity.GoodsCode);
            dic.Add("storeId", GlobalsInfo.storeId);
            dic.Add("goodsName", goodsName);
            dic.Add("goodsUnit", goodsUnit);
            dic.Add("goodsLift", goodsLift);
            dic.Add("goodUcode", goodUcode);
            dic.Add("fCategoryId",entity.FCategoryId);
            dic.Add("sCategoryId", entity.SCategoryId);
            dic.Add("tCategoryId",entity.TCategoryId);
            dic.Add("goodsPic", entity.GoodsPic);
            dic.Add("brand", brand);
            dic.Add("goodsPrice", goodsPrice);
            dic.Add("goodsFlag", goodsFlag);
            dic.Add("stock", stock);
            dic.Add("offlineStock", offlineStock);
            dic.Add("purchasePrice", purchasePrice);
            dic.Add("goodsMixed",this.txtGoodsMixed.Text);
            UpdatexEamineGoodInfo(dic);
        }
        /// <summary>
        /// 修改审核信息
        /// </summary>
        /// <param name="dic"></param>
        private void UpdatexEamineGoodInfo(Dictionary<string, object> dic)
        {
            this.btnSubmit.Text = "正在提交...";
            this.btnSubmit.Enabled = false;
            ResponseResultDelegate resultDelegate = UpdatexEamineGoodCallback;
            service.good.goodService.UpdateExamineGoodsByStoreId(resultDelegate, dic);
        }
        /// <summary>
        /// 请求回调
        /// </summary>
        /// <param name="result"></param>
        /// <param name="sc"></param>
        private void UpdatexEamineGoodCallback(ResponseResult result,System.Threading.SynchronizationContext sc)
        {
            if (result.Error != null)
            {
                MessageBox.Show(result.Error);
                return;
            }
            Console.Write(result.JsonStr);
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Enabled = true;
        }
        #endregion
        #region 输入框设置
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 只能输入double类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
    }
}
