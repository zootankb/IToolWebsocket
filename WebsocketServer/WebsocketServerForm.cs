using System;
using System.Text;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;

namespace IToolWebsocket
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
                    AddHistoryTotal(string.Format("{0} 服务器 {1}:{2} 已经启动", GetTimeTick(), server.Config.Ip, server.Config.Port));
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

        #region Call Func
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

        #region Pri Func
        /// <summary>
        /// 获取时间格式化的字符串
        /// </summary>
        /// <returns></returns>
        private string GetTimeTick()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 添加总的消息记录
        /// </summary>
        /// <param name="history"></param>
        private void AddHistoryTotal(string history)
        {
            tbHistory.AppendText(history + "\r\n\r\n");
        }

        #endregion

    }
}
