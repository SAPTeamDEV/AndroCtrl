using System.Net;

using QRCoder;

namespace AndroCtrl.Connection;

internal partial class Adb
{
    internal class QRCodePair
    {
        private const string QRCodePairingText = "WIFI:T:ADB;S:debug;P:{0};;";
        private string pairCode;
        private DnsServiceBrowser mdns;

        internal event Action? OnPaired;

        public QRCodePair()
        {
            pairCode = Random.Shared.Next(0, 1000000).ToString("000000");

            mdns = new(DnsServiceTypes.DevicePairing);
            mdns.NetworkFound += (DnsEndPoint ep) =>
            {
                Client.Pair(ep, int.Parse(pairCode));
                mdns.Stop();
                OnPaired?.Invoke();
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

        internal void StartScan()
        {
            mdns.Scan();
        }

        internal void StopScan()
        {
            mdns.Stop();
        }
    }
}
