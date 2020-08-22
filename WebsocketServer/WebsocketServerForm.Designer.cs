namespace IToolWebsocket
{
    partial class WebsocketServerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbClients = new System.Windows.Forms.ListBox();
            this.btnCloseOne = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbHistoryOne = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口：";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(60, 10);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(181, 21);
            this.tb_port.TabIndex = 1;
            this.tb_port.Text = "8001";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(60, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动服务器";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(166, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭服务器";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbClients
            // 
            this.lbClients.FormattingEnabled = true;
            this.lbClients.ItemHeight = 12;
            this.lbClients.Location = new System.Drawing.Point(15, 62);
            this.lbClients.Name = "lbClients";
            this.lbClients.Size = new System.Drawing.Size(226, 448);
            this.lbClients.TabIndex = 4;
            // 
            // btnCloseOne
            // 
            this.btnCloseOne.Location = new System.Drawing.Point(166, 516);
            this.btnCloseOne.Name = "btnCloseOne";
            this.btnCloseOne.Size = new System.Drawing.Size(75, 23);
            this.btnCloseOne.TabIndex = 5;
            this.btnCloseOne.Text = "断开此链接";
            this.btnCloseOne.UseVisualStyleBackColor = true;
            this.btnCloseOne.Click += new System.EventHandler(this.btnCloseOne_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(275, 10);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSend.Size = new System.Drawing.Size(226, 500);
            this.tbSend.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(426, 516);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbHistoryOne
            // 
            this.tbHistoryOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHistoryOne.Location = new System.Drawing.Point(533, 28);
            this.tbHistoryOne.Multiline = true;
            this.tbHistoryOne.Name = "tbHistoryOne";
            this.tbHistoryOne.ReadOnly = true;
            this.tbHistoryOne.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHistoryOne.Size = new System.Drawing.Size(226, 511);
            this.tbHistoryOne.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "此链接消息：";
            // 
            // tbHistory
            // 
            this.tbHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbHistory.Location = new System.Drawing.Point(791, 28);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ReadOnly = true;
            this.tbHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbHistory.Size = new System.Drawing.Size(244, 511);
            this.tbHistory.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "消息历史：";
            // 
            // WebsocketServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1047, 551);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHistoryOne);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnCloseOne);
            this.Controls.Add(this.lbClients);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WebsocketServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Websocket_服务端";
            this.Load += new System.EventHandler(this.WebsocketServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.Button btnCloseOne;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbHistoryOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHistory;
        private System.Windows.Forms.Label label3;
    }
}

