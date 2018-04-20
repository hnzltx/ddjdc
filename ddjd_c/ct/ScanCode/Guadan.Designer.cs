namespace ddjd_c.ct.ScanCode
{
    partial class frmGuadan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteGuadanNumber = new DevComponents.DotNetBar.ButtonX();
            this.btnGet = new DevComponents.DotNetBar.ButtonX();
            this.dgvGuadanDetail = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAllGuadan = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.guadanNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuadanDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllGuadan)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Controls.Add(this.btnDeleteGuadanNumber);
            this.panelEx1.Controls.Add(this.btnGet);
            this.panelEx1.Controls.Add(this.dgvGuadanDetail);
            this.panelEx1.Controls.Add(this.dgvAllGuadan);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(668, 485);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(565, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 49);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteGuadanNumber
            // 
            this.btnDeleteGuadanNumber.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteGuadanNumber.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteGuadanNumber.Location = new System.Drawing.Point(441, 419);
            this.btnDeleteGuadanNumber.Name = "btnDeleteGuadanNumber";
            this.btnDeleteGuadanNumber.Size = new System.Drawing.Size(90, 49);
            this.btnDeleteGuadanNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteGuadanNumber.TabIndex = 3;
            this.btnDeleteGuadanNumber.Text = "删除此挂单";
            this.btnDeleteGuadanNumber.Click += new System.EventHandler(this.btnDeleteGuadanNumber_Click);
            // 
            // btnGet
            // 
            this.btnGet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGet.Location = new System.Drawing.Point(312, 419);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(90, 49);
            this.btnGet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "取出";
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dgvGuadanDetail
            // 
            this.dgvGuadanDetail.AllowUserToAddRows = false;
            this.dgvGuadanDetail.AllowUserToDeleteRows = false;
            this.dgvGuadanDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuadanDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvGuadanDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuadanDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGuadanDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGuadanDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvGuadanDetail.Location = new System.Drawing.Point(312, 12);
            this.dgvGuadanDetail.Name = "dgvGuadanDetail";
            this.dgvGuadanDetail.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGuadanDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvGuadanDetail.RowTemplate.Height = 23;
            this.dgvGuadanDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGuadanDetail.Size = new System.Drawing.Size(343, 390);
            this.dgvGuadanDetail.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "商品名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "数量/重量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dgvAllGuadan
            // 
            this.dgvAllGuadan.AllowUserToAddRows = false;
            this.dgvAllGuadan.AllowUserToDeleteRows = false;
            this.dgvAllGuadan.AllowUserToResizeColumns = false;
            this.dgvAllGuadan.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAllGuadan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAllGuadan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllGuadan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.guadanNumber});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllGuadan.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAllGuadan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvAllGuadan.Location = new System.Drawing.Point(12, 12);
            this.dgvAllGuadan.MultiSelect = false;
            this.dgvAllGuadan.Name = "dgvAllGuadan";
            this.dgvAllGuadan.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvAllGuadan.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAllGuadan.RowTemplate.Height = 23;
            this.dgvAllGuadan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllGuadan.Size = new System.Drawing.Size(244, 456);
            this.dgvAllGuadan.TabIndex = 1;
            this.dgvAllGuadan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllGuadan_CellClick);
            // 
            // guadanNumber
            // 
            this.guadanNumber.DataPropertyName = "guadanNumber";
            this.guadanNumber.HeaderText = "挂单号";
            this.guadanNumber.Name = "guadanNumber";
            this.guadanNumber.ReadOnly = true;
            this.guadanNumber.Width = 200;
            // 
            // frmGuadan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 485);
            this.Controls.Add(this.panelEx1);
            this.Name = "frmGuadan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取出挂单";
            this.Load += new System.EventHandler(this.frmGuadan_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuadanDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllGuadan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvAllGuadan;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvGuadanDetail;
        private DevComponents.DotNetBar.ButtonX btnDeleteGuadanNumber;
        private DevComponents.DotNetBar.ButtonX btnGet;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn guadanNumber;
    }
}