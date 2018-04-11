using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.Set
{
    public partial class frmSetCashierScale : Form
    {
        public frmSetCashierScale()
        {
            InitializeComponent();
        }

        private void frmSetCashierScale_Load(object sender, EventArgs e)
        {
            //获取系统当前所有的串口
            string[] allPort = common.serialport.getAllPortList();
            cmbPortList.DataSource = allPort;

            //选中第一个波特率
            cmbBaudRate.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 0;
            cmbParity.SelectedIndex = 0;
            cmbStopBits.SelectedIndex = 0;
        }


        private void btnSetCashierScale_Click(object sender, EventArgs e)
        {
            JObject source = new JObject();
            source.Add("PortName", cmbPortList.Text);
            source.Add("BaudRate", cmbBaudRate.Text);
            source.Add("StopBits", cmbStopBits.Text);
            source.Add("Parity", cmbParity.Text);
            source.Add("DataBits", cmbDataBits.Text);

            if (common.utils.writeFile("SetCashierScale.json", source))
            {
                db.SetCashierScale.SetCashierScale.BaudRate = int.Parse(cmbBaudRate.Text);
                db.SetCashierScale.SetCashierScale.PortName = cmbPortList.Text;
                db.SetCashierScale.SetCashierScale.StopBits = cmbStopBits.Text;
                db.SetCashierScale.SetCashierScale.Parity = cmbParity.Text;
                db.SetCashierScale.SetCashierScale.DataBits = int.Parse(cmbDataBits.Text);
                MessageBox.Show("保存成功!");
            }
            else {
                MessageBox.Show("保存失败! -- ");
            }
        }
    }
}
