namespace ddjd_c
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.pbKey = new System.Windows.Forms.PictureBox();
            this.cbPs = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cancel = new DevComponents.DotNetBar.ButtonX();
            this.loginClick = new DevComponents.DotNetBar.ButtonX();
            this.userPossword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.userAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.pbKey);
            this.panelEx1.Controls.Add(this.cbPs);
            this.panelEx1.Controls.Add(this.cancel);
            this.panelEx1.Controls.Add(this.loginClick);
            this.panelEx1.Controls.Add(this.userPossword);
            this.panelEx1.Controls.Add(this.userAccount);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.pictureBox2);
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(809, 444);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // pbKey
            // 
            this.pbKey.Image = global::ddjd_c.Properties.Resources.键盘;
            this.pbKey.Location = new System.Drawing.Point(578, 196);
            this.pbKey.Name = "pbKey";
            this.pbKey.Size = new System.Drawing.Size(150, 96);
            this.pbKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKey.TabIndex = 7;
            this.pbKey.TabStop = false;
            this.pbKey.Click += new System.EventHandler(this.pbAccount_Click);
            // 
            // cbPs
            // 
            // 
            // 
            // 
            this.cbPs.BackgroundStyle.Class = "";
            this.cbPs.Location = new System.Drawing.Point(378, 318);
            this.cbPs.Name = "cbPs";
            this.cbPs.Size = new System.Drawing.Size(100, 23);
            this.cbPs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPs.TabIndex = 6;
            this.cbPs.Text = "记住密码";
            // 
            // cancel
            // 
            this.cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel.Location = new System.Drawing.Point(440, 370);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(103, 33);
            this.cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // loginClick
            // 
            this.loginClick.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.loginClick.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.loginClick.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginClick.Location = new System.Drawing.Point(297, 370);
            this.loginClick.Name = "loginClick";
            this.loginClick.Size = new System.Drawing.Size(103, 33);
            this.loginClick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.loginClick.TabIndex = 2;
            this.loginClick.Text = "登录";
            this.loginClick.Click += new System.EventHandler(this.loginClick_Click);
            // 
            // userPossword
            // 
            // 
            // 
            // 
            this.userPossword.Border.Class = "TextBoxBorder";
            this.userPossword.Location = new System.Drawing.Point(378, 271);
            this.userPossword.Multiline = true;
            this.userPossword.Name = "userPossword";
            this.userPossword.PasswordChar = '*';
            this.userPossword.Size = new System.Drawing.Size(165, 22);
            this.userPossword.TabIndex = 1;
            // 
            // userAccount
            // 
            // 
            // 
            // 
            this.userAccount.Border.Class = "TextBoxBorder";
            this.userAccount.Location = new System.Drawing.Point(378, 203);
            this.userAccount.Multiline = true;
            this.userAccount.Name = "userAccount";
            this.userAccount.Size = new System.Drawing.Size(165, 22);
            this.userAccount.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(297, 274);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "密码：";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(297, 206);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "账号：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ddjd_c.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(40, 196);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 145);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ddjd_c.Properties.Resources.c;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(809, 444);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点单相邻收银管理系统";
            this.Load += new System.EventHandler(this.login_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.Controls.TextBoxX userPossword;
        private DevComponents.DotNetBar.Controls.TextBoxX userAccount;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX cancel;
        private DevComponents.DotNetBar.ButtonX loginClick;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbPs;
        private System.Windows.Forms.PictureBox pbKey;
    }
}

