using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AndroCtrl.Connection;
using AndroCtrl.Services;

namespace AndroCtrl.Dialogs
{
    public partial class TCPConnect : Form
    {
        public TCPConnect()
        {
            InitializeComponent();
        }

        private void DoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            DelayIn.Enabled = DoReconnect.Checked;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            DnsEndPoint ep = new(IPAddressIn.Text, int.Parse(PortIn.Text));
            Adb.Client.Connect(ep);

            if (DoReconnect.Checked)
            {
                new ReconnectionService(ep, int.Parse(DelayIn.Text)).Start(true);
            }

            Close();
        }
    }
}
