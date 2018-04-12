using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct.good
{
    public delegate void GetInputTextDelegate(string str,int? storeAndGoodsId,int rowIndex);
    public partial class inputTxtSort : Form
    {
        private int? storeAndGoodsId;
        private int rowIndex;
        public event GetInputTextDelegate GetInputText;
        public inputTxtSort(int? storeAndGoodsId,int rowIndex)
        {
            this.rowIndex = rowIndex;
            this.storeAndGoodsId = storeAndGoodsId;
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
            GetInputText(this.textBoxX1.Text,this.storeAndGoodsId,this.rowIndex);
            
        }
    }
}
