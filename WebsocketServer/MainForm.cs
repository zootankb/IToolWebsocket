using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IToolWebsocket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            new WebsocketServerForm().Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            new WebsocketClientForm().Show();
        }

        private void btnOpenAll_Click(object sender, EventArgs e)
        {
            new WebsocketServerForm().Show();
            new WebsocketClientForm().Show();
        }
    }
}
