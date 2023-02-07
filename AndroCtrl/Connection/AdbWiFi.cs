using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using QRCoder;

namespace AndroCtrl.Connection;

internal partial class Adb
{
    internal class Wifi
    {
        const string TYPE = "_adb-tls-pairing._tcp.local.";
        const string NAME = "debug";
        const string PASS = "123456";
        const string FORMAT_QR = "WIFI:T:ADB;S:{0};P:{1};;";

        MulticastDNS mdns;

        internal static Bitmap CreateQrCode()
{
            QRCodeGenerator qrGenerator = new();
            string FormattedQR = string.Format(FORMAT_QR, NAME, PASS);
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(FormattedQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        internal void Listen(DnsEndPoint ep)
        {
            Client.Pair(ep, int.Parse(PASS));
            mdns.Stop();
        }

        internal void StartScan()
        {
            mdns = new(TYPE);
            mdns.NetworkFound += Listen;
            mdns.Scan();
        }
    }
}
