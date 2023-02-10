using System.Net;

using AndroCtrl.Connection;
using AndroCtrl.Services.EventArgs;

using QRCoder;

namespace AndroCtrl.Services;

internal class QRCodePairingService : Service, IService
{
    private const string QRCodePairingText = "WIFI:T:ADB;S:debug;P:{0};;";
    private string pairCode;
    private DnsServiceBrowser mdns;

    public QRCodePairingService() : base()
    {
        pairCode = Random.Shared.Next(0, 1000000).ToString("000000");

        mdns = new(DnsServiceTypes.DevicePairing);
        mdns.NetworkFound += (ep) =>
        {
            Adb.Client.Pair(ep, int.Parse(pairCode));
            OnExecute(ServiceEventArgs.Empty);
        };
    }

    internal Bitmap CreateQrCode()
    {
        QRCodeGenerator qrGenerator = new();
        string FormattedQR = string.Format(QRCodePairingText, pairCode);
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(FormattedQR, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new(qrCodeData);
        return qrCode.GetGraphic(20);
    }

    protected override void Run(object? sender, IServiceEventArgs e)
    {
        mdns.Scan();
        Status = ServiceStatus.Running;
    }

    protected override void Finish(object? sender, IServiceEventArgs e) => mdns.Stop();
}
