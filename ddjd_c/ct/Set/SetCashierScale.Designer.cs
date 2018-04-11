namespace ddjd_c.ct.Set
{
    partial class frmSetCashierScale
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbPortList = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbBaudRate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.btnSetCashierScale = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbDataBits = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbParity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmbStopBits = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnSetCashierScale);
            this.panelEx1.Controls.Add(this.cmbStopBits);
            this.panelEx1.Controls.Add(this.cmbParity);
            this.panelEx1.Controls.Add(this.cmbBaudRate);
            this.panelEx1.Controls.Add(this.cmbDataBits);
            this.panelEx1.Controls.Add(this.cmbPortList);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(680, 393);
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
            this.labelX1.Location = new System.Drawing.Point(26, 44);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "端口号：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(26, 103);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "波特率：";
            // 
            // cmbPortList
            // 
            this.cmbPortList.DisplayMember = "Text";
            this.cmbPortList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.ItemHeight = 15;
            this.cmbPortList.Location = new System.Drawing.Point(108, 44);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(121, 21);
            this.cmbPortList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPortList.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DisplayMember = "Text";
            this.cmbBaudRate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.ItemHeight = 15;
            this.cmbBaudRate.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cmbBaudRate.Location = new System.Drawing.Point(108, 103);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbBaudRate.TabIndex = 1;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "9600";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "19200";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "38400";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "57600";
            // 
            // btnSetCashierScale
            // 
            this.btnSetCashierScale.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetCashierScale.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetCashierScale.Location = new System.Drawing.Point(26, 224);
            this.btnSetCashierScale.Name = "btnSetCashierScale";
            this.btnSetCashierScale.Size = new System.Drawing.Size(115, 39);
            this.btnSetCashierScale.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetCashierScale.TabIndex = 0;
            this.btnSetCashierScale.Text = "保存";
            this.btnSetCashierScale.Click += new System.EventHandler(this.btnSetCashierScale_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Location = new System.Drawing.Point(323, 44);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "数据位：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Location = new System.Drawing.Point(323, 103);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "校验位：";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.DisplayMember = "Text";
            this.cmbDataBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.ItemHeight = 15;
            this.cmbDataBits.Items.AddRange(new object[] {
            this.comboItem12,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11});
            this.cmbDataBits.Location = new System.Drawing.Point(405, 44);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cmbDataBits.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbDataBits.TabIndex = 1;
            // 
            // cmbParity
            // 
            this.cmbParity.DisplayMember = "Text";
            this.cmbParity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.ItemHeight = 15;
            this.cmbParity.Items.AddRange(new object[] {
            this.comboItem13,
            this.comboItem5});
            this.cmbParity.Location = new System.Drawing.Point(405, 103);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(121, 21);
            this.cmbParity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParity.TabIndex = 1;
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "5";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "6";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "7";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "8";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "None";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.Location = new System.Drawing.Point(26, 158);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "停止位：";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DisplayMember = "Text";
            this.cmbStopBits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.ItemHeight = 15;
            this.cmbStopBits.Items.AddRange(new object[] {
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.cmbStopBits.Location = new System.Drawing.Point(108, 158);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cmbStopBits.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbStopBits.TabIndex = 1;
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "1";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "1.5";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "2";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "Even";
            // 
            // frmSetCashierScale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 393);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmSetCashierScale";
            this.Text = "收银秤设置";
            this.Load += new System.EventHandler(this.frmSetCashierScale_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbBaudRate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPortList;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.ButtonX btnSetCashierScale;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbParity;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbDataBits;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbStopBits;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem5;
    }
}