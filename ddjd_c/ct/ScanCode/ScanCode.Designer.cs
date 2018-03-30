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
            this.tabGoodscategory = new DevComponents.DotNetBar.TabControl();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.dgvShopcar = new System.Windows.Forms.DataGridView();
            this.goodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabGoodscategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopcar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tabGoodscategory);
            this.panelEx1.Controls.Add(this.buttonX5);
            this.panelEx1.Controls.Add(this.buttonX4);
            this.panelEx1.Controls.Add(this.buttonX3);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.lblTime);
            this.panelEx1.Controls.Add(this.dgvShopcar);
            this.panelEx1.Controls.Add(this.buttonX1);
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
            // tabGoodscategory
            // 
            this.tabGoodscategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGoodscategory.BackColor = System.Drawing.Color.Transparent;
            this.tabGoodscategory.CanReorderTabs = true;
            this.tabGoodscategory.Location = new System.Drawing.Point(487, 63);
            this.tabGoodscategory.Name = "tabGoodscategory";
            this.tabGoodscategory.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabGoodscategory.SelectedTabIndex = -1;
            this.tabGoodscategory.Size = new System.Drawing.Size(579, 376);
            this.tabGoodscategory.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabGoodscategory.TabIndex = 6;
            this.tabGoodscategory.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabGoodscategory.Text = "tabControl1";
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.BackColor = System.Drawing.Color.Transparent;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(342, 344);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(102, 58);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 5;
            this.buttonX5.Text = "清空购物车";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.BackColor = System.Drawing.Color.Transparent;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(342, 254);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(102, 58);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 5;
            this.buttonX4.Text = "支付宝支付";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.BackColor = System.Drawing.Color.Transparent;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(342, 161);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(102, 58);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "微信支付";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.Transparent;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(342, 63);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(102, 58);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 5;
            this.buttonX2.Text = "结算";
            // 
            // lblTime
            // 
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.Class = "";
            this.lblTime.Location = new System.Drawing.Point(342, 11);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(211, 23);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "这里显示时间";
            // 
            // dgvShopcar
            // 
            this.dgvShopcar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvShopcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShopcar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodsName,
            this.num,
            this.sumMoney});
            this.dgvShopcar.Location = new System.Drawing.Point(32, 63);
            this.dgvShopcar.MultiSelect = false;
            this.dgvShopcar.Name = "dgvShopcar";
            this.dgvShopcar.RowHeadersVisible = false;
            this.dgvShopcar.RowTemplate.Height = 23;
            this.dgvShopcar.Size = new System.Drawing.Size(271, 376);
            this.dgvShopcar.TabIndex = 2;
            // 
            // goodsName
            // 
            this.goodsName.HeaderText = "商品名称";
            this.goodsName.Name = "goodsName";
            // 
            // num
            // 
            this.num.HeaderText = "数量/重量";
            this.num.Name = "num";
            this.num.Width = 70;
            // 
            // sumMoney
            // 
            this.sumMoney.HeaderText = "小计";
            this.sumMoney.Name = "sumMoney";
            this.sumMoney.Width = 55;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(228, 10);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "确定";
            // 
            // textCode
            // 
            // 
            // 
            // 
            this.textCode.Border.Class = "TextBoxBorder";
            this.textCode.Location = new System.Drawing.Point(32, 13);
            this.textCode.Name = "textCode";
            this.textCode.Size = new System.Drawing.Size(173, 21);
            this.textCode.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmScanCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 484);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScanCode";
            this.Text = "收银管理";
            this.Load += new System.EventHandler(this.frmScanCode_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabGoodscategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShopcar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textCode;
        private System.Windows.Forms.DataGridView dgvShopcar;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoney;
        private System.Windows.Forms.Timer timer1;
        private DevComponents.DotNetBar.LabelX lblTime;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.TabControl tabGoodscategory;
    }
}