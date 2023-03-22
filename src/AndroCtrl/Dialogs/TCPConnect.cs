using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using AndroCtrl.Connection;
using AndroCtrl.Services;

namespace AndroCtrl.Dialogs
{
    public partial class TCPConnect : Form
    {
        public static Regex IPAddressRegex { get; } = new(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

        public TCPConnect()
        {
            InitializeComponent();
        }

        private void TCPConnect_Load(object sender, EventArgs e)
        {
            if (Program.Settings.IPAddresses.Count > 0)
            {
                foreach (var ip in Program.Settings.IPAddresses)
                {
                    IPAddressIn.Items.Add(ip);
                }

                IPAddressIn.SelectedIndex = 0;
            }
        }

        private void DoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            DelayIn.Enabled = DoReconnect.Checked;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            DnsEndPoint ep = new(IPAddressIn.Text, int.Parse(PortIn.Text));
            Adb.Client.Connect(ep);

            if (!Program.Settings.IPAddresses.Contains(ep.Host))
            {
                Program.Settings.IPAddresses.Add(ep.Host);
            }

            if (DoReconnect.Checked)
            {
                new ReconnectionService(ep, int.Parse(DelayIn.Text)).Start(true);
            }

            Close();
        }

        private void KeyHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConnectButton_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IPAddressIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyHandler(sender, e);

            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == '.')
            {
                e.Handled = false;
            }

            if (!e.Handled)
            {
                string rawText = IPAddressIn.Text + e.KeyChar;
                var divText = rawText.Split('.');
                List<string> finTexts = new List<string>();

                if (divText.Length > 4)
                {
                    e.Handled = true;
                    return;
                }

                foreach (var text in divText)
                {
                    string finText;

                    if (text.Length > 3)
                    {
                        e.Handled = true;
                        return;
                    }
                    else if (text.Length < 3)
                    {
                        finText = new string('0', 3 - text.Length) + text;
                    }
                    else
                    {
                        finText = text;
                    }

                    finTexts.Add(finText);
                }

                if (finTexts.Count < 4)
                {
                    for (int i = 4 - finTexts.Count; i > 0; i--)
                    {
                        finTexts.Add("000");
                    }
                }

                if (!IPAddressRegex.IsMatch(string.Join('.', finTexts)))
                {
                    e.Handled = true;
                }
            }
        }

        private void TCPConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Config.Write();
        }
    }
}
