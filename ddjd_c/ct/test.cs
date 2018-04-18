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
        //private Class1 listener = new Class1();

        //public frmTest()
        //{
        //    InitializeComponent();
        //    listener.BarCodeEvent += Listener_ScanerEvent;
        //}


        //private void Listener_ScanerEvent(Class1.BarCodes codes)
        //{
        //    textBox1.Text = codes.BarCode;

        //}




        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    listener.Start();
        //}


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    listener.Stop();
        //}

        //private void frmTest_Load(object sender, EventArgs e)
        //{
        //    listener.Start();
        //}




        BardCodeHooK BarCode = new BardCodeHooK();

        public frmTest()
        {
            InitializeComponent();
            BarCode.BarCodeEvent += new BardCodeHooK.BardCodeDeletegate(BarCode_BarCodeEvent);
        }
        
        private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);
        private void ShowInfo(BardCodeHooK.BarCodes barCode)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowInfoDelegate(ShowInfo), new object[] { barCode });
            }
            else
            {
                //textBox1.Text = barCode.KeyName;
                //textBox2.Text = barCode.VirtKey.ToString();
                //textBox3.Text = barCode.ScanCode.ToString();
                //textBox4.Text = barCode.Ascll.ToString();
                //textBox5.Text = barCode.Chr.ToString();

                //textBox7.Text += barCode.KeyName;
                
                textBox1.Text = barCode.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入  
                
                //MessageBox.Show(barCode.IsValid.ToString());  
            }
        }


        void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        {
            ShowInfo(barCode);
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarCode.Start();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            BarCode.Stop();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            BarCode.Start();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    
                    return true;
                case Keys.Enter:
                    textBox2.Text = textBox1.Text; 
                    Console.WriteLine("123:" + textBox2.Text);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



    }
}
