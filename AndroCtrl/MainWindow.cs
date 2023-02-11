using AndroCtrl.Connection;
using AndroCtrl.Dialogs;
using AndroCtrl.Services;

namespace AndroCtrl;

public partial class MainWindow : Form
{
    bool isUpdating;
    RemoteConnectionService rcs;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        rcs = new();
        Refresh(null, EventArgs.Empty);
    }

    public void RefreshDevicesGroup()
    {
        if (!isUpdating && Adb.DefaultDevice != null)
        {
            isUpdating = true;
            DeviceSelector.Items.Clear();

            foreach (var device in Adb.Devices)
            {
                DeviceSelector.Items.Add(device.Value);
            }
            DeviceSelector.SelectedItem = Adb.DefaultDevice;

            DisconnectButtun.Enabled = Adb.DefaultDevice.ConnectionType == ConnectionTypes.Wifi;
            label1.Text = Adb.DefaultDevice.IsUsbDevice ? "Serial Number:" : "IP Address:";
            DeviceModelOut.Text = Adb.DefaultDevice.Model;
            ManufacturerOut.Text = Adb.DefaultDevice.Manufacturer;
            SerialOut.Text = Adb.DefaultDevice.DeviceID.Serial;
            SDKVersionOut.Text = Adb.DefaultDevice.API;
            BuildFingerprintOut.Text = Adb.DefaultDevice.Fingerprint;
        }
        else if (!isUpdating && Adb.DefaultDevice == null)
        {
            isUpdating = true;
            DeviceSelector.Items.Clear();

            DisconnectButtun.Enabled = false;
            label1.Text = "Serial Number:";
            DeviceModelOut.Text = "";
            ManufacturerOut.Text = "";
            SerialOut.Text = "";
            SDKVersionOut.Text = "";
            BuildFingerprintOut.Text = "";
        }

        isUpdating = false;
    }

    private void DeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        Adb.DefaultDevice = (Android.Device)DeviceSelector.SelectedItem;
        RefreshDevicesGroup();
    }

    private void PairButton_Click(object sender, EventArgs e)
    {
        new QRCodePair().ShowDialog();
    }

    private void TCPConnectButton_Click(object sender, EventArgs e)
    {
        new TCPConnect().ShowDialog();
    }

    private void Refresh(object? sender, EventArgs e)
    {
        Adb.UpdateDevices();
        RefreshDevicesGroup();
    }

    private void DisconnectButtun_Click(object sender, EventArgs e)
    {
        Adb.DefaultDevice.Disconnect();
    }

    private void MainWindow_Enter(object sender, EventArgs e)
    {
        rcs.Start(true);
    }

    private void MainWindow_Leave(object sender, EventArgs e)
    {
        rcs.Stop();
    }
}