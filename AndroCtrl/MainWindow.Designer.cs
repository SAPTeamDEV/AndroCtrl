namespace AndroCtrl;

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
        RefreshButton = new Button();
        PairButton = new Button();
        DisconnectButtun = new Button();
        TCPConnectButton = new Button();
        DeviceSelector = new ComboBox();
        DbgBtn = new Button();
        DeviceGroup.SuspendLayout();
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
        DeviceGroup.Controls.Add(RefreshButton);
        DeviceGroup.Controls.Add(PairButton);
        DeviceGroup.Controls.Add(DisconnectButtun);
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
        // RefreshButton
        // 
        RefreshButton.Location = new Point(119, 86);
        RefreshButton.Name = "RefreshButton";
        RefreshButton.Size = new Size(105, 24);
        RefreshButton.TabIndex = 1;
        RefreshButton.Text = "&Refresh Devices";
        RefreshButton.UseVisualStyleBackColor = true;
        RefreshButton.Click += Refresh;
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
        DisconnectButtun.Location = new Point(6, 86);
        DisconnectButtun.Name = "DisconnectButtun";
        DisconnectButtun.Size = new Size(105, 24);
        DisconnectButtun.TabIndex = 1;
        DisconnectButtun.Text = "Disconnect";
        DisconnectButtun.UseVisualStyleBackColor = true;
        DisconnectButtun.Click += DisconnectButtun_Click;
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
        // DbgBtn
        // 
        DbgBtn.Location = new Point(18, 303);
        DbgBtn.Name = "DbgBtn";
        DbgBtn.Size = new Size(218, 36);
        DbgBtn.TabIndex = 1;
        DbgBtn.Text = "Debug";
        DbgBtn.UseVisualStyleBackColor = true;
        DbgBtn.Click += DbgBtn_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(DbgBtn);
        Controls.Add(DeviceGroup);
        Name = "MainWindow";
        Text = "AndroCtrl";
        Activated += MainWindow_Activated;
        Deactivate += MainWindow_Deactivate;
        FormClosed += MainWindow_FormClosed;
        Load += MainWindow_Load;
        DeviceGroup.ResumeLayout(false);
        DeviceGroup.PerformLayout();
        ResumeLayout(false);
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
    private Button RefreshButton;
    private Button DisconnectButtun;
    private Button DbgBtn;
}