using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Login : Form
    {
        Socket SSocket;
        public Login()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {    
                long ip = long.Parse(textBox1.Text);
                int port = int.Parse(textBox1.Text);
                SSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
                SSocket.Bind(ipEndPoint);
                Server sv = new Server();
                sv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServerUDP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
