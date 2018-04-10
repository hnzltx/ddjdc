namespace ddjd_c.ct.good
{
    partial class goodManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(goodManagement));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tab = new DevComponents.DotNetBar.TabControl();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbx3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tab)).BeginInit();
            this.tab.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "labelX1";
            // 
            // tab
            // 
            this.tab.CanReorderTabs = true;
            this.tab.Controls.Add(this.tabControlPanel1);
            this.tab.Controls.Add(this.tabControlPanel2);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tab.SelectedTabIndex = 0;
            this.tab.Size = new System.Drawing.Size(800, 450);
            this.tab.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tab.TabIndex = 1;
            this.tab.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tab.Tabs.Add(this.tabItem1);
            this.tab.Tabs.Add(this.tabItem2);
            this.tab.Text = "tabControl1";
            this.tab.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tab_SelectedTabChanged);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "上架";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dataGridViewX1);
            this.tabControlPanel1.Controls.Add(this.buttonX1);
            this.tabControlPanel1.Controls.Add(this.cbx3);
            this.tabControlPanel1.Controls.Add(this.labelX5);
            this.tabControlPanel1.Controls.Add(this.cbx2);
            this.tabControlPanel1.Controls.Add(this.labelX4);
            this.tabControlPanel1.Controls.Add(this.cbx1);
            this.tabControlPanel1.Controls.Add(this.labelX3);
            this.tabControlPanel1.Controls.Add(this.btnSearch);
            this.tabControlPanel1.Controls.Add(this.txtSearch);
            this.tabControlPanel1.Controls.Add(this.labelX2);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(800, 425);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel1;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "下架";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(800, 425);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(16, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "商品搜索:";
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Location = new System.Drawing.Point(70, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(141, 21);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(217, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Location = new System.Drawing.Point(16, 56);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "1级分类:";
            // 
            // cbx1
            // 
            this.cbx1.DisplayMember = "Text";
            this.cbx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx1.FormattingEnabled = true;
            this.cbx1.ItemHeight = 15;
            this.cbx1.Location = new System.Drawing.Point(70, 56);
            this.cbx1.Name = "cbx1";
            this.cbx1.Size = new System.Drawing.Size(141, 21);
            this.cbx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbx1.TabIndex = 4;
            this.cbx1.SelectedIndexChanged += new System.EventHandler(this.cbx1_SelectedIndexChanged);
            // 
            // cbx2
            // 
            this.cbx2.DisplayMember = "Text";
            this.cbx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx2.FormattingEnabled = true;
            this.cbx2.ItemHeight = 15;
            this.cbx2.Location = new System.Drawing.Point(271, 56);
            this.cbx2.Name = "cbx2";
            this.cbx2.Size = new System.Drawing.Size(141, 21);
            this.cbx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbx2.TabIndex = 6;
            this.cbx2.SelectedIndexChanged += new System.EventHandler(this.cbx2_SelectedIndexChanged);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Location = new System.Drawing.Point(217, 56);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "2级分类:";
            // 
            // cbx3
            // 
            this.cbx3.DisplayMember = "Text";
            this.cbx3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx3.FormattingEnabled = true;
            this.cbx3.ItemHeight = 15;
            this.cbx3.Location = new System.Drawing.Point(472, 56);
            this.cbx3.Name = "cbx3";
            this.cbx3.Size = new System.Drawing.Size(141, 21);
            this.cbx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbx3.TabIndex = 8;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.Location = new System.Drawing.Point(418, 56);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "3级分类:";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(619, 56);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "筛选";
            this.buttonX1.Click += new System.EventHandler(this.btnScreening_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(16, 85);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(762, 328);
            this.dataGridViewX1.TabIndex = 10;
            this.dataGridViewX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellDoubleClick);
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // name
            // 
            this.name.DataPropertyName = "GoodsName";
            this.name.HeaderText = "商品名称";
            this.name.Name = "name";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "StoreGoodsPrice";
            this.Column2.HeaderText = "商品零售价";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SalesCount";
            this.Column3.HeaderText = "销量";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GoodsUnit";
            this.Column4.HeaderText = "单位";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Stock";
            this.Column5.HeaderText = "库存";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "操作";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // goodManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.labelX1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "goodManagement";
            this.Text = "商品管理";
            this.Load += new System.EventHandler(this.goodManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tab)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.TabControl tab;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbx3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbx2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbx1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column6;
    }
}