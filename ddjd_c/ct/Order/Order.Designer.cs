namespace ddjd_c.ct.Order
{
    partial class frmOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnDetail = new DevComponents.DotNetBar.ButtonX();
            this.btnDeliverGoods = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dtEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnShowAllOrder = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnSeatchOrder = new DevComponents.DotNetBar.ButtonX();
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
            this.dgvOrderInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderOriginalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnPrint);
            this.panelEx1.Controls.Add(this.btnDetail);
            this.panelEx1.Controls.Add(this.btnDeliverGoods);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(817, 110);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(3, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 47);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDetail.Location = new System.Drawing.Point(3, 4);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 49);
            this.btnDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "订单详情";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnDeliverGoods
            // 
            this.btnDeliverGoods.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeliverGoods.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeliverGoods.Location = new System.Drawing.Point(84, 5);
            this.btnDeliverGoods.Name = "btnDeliverGoods";
            this.btnDeliverGoods.Size = new System.Drawing.Size(70, 102);
            this.btnDeliverGoods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeliverGoods.TabIndex = 2;
            this.btnDeliverGoods.Text = "发货";
            this.btnDeliverGoods.Click += new System.EventHandler(this.btnDeliverGoods_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dtEndTime);
            this.panelEx2.Controls.Add(this.dtStartTime);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.btnShowAllOrder);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.btnSeatchOrder);
            this.panelEx2.Location = new System.Drawing.Point(275, 3);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(539, 104);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            // 
            // dtEndTime
            // 
            // 
            // 
            // 
            this.dtEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEndTime.ButtonDropDown.Visible = true;
            this.dtEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtEndTime.Location = new System.Drawing.Point(268, 7);
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtEndTime.MonthCalendar.BackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.dtEndTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtEndTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtEndTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(116, 21);
            this.dtEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEndTime.TabIndex = 3;
            // 
            // dtStartTime
            // 
            // 
            // 
            // 
            this.dtStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStartTime.ButtonDropDown.Visible = true;
            this.dtStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtStartTime.Location = new System.Drawing.Point(71, 7);
            // 
            // 
            // 
            this.dtStartTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStartTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtStartTime.MonthCalendar.BackgroundStyle.Class = "";
            this.dtStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStartTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.dtStartTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtStartTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStartTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtStartTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(116, 21);
            this.dtStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStartTime.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(200, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(62, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "结束时间:";
            // 
            // btnShowAllOrder
            // 
            this.btnShowAllOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowAllOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowAllOrder.Location = new System.Drawing.Point(196, 78);
            this.btnShowAllOrder.Name = "btnShowAllOrder";
            this.btnShowAllOrder.Size = new System.Drawing.Size(75, 23);
            this.btnShowAllOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowAllOrder.TabIndex = 2;
            this.btnShowAllOrder.Text = "显示全部";
            this.btnShowAllOrder.Click += new System.EventHandler(this.btnShowAllOrder_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(3, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(62, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "开始时间:";
            // 
            // btnSeatchOrder
            // 
            this.btnSeatchOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeatchOrder.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSeatchOrder.Location = new System.Drawing.Point(112, 78);
            this.btnSeatchOrder.Name = "btnSeatchOrder";
            this.btnSeatchOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSeatchOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSeatchOrder.TabIndex = 2;
            this.btnSeatchOrder.Text = "搜索";
            this.btnSeatchOrder.Click += new System.EventHandler(this.btnSeatchOrder_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.bar1.Location = new System.Drawing.Point(0, 110);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(817, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnHomePage
            // 
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Text = "首页";
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Text = "上一页";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnEndPage
            // 
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Text = "尾页";
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
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
            // dgvOrderInfo
            // 
            this.dgvOrderInfo.AllowUserToAddRows = false;
            this.dgvOrderInfo.AllowUserToDeleteRows = false;
            this.dgvOrderInfo.AllowUserToOrderColumns = true;
            this.dgvOrderInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderId,
            this.orderPrice,
            this.orderOriginalPrice,
            this.addTime});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderInfo.MultiSelect = false;
            this.dgvOrderInfo.Name = "dgvOrderInfo";
            this.dgvOrderInfo.ReadOnly = true;
            this.dgvOrderInfo.RowTemplate.Height = 23;
            this.dgvOrderInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderInfo.Size = new System.Drawing.Size(817, 318);
            this.dgvOrderInfo.TabIndex = 2;
            this.dgvOrderInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderInfo_CellDoubleClick);
            // 
            // orderId
            // 
            this.orderId.DataPropertyName = "orderId";
            this.orderId.HeaderText = "订单ID";
            this.orderId.Name = "orderId";
            this.orderId.ReadOnly = true;
            this.orderId.Visible = false;
            // 
            // orderPrice
            // 
            this.orderPrice.DataPropertyName = "orderPrice";
            this.orderPrice.HeaderText = "订单价格";
            this.orderPrice.Name = "orderPrice";
            this.orderPrice.ReadOnly = true;
            // 
            // orderOriginalPrice
            // 
            this.orderOriginalPrice.DataPropertyName = "orderOriginalPrice";
            this.orderOriginalPrice.HeaderText = "订单原价";
            this.orderOriginalPrice.Name = "orderOriginalPrice";
            this.orderOriginalPrice.ReadOnly = true;
            // 
            // addTime
            // 
            this.addTime.DataPropertyName = "addTime";
            this.addTime.HeaderText = "下单时间";
            this.addTime.Name = "addTime";
            this.addTime.ReadOnly = true;
            this.addTime.Width = 200;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.dgvOrderInfo);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 138);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(817, 318);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 3;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 456);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmOrder";
            this.Text = "订单管理";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnDeliverGoods;
        private DevComponents.DotNetBar.ButtonX btnShowAllOrder;
        private DevComponents.DotNetBar.ButtonX btnSeatchOrder;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnDetail;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnHomePage;
        private DevComponents.DotNetBar.ButtonItem btnPreviousPage;
        private DevComponents.DotNetBar.ButtonItem btnNextPage;
        private DevComponents.DotNetBar.ButtonItem btnEndPage;
        private DevComponents.DotNetBar.LabelItem labitem123;
        private DevComponents.DotNetBar.LabelItem lblCount;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ComboBoxItem cmbSelect;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvOrderInfo;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderOriginalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn addTime;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEndTime;
    }
}