using System;
using System.Collections.Generic;
using System.Linq;
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

        const string CMD_SHOW = "qrencode -t UTF8 '%s'";
        const string CMD_PAIR = "adb pair %s:%s %s";
        const string CMD_DEVICES = "adb devices -l";

        internal static Bitmap CreateQrCode()
{
            QRCodeGenerator qrGenerator = new();
            string FormattedQR = string.Format(FORMAT_QR, NAME, PASS);
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(FormattedQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        internal static void Listen()
    {

        }
    }
}
