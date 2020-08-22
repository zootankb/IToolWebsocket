using System;
using System.Text;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;

namespace WebsocketServer
{
    public partial class WebsocketServerForm : Form
    {
        private AppServer server = null;

        public WebsocketServerForm()
        {
            InitializeComponent();
        }

        private void WebsocketServerForm_Load(object sender, EventArgs e)
        {

        }

        #region Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            string portStr = tb_port.Text;
            if (string.IsNullOrEmpty(portStr))
            {
                MessageBox.Show("端口不能为空");
                return;
            }
            server = new AppServer();
            server.NewRequestReceived += Server_NewRequestReceived;
            server.NewSessionConnected += Server_NewSessionConnected;
            server.SessionClosed += Server_SessionClosed;
            if (server.Setup(int.Parse(portStr)))
            {
                if (server.Start())
                {
                    MessageBox.Show("启动成功");
                }
                else
                {
                    server = null;
                }
            }
            else
            {
                server = null;
            }
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseOne_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Func
        private void Server_SessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason value)
        {

        }

        private void Server_NewSessionConnected(AppSession session)
        {

        }

        private void Server_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {

        }

        #endregion
    }
}
