namespace ddjd_c.ct
{
    partial class frmTest
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.text2 = new System.Windows.Forms.TextBox();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnHomePage = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreviousPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNextPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnEndPage = new DevComponents.DotNetBar.ButtonItem();
            this.cmbInputNum = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnGoPage = new DevComponents.DotNetBar.ButtonItem();
            this.labitem123 = new DevComponents.DotNetBar.LabelItem();
            this.lblCount = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.cmbSelect = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 121);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 218);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "安装";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(444, 121);
            this.text2.Multiline = true;
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(266, 218);
            this.text2.TabIndex = 2;
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
            this.cmbInputNum,
            this.btnGoPage,
            this.labitem123,
            this.lblCount,
            this.labelItem1,
            this.labelItem2,
            this.buttonItem5,
            this.cmbSelect,
            this.labelItem3});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(779, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
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
            // cmbInputNum
            // 
            this.cmbInputNum.DropDownHeight = 106;
            this.cmbInputNum.ItemHeight = 17;
            this.cmbInputNum.Name = "cmbInputNum";
            // 
            // btnGoPage
            // 
            this.btnGoPage.Name = "btnGoPage";
            this.btnGoPage.Text = "GO";
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
            this.comboItem1,
            this.comboItem3,
            this.comboItem2,
            this.comboItem4});
            this.cmbSelect.Name = "cmbSelect";
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
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 380);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmTest";
            this.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnHomePage;
        private DevComponents.DotNetBar.ButtonItem btnPreviousPage;
        private DevComponents.DotNetBar.ButtonItem btnNextPage;
        private DevComponents.DotNetBar.ButtonItem btnEndPage;
        private DevComponents.DotNetBar.ComboBoxItem cmbInputNum;
        private DevComponents.DotNetBar.ButtonItem btnGoPage;
        private DevComponents.DotNetBar.LabelItem labitem123;
        private DevComponents.DotNetBar.LabelItem lblCount;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ComboBoxItem cmbSelect;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelItem labelItem3;
    }
}