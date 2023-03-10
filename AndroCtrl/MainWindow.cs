using System.Net;

using AndroCtrl.Connection;
using AndroCtrl.Dialogs;
using AndroCtrl.Protocols.AndroidDebugBridge;
using AndroCtrl.Services;

using static SAPTeam.CommonTK.Console.ConsoleManager;
using SAPTeam.CommonTK;

namespace AndroCtrl;

public partial class MainWindow : Form
{
    bool isUpdating;
    RemoteConnectionService rcs;
    DeviceMonitor dm;

    public MainWindow()
    {
        Adb.Server.StartServer(Adb.LocalServer, true);

        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        rcs = new();

        dm = new(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
        dm.DeviceConnected += Refresh;
        dm.DeviceDisconnected += Refresh;
        dm.DeviceChanged += Refresh;

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
        Adb.DefaultDevice = (Android.AndroidDevice)DeviceSelector.SelectedItem;
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

    private void MainWindow_Activated(object sender, EventArgs e)
    {
        rcs.Start(true);
        // dm.Start();
    }

    private void MainWindow_Deactivate(object sender, EventArgs e)
    {
        rcs.Stop();
        // dm.Stop();
    }

    private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.F5)
        {

        }
    }

    void Dbg()
    {
        ShowConsole();
        var shell = Adb.Client.StartShell(Adb.DDID);
        Console.Write(shell.GetPrompt(false));
        while (true)
        {
            shell.Interact(Console.ReadLine(), writer: Console.Out);
            Console.Write(shell.GetPrompt(false));
        }
    }

    private void DbgBtn_Click(object sender, EventArgs e)
    {
        Dbg();
    }

    private void MainWindow_Leave(object sender, EventArgs e)
    {
        Program.Settings.Write();
    }
}