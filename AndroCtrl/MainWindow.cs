using AndroCtrl.Connection;

namespace AndroCtrl;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Adb.UpdateDevices();
    }

    public void RefreshDevicesGroup()
    {
        if (Adb.DefaultDevice != null)
        {
            DeviceSelector.Items.Clear();

            foreach (var device in Adb.Devices)
            {
                DeviceSelector.Items.Add(device);
            }

            DeviceModelOut.Text = Adb.DefaultDevice.Model;
            ManufacturerOut.Text = Adb.DefaultDevice.Manufacturer;
            SerialOut.Text = Adb.DefaultDevice.;
            DeviceModelOut.Text = Adb.DefaultDevice.Model;
            DeviceModelOut.Text = Adb.DefaultDevice.Model;
        }
    }
}