using System.Net;

using AndroCtrl.Connection;
using AndroCtrl.Dialogs;
using AndroCtrl.Protocols.AndroidDebugBridge;
using AndroCtrl.Services;

using static SAPTeam.CommonTK.Console.ConsoleManager;
using SAPTeam.CommonTK;
using SAPTeam.CommonTK.Contexts;
using Timer = SAPTeam.CommonTK.Timer;
using System.Net.Sockets;

namespace AndroCtrl;

public partial class MainWindow : Form
{
    bool isUpdating;
    RemoteConnectionService rcs;
    DeviceMonitor dm;
    Timer timer;

    public MainWindow()
    {
        Adb.Server.StartServer(Adb.LocalServer, true);

        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        rcs = new();

#if !DEBUG
        dm = new(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
        dm.DeviceConnected += Refresh;
        dm.DeviceDisconnected += Refresh;
        dm.DeviceChanged += Refresh;
#else
        Text += " [Debug]";
#endif

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
            RootButton.Enabled = !Adb.DefaultDevice.IsRoot;
            label1.Text = Adb.DefaultDevice.IsUsbDevice ? "Serial Number:" : "IP Address:";
            DeviceModelOut.Text = Adb.DefaultDevice.Model;
            ManufacturerOut.Text = Adb.DefaultDevice.Manufacturer;
            SerialOut.Text = Adb.DefaultDevice.DeviceID.Serial;
            SDKVersionOut.Text = Adb.DefaultDevice.API;
            BuildFingerprintOut.Text = Adb.DefaultDevice.Fingerprint;

            UtilsGroup.Enabled = true;
        }
        else if (!isUpdating && Adb.DefaultDevice == null)
        {
            isUpdating = true;
            DeviceSelector.Items.Clear();

            DisconnectButtun.Enabled = false;
            RootButton.Enabled = false;

            label1.Text = "Serial Number:";
            DeviceModelOut.Text = "";
            ManufacturerOut.Text = "";
            SerialOut.Text = "";
            SDKVersionOut.Text = "";
            BuildFingerprintOut.Text = "";

            UtilsGroup.Enabled = false;
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
#if !DEBUG
        dm.Start();
#endif
    }

    private void MainWindow_Deactivate(object sender, EventArgs e)
    {
        rcs.Stop();
#if !DEBUG
        dm.Stop();
#endif
    }

    private void MainWindow_KeyPress(object sender, KeyEventArgs e)
    {
#if DEBUG
        if (e.KeyCode == Keys.F2)
        {
            // Debug button
        }
#endif
        if (e.KeyCode == Keys.F5)
        {
            Refresh(sender, EventArgs.Empty);
        }
    }

    private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
    {
        Program.Config.Write();
    }

    private void RunShellButton_Click(object sender, EventArgs e)
    {
        new Thread(() =>
        {
            using ConsoleWindow console = new();
            var shell = Adb.Client.StartShell(Adb.DDID);
            Console.Write(shell.GetPrompt(false));
            try
            {
                while (true)
                {
                    shell.Interact(Console.ReadLine(), writer: Console.Out);
                    Console.Write(shell.GetPrompt(false));
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != (int)SocketError.NotConnected)
                {
                    throw;
                }
            }
        }).Start();
    }

    private void RootButton_Click(object sender, EventArgs e)
    {
        Adb.DefaultDevice.SuperUser();
        if (Adb.DefaultDevice.IsRoot)
        {
            Refresh(sender, EventArgs.Empty);
        }
    }
}