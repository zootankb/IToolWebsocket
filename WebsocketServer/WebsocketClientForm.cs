using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using WebSocket4Net;

namespace IToolWebsocket
{
    public partial class WebsocketClientForm : Form
    {

        private WebSocket client = null;

        public WebsocketClientForm()
        {
            InitializeComponent();
        }

        private void WebsocketClientForm_Load(object sender, EventArgs e)
        {
            TransformConnect(true);
        }

        #region 点击事件
        private void btnStart_Click(object sender, EventArgs e)
        {
            string ipStr = tbIP.Text.Trim();
            if (string.IsNullOrEmpty(ipStr))
            {
                MessageBox.Show("地址不能为空！");
                return;
            }
            string portStr = tbPort.Text.Trim();
            if (string.IsNullOrEmpty(portStr))
            {
                MessageBox.Show("端口不能为空！");
                return;
            }
            try
            {
                client = new WebSocket(string.Format("ws://{0}:{1}", ipStr, portStr));
                client.Closed += Client_Closed;
                client.Opened += Client_Opened;
                client.Error += Client_Error;
                client.DataReceived += Client_DataReceived;
                client.ReceiveBufferSize = 2048;
                client.Open();
                AddHistory(string.Format("正在连接 ws://{0}:{1}...", ipStr, portStr));
            }
            catch(Exception ee)
            {
                AddHistory(string.Format( "连接错误，异常为 {0}", ee.Message));
                client = null;
            }
        }

        private void Client_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string content = Encoding.UTF8.GetString(e.Data);
            AddHistory("收到的消息： " + content);
        }

        private void Client_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            AddHistory(string.Format("连接失败 {0}", e.Exception.Message));
            client = null;
            TransformConnect(true);
        }

        private void Client_Opened(object sender, EventArgs e)
        {
            client.Send("客户端准备发送数据");
            AddHistory(string.Format("连接成功,准备发送数据！"));
            TransformConnect(false);
        }


        private void Client_Closed(object sender, EventArgs e)
        {
            client = null;
            AddHistory("关闭连接！");
            TransformConnect(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (client != null && client.State == WebSocketState.Open)
            {
                TransformConnect(false);
                client.Close();
                client = null;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = tbSend.Text.Trim();
            if (!string.IsNullOrEmpty(content))
            {
                byte[] bs = Encoding.UTF8.GetBytes(content);
                try
                {
                    client.Send(bs, 0, bs.Length);
                    AddHistory(string.Format("发送消息 {0}", content));
                }
                catch (Exception ee)
                {
                    AddHistory(string.Format("发送失败，异常为 {0}", ee.Message));
                }
            }
        }
        #endregion

        #region Func

        /// <summary>
        /// 返回时间戳
        /// </summary>
        /// <returns></returns>
        private string GetTimeTick()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        /// <summary>
        /// 添加历史记录
        /// </summary>
        /// <param name="content"></param>
        private void AddHistory(string content)
        {
            if (tbHistoryTotal.InvokeRequired)
            {
                Action<string> cb = new Action<string>(AddHistory);
                tbHistoryTotal.Invoke(cb, new object[] { content });
            }
            else
            {
                tbHistoryTotal.AppendText(GetTimeTick() + "\r\n" + content + "\r\n\r\n");
            }
            
        }

        /// <summary>
        /// 连接时转换状态
        /// </summary>
        /// <param name="state"></param>
        private void TransformConnect(bool state)
        {
            if (this.InvokeRequired)
            {
                Action<bool> cb = new Action<bool>(TransformConnect);
                this.Invoke(cb, new object[] { state });
            }
            else
            {
                tbIP.Enabled = state;
                tbPort.Enabled = state;
                btnStart.Enabled = state;
                btnClose.Enabled = !state;
                tbSend.Enabled = !state;
                btnSend.Enabled = !state;
            }
        }

        #endregion
    }
}
