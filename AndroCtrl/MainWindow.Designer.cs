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
            this.DeviceGroup = new System.Windows.Forms.GroupBox();
            this.SDKVersionOut = new System.Windows.Forms.TextBox();
            this.ManufacturerOut = new System.Windows.Forms.TextBox();
            this.BuildFingerprintOut = new System.Windows.Forms.TextBox();
            this.SerialOut = new System.Windows.Forms.TextBox();
            this.DeviceModelOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PairButton = new System.Windows.Forms.Button();
            this.TCPConnectButton = new System.Windows.Forms.Button();
            this.DeviceSelector = new System.Windows.Forms.ComboBox();
            this.DeviceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceGroup
            // 
            this.DeviceGroup.Controls.Add(this.SDKVersionOut);
            this.DeviceGroup.Controls.Add(this.ManufacturerOut);
            this.DeviceGroup.Controls.Add(this.BuildFingerprintOut);
            this.DeviceGroup.Controls.Add(this.SerialOut);
            this.DeviceGroup.Controls.Add(this.DeviceModelOut);
            this.DeviceGroup.Controls.Add(this.label4);
            this.DeviceGroup.Controls.Add(this.label2);
            this.DeviceGroup.Controls.Add(this.label3);
            this.DeviceGroup.Controls.Add(this.label5);
            this.DeviceGroup.Controls.Add(this.label1);
            this.DeviceGroup.Controls.Add(this.PairButton);
            this.DeviceGroup.Controls.Add(this.TCPConnectButton);
            this.DeviceGroup.Controls.Add(this.DeviceSelector);
            this.DeviceGroup.Location = new System.Drawing.Point(12, 12);
            this.DeviceGroup.Name = "DeviceGroup";
            this.DeviceGroup.Size = new System.Drawing.Size(230, 278);
            this.DeviceGroup.TabIndex = 0;
            this.DeviceGroup.TabStop = false;
            this.DeviceGroup.Text = "Devices";
            // 
            // SDKVersionOut
            // 
            this.SDKVersionOut.Location = new System.Drawing.Point(119, 185);
            this.SDKVersionOut.Name = "SDKVersionOut";
            this.SDKVersionOut.ReadOnly = true;
            this.SDKVersionOut.Size = new System.Drawing.Size(105, 23);
            this.SDKVersionOut.TabIndex = 1;
            // 
            // ManufacturerOut
            // 
            this.ManufacturerOut.Location = new System.Drawing.Point(119, 132);
            this.ManufacturerOut.Name = "ManufacturerOut";
            this.ManufacturerOut.ReadOnly = true;
            this.ManufacturerOut.Size = new System.Drawing.Size(105, 23);
            this.ManufacturerOut.TabIndex = 1;
            // 
            // BuildFingerprintOut
            // 
            this.BuildFingerprintOut.Location = new System.Drawing.Point(6, 239);
            this.BuildFingerprintOut.Name = "BuildFingerprintOut";
            this.BuildFingerprintOut.ReadOnly = true;
            this.BuildFingerprintOut.Size = new System.Drawing.Size(218, 23);
            this.BuildFingerprintOut.TabIndex = 1;
            // 
            // SerialOut
            // 
            this.SerialOut.Location = new System.Drawing.Point(6, 185);
            this.SerialOut.Name = "SerialOut";
            this.SerialOut.ReadOnly = true;
            this.SerialOut.Size = new System.Drawing.Size(105, 23);
            this.SerialOut.TabIndex = 1;
            // 
            // DeviceModelOut
            // 
            this.DeviceModelOut.Location = new System.Drawing.Point(6, 132);
            this.DeviceModelOut.Name = "DeviceModelOut";
            this.DeviceModelOut.ReadOnly = true;
            this.DeviceModelOut.Size = new System.Drawing.Size(105, 23);
            this.DeviceModelOut.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Android Version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manufacturer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Build Fingerprint:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Number:";
            // 
            // PairButton
            // 
            this.PairButton.Location = new System.Drawing.Point(119, 56);
            this.PairButton.Name = "PairButton";
            this.PairButton.Size = new System.Drawing.Size(105, 24);
            this.PairButton.TabIndex = 1;
            this.PairButton.Text = "&Pair New Device";
            this.PairButton.UseVisualStyleBackColor = true;
            // 
            // TCPConnectButton
            // 
            this.TCPConnectButton.Location = new System.Drawing.Point(6, 56);
            this.TCPConnectButton.Name = "TCPConnectButton";
            this.TCPConnectButton.Size = new System.Drawing.Size(105, 24);
            this.TCPConnectButton.TabIndex = 1;
            this.TCPConnectButton.Text = "TCP/IP &Connect";
            this.TCPConnectButton.UseVisualStyleBackColor = true;
            // 
            // DeviceSelector
            // 
            this.DeviceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceSelector.FormattingEnabled = true;
            this.DeviceSelector.Location = new System.Drawing.Point(6, 22);
            this.DeviceSelector.Name = "DeviceSelector";
            this.DeviceSelector.Size = new System.Drawing.Size(218, 23);
            this.DeviceSelector.TabIndex = 2;
            this.DeviceSelector.SelectedIndexChanged += new System.EventHandler(this.DeviceSelector_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeviceGroup);
            this.Name = "MainWindow";
            this.Text = "AndroCtrl";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DeviceGroup.ResumeLayout(false);
            this.DeviceGroup.PerformLayout();
            this.ResumeLayout(false);

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
}