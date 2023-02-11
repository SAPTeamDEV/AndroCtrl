using AndroCtrl.Connection;
using AndroCtrl.Dialogs;

namespace AndroCtrl;

public partial class MainWindow : Form
{
    bool isUpdating;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Adb.UpdateDevices();
        RefreshDevicesGroup();
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

            DeviceModelOut.Text = Adb.DefaultDevice.Model;
            ManufacturerOut.Text = Adb.DefaultDevice.Manufacturer;
            SerialOut.Text = Adb.DefaultDevice.DeviceID.Serial;
            SDKVersionOut.Text = Adb.DefaultDevice.API;
            BuildFingerprintOut.Text = Adb.DefaultDevice.Fingerprint;
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

    private void DeviceSelector_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.F5)
        {
            Adb.UpdateDevices();
            RefreshDevicesGroup();
        }
    }
}