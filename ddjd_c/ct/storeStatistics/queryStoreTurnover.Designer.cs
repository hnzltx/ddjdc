namespace ddjd_c.ct.storeStatistics
{
    partial class frmQueryStoreTurnover
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbWeixin = new System.Windows.Forms.RadioButton();
            this.rbAli = new System.Windows.Forms.RadioButton();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
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
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dgvStoreStatistics = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.today = new DevComponents.DotNetBar.LabelX();
            this.month = new DevComponents.DotNetBar.LabelX();
            this.year = new DevComponents.DotNetBar.LabelX();
            this.sumPrice = new DevComponents.DotNetBar.LabelX();
            this.transferAccountsRecordAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferAccountsRecordPayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferAccountsRecordType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.dgvStoreStatistics);
            this.panelEx1.Controls.Add(this.bar1);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(911, 499);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(24, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "今日：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(465, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "今年：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(234, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(64, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "当月：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(691, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(91, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "总营业额：";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAll.Location = new System.Drawing.Point(34, 80);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(58, 20);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbWeixin
            // 
            this.rbWeixin.AutoSize = true;
            this.rbWeixin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbWeixin.Location = new System.Drawing.Point(178, 80);
            this.rbWeixin.Name = "rbWeixin";
            this.rbWeixin.Size = new System.Drawing.Size(90, 20);
            this.rbWeixin.TabIndex = 2;
            this.rbWeixin.Text = "微信转账";
            this.rbWeixin.UseVisualStyleBackColor = true;
            this.rbWeixin.CheckedChanged += new System.EventHandler(this.rbWeixin_CheckedChanged);
            // 
            // rbAli
            // 
            this.rbAli.AutoSize = true;
            this.rbAli.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAli.Location = new System.Drawing.Point(346, 80);
            this.rbAli.Name = "rbAli";
            this.rbAli.Size = new System.Drawing.Size(106, 20);
            this.rbAli.TabIndex = 2;
            this.rbAli.Text = "支付宝转账";
            this.rbAli.UseVisualStyleBackColor = true;
            this.rbAli.CheckedChanged += new System.EventHandler(this.rbAli_CheckedChanged);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.sumPrice);
            this.panelEx2.Controls.Add(this.year);
            this.panelEx2.Controls.Add(this.month);
            this.panelEx2.Controls.Add(this.today);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.rbAll);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.rbWeixin);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.rbAli);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(911, 108);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
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
            this.bar1.Location = new System.Drawing.Point(0, 108);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(911, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
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
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(24, 51);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(171, 23);
            this.labelX5.TabIndex = 5;
            this.labelX5.Text = "以下为收入明细列表";
            // 
            // dgvStoreStatistics
            // 
            this.dgvStoreStatistics.AllowUserToAddRows = false;
            this.dgvStoreStatistics.AllowUserToDeleteRows = false;
            this.dgvStoreStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transferAccountsRecordAmount,
            this.transferAccountsRecordPayDate,
            this.transferAccountsRecordType});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStoreStatistics.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvStoreStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStoreStatistics.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStoreStatistics.Location = new System.Drawing.Point(0, 136);
            this.dgvStoreStatistics.MultiSelect = false;
            this.dgvStoreStatistics.Name = "dgvStoreStatistics";
            this.dgvStoreStatistics.ReadOnly = true;
            this.dgvStoreStatistics.RowTemplate.Height = 23;
            this.dgvStoreStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoreStatistics.Size = new System.Drawing.Size(911, 363);
            this.dgvStoreStatistics.TabIndex = 5;
            // 
            // today
            // 
            // 
            // 
            // 
            this.today.BackgroundStyle.Class = "";
            this.today.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.today.Location = new System.Drawing.Point(99, 12);
            this.today.Name = "today";
            this.today.Size = new System.Drawing.Size(111, 23);
            this.today.TabIndex = 6;
            this.today.Text = "today";
            // 
            // month
            // 
            // 
            // 
            // 
            this.month.BackgroundStyle.Class = "";
            this.month.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.month.Location = new System.Drawing.Point(318, 12);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(134, 23);
            this.month.TabIndex = 7;
            this.month.Text = "month";
            // 
            // year
            // 
            // 
            // 
            // 
            this.year.BackgroundStyle.Class = "";
            this.year.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.year.Location = new System.Drawing.Point(551, 12);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(124, 23);
            this.year.TabIndex = 7;
            this.year.Text = "year";
            // 
            // sumPrice
            // 
            // 
            // 
            // 
            this.sumPrice.BackgroundStyle.Class = "";
            this.sumPrice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sumPrice.Location = new System.Drawing.Point(799, 12);
            this.sumPrice.Name = "sumPrice";
            this.sumPrice.Size = new System.Drawing.Size(124, 23);
            this.sumPrice.TabIndex = 7;
            this.sumPrice.Text = "sumPrice";
            // 
            // transferAccountsRecordAmount
            // 
            this.transferAccountsRecordAmount.DataPropertyName = "transferAccountsRecordAmount";
            this.transferAccountsRecordAmount.HeaderText = "金额";
            this.transferAccountsRecordAmount.Name = "transferAccountsRecordAmount";
            this.transferAccountsRecordAmount.ReadOnly = true;
            this.transferAccountsRecordAmount.Width = 200;
            // 
            // transferAccountsRecordPayDate
            // 
            this.transferAccountsRecordPayDate.DataPropertyName = "transferAccountsRecordPayDate";
            this.transferAccountsRecordPayDate.HeaderText = "时间";
            this.transferAccountsRecordPayDate.Name = "transferAccountsRecordPayDate";
            this.transferAccountsRecordPayDate.ReadOnly = true;
            this.transferAccountsRecordPayDate.Width = 200;
            // 
            // transferAccountsRecordType
            // 
            this.transferAccountsRecordType.DataPropertyName = "transferAccountsRecordType";
            this.transferAccountsRecordType.HeaderText = "转账方式";
            this.transferAccountsRecordType.Name = "transferAccountsRecordType";
            this.transferAccountsRecordType.ReadOnly = true;
            this.transferAccountsRecordType.Width = 200;
            // 
            // frmQueryStoreTurnover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 499);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmQueryStoreTurnover";
            this.Text = "营业额与收入明细";
            this.Load += new System.EventHandler(this.frmQueryStoreTurnover_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.RadioButton rbAli;
        private System.Windows.Forms.RadioButton rbWeixin;
        private System.Windows.Forms.RadioButton rbAll;
        private DevComponents.DotNetBar.PanelEx panelEx2;
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
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvStoreStatistics;
        private DevComponents.DotNetBar.LabelX today;
        private DevComponents.DotNetBar.LabelX sumPrice;
        private DevComponents.DotNetBar.LabelX year;
        private DevComponents.DotNetBar.LabelX month;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferAccountsRecordAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferAccountsRecordPayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferAccountsRecordType;
    }
}