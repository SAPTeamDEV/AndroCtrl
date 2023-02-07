using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AndroCtrl.Connection;

namespace AndroCtrl.Dialogs
{
    public partial class QRCodePair : Form
    {
        public QRCodePair()
        {
            InitializeComponent();
        }

        private void QRCodePair_Load(object sender, EventArgs e)
        {
            QRCodeBox.Image = Adb.Wifi.CreateQrCode();
            Adb.Wifi adbWifi = new();
            adbWifi.OnPaired += Close;
            adbWifi.StartScan();
        }
    }
}
