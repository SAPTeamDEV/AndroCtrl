using System.Net;

using AndroCtrl.Connection;
using AndroCtrl.Services;

namespace AndroCtrl.Dialogs;

public partial class QRCodePair : Form
{
    private QRCodePairingService adbPair;
    private DnsServiceBrowser mdns;

    public QRCodePair()
    {
        InitializeComponent();
    }

    private void QRCodePair_Load(object sender, EventArgs e)
    {
        adbPair = new();
        adbPair.TaskExecuted += (sender, e) => Close();

        mdns = new(DnsServiceTypes.DevicePairing);
        mdns.NetworkFound += (DnsEndPoint ep) =>
        {
            HostName.Text = ep.Host;
            HostName.Enabled = false;

            Port.Text = ep.Port.ToString();
            Port.Enabled = false;
            mdns.Stop();
        };

    }

    private void QRCodePair_FormClosed(object sender, FormClosedEventArgs e)
    {
        adbPair.Stop();
        mdns.Stop();
    }

    private void QRPairing_Enter(object sender, EventArgs e)
    {
        QRCodeBox.Image = adbPair.CreateQrCode();
        adbPair.Start();
    }

    private void QRPairing_Leave(object sender, EventArgs e) => adbPair.Stop();

    private void ManualPairing_Enter(object sender, EventArgs e) => mdns.Scan();

    private void ManualPairing_Leave(object sender, EventArgs e) => mdns.Stop();

    private void Pair_Click(object sender, EventArgs e)
    {
        Adb.Client.Pair(new(HostName.Text, int.Parse(Port.Text)), int.Parse(PairCode.Text));
        this.Close();
    }
}
