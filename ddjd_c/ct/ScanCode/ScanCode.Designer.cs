﻿namespace ddjd_c.ct.ScanCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnHomePage = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreviousPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNextPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnEndPage = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labitem123 = new DevComponents.DotNetBar.LabelItem();
            this.lblCount = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.cmbSelect = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.btnDeleteOneGoods = new DevComponents.DotNetBar.ButtonX();
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
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
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
            this.btnGetGuadan = new DevComponents.DotNetBar.ButtonX();
            this.btnGuadan = new DevComponents.DotNetBar.ButtonX();
            this.storeShoppingcarId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isBulkCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
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
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.Controls.Add(this.btnDeleteOneGoods);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.ribbonControl1);
            this.panelEx1.Controls.Add(this.tabGoodscategory);
            this.panelEx1.Controls.Add(this.emptyShopCar);
            this.panelEx1.Controls.Add(this.alipay);
            this.panelEx1.Controls.Add(this.weixinPay);
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Controls.Add(this.btnGuadan);
            this.panelEx1.Controls.Add(this.btnGetGuadan);
            this.panelEx1.Controls.Add(this.submitOrder);
            this.panelEx1.Controls.Add(this.lblTime);
            this.panelEx1.Controls.Add(this.dgvShopcar);
            this.panelEx1.Controls.Add(this.btnAddGoods);
            this.panelEx1.Controls.Add(this.textCode);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1085, 595);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panelEx3
            // 
            this.panelEx3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.bar1);
            this.panelEx3.Location = new System.Drawing.Point(493, 543);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(582, 31);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 12;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnHomePage,
            this.btnPreviousPage,
            this.btnNextPage,
            this.btnEndPage,
            this.labelItem4,
            this.labitem123,
            this.lblCount,
            this.labelItem1,
            this.labelItem2,
            this.buttonItem5,
            this.cmbSelect,
            this.labelItem3});
            this.bar1.Location = new System.Drawing.Point(-1, -1);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(583, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 11;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnHomePage
            // 
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Text = "首页";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Text = "上一页";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Text = "下一页";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Text = "尾页";
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = " | ";
            // 
            // labitem123
            // 
            this.labitem123.Name = "labitem123";
            this.labitem123.Text = "共有记录";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = " ** ";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "条";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = " | ";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "每页显示";
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownHeight = 106;
            this.cmbSelect.ItemHeight = 17;
            this.cmbSelect.Items.AddRange(new object[] {
            this.comboItem5,
            this.comboItem1,
            this.comboItem3,
            this.comboItem2,
            this.comboItem4});
            this.cmbSelect.Name = "cmbSelect";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "10";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "20";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "30";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "50";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "100";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "条";
            // 
            // btnDeleteOneGoods
            // 
            this.btnDeleteOneGoods.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteOneGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteOneGoods.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteOneGoods.Location = new System.Drawing.Point(401, 407);
            this.btnDeleteOneGoods.Name = "btnDeleteOneGoods";
            this.btnDeleteOneGoods.Size = new System.Drawing.Size(73, 58);
            this.btnDeleteOneGoods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteOneGoods.TabIndex = 10;
            this.btnDeleteOneGoods.Text = "删除此项";
            this.btnDeleteOneGoods.Click += new System.EventHandler(this.btnDeleteOneGoods_Click);
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
            this.panelEx2.Location = new System.Drawing.Point(32, 543);
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
            this.ribbonControl1.Size = new System.Drawing.Size(1085, 23);
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
            this.tabGoodscategory.Size = new System.Drawing.Size(577, 435);
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
            this.emptyShopCar.Location = new System.Drawing.Point(401, 461);
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
            this.alipay.Location = new System.Drawing.Point(401, 335);
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
            this.weixinPay.Location = new System.Drawing.Point(401, 280);
            this.weixinPay.Name = "weixinPay";
            this.weixinPay.Size = new System.Drawing.Size(73, 58);
            this.weixinPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.weixinPay.TabIndex = 5;
            this.weixinPay.Text = "微信支付";
            this.weixinPay.Click += new System.EventHandler(this.weixinPay_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(401, 533);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 49);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // submitOrder
            // 
            this.submitOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.submitOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.submitOrder.BackColor = System.Drawing.Color.Transparent;
            this.submitOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.submitOrder.Location = new System.Drawing.Point(401, 101);
            this.submitOrder.Name = "submitOrder";
            this.submitOrder.Size = new System.Drawing.Size(73, 50);
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
            this.lblTime.Location = new System.Drawing.Point(862, 56);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(211, 23);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "这里显示时间";
            // 
            // dgvShopcar
            // 
            this.dgvShopcar.AllowUserToAddRows = false;
            this.dgvShopcar.AllowUserToResizeColumns = false;
            this.dgvShopcar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShopcar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShopcar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvShopcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopcar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.storeShoppingcarId,
            this.goodsName,
            this.num,
            this.oneMoney,
            this.sumMoney,
            this.isBulkCargo});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShopcar.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvShopcar.Location = new System.Drawing.Point(32, 96);
            this.dgvShopcar.MultiSelect = false;
            this.dgvShopcar.Name = "dgvShopcar";
            this.dgvShopcar.ReadOnly = true;
            this.dgvShopcar.RowHeadersVisible = false;
            this.dgvShopcar.RowTemplate.Height = 23;
            this.dgvShopcar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShopcar.Size = new System.Drawing.Size(348, 435);
            this.dgvShopcar.TabIndex = 2;
            this.dgvShopcar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShopcar_CellMouseClick);
            // 
            // btnAddGoods
            // 
            this.btnAddGoods.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddGoods.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddGoods.Location = new System.Drawing.Point(303, 50);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(74, 34);
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
            this.textCode.Size = new System.Drawing.Size(253, 21);
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
            // btnGetGuadan
            // 
            this.btnGetGuadan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetGuadan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetGuadan.BackColor = System.Drawing.Color.Transparent;
            this.btnGetGuadan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetGuadan.Location = new System.Drawing.Point(401, 214);
            this.btnGetGuadan.Name = "btnGetGuadan";
            this.btnGetGuadan.Size = new System.Drawing.Size(73, 50);
            this.btnGetGuadan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetGuadan.TabIndex = 5;
            this.btnGetGuadan.Text = "取出挂单";
            this.btnGetGuadan.Click += new System.EventHandler(this.btnGetGuadan_Click);
            // 
            // btnGuadan
            // 
            this.btnGuadan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuadan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuadan.BackColor = System.Drawing.Color.Transparent;
            this.btnGuadan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuadan.Location = new System.Drawing.Point(401, 167);
            this.btnGuadan.Name = "btnGuadan";
            this.btnGuadan.Size = new System.Drawing.Size(73, 50);
            this.btnGuadan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuadan.TabIndex = 5;
            this.btnGuadan.Text = "挂单";
            this.btnGuadan.Click += new System.EventHandler(this.btnGuadan_Click);
            // 
            // storeShoppingcarId
            // 
            this.storeShoppingcarId.HeaderText = "购物车ID";
            this.storeShoppingcarId.Name = "storeShoppingcarId";
            this.storeShoppingcarId.ReadOnly = true;
            this.storeShoppingcarId.Visible = false;
            // 
            // goodsName
            // 
            this.goodsName.HeaderText = "商品名称";
            this.goodsName.Name = "goodsName";
            this.goodsName.ReadOnly = true;
            this.goodsName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goodsName.Width = 150;
            // 
            // num
            // 
            this.num.HeaderText = "数量/重量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.num.Width = 70;
            // 
            // oneMoney
            // 
            this.oneMoney.HeaderText = "单价";
            this.oneMoney.Name = "oneMoney";
            this.oneMoney.ReadOnly = true;
            this.oneMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oneMoney.Width = 70;
            // 
            // sumMoney
            // 
            this.sumMoney.HeaderText = "小计";
            this.sumMoney.Name = "sumMoney";
            this.sumMoney.ReadOnly = true;
            this.sumMoney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sumMoney.Width = 55;
            // 
            // isBulkCargo
            // 
            this.isBulkCargo.HeaderText = "是否散货";
            this.isBulkCargo.Name = "isBulkCargo";
            this.isBulkCargo.ReadOnly = true;
            this.isBulkCargo.Visible = false;
            // 
            // frmScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 595);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScanCode";
            this.Text = "收银 -- 主界面 -- 点单收银";
            this.Activated += new System.EventHandler(this.frmScanCode_Activated);
            this.Load += new System.EventHandler(this.frmScanCode_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
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
        private DevComponents.DotNetBar.ButtonX btnDeleteOneGoods;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnHomePage;
        private DevComponents.DotNetBar.ButtonItem btnPreviousPage;
        private DevComponents.DotNetBar.ButtonItem btnNextPage;
        private DevComponents.DotNetBar.ButtonItem btnEndPage;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labitem123;
        private DevComponents.DotNetBar.LabelItem lblCount;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ComboBoxItem cmbSelect;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnGetGuadan;
        private DevComponents.DotNetBar.ButtonX btnGuadan;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeShoppingcarId;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn isBulkCargo;
    }
}