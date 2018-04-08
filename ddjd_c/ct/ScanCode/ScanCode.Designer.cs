namespace ddjd_c.ct.ScanCode
{
    partial class frmScanCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lblSumMoney = new DevComponents.DotNetBar.LabelX();
            this.lblSumCount = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.tabGoodscategory = new DevComponents.DotNetBar.TabControl();
            this.emptyShopCar = new DevComponents.DotNetBar.ButtonX();
            this.alipay = new DevComponents.DotNetBar.ButtonX();
            this.weixinPay = new DevComponents.DotNetBar.ButtonX();
            this.submitOrder = new DevComponents.DotNetBar.ButtonX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.dgvShopcar = new System.Windows.Forms.DataGridView();
            this.btnAddGoods = new DevComponents.DotNetBar.ButtonX();
            this.textCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteGoodsBystoreAndGoodsId = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager();
            this.command1 = new DevComponents.DotNetBar.Command(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.storeShoppingcarId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isBulkCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabGoodscategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopcar)).BeginInit();
            this.dgvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.ribbonControl1);
            this.panelEx1.Controls.Add(this.tabGoodscategory);
            this.panelEx1.Controls.Add(this.emptyShopCar);
            this.panelEx1.Controls.Add(this.alipay);
            this.panelEx1.Controls.Add(this.weixinPay);
            this.panelEx1.Controls.Add(this.submitOrder);
            this.panelEx1.Controls.Add(this.lblTime);
            this.panelEx1.Controls.Add(this.dgvShopcar);
            this.panelEx1.Controls.Add(this.btnAddGoods);
            this.panelEx1.Controls.Add(this.textCode);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1090, 484);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.lblSumMoney);
            this.panelEx2.Controls.Add(this.lblSumCount);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Location = new System.Drawing.Point(32, 432);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(348, 40);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 9;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Location = new System.Drawing.Point(196, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(44, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "总价：";
            // 
            // lblSumMoney
            // 
            // 
            // 
            // 
            this.lblSumMoney.BackgroundStyle.Class = "";
            this.lblSumMoney.Location = new System.Drawing.Point(250, 8);
            this.lblSumMoney.Name = "lblSumMoney";
            this.lblSumMoney.Size = new System.Drawing.Size(95, 23);
            this.lblSumMoney.TabIndex = 10;
            this.lblSumMoney.Text = "0";
            // 
            // lblSumCount
            // 
            // 
            // 
            // 
            this.lblSumCount.BackgroundStyle.Class = "";
            this.lblSumCount.Location = new System.Drawing.Point(73, 8);
            this.lblSumCount.Name = "lblSumCount";
            this.lblSumCount.Size = new System.Drawing.Size(100, 23);
            this.lblSumCount.TabIndex = 10;
            this.lblSumCount.Text = "0";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Location = new System.Drawing.Point(15, 8);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(49, 23);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "总数：";
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.Size = new System.Drawing.Size(1090, 24);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 7;
            // 
            // tabGoodscategory
            // 
            this.tabGoodscategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGoodscategory.BackColor = System.Drawing.Color.Transparent;
            this.tabGoodscategory.CanReorderTabs = true;
            this.tabGoodscategory.Location = new System.Drawing.Point(496, 96);
            this.tabGoodscategory.Name = "tabGoodscategory";
            this.tabGoodscategory.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabGoodscategory.SelectedTabIndex = -1;
            this.tabGoodscategory.Size = new System.Drawing.Size(582, 376);
            this.tabGoodscategory.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabGoodscategory.TabIndex = 6;
            this.tabGoodscategory.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabGoodscategory.Text = "tabControl1";
            // 
            // emptyShopCar
            // 
            this.emptyShopCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.emptyShopCar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.emptyShopCar.BackColor = System.Drawing.Color.Transparent;
            this.emptyShopCar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.emptyShopCar.Location = new System.Drawing.Point(398, 354);
            this.emptyShopCar.Name = "emptyShopCar";
            this.emptyShopCar.Size = new System.Drawing.Size(73, 58);
            this.emptyShopCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.emptyShopCar.TabIndex = 5;
            this.emptyShopCar.Text = "清空购物车";
            this.emptyShopCar.Click += new System.EventHandler(this.emptyShopCar_Click);
            // 
            // alipay
            // 
            this.alipay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.alipay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alipay.BackColor = System.Drawing.Color.Transparent;
            this.alipay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.alipay.Location = new System.Drawing.Point(398, 267);
            this.alipay.Name = "alipay";
            this.alipay.Size = new System.Drawing.Size(73, 58);
            this.alipay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.alipay.TabIndex = 5;
            this.alipay.Text = "支付宝支付";
            this.alipay.Click += new System.EventHandler(this.alipay_Click);
            // 
            // weixinPay
            // 
            this.weixinPay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.weixinPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.weixinPay.BackColor = System.Drawing.Color.Transparent;
            this.weixinPay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.weixinPay.Location = new System.Drawing.Point(398, 183);
            this.weixinPay.Name = "weixinPay";
            this.weixinPay.Size = new System.Drawing.Size(73, 58);
            this.weixinPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.weixinPay.TabIndex = 5;
            this.weixinPay.Text = "微信支付";
            this.weixinPay.Click += new System.EventHandler(this.weixinPay_Click);
            // 
            // submitOrder
            // 
            this.submitOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.submitOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.submitOrder.BackColor = System.Drawing.Color.Transparent;
            this.submitOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.submitOrder.Location = new System.Drawing.Point(398, 96);
            this.submitOrder.Name = "submitOrder";
            this.submitOrder.Size = new System.Drawing.Size(73, 58);
            this.submitOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.submitOrder.TabIndex = 5;
            this.submitOrder.Text = "结算";
            this.submitOrder.Click += new System.EventHandler(this.submitOrder_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.Class = "";
            this.lblTime.Location = new System.Drawing.Point(867, 56);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(211, 23);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "这里显示时间";
            // 
            // dgvShopcar
            // 
            this.dgvShopcar.AllowUserToAddRows = false;
            this.dgvShopcar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShopcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopcar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.storeShoppingcarId,
            this.goodsName,
            this.num,
            this.oneMoney,
            this.sumMoney,
            this.isBulkCargo});
            this.dgvShopcar.Location = new System.Drawing.Point(32, 96);
            this.dgvShopcar.MultiSelect = false;
            this.dgvShopcar.Name = "dgvShopcar";
            this.dgvShopcar.RowHeadersVisible = false;
            this.dgvShopcar.RowTemplate.Height = 23;
            this.dgvShopcar.Size = new System.Drawing.Size(348, 324);
            this.dgvShopcar.TabIndex = 2;
            this.dgvShopcar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShopcar_CellMouseClick);
            // 
            // btnAddGoods
            // 
            this.btnAddGoods.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddGoods.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddGoods.Location = new System.Drawing.Point(228, 56);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(74, 23);
            this.btnAddGoods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddGoods.TabIndex = 1;
            this.btnAddGoods.Text = "确定";
            this.btnAddGoods.Click += new System.EventHandler(this.btnAddGoods_Click);
            // 
            // textCode
            // 
            // 
            // 
            // 
            this.textCode.Border.Class = "TextBoxBorder";
            this.textCode.Location = new System.Drawing.Point(32, 56);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(173, 21);
            this.textCode.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvMenu
            // 
            this.dgvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteGoodsBystoreAndGoodsId});
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.Size = new System.Drawing.Size(137, 26);
            // 
            // deleteGoodsBystoreAndGoodsId
            // 
            this.deleteGoodsBystoreAndGoodsId.Name = "deleteGoodsBystoreAndGoodsId";
            this.deleteGoodsBystoreAndGoodsId.Size = new System.Drawing.Size(136, 22);
            this.deleteGoodsBystoreAndGoodsId.Text = "删除此商品";
            this.deleteGoodsBystoreAndGoodsId.Click += new System.EventHandler(this.deleteGoodsBystoreAndGoodsId_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // storeShoppingcarId
            // 
            this.storeShoppingcarId.HeaderText = "购物车ID";
            this.storeShoppingcarId.Name = "storeShoppingcarId";
            this.storeShoppingcarId.Visible = false;
            // 
            // goodsName
            // 
            this.goodsName.HeaderText = "商品名称";
            this.goodsName.Name = "goodsName";
            this.goodsName.Width = 150;
            // 
            // num
            // 
            this.num.HeaderText = "数量/重量";
            this.num.Name = "num";
            this.num.Width = 70;
            // 
            // oneMoney
            // 
            this.oneMoney.HeaderText = "单价";
            this.oneMoney.Name = "oneMoney";
            this.oneMoney.Width = 70;
            // 
            // sumMoney
            // 
            this.sumMoney.HeaderText = "小计";
            this.sumMoney.Name = "sumMoney";
            this.sumMoney.Width = 55;
            // 
            // isBulkCargo
            // 
            this.isBulkCargo.HeaderText = "是否散货";
            this.isBulkCargo.Name = "isBulkCargo";
            this.isBulkCargo.Visible = false;
            // 
            // frmScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 484);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScanCode";
            this.Text = "收银 -- 主界面 -- 点单收银";
            this.Activated += new System.EventHandler(this.frmScanCode_Activated);
            this.Load += new System.EventHandler(this.frmScanCode_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabGoodscategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopcar)).EndInit();
            this.dgvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnAddGoods;
        private DevComponents.DotNetBar.Controls.TextBoxX textCode;
        private System.Windows.Forms.DataGridView dgvShopcar;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.LabelX lblTime;
        private DevComponents.DotNetBar.ButtonX submitOrder;
        private DevComponents.DotNetBar.ButtonX alipay;
        private DevComponents.DotNetBar.ButtonX weixinPay;
        private DevComponents.DotNetBar.ButtonX emptyShopCar;
        private DevComponents.DotNetBar.TabControl tabGoodscategory;
        private System.Windows.Forms.ContextMenuStrip dgvMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteGoodsBystoreAndGoodsId;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblSumMoney;
        private DevComponents.DotNetBar.LabelX lblSumCount;
        private DevComponents.DotNetBar.Command command1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeShoppingcarId;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn isBulkCargo;
    }
}