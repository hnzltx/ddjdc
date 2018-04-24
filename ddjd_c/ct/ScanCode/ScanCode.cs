using ddjd_c.common;
using ddjd_c.common.extension;
using ddjd_c.service.scanCode_service;
using ddjd_c.vo.addShopCar;
using DevComponents.DotNetBar;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
        //定义键盘钩子 ； 用来无焦点状态下获取扫描枪扫描的条码
        private KeyboardHookLib listener = new KeyboardHookLib();

        public frmScanCode()
        {
            InitializeComponent();
            listener.ScanerEvent += Listener_ScanerEvent;
        }

        private void Listener_ScanerEvent(KeyboardHookLib.ScanerCodes codes)
        {
            //键盘钩子获取的条码，赋值到文本框中
            textCode.Text = codes.Result;

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
                        exitAndClose();
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
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmScanCode_Load(object sender, EventArgs e)
        {

            //将窗体全屏
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width1 = ScreenArea.Width;
            int height1 = ScreenArea.Height;
            this.Width = width1;
            this.Height = height1;
            this.Top = 0;
            this.Left = 0;
            this.TopMost = true;

            //加载键盘钩子
            listener.Start();

            ///隐藏最大化和关闭按钮
            ArrayList items = ribbonControl1.RibbonStrip.GetItems("", typeof(SystemCaptionItem));
            foreach (SystemCaptionItem sci in items)
            {
                if (!sci.IsSystemIcon)
                {

                    //sci.MinimizeVisible = false;
                    sci.RestoreMaximizeVisible = false;
                    sci.CloseVisible = false;
                    break;
                }
            }

            //加载收银秤配置
            if (!loadCashierScaleConfig())
            {
                return;
            }

            //加载分页配置
            loagPageConfig();


            //获取当前店铺购物车的商品
            queryStoreshoppingcar();

            //添加默认常用选项 ,并绑定点击事件，添加listview
            TabItem cy = this.tabGoodscategory.CreateTab("  常用  ");
            cy.Tag = 0;
            cy.Click += new System.EventHandler(this.goodscategory_click);
            addListView(cy, 0);

            commItem = cy;
            commGoodsCategoryId = 0;


            //查询分类集合
            List<model.goodscategory> goodsCategoryList = service.goodsCategory_service.goodsCategoryService.queryGoodsCateGoryForOne();

            if (goodsCategoryList.Count > 0) {
                foreach (model.goodscategory g in goodsCategoryList) {
                    TabItem t = this.tabGoodscategory.CreateTab("  " + g.GoodsCategoryName + "  ");
                    t.Tag = g.GoodsCategoryId;
                    t.Click += new System.EventHandler(this.goodscategory_click);

                }
            }

            //显示总数和总价
            displaySumCountAndSumMoney();
            //输入框选中
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
                        row.Cells[4].Value = common.utils.CutDecimalWithN(new decimal(double.Parse(goods.Weight)) * storeGoodsPrice, 2);
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
            //每次切换分类， 都是从第一页开始
            ct_pageNumber = 1;

            TabItem t = (TabItem)sender;

            commItem = t;
            commGoodsCategoryId = int.Parse(t.Tag.ToString());

            //commItem.AttachedControl.Controls.RemoveAt(0);
            commItem.AttachedControl.Controls.Clear();


            addListView(t, int.Parse(t.Tag.ToString()));
            SetTextCode();


        }

        //记录全局的tabItem; 分页时使用
        TabItem commItem;
        //记录全局的分类ID; 分页时使用
        int? commGoodsCategoryId;


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
            il.ImageSize = new Size(90, 90);

            //设置listView显示的图片
            lv.LargeImageList = il;

            Dictionary<String, object> d = new Dictionary<string, object>();
            if (null != goodsCategoryId) {
                if (goodsCategoryId != 0) {
                    //添加分类ID
                    d.Add("fCategoryId", goodsCategoryId);
                }

            }
            d.Add("pageSize", ct_pageSize);
            d.Add("pageNumber", ct_pageNumber);

            vo.pageInfo<vo.goods.scanCodeGoods> pg = new vo.pageInfo<vo.goods.scanCodeGoods>();
            //查询此分类下的商品
            pg = scanCodeService.queryGoodsWithCustomGoods(d);

            //分页配置
            pageInfoConfig(pg);

            //商品数量大于0，进行遍历
            if (pg.TotalRow > 0) {
                int i = 0;
                foreach (var goods in pg.List) {

                    il.Images.Add(ExtensionImage.HttpGetImage(http.baseHttp.getDdjdcUrl() + goods.GoodsPic, DefaultImgType.Good));
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
                            if (!InitPort()) {
                                //删除刚刚加入的商品
                                service.scanCode_service.scanCodeService.deleteStoreshoppingcar(statuInfo.StoreShoppingcarId);
                                return;
                            }
                            //发送指令，获取重量
                            com.Write("ESCP");
                            //暂停下再拿
                            Thread.Sleep(200);

                            //获取收银秤重量
                            bulkCargoWeight = weight.ToString();
                            //如果没有获取到，设置重量=0
                            if (bulkCargoWeight.Length <= 0)
                            {
                                bulkCargoWeight = "0";
                            }
                            else {
                                //最终重量
                                bulkCargoWeight = bulkCargoWeight.Substring(0, bulkCargoWeight.Length - 3).Insert(1, ".") + bulkCargoWeight.Substring(bulkCargoWeight.Length - 3);
                            }

                            //清空重量变量
                            weight.Clear();


                            scanCodeService.updateStoreCar(1, bulkCargoWeight, statuInfo.StoreShoppingcarId);

                        }

                        //判断是新增还是增加数量
                        if (statuInfo.AddOrUpdate.Equals(1))
                        {
                            //增加数量
                            DataGridViewRowAddCount(statuInfo.StoreShoppingcarId.Value, isBulkCargo, bulkCargoWeight);

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
                                row.Cells[4].Value = common.utils.CutDecimalWithN(new decimal(double.Parse(goodsInfo.StoreGoodsPrice)) * new decimal(double.Parse(bulkCargoWeight)), 2);
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
        private void DataGridViewRowAddCount(int storeShoppingcarId, bool isBulkCargo = false, string bulkCargoWeight = "") {
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
                        dgvShopcar.Rows[dgvr.Index].Cells[4].Value = common.utils.CutDecimalWithN(count * storeGoodsPrice, 2);


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

                    sumMoney += new decimal(double.Parse(dgvr.Cells[4].Value.ToString()));

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
            this.lblSumMoney.Text = common.utils.CutDecimalWithN(sumMoney, 2).ToString();

        }


        /// <summary>
        ///  结算按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitOrder_Click(object sender, EventArgs e)
        {
            frmSubmitOrder submitOrder = new frmSubmitOrder(this.lblSumMoney.Text, this);
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
            deleteOneGoods();
        }


        

        private void frmScanCode_Activated(object sender, EventArgs e)
        {
            SetTextCode();
        }




        #region 串口获取重量
        //重量
        StringBuilder weight = new StringBuilder();
        //定义个串口
        SerialPort com = new SerialPort();
        private bool InitPort()
        {
            //清空重量变量
            weight.Clear();
            try
            {
                if (!com.IsOpen)
                {
                    com.BaudRate = db.SetCashierScale.SetCashierScale.BaudRate;
                    com.PortName = db.SetCashierScale.SetCashierScale.PortName;
                    com.DataBits = db.SetCashierScale.SetCashierScale.DataBits;
                    //com.BaudRate = 9600;
                    //com.PortName = "COM4";
                    //com.DataBits = 8;
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " -- (请检查收银秤是否连接正确!)");
                return false;
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
                if (res != "")
                {
                    weight.Append(res);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 关闭串口连接
        /// </summary>
        private void CloseSerialPort() {
            if (com.IsOpen)
            {
                com.Close();
            }

        }

        #endregion





        /// <summary>
        /// 加载收银秤的配置
        /// </summary>
        /// <returns></returns>
        private bool loadCashierScaleConfig() {

            if (common.utils.FileExists("SetCashierScale.json"))
            {
                JObject json = common.utils.getFile("SetCashierScale.json");
                if (json != null)
                {
                    db.SetCashierScale.SetCashierScale.PortName = json["PortName"].ToString();
                    db.SetCashierScale.SetCashierScale.BaudRate = int.Parse(json["BaudRate"].ToString());
                    db.SetCashierScale.SetCashierScale.DataBits = int.Parse(json["DataBits"].ToString());
                    return true;
                }
                else
                {
                    MessageBox.Show("您可能还未设置收银秤,请先去设置!");
                    this.Close();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("您可能还未设置收银秤,请先去设置!");
                this.Close();
                return false;
            }
        }

        /// <summary>
        /// 点击按钮，删除某一商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteOneGoods_Click(object sender, EventArgs e)
        {
            deleteOneGoods();
        }


        /// <summary>
        /// 删除某选中商品
        /// </summary>
        private void deleteOneGoods() {
            if (this.dgvShopcar.SelectedRows.Count > 0)
            {
                var storeShoppingcarId = this.dgvShopcar.SelectedRows[0].Cells[0].Value;
                if (null != storeShoppingcarId)
                {
                    JObject json = service.scanCode_service.scanCodeService.deleteStoreshoppingcar(storeShoppingcarId.ToString());
                    if (json["success"].ToString().Equals(GlobalsInfo.success))
                    {
                        this.dgvShopcar.Rows.Remove(this.dgvShopcar.SelectedRows[0]);
                        displaySumCountAndSumMoney();

                    }
                    else
                    {
                        MessageBox.Show("删除失败,请刷新后重试！");
                    }
                }
                else
                {
                    MessageBox.Show("删除异常,请刷新后重试！");
                }
            }
            else
            {
                MessageBox.Show("没有选中商品!");
            }
        }



        /// <summary>
        /// 查询数据并配置分页
        /// </summary>
        private void commQueryPageInfo()
        {
            //移除当前分类下的listview，用以重新展示新数据
            //commItem.AttachedControl.Controls.RemoveAt(0);
            commItem.AttachedControl.Controls.Clear();
            //查询新数据
            addListView(commItem,commGoodsCategoryId);

        }



        #region 分页代码
        /** 目前分页需要改动的只有泛型对象， 
         * 按道理将所有model都继承一个baseModel，稍作改动即可使分页更加通用，暂时记着，以后看改不改 —_—*/

        //数据绑定到dataGridView的泛型集合，方便后期操作；   -- 此处的 T 需要改成你需要的对象
        BindingList<vo.order.order> BList;
        //当前窗体的每页查询条数
        //int ct_pageSize = GlobalsInfo.pageSize;
        int ct_pageSize = GlobalsInfo.pageSize + 10;
        //当前窗体已经查询到第几页
        int ct_pageNumber = GlobalsInfo.pageNumber;
        //数据总页数
        int ct_totalPage = 1;


        /// <summary>
        /// 绑定分页控件和事件代码的关系；  在窗体加载时调用
        /// </summary>
        private void loagPageConfig() {
            //尾页事件
            this.btnEndPage.Click += new EventHandler(this.btnEndPage_Click);
            //首页事件
            this.btnHomePage.Click += new EventHandler(this.btnHomePage_Click);
            //下一页事件
            this.btnNextPage.Click += new EventHandler(this.btnNextPage_Click);
            //上一页事件
            this.btnPreviousPage.Click += new EventHandler(this.btnPreviousPage_Click);
            //页面条数显示框默认显示条数
            this.cmbSelect.Text = ct_pageSize.ToString();
            //绑定页面显示条数设置控件的TextChanged事件
            this.cmbSelect.SelectedIndexChanged += new EventHandler(cmbSelect_TextChanged);
        }


        /// <summary>
        /// 分页控件配置
        /// </summary>
        /// <param name="pg"></param>
        private void pageInfoConfig(vo.pageInfo<vo.goods.scanCodeGoods> pg)
        {

            //数据总数
            this.lblCount.Text = pg.TotalRow.ToString();
            //总页数
            ct_totalPage = pg.TotalPage.Value;

            if (pg.LastPage)
            {
                //如果是最后一页，禁用下一页和尾页
                btnNextPage.Enabled = false;
                btnEndPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
                btnEndPage.Enabled = true;
            }

            if (pg.FirstPage)
            {
                //如果是第一页，禁用首页和上一页
                btnHomePage.Enabled = false;
                btnPreviousPage.Enabled = false;
            }
            else
            {
                btnHomePage.Enabled = true;
                btnPreviousPage.Enabled = true;
            }

        }


        /// <summary>
        /// 首页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHomePage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = 1;
            commQueryPageInfo();
        }

        /// <summary>
        /// 每页多少条的选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelect_TextChanged(object sender, EventArgs e)
        {
            //当前选择的每页多少条
            int selectPageSize = int.Parse(this.cmbSelect.SelectedItem.ToString());
            //设置公共每页多少条
            ct_pageSize = selectPageSize;
            //如果当前选择的数量  大于或等于 总的数据条数
            if (selectPageSize >= int.Parse(this.lblCount.Text))
            {
                //回到第一页
                ct_pageNumber = 1;
            }
            commQueryPageInfo();

        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber - 1;
            commQueryPageInfo();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_pageNumber + 1;
            commQueryPageInfo();
        }


        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndPage_Click(object sender, EventArgs e)
        {
            ct_pageNumber = ct_totalPage;
            commQueryPageInfo();
        }



        #endregion


        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            exitAndClose();
        }


        /// <summary>
        /// 退出的操作
        /// </summary>
        private void exitAndClose() {
            //关闭键盘钩子
            listener.Stop();
            //关闭收银秤的串口连接
            CloseSerialPort();
            //关闭本窗体
            this.Close();
        }

        /// <summary>
        /// 挂单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuadan_Click(object sender, EventArgs e)
        {
            JObject json =  service.scanCode_service.scanCodeService.guadan();
            if (!string.IsNullOrEmpty(json.ToString()))
            {
                if (json["success"].ToString().Equals(GlobalsInfo.success))
                {
                    this.dgvShopcar.Rows.Clear();
                    MessageBox.Show("挂单成功!");
                }
                else {
                    MessageBox.Show("挂单失败!当前没有待结算的商品也会挂单失败哦！");
                }
            }
            else {
                MessageBox.Show("挂单失败!请重试!");
            }
           
        }

        /// <summary>
        /// 取出挂单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetGuadan_Click(object sender, EventArgs e)
        {
            frmGuadan guadan = new frmGuadan(this);
            guadan.TopMost = true;
            guadan.ShowDialog();
        }


        #region 给子窗体调用
        /// <summary>
        /// 刷新首页界面待结算商品
        /// </summary>
        public void queryStoreshoppingcar_zi()
        {
            queryStoreshoppingcar();
            //显示总数和总价
            displaySumCountAndSumMoney();
            //输入框选中
            SetTextCode();
        }


        /// <summary>
        /// 用来给子窗体调用 ; 清空当前待结算商品。清空数量和金额；
        /// </summary>
        public void emptyOther()
        {

            this.dgvShopcar.Rows.Clear();
            this.lblSumCount.Text = "0";
            this.lblSumMoney.Text = "0";

            SetTextCode();
        }
        #endregion




    }
}
