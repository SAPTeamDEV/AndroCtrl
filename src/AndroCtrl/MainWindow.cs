using System.Net;
using AndroCtrl.Dialogs;
using SAPTeam.AndroCtrl.Adb;

using static SAPTeam.CommonTK.Console.ConsoleManager;
using SAPTeam.CommonTK;
using SAPTeam.CommonTK.Contexts;
using Timer = SAPTeam.CommonTK.Timer;
using System.Net.Sockets;
using SAPTeam.AndroCtrl.Android;
using System.Reflection;
using System.Diagnostics;
using SAPTeam.AndroCtrl.Connection;
using SAPTeam.AndroCtrl;
using SAPTeam.AndroCtrl.Services;

namespace SAPTeam.AndroCtrl;

public partial class MainWindow : Form
{
    bool isUpdating;
    RemoteConnectionService rcs;
#if !DEBUG
    DeviceMonitor dm;
#endif

    AndroidDevice Device => AdbInterface.DefaultDevice;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        Interact.AssignStatus(new AppStatusProvider(StatusBar));

        AdbServerStatus status = AdbInterface.UpdateServerStatus();

        if (status.IsRunning && status.Version >= AdbServer.RequiredAdbVersion)
        {
            // using an already runned server.
            if (AdbInterface.AdbPath != null)
            {
                AdbInterface.Server.UpdateAdbPath(AdbInterface.AdbPath);
            }
        }
        else if (AdbInterface.AdbPath != null)
        {
            AdbInterface.Server.StartServer(AdbInterface.AdbPath, true);
        }
        else
        {
            throw new InvalidOperationException("Adb server is not running in this machine and adb executable is not found.");
        }

        rcs = new();

#if !DEBUG
        dm = new(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
        dm.DeviceConnected += Refresh;
        dm.DeviceDisconnected += Refresh;
        dm.DeviceChanged += Refresh;
#else
        Text += " [Debug]";
        rcs.TaskExecuted += (obj, s) =>
        {
            Thread.Sleep(200);
            Refresh(sender, e);
        };
#endif

        Text += $" v{FileVersionInfo.GetVersionInfo(Program.ProcessPath).FileVersion}";
        Refresh(sender, e);
    }

    public void Refresh(object? sender, EventArgs e)
    {
        if (RefreshServerStatus())
        {
            AdbInterface.UpdateDevices();
        }
        else
        {
            AdbInterface.Devices.Clear();
            AdbInterface.DefaultDevice = null;
        }
        RefreshDevicesGroup();
    }

    public void RefreshDevicesGroup()
    {
        if (!isUpdating && Device != null)
        {
            isUpdating = true;
            DeviceSelector.Items.Clear();

            foreach (var device in AdbInterface.Devices)
            {
                DeviceSelector.Items.Add(device.Value);
            }
            DeviceSelector.SelectedItem = Device;

            DisconnectButtun.Enabled = Device.ConnectionType == ConnectionTypes.Wifi;
            RootButton.Enabled = Device.IsUsable && !Device.IsRoot;
            label1.Text = Device.IsUsbDevice ? "Serial Number:" : "IP Address:";
            DeviceModelOut.Text = Device.Model;
            ManufacturerOut.Text = Device.Manufacturer;
            SerialOut.Text = Device.DeviceID.Serial;
            SDKVersionOut.Text = Device.API;
            BuildFingerprintOut.Text = Device.Fingerprint;

            UtilsGroup.Enabled = Device.IsUsable;
        }
        else if (!isUpdating && Device == null)
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

            DeviceGroup.Enabled = AdbInterface.LastServerStatus.IsRunning;
            UtilsGroup.Enabled = false;
        }

        isUpdating = false;
    }

    public bool RefreshServerStatus()
    {
        AdbServerStatus status = AdbInterface.UpdateServerStatus();

        if (status.IsRunning)
        {
            ServerStatus.Text = $"Adb Server v{status.Version} is running";

            RestartServerButton.Enabled = AdbInterface.Server.HasAdbPath;
            StartServerButton.Enabled = false;
            KillServerButton.Enabled = true;
        }
        else
        {
            ServerStatus.Text = "Adb Server is Offline";

            RestartServerButton.Enabled = false;
            StartServerButton.Enabled = AdbInterface.Server.HasAdbPath;
            KillServerButton.Enabled = false;
        }

        return status.IsRunning;
    }

    private void DeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdbInterface.DefaultDevice = (AndroidDevice)DeviceSelector.SelectedItem;
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

    private void DisconnectButtun_Click(object sender, EventArgs e)
    {
        Device.Disconnect();
#if DEBUG
        Refresh(sender, e);
#endif
    }

    private void MainWindow_Activated(object sender, EventArgs e)
    {
        rcs.Start(true);
#if !DEBUG
        dm.Start();
#else
        Thread.Sleep(200);
        Refresh(sender, e);
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
            var shell = AdbInterface.Client.StartShell(AdbInterface.DDID);
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
        Device.SuperUser();
        if (Device.IsRoot)
        {
            Refresh(sender, EventArgs.Empty);
        }
    }

    private void RestartServerButton_Click(object sender, EventArgs e)
    {
        AdbInterface.Client.KillAdb();
        Refresh(sender, e);
        Thread.Sleep(100);
        AdbInterface.Server.RestartServer();
        Refresh(sender, e);
    }

    private void StartServerButton_Click(object sender, EventArgs e)
    {
        AdbInterface.Server.RestartServer();
        Refresh(sender, e);
    }

    private void KillServerButton_Click(object sender, EventArgs e)
    {
        AdbInterface.Client.KillAdb();
        Refresh(sender, e);
    }
}