using AndroCtrl.Connection;

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
}