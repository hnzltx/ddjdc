using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.Set
{
    public partial class frmSetPrint : Form
    {
        public frmSetPrint()
        {
            InitializeComponent();
        }

        //设置打印机参数
        string setPrintFileName = "setPrint.json";
        private void frmSetPrint_Load(object sender, EventArgs e)
        {
            if (common.utils.FileExists(setPrintFileName))
            {
                JObject json = common.utils.getFile(setPrintFileName);
                this.cbLineCount.Text = json["lineCount"].ToString();
                this.cbLptName.Text = json["lptName"].ToString();
                this.cbOpenQX.Checked = Boolean.Parse(json["openQX"].ToString());
            }
            else
            {
                this.cbLineCount.SelectedIndex = 0;
                this.cbLptName.SelectedIndex = 0;
            }
        }

        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            JObject source = new JObject();
            source.Add("lineCount", cbLineCount.Text);
            source.Add("lptName", cbLptName.Text);
            source.Add("openQX",cbOpenQX.Checked);

            if (common.utils.writeFile(setPrintFileName, source))
            {
                db.SetPrint.SetPrint.lineCount = int.Parse(this.cbLineCount.Text);
                db.SetPrint.SetPrint.lptStr = cbLptName.Text;
                db.SetPrint.SetPrint.openQX = cbOpenQX.Checked;


                MessageBox.Show("保存成功!");
            }
            else
            {
                MessageBox.Show("保存失败!  ");
            }
        }
        

    }
}
