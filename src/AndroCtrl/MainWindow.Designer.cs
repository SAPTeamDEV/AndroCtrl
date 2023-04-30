namespace SAPTeam.AndroCtrl;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DeviceGroup = new GroupBox();
        SDKVersionOut = new TextBox();
        ManufacturerOut = new TextBox();
        BuildFingerprintOut = new TextBox();
        SerialOut = new TextBox();
        DeviceModelOut = new TextBox();
        label4 = new Label();
        label2 = new Label();
        label3 = new Label();
        label5 = new Label();
        label1 = new Label();
        PairButton = new Button();
        DisconnectButtun = new Button();
        RootButton = new Button();
        TCPConnectButton = new Button();
        DeviceSelector = new ComboBox();
        UtilsGroup = new GroupBox();
        RunShellButton = new Button();
        AdbServerGroup = new GroupBox();
        ServerStatus = new Label();
        KillServerButton = new Button();
        RestartServerButton = new Button();
        StartServerButton = new Button();
        StatusBar = new StatusStrip();
        DeviceGroup.SuspendLayout();
        UtilsGroup.SuspendLayout();
        AdbServerGroup.SuspendLayout();
        SuspendLayout();
        // 
        // DeviceGroup
        // 
        DeviceGroup.Controls.Add(SDKVersionOut);
        DeviceGroup.Controls.Add(ManufacturerOut);
        DeviceGroup.Controls.Add(BuildFingerprintOut);
        DeviceGroup.Controls.Add(SerialOut);
        DeviceGroup.Controls.Add(DeviceModelOut);
        DeviceGroup.Controls.Add(label4);
        DeviceGroup.Controls.Add(label2);
        DeviceGroup.Controls.Add(label3);
        DeviceGroup.Controls.Add(label5);
        DeviceGroup.Controls.Add(label1);
        DeviceGroup.Controls.Add(PairButton);
        DeviceGroup.Controls.Add(DisconnectButtun);
        DeviceGroup.Controls.Add(RootButton);
        DeviceGroup.Controls.Add(TCPConnectButton);
        DeviceGroup.Controls.Add(DeviceSelector);
        DeviceGroup.Location = new Point(12, 12);
        DeviceGroup.Name = "DeviceGroup";
        DeviceGroup.Size = new Size(230, 278);
        DeviceGroup.TabIndex = 0;
        DeviceGroup.TabStop = false;
        DeviceGroup.Text = "Devices";
        // 
        // SDKVersionOut
        // 
        SDKVersionOut.Location = new Point(119, 185);
        SDKVersionOut.Name = "SDKVersionOut";
        SDKVersionOut.ReadOnly = true;
        SDKVersionOut.Size = new Size(105, 23);
        SDKVersionOut.TabIndex = 1;
        // 
        // ManufacturerOut
        // 
        ManufacturerOut.Location = new Point(119, 132);
        ManufacturerOut.Name = "ManufacturerOut";
        ManufacturerOut.ReadOnly = true;
        ManufacturerOut.Size = new Size(105, 23);
        ManufacturerOut.TabIndex = 1;
        // 
        // BuildFingerprintOut
        // 
        BuildFingerprintOut.Location = new Point(6, 239);
        BuildFingerprintOut.Name = "BuildFingerprintOut";
        BuildFingerprintOut.ReadOnly = true;
        BuildFingerprintOut.Size = new Size(218, 23);
        BuildFingerprintOut.TabIndex = 1;
        // 
        // SerialOut
        // 
        SerialOut.Location = new Point(6, 185);
        SerialOut.Name = "SerialOut";
        SerialOut.ReadOnly = true;
        SerialOut.Size = new Size(105, 23);
        SerialOut.TabIndex = 1;
        // 
        // DeviceModelOut
        // 
        DeviceModelOut.Location = new Point(6, 132);
        DeviceModelOut.Name = "DeviceModelOut";
        DeviceModelOut.ReadOnly = true;
        DeviceModelOut.Size = new Size(105, 23);
        DeviceModelOut.TabIndex = 1;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(119, 167);
        label4.Name = "label4";
        label4.Size = new Size(94, 15);
        label4.TabIndex = 1;
        label4.Text = "Android Version:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(119, 114);
        label2.Name = "label2";
        label2.Size = new Size(82, 15);
        label2.TabIndex = 1;
        label2.Text = "Manufacturer:";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(6, 114);
        label3.Name = "label3";
        label3.Size = new Size(82, 15);
        label3.TabIndex = 1;
        label3.Text = "Device Model:";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(6, 220);
        label5.Name = "label5";
        label5.Size = new Size(98, 15);
        label5.TabIndex = 1;
        label5.Text = "Build Fingerprint:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(6, 167);
        label1.Name = "label1";
        label1.Size = new Size(85, 15);
        label1.TabIndex = 1;
        label1.Text = "Serial Number:";
        // 
        // PairButton
        // 
        PairButton.Location = new Point(119, 56);
        PairButton.Name = "PairButton";
        PairButton.Size = new Size(105, 24);
        PairButton.TabIndex = 1;
        PairButton.Text = "&Pair New Device";
        PairButton.UseVisualStyleBackColor = true;
        PairButton.Click += PairButton_Click;
        // 
        // DisconnectButtun
        // 
        DisconnectButtun.Enabled = false;
        DisconnectButtun.Location = new Point(119, 86);
        DisconnectButtun.Name = "DisconnectButtun";
        DisconnectButtun.Size = new Size(105, 24);
        DisconnectButtun.TabIndex = 1;
        DisconnectButtun.Text = "Disconnect";
        DisconnectButtun.UseVisualStyleBackColor = true;
        DisconnectButtun.Click += DisconnectButtun_Click;
        // 
        // RootButton
        // 
        RootButton.Location = new Point(8, 86);
        RootButton.Name = "RootButton";
        RootButton.Size = new Size(105, 24);
        RootButton.TabIndex = 1;
        RootButton.Text = "&Root Access";
        RootButton.UseVisualStyleBackColor = true;
        RootButton.Click += RootButton_Click;
        // 
        // TCPConnectButton
        // 
        TCPConnectButton.Location = new Point(6, 56);
        TCPConnectButton.Name = "TCPConnectButton";
        TCPConnectButton.Size = new Size(105, 24);
        TCPConnectButton.TabIndex = 1;
        TCPConnectButton.Text = "TCP/IP &Connect";
        TCPConnectButton.UseVisualStyleBackColor = true;
        TCPConnectButton.Click += TCPConnectButton_Click;
        // 
        // DeviceSelector
        // 
        DeviceSelector.DropDownStyle = ComboBoxStyle.DropDownList;
        DeviceSelector.FormattingEnabled = true;
        DeviceSelector.Location = new Point(6, 22);
        DeviceSelector.Name = "DeviceSelector";
        DeviceSelector.Size = new Size(218, 23);
        DeviceSelector.TabIndex = 2;
        DeviceSelector.SelectedIndexChanged += DeviceSelector_SelectedIndexChanged;
        // 
        // UtilsGroup
        // 
        UtilsGroup.Controls.Add(RunShellButton);
        UtilsGroup.Location = new Point(248, 12);
        UtilsGroup.Name = "UtilsGroup";
        UtilsGroup.Size = new Size(540, 426);
        UtilsGroup.TabIndex = 1;
        UtilsGroup.TabStop = false;
        UtilsGroup.Text = "Utilities";
        // 
        // RunShellButton
        // 
        RunShellButton.Location = new Point(6, 22);
        RunShellButton.Name = "RunShellButton";
        RunShellButton.Size = new Size(102, 23);
        RunShellButton.TabIndex = 0;
        RunShellButton.Text = "Shell Terminal";
        RunShellButton.UseVisualStyleBackColor = true;
        RunShellButton.Click += RunShellButton_Click;
        // 
        // AdbServerGroup
        // 
        AdbServerGroup.Controls.Add(ServerStatus);
        AdbServerGroup.Controls.Add(KillServerButton);
        AdbServerGroup.Controls.Add(RestartServerButton);
        AdbServerGroup.Controls.Add(StartServerButton);
        AdbServerGroup.Location = new Point(12, 296);
        AdbServerGroup.Name = "AdbServerGroup";
        AdbServerGroup.Size = new Size(230, 142);
        AdbServerGroup.TabIndex = 2;
        AdbServerGroup.TabStop = false;
        AdbServerGroup.Text = "Adb Server";
        // 
        // ServerStatus
        // 
        ServerStatus.AutoSize = true;
        ServerStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        ServerStatus.Location = new Point(6, 30);
        ServerStatus.Name = "ServerStatus";
        ServerStatus.Size = new Size(94, 20);
        ServerStatus.TabIndex = 2;
        ServerStatus.Text = "Server Status";
        ServerStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // KillServerButton
        // 
        KillServerButton.Location = new Point(117, 101);
        KillServerButton.Name = "KillServerButton";
        KillServerButton.Size = new Size(105, 24);
        KillServerButton.TabIndex = 1;
        KillServerButton.Text = "&Kill Server";
        KillServerButton.UseVisualStyleBackColor = true;
        KillServerButton.Click += KillServerButton_Click;
        // 
        // RestartServerButton
        // 
        RestartServerButton.Location = new Point(6, 71);
        RestartServerButton.Name = "RestartServerButton";
        RestartServerButton.Size = new Size(216, 24);
        RestartServerButton.TabIndex = 1;
        RestartServerButton.Text = "Restart Server";
        RestartServerButton.UseVisualStyleBackColor = true;
        RestartServerButton.Click += RestartServerButton_Click;
        // 
        // StartServerButton
        // 
        StartServerButton.Location = new Point(6, 101);
        StartServerButton.Name = "StartServerButton";
        StartServerButton.Size = new Size(105, 24);
        StartServerButton.TabIndex = 1;
        StartServerButton.Text = "&Start Server";
        StartServerButton.UseVisualStyleBackColor = true;
        StartServerButton.Click += StartServerButton_Click;
        // 
        // StatusBar
        // 
        StatusBar.Location = new Point(0, 450);
        StatusBar.Name = "StatusBar";
        StatusBar.Size = new Size(800, 22);
        StatusBar.SizingGrip = false;
        StatusBar.TabIndex = 3;
        StatusBar.Text = "statusStrip1";
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 472);
        Controls.Add(StatusBar);
        Controls.Add(AdbServerGroup);
        Controls.Add(UtilsGroup);
        Controls.Add(DeviceGroup);
        KeyPreview = true;
        Name = "MainWindow";
        Text = "AndroCtrl";
        Activated += MainWindow_Activated;
        Deactivate += MainWindow_Deactivate;
        FormClosed += MainWindow_FormClosed;
        Load += MainWindow_Load;
        KeyUp += MainWindow_KeyPress;
        DeviceGroup.ResumeLayout(false);
        DeviceGroup.PerformLayout();
        UtilsGroup.ResumeLayout(false);
        AdbServerGroup.ResumeLayout(false);
        AdbServerGroup.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private GroupBox DeviceGroup;
    private ComboBox DeviceSelector;
    private Button TCPConnectButton;
    private Button PairButton;
    private TextBox ManufacturerOut;
    private TextBox DeviceModelOut;
    private Label label2;
    private Label label1;
    private TextBox SDKVersionOut;
    private TextBox SerialOut;
    private Label label4;
    private Label label3;
    private TextBox BuildFingerprintOut;
    private Label label5;
    private Button DisconnectButtun;
    private GroupBox UtilsGroup;
    private Button RunShellButton;
    private Button RootButton;
    private GroupBox AdbServerGroup;
    private Label ServerStatus;
    private Button KillServerButton;
    private Button RestartServerButton;
    private Button StartServerButton;
    private StatusStrip StatusBar;
}