using ddjd_c.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct
{
    public partial class frmTest : Form
    {
        private KeyboardHookLib listener = new KeyboardHookLib();

        public frmTest()
        {
            InitializeComponent();
            listener.ScanerEvent += Listener_ScanerEvent;
        }


        private void Listener_ScanerEvent(KeyboardHookLib.ScanerCodes codes)
        {
            //键盘钩子获取的条码，赋值到文本框中
            textBox1.Text = codes.Result;
            Console.WriteLine("codes.Result：" + codes.Result);

        }

       


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listener.Start();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listener.Stop();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            listener.Start();
        }




        


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    
                    return true;
                case Keys.Enter:
                   
                    Console.WriteLine("结果:" + textBox1.Text);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



    }
}
