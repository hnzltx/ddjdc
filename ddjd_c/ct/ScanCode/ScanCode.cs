using ddjd_c.service.scanCode_service;
using ddjd_c.vo.addShopCar;
using DevComponents.DotNetBar;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.ScanCode
{
    public partial class frmScanCode : Form
    {
        public frmScanCode()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScanCode_Load(object sender, EventArgs e)
        {
            

            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            //int width1 = ScreenArea.Width;
            //int height1 = ScreenArea.Height;
            //this.Width = width1;
            //this.Height = height1;
            //this.Top = 0;
            //this.Left = 0;
            //this.TopMost = true;


            //获取当前店铺购物车的商品
            queryStoreshoppingcar();

            //添加默认常用选项 ,并添加listview
            addListView(this.tabGoodscategory.CreateTab("  常用  "), null);

            //查询分类集合
            List<model.goodscategory> goodsCategoryList = service.goodsCategory_service.goodsCategoryService.queryGoodsCateGoryForOne();

            if (goodsCategoryList.Count > 0) {
                foreach (model.goodscategory g in goodsCategoryList) {
                    TabItem t = this.tabGoodscategory.CreateTab("  " + g.GoodsCategoryName + "  ");
                    t.Name = "goodscategory_" + g.GoodsCategoryId;
                    t.Click += new System.EventHandler(this.goodscategory_click);

                }
            }


            displaySumCountAndSumMoney();
            SetTextCode();

        }


        /// <summary>
        /// 查询店铺当前购物车数据
        /// </summary>
        private void queryStoreshoppingcar() {
            List<addShopCarGoods> goodsInfo = service.scanCode_service.scanCodeService.queryStoreshoppingcar();

            if (goodsInfo.Count > 0)
            {
                foreach (addShopCarGoods goods in goodsInfo)
                {
                    //新增购物车数据
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvShopcar);

                    decimal count = new decimal(int.Parse(goods.GoodsCount.ToString()));
                    decimal storeGoodsPrice = new decimal(double.Parse(goods.StoreGoodsPrice));

                    row.Cells[0].Value = goods.StoreShoppingcarId;
                    row.Cells[1].Value = goods.GoodsName;
                    //散货使用Weight ，非散户使用GoodsCount
                    if (goods.IsBulkCargo == 1)
                    {
                        row.Cells[2].Value = goods.GoodsCount;
                        row.Cells[4].Value = count * storeGoodsPrice;
                    }
                    else {
                        row.Cells[2].Value = goods.Weight;
                        row.Cells[4].Value = (new decimal(double.Parse(goods.Weight)) * storeGoodsPrice).ToString("#0.00");
                    }
                    row.Cells[3].Value = goods.StoreGoodsPrice;
                    row.Cells[5].Value = goods.IsBulkCargo;

                    dgvShopcar.Rows.Add(row);
                }
            }
        }



        /// <summary>
        ///  分类的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goodscategory_click(object sender, EventArgs e)
        {
            TabItem t = (TabItem)sender;
            string[] strArray = t.Name.Split('_');
            addListView(t, int.Parse(strArray[1]));
            SetTextCode();
        }




        /// <summary>
        /// 为TabItem添加listView
        /// </summary>
        /// <param name="item"></param>
        private void addListView(TabItem item, int? goodsCategoryId) {
            ListView lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.Click += new System.EventHandler(this.goodsListView_click);

            //每个listView显示的图片
            ImageList il = new ImageList();
            il.ImageSize = new Size(100, 100);

            //设置listView显示的图片
            lv.LargeImageList = il;

            Dictionary<String, object> d = new Dictionary<string, object>();
            if (null != goodsCategoryId) {
                //添加分类ID
                d.Add("fCategoryId", goodsCategoryId);
            }
            //查询此分类下的商品
            List<vo.goods.scanCodeGoods> listGoods = scanCodeService.queryGoodsWithCustomGoods(d);

            //商品数量大于0，进行遍历
            if (listGoods.Count > 0) {
                int i = 0;
                foreach (var goods in listGoods) {
                    Image img = Image.FromStream(WebRequest.Create(http.baseHttp.getDdjdcUrl() + goods.GoodsPic).GetResponse().GetResponseStream());

                    il.Images.Add(img);
                    lv.Items.Add(System.IO.Path.GetFileName(i.ToString()), i);
                    lv.Items[i].ImageIndex = i;
                    lv.Items[i].Name = goods.GoodsCode;
                    lv.Items[i].Text = goods.GoodsName;

                    i++;
                }
            }
            item.AttachedControl.Controls.Add(lv);

        }


        /// <summary>
        /// 为每个分类下面的商品添加点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goodsListView_click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            int selectCount = lv.SelectedItems.Count; //SelectedItems.Count就是：取得值，表示SelectedItems集合的物件数目。 
            if (selectCount > 0)//若selectCount大於0，说明用户有选中某列。
            {
                this.textCode.Text = lv.SelectedItems[0].SubItems[0].Name;
                addGoods();
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
                    if (MessageBox.Show("确认退出收银界面?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    return true;
                case Keys.Enter:
                    addGoods();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



        /// <summary>
        /// 添加商品 -  加入购物车
        /// </summary>
        protected void addGoods()
        {
            string code = this.textCode.Text;
            if (code == "") {
                MessageBox.Show("请输入或扫描条码!");
                SetTextCode();
                return;
            }

            //查询商品后返回的jsonObjer
            JObject json = scanCodeService.queryGoodsInfoByGoodsCode(this.textCode.Text);

            if (null != json)
            {
                if (null != json["result"])
                {
                    //获得加入购物车返回的状态信息
                    addShopCarStatuInfo statuInfo = common.JsonHelper.DeserializeJsonToObject<addShopCarStatuInfo>(json["result"].ToString());
                    if (statuInfo.Success.Equals("success"))
                    {
                        //获取商品信息
                        addShopCarGoods goodsInfo = common.JsonHelper.DeserializeJsonToObject<addShopCarGoods>(json["goodsInfo"].ToString());
                       
                        //是否为散货 true 是
                        bool isBulkCargo = goodsInfo.IsBulkCargo == 2 ? true : false;
                        //散货的重量
                        string bulkCargoWeight = "";

                        //验证是否为散货
                        if (isBulkCargo)
                        {
                            //如果是散货，打开电脑与收银秤的串口连接
                            InitPort();
                            //暂停下再拿
                            Thread.Sleep(100);

                            //获取收银秤重量
                            bulkCargoWeight = getWeight();

                            //清空重量变量
                            weight.Clear();
                            

                            scanCodeService.updateStoreCar(1, bulkCargoWeight, statuInfo.StoreShoppingcarId);

                        }

                        //判断是新增还是增加数量
                        if (statuInfo.AddOrUpdate.Equals(1))
                        {
                            //增加数量
                            DataGridViewRowAddCount(statuInfo.StoreShoppingcarId.Value,isBulkCargo,bulkCargoWeight);

                        }
                        else
                        {
                            //新增购物车数据
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dgvShopcar);

                            row.Cells[0].Value = goodsInfo.StoreShoppingcarId;
                            row.Cells[1].Value = goodsInfo.GoodsName;

                            //如果是散货，
                            if (isBulkCargo)
                            {
                                //显示散货重量
                                row.Cells[2].Value = bulkCargoWeight;

                                //计算散货金额
                                row.Cells[4].Value = (new decimal(double.Parse(goodsInfo.StoreGoodsPrice)) * new decimal(double.Parse(bulkCargoWeight))).ToString("#0.00");
                            }
                            else
                            {
                                //否则默认是数量1
                                row.Cells[2].Value = 1;

                                //默认是单价
                                row.Cells[4].Value = goodsInfo.StoreGoodsPrice;
                            }
                            
                            //添加单价
                            row.Cells[3].Value = goodsInfo.StoreGoodsPrice;
                            
                            //添加是否为散货标识
                            row.Cells[5].Value = goodsInfo.IsBulkCargo;

                            dgvShopcar.Rows.Add(row);
                        }

                        //计算总价
                        displaySumCountAndSumMoney();
                        
                    }
                    else
                    {
                        MessageBox.Show("加入购物车失败!");
                    }
                }
                else
                {
                    string success1 = json["success"].ToString();
                    if (success1.Equals("underStock"))
                    {
                        MessageBox.Show("库存不足!");
                    }
                    else if (success1.Equals("xiajia"))
                    {
                        MessageBox.Show("商品已下架!");
                    }
                    else if (success1.Equals("notExist"))
                    {
                        MessageBox.Show("商品不存在!");
                    }
                    else
                    {
                        MessageBox.Show("请求失败!");
                    }
                }
            }
            else
            {
                MessageBox.Show("请求失败!");
            }

            SetTextCode();
        }


        /// <summary>
        /// 为某行商品增加数量
        /// </summary>
        /// <param name="storeShoppingcarId"></param>
        /// <param name="isBulkCargo">是否为散货； true是</param>
        /// <param name="bulkCargoWeight">散货的重量</param>
        private void DataGridViewRowAddCount(int storeShoppingcarId,bool isBulkCargo = false, string bulkCargoWeight = "") {
            //列表中所有的行
            DataGridViewRowCollection dvrc = dgvShopcar.Rows;

            if (dvrc.Count > 0) {
                foreach (DataGridViewRow dgvr in dvrc) {
                    if (int.Parse(dgvr.Cells[0].Value.ToString()).Equals(storeShoppingcarId)) {
                        decimal count = new decimal(0);
                        if (isBulkCargo)
                        {
                            count = new decimal(double.Parse(bulkCargoWeight));
                        }
                        else {
                            //增加一个之后的数量
                            count = int.Parse(dgvr.Cells[2].Value.ToString()) + 1;
                        }
                        

                        //将数量和单价转换为高精度来处理
                        decimal storeGoodsPrice = new decimal(double.Parse(dgvr.Cells[3].Value.ToString()));

                        //重新设置商品数量和小计
                        dgvShopcar.Rows[dgvr.Index].Cells[2].Value = count;
                        dgvShopcar.Rows[dgvr.Index].Cells[4].Value = (count * storeGoodsPrice).ToString("#0.00");

                    }
                }
            }
        }



        /// <summary>
        /// 显示当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }


        /// <summary>
        /// 设置收银界面条码输入框的焦点，并清空
        /// </summary>
        private void SetTextCode() {
            this.textCode.Text = "";
            this.textCode.Focus();
        }


        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emptyShopCar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空购物车所有商品吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string deleteStatu = scanCodeService.deleteStoreshoppingcarAll();
                if (deleteStatu != "") {
                    //清空表单
                    this.dgvShopcar.Rows.Clear();
                    this.lblSumCount.Text = "0";
                    this.lblSumMoney.Text = "0";
                }
                else {
                    MessageBox.Show("清空失败!");
                }
            }
        }


        /// <summary>
        /// 微信支付按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weixinPay_Click(object sender, EventArgs e)
        {
            if (GlobalsInfo.storeType == 1)
            {
                MessageBox.Show("微信支付成功!");
            }
            else {
                MessageBox.Show("加盟店暂时不能使用此支付方式!");
            }
        }

        /// <summary>
        /// 支付宝支付按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alipay_Click(object sender, EventArgs e)
        {
            if (GlobalsInfo.storeType == 1)
            {
                MessageBox.Show("支付宝支付成功!");
            }
            else
            {
                MessageBox.Show("加盟店暂时不能使用此支付方式!");
            }
        }


        /// <summary>
        /// 右键购物车某商品出现的菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShopcar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.dgvShopcar.Rows[e.RowIndex].Selected = true;
                this.dgvMenu.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示
                

            }
        }
        


        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            addGoods();
        }




        /// <summary>
        /// 计算购物车中商品总数量和总金额
        /// </summary>
        private void displaySumCountAndSumMoney() {
            //列表中所有的行
            DataGridViewRowCollection dvrc = dgvShopcar.Rows;

            //默认数量
            int sumCount = 0;
            //默认金额
            decimal sumMoney = 0;

            if (dvrc.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dvrc)
                {
                    //将数量和单价转换为高精度来处理
                    decimal storeGoodsPrice = new decimal(double.Parse(dgvr.Cells[3].Value.ToString()));
                    
                    sumMoney += new decimal(double.Parse(dgvr.Cells[2].Value.ToString())) * storeGoodsPrice ;

                    //如果不是散货，数量累加
                    if (int.Parse(dgvr.Cells[5].Value.ToString()) == 1)
                    {
                        sumCount += int.Parse(dgvr.Cells[2].Value.ToString());
                    }
                    else {
                        //如果是散货，数量直接+1
                        sumCount += 1;
                    }
                    
                    
                }
            }

            this.lblSumCount.Text = sumCount.ToString();
            this.lblSumMoney.Text = sumMoney.ToString("#0.00");

        }


        /// <summary>
        ///  结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitOrder_Click(object sender, EventArgs e)
        {
            frmSubmitOrder submitOrder = new frmSubmitOrder(this.lblSumMoney.Text,this);
            submitOrder.TopMost = true;
            submitOrder.ShowDialog();
            
        }

        /// <summary>
        /// 删除商品点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteGoodsBystoreAndGoodsId_Click(object sender, EventArgs e)
        {
            var storeShoppingcarId = this.dgvShopcar.SelectedRows[0].Cells[0].Value;
            if (null != storeShoppingcarId)
            {
                JObject json =  service.scanCode_service.scanCodeService.deleteStoreshoppingcar(storeShoppingcarId.ToString());
                if (json["success"].ToString().Equals(GlobalsInfo.success))
                {
                    this.dgvShopcar.Rows.Remove(this.dgvShopcar.SelectedRows[0]);
                    displaySumCountAndSumMoney();

                }
                else {
                    MessageBox.Show("删除失败,请刷新后重试！");
                }
            }
            else {
                MessageBox.Show("删除异常,请刷新后重试！");
            }
        }


        /// <summary>
        /// 用来给子窗体调用
        /// </summary>
        public void emptyOther() {

            this.dgvShopcar.Rows.Clear();
            this.lblSumCount.Text = "0";
            this.lblSumMoney.Text = "0";

            SetTextCode();
        }

        private void frmScanCode_Activated(object sender, EventArgs e)
        {
            SetTextCode();
        }


        private string getWeight() {
            try
            {
                double ss = double.Parse(weight.ToString());
                return ss.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "--" + weight.ToString());
                return "0";
            }
        }
        

        //重量
        StringBuilder weight = new StringBuilder();
        //定义个串口
        SerialPort com = new SerialPort();
        private void InitPort()
        {
            if (!com.IsOpen)
            {
                com.BaudRate = 9600;
                com.PortName = "COM4";
                com.DataBits = 8;
                com.Parity = Parity.None;
                com.StopBits = StopBits.One;

                com.Open();
            }
            com.WriteTimeout = 3000;
            com.ReadTimeout = 3000;
            com.ReceivedBytesThreshold = 1;
            com.DtrEnable = true;
            com.RtsEnable = true;
            com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
            
        }

        //定义委托处理数据
        private delegate void MyDelegate(string str);
        private void DisplayData(string str)
        {
            weight.Append(str);
            if (weight.ToString().Length >= 4)
            {
                if (com.IsOpen) {
                    com.DataReceived -= new SerialDataReceivedEventHandler(com_DataReceived);
                    com.Close();
                }
                weight = weight.Insert(1, ".");
                
            }
        }

        private void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!com.IsOpen)
                {
                    com.Open();
                }
                com.ReadTimeout = 500;
                string res = "";
                byte[] buffer = new byte[com.BytesToRead];
                com.Read(buffer, 0, buffer.Length);
                res = System.Text.Encoding.ASCII.GetString(buffer);
                res = System.Text.RegularExpressions.Regex.Replace(res, @"[^\d]*", "");
                res = res.Replace("\n", "");
                res = res.Replace("\r", "");
                res = res.Replace("\t", "");
                res = res.Replace(" ", "");
                res = res.Replace("?", "");
                res = res.Replace(".", "");
                DisplayData(res);
                //if (test2.InvokeRequired)
                //{
                //    test2.Invoke((System.Threading.ThreadStart)delegate
                //    {
                //        Console.WriteLine(res);
                //        test2.Text = res;


                //        if (test1.Text == "")
                //        {
                //            double s = double.Parse(res.Replace("\r", "")) / 1000;
                //            test1.Text = res.Replace("\r", "");
                //        }

                //    });
                //}

                //res = System.Text.RegularExpressions.Regex.Replace(res, @"[^\d]*", "");

                //if (res.Length >= 4)
                //{
                //    res = res.Substring(0, 4);
                //    //Console.WriteLine("持续读取:" + res);
                //    if (!res.Equals("0000"))
                //    {
                //        //com.Close();
                //        res = res.Insert(1, ".");
                //        weight = res;
                //        //Console.WriteLine(DateTime.Now.ToString() + "关闭：" + res);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
