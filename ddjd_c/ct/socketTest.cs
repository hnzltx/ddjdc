using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace ddjd_c.ct
{
    public partial class socketTest : Form
    {
        
        
        public socketTest()
        {
            InitializeComponent();
        }

        private void socketTest_Load(object sender, EventArgs e) {
            test();
        }

        WebSocket ws;
        private void test() {
            //using (var ws = new WebSocket("ws://localhost/websocket/" + GlobalsInfo.storeId))
            //{
            //    ws.OnMessage += (sender, e) =>
            //        Console.WriteLine("Laputa says: " + e.Data);

            //    ws.Connect();
            //    ws.Send("BALUS");
            //}
            ws = new WebSocket("ws://localhost/websocket/" + GlobalsInfo.storeId);

            ws.OnOpen += (sender, e) => {
                Console.WriteLine("连接成功!");
            };

            ws.OnError += (sender, e) => {
                Console.WriteLine("发生错误!");
            };

            ws.OnMessage += (sender, e) =>
            {
                Console.WriteLine(e.Data);
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = Application.StartupPath + "//xindingdan.mp3";
                player.LoadAsync();
                player.PlaySync();
            };
               

            ws.OnClose += (sender, e) => {
                Console.WriteLine("连接关闭!" + e.Reason);
            };

            ws.Connect();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ws.Close();
        }
    }
}
