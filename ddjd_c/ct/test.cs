using ddjd_c.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ddjd_c.ct
{
    public partial class frmTest : Form
    {
        private KeyboardHookLib _keyboardHook = null;

        public frmTest()
        {
            InitializeComponent();
        }

        






        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //安装勾子
            _keyboardHook = new KeyboardHookLib();
            _keyboardHook.InstallHook(this.OnKeyPress);
            textBox1.Text += "你按下:";
        }


        private string AllKey = "";

        public void OnKeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false; //预设不拦截任何键
            Keys key = (Keys)hookStruct.vkCode;

            //  textBox1.Text = key.ToString();
            string keyName = key.ToString();
            AllKey = AllKey + (key == Keys.None ? "" : keyName);
            textBox1.Text = AllKey;
            return;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消勾子
            if (_keyboardHook != null) _keyboardHook.UninstallHook();
        }
    }
}
