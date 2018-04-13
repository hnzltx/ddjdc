namespace ddjd_c.ct.Set
{
    partial class frmSetPrint
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbLptName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbLineCount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.btnSetPrint = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cbOpenQX = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(33, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "打印机端口：";
            // 
            // cbLptName
            // 
            this.cbLptName.DisplayMember = "Text";
            this.cbLptName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLptName.FormattingEnabled = true;
            this.cbLptName.ItemHeight = 15;
            this.cbLptName.Items.AddRange(new object[] {
            this.comboItem6});
            this.cbLptName.Location = new System.Drawing.Point(138, 40);
            this.cbLptName.Name = "cbLptName";
            this.cbLptName.Size = new System.Drawing.Size(96, 21);
            this.cbLptName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbLptName.TabIndex = 1;
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "LPT1";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(33, 95);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(99, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "底部换几行：";
            // 
            // cbLineCount
            // 
            this.cbLineCount.DisplayMember = "Text";
            this.cbLineCount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLineCount.FormattingEnabled = true;
            this.cbLineCount.ItemHeight = 15;
            this.cbLineCount.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5});
            this.cbLineCount.Location = new System.Drawing.Point(138, 95);
            this.cbLineCount.Name = "cbLineCount";
            this.cbLineCount.Size = new System.Drawing.Size(96, 21);
            this.cbLineCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbLineCount.TabIndex = 1;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "4";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "5";
            // 
            // btnSetPrint
            // 
            this.btnSetPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetPrint.Location = new System.Drawing.Point(33, 222);
            this.btnSetPrint.Name = "btnSetPrint";
            this.btnSetPrint.Size = new System.Drawing.Size(82, 35);
            this.btnSetPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetPrint.TabIndex = 2;
            this.btnSetPrint.Text = "保存";
            this.btnSetPrint.Click += new System.EventHandler(this.btnSetPrint_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cbOpenQX);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.btnSetPrint);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.cbLineCount);
            this.panelEx1.Controls.Add(this.cbLptName);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(634, 368);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // cbOpenQX
            // 
            this.cbOpenQX.AutoSize = true;
            this.cbOpenQX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOpenQX.Location = new System.Drawing.Point(33, 149);
            this.cbOpenQX.Name = "cbOpenQX";
            this.cbOpenQX.Size = new System.Drawing.Size(192, 16);
            this.cbOpenQX.TabIndex = 3;
            this.cbOpenQX.Text = "是否每次打印小票都弹出钱箱？";
            this.cbOpenQX.UseVisualStyleBackColor = true;
            // 
            // frmSetPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 368);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmSetPrint";
            this.Text = "打印机设置";
            this.Load += new System.EventHandler(this.frmSetPrint_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLptName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbLineCount;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.ButtonX btnSetPrint;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.CheckBox cbOpenQX;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}