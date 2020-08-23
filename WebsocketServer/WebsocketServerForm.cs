using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;

namespace IToolWebsocket
{
    public partial class WebsocketServerForm : Form
    {
        /// <summary>
        /// 服务端
        /// </summary>
        private AppServer server = null;

        /// <summary>
        /// 连接的客户端
        /// </summary>
        private Dictionary<string, AppSession> clients = new Dictionary<string, AppSession>();

        /// <summary>
        /// 客户端的历史存储记录
        /// </summary>
        private Dictionary<string, List<string>> clientsHistory = new Dictionary<string, List<string>>();

        public WebsocketServerForm()
        {
            InitializeComponent();
        }

        private void WebsocketServerForm_Load(object sender, EventArgs e)
        {
            TransformCreateTB(true);
        }

        #region Click
        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            string portStr = tb_port.Text;
            if (string.IsNullOrEmpty(portStr))
            {
                MessageBox.Show("端口不能为空");
                return;
            }
            try
            {
                server = new AppServer();
                server.NewRequestReceived += Server_NewRequestReceived;
                server.NewSessionConnected += Server_NewSessionConnected;
                server.SessionClosed += Server_SessionClosed;
                if (server.Setup(int.Parse(portStr)))
                {
                    if (server.Start())
                    {
                        TransformCreateTB(false);
                        AddHistoryTotal(string.Format("服务器 {0}:{1} 已经启动",  server.Config.Ip, server.Config.Port));
                    }
                    else
                    {
                        AddHistoryTotal(string.Format("启动端口为 {0} 的服务器失败！", portStr));
                        server = null;
                    }
                }
                else
                {
                    AddHistoryTotal(string.Format("设置端口 {0} 失败！", portStr));
                    server = null;
                }
            }
            catch(Exception ee)
            {
                AddHistoryTotal(string.Format("创建端口为 {0} 的服务器失败，异常为：{1}", portStr, ee.Message));
            }
        }

        /// <summary>
        /// 关闭服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            server.Stop();
            TransformCreateTB(true);
            AddHistoryTotal(string.Format("服务器 {0}:{1} 已经关闭", server.Config.Ip, server.Config.Port));
            server = null;
            clients.Clear();
            clientsHistory.Clear();
            lbClients.Items.Clear();
        }

        /// <summary>
        /// 关闭某个客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseOne_Click(object sender, EventArgs e)
        {
            if (lbClients.SelectedIndex >= 0)
            {
                // TODO
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(lbClients.SelectedIndex >= 0)
            {
                // TODO
            }
        }

        #endregion

        #region Call Func
        private void Server_SessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason value)
        {
            if (clients.ContainsKey(session.RemoteEndPoint.ToString()))
            {
                RemoveClient(session.RemoteEndPoint.ToString());
            }
        }

        private void Server_NewSessionConnected(AppSession session)
        {
            AddClient(session);
            AddHistoryTotal("客户端 " + session.RemoteEndPoint.ToString() + " 连接");
        }

        private void Server_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            if (clients.ContainsKey(session.RemoteEndPoint.ToString()))
            {
                string content = requestInfo.Body;
                clientsHistory[session.RemoteEndPoint.ToString()].Add(string.Format("{0}\r\n收到客户端 {1} 的消息： {2}", GetTimeTick(), session.RemoteEndPoint.ToString(), content));
                AddHistoryTotal(string.Format("收到客户端 {0} 的消息： {1}", session.RemoteEndPoint.ToString(), content));
            }
        }

        #endregion

        #region Pri Func

        private void AddClient(AppSession session)
        {
            if (lbClients.InvokeRequired)
            {
                Action<AppSession> cb = new Action<AppSession>(AddClient);
                lbClients.Invoke(cb, new object[] { session });
            }
            else
            {
                clients.Add(session.RemoteEndPoint.ToString(), session);
                clientsHistory.Add(session.RemoteEndPoint.ToString(), new List<string>());
                lbClients.Items.Add(session.RemoteEndPoint.ToString());
            }
        }

        /// <summary>
        /// 移除客户端
        /// </summary>
        /// <param name="sessionId"></param>
        private void RemoveClient(string sessionId)
        {
            if (lbClients.InvokeRequired)
            {
                Action<string> cb = new Action<string>(RemoveClient);
                lbClients.Invoke(cb, new object[] { sessionId });
            }
            else
            {
                int index = -1;
                foreach (var c in lbClients.Items)
                {
                    if (c.ToString().Equals(sessionId))
                    {
                        index = lbClients.Items.IndexOf(c);
                        break;
                    }
                }
                if (index >= 0)
                {
                    lbClients.Items.RemoveAt(index);
                    if (clients[sessionId] != null || clients[sessionId].Connected)
                    {
                        clients[sessionId].Close();
                    }
                    clients.Remove(sessionId);
                    clientsHistory.Remove(sessionId);
                    AddHistoryTotal("关闭客户端：" + sessionId);
                }
            }
        }

        /// <summary>
        /// 启动服务器时的空间转换
        /// </summary>
        /// <param name="state"></param>
        private void TransformCreateTB(bool state)
        {
            tb_port.Enabled = state;
            btnStart.Enabled = state;
            btnClose.Enabled = !state;
            lbClients.Enabled = !state;
            btnCloseOne.Enabled = !state;
            tbSend.Enabled = !state;
            btnSend.Enabled = !state;
        }

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
            if (tbHistory.InvokeRequired)
            {
                Action<string> cb = new Action<string>(AddHistoryTotal);
                tbHistory.Invoke(cb, new object[] { history });
            }
            else
            {
                tbHistory.AppendText(GetTimeTick() + "\r\n" + history + "\r\n\r\n");
            }
        }

        #endregion

    }
}
