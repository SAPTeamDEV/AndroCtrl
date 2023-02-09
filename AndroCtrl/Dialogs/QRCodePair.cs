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

namespace AndroCtrl.Dialogs
{
    public partial class QRCodePair : Form
    {
        Adb.Wifi adbWifi;
        DnsServiceBrowser mdns;

        public QRCodePair()
        {
            InitializeComponent();
        }

        void EnterEndpoint(DnsEndPoint ep)
        {
            HostName.Text = ep.Host;
            HostName.Enabled = false;

            Port.Text = ep.Port.ToString();
            Port.Enabled = false;
        }

        private void QRCodePair_Load(object sender, EventArgs e)
        {
            adbWifi = new();
            adbWifi.OnPaired += Close;

            mdns = new(Adb.Wifi.TYPE);
            mdns.NetworkFound += EnterEndpoint;

        }

        private void QRCodePair_FormClosed(object sender, FormClosedEventArgs e)
        {
            adbWifi.StopScan();
            mdns.Stop();
        }

        private void QRPairing_Enter(object sender, EventArgs e)
        {
            QRCodeBox.Image = Adb.Wifi.CreateQrCode();
            adbWifi.StartScan();
        }

        private void QRPairing_Leave(object sender, EventArgs e)
        {
            adbWifi.StopScan();
        }

        private void ManualPairing_Enter(object sender, EventArgs e)
        {
            mdns.Scan();
        }

        private void ManualPairing_Leave(object sender, EventArgs e)
        {
            mdns.Stop();
        }

        private void Pair_Click(object sender, EventArgs e)
        {
            Adb.Client.Pair(new(HostName.Text, int.Parse(Port.Text)), int.Parse(PairCode.Text));
            this.Close();
        }
    }
}
