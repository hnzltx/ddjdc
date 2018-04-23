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
using System.IO;
using System.Collections.Specialized;

namespace ddjd_c.ct.good
{
    public partial class UpdateExamineGoodInfoForm : Form
    {
        //保存entity
        private goodEntity entity;
        //保存行索引
        private int rowIndex;
        ///保存分类数据
        private List<model.goodscategory> goodscategoriesList=new List<model.goodscategory>();
        //保存每次选择的2级分类
        private List<model.goodscategory> goodscategoriesList2;
        ///修改成功回调
        public Action<int> action;
        public UpdateExamineGoodInfoForm(goodEntity entity,int rowIndex)
        {
            this.rowIndex = rowIndex;
            this.entity=entity;
            InitializeComponent();
        }

        private void UpdateExamineGoodInfoForm_Load(object sender, EventArgs e)
        {
            ///上传图片 用到
            this.AllowDrop = true;
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
        private void cbx3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.lblGoodsCategoryName.Text = cbx3.Text;
            this.entity.FCategoryId = int.Parse(cbx1.SelectedValue.ToString());
            this.entity.SCategoryId = int.Parse(cbx2.SelectedValue.ToString());
            this.entity.TCategoryId = int.Parse(cbx3.SelectedValue.ToString());
        }
        #endregion

        
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
            sc.Post(UpdatexEamineGoodPostCallback, result);
            
           
        }
        /// <summary>
        /// 异步线程同步
        /// </summary>
        /// <param name="obj"></param>
        private void UpdatexEamineGoodPostCallback(object obj)
        {
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Enabled = true;
            string success = ((ResponseResult)obj).ToObj()["success"].ToString();
            switch (success)
            {
                case "success":
                    if(MessageBox.Show("商品成功提交审核；请等待审核结果")== DialogResult.OK)
                    {
                        action(rowIndex);
                        this.Close();
                    }
                    break;
                case "offlineStockMaxError":
                    MessageBox.Show("库存下限填写的数量不能等于或超过库存");
                    break;
                case "goodsPriceOrpurchasePriceTypeError":
                    MessageBox.Show("商品价格或进货价填写有误");
                    break;
                default:
                    MessageBox.Show("修改失败");
                    break;
            }
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

       


        private void pbGoodPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                //获取用户选择文件的后缀名 
                string extension = Path.GetExtension(openFileDialog.FileName);
                //声明允许的后缀名 
                string[] str = new string[] {".jpg", ".png" };
                if (!str.Contains(extension))
                {
                    MessageBox.Show("仅能上传png,jpg格式的图片！");
                    return;
                }
                else
                {
                    //获取用户选择的文件，并判断文件大小不能超过500K，fileInfo.Length是以字节为单位的 
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > 1048*500)
                    {
                        MessageBox.Show("上传的图片不能大于500K");
                        return;
                    }
                    else
                    {
                        //PictureBox控件显示图片
                        this.pbGoodPic.Load(openFileDialog.FileName);
                        //绝对路径
                        string imageUrl = openFileDialog.FileName;
                        //  是指XXX.jpg
                        string picpath = openFileDialog.SafeFileName;

                        //NameValueCollection data = new NameValueCollection();
                        //data.Add("path","goodsImages");

                        Upload_Request(http.baseHttp.getDdjdcUrl() + "upload/start", imageUrl, picpath);
                        //http.baseHttp.HttpUploadFile(http.baseHttp.getDdjdcUrl()+ "upload/start", new string[] { imageUrl,picpath }, data);


                       
                    }
                }
            }
        }


        // <summary>  
        /// 将本地文件上传到指定的服务器(HttpWebRequest方法)  
        /// </summary>  
        /// <param name="address">文件上传到的服务器</param>  
        /// <param name="fileNamePath">要上传的本地文件（全路径）</param>  
        /// <param name="saveName">文件上传后的名称</param>  
        /// <param name="progressBar">上传进度条</param>  
        /// <returns>成功返回1，失败返回0</returns>  
        private int Upload_Request(string address, string fileNamePath, string saveName)
        {
            int returnValue = 0;

            // 要上传的文件  
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            //时间戳  
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("/r/n--" + strBoundary + "/r/n");
            
            //请求头部信息  
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("/r/n");
            sb.Append("Content-Disposition: form-data; name=/");  
            sb.Append("file");
            sb.Append("/filename=/");
            sb.Append(saveName);
            sb.Append("/path=/");
            sb.Append("goodsImages");  
            sb.Append("/r/n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("/r/n");
            sb.Append("/r/n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);

            // 根据uri创建HttpWebRequest对象  
            var httpReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";

            //对发送的数据不使用缓存  
            httpReq.AllowWriteStreamBuffering = false;

            //设置获得响应的超时时间（300秒）  
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                //progressBar.Maximum = int.MaxValue;
                //progressBar.Minimum = 0;
                //progressBar.Value = 0;

                //每次上传4k  
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength];

                //已上传的字节数  
                long offset = 0;

                //开始上传时间  
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();
                //发送请求头部消息  
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    //progressBar.Value = (int)(offset * (int.MaxValue / length));
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
                    //lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
                    if (second > 0.001)
                    {
                        //lblSpeed.Text = " 平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                    }
                    else
                    {
                        //lblSpeed.Text = " 正在连接…";
                    }
                    //lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                    //lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    Application.DoEvents();
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳  
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();

                //获取服务器端的响应  
                var webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                StreamReader sr = new StreamReader(s);

                //读取服务器端返回的消息  
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                {
                    returnValue = 1;
                }
                else if (sReturnString == "Error")
                {
                    returnValue = 0;
                }

            }
            catch
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }

            return returnValue;
        }

    }
}
