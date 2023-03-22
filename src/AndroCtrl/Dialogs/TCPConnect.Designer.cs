namespace AndroCtrl.Dialogs
{
    partial class TCPConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            PortIn = new TextBox();
            DoReconnect = new CheckBox();
            DelayIn = new TextBox();
            label3 = new Label();
            ConnectButton = new Button();
            IPAddressIn = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 0;
            label1.Text = "Host name or IP Address:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 25);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 0;
            label2.Text = "Port:";
            // 
            // PortIn
            // 
            PortIn.Location = new Point(282, 43);
            PortIn.Name = "PortIn";
            PortIn.Size = new Size(90, 23);
            PortIn.TabIndex = 1;
            PortIn.Text = "5555";
            PortIn.KeyPress += KeyHandler;
            // 
            // DoReconnect
            // 
            DoReconnect.AutoSize = true;
            DoReconnect.Enabled = false;
            DoReconnect.Location = new Point(12, 98);
            DoReconnect.Name = "DoReconnect";
            DoReconnect.Size = new Size(147, 19);
            DoReconnect.TabIndex = 3;
            DoReconnect.Text = "Auto-Reconnect every:";
            DoReconnect.UseVisualStyleBackColor = true;
            DoReconnect.CheckedChanged += DoReconnect_CheckedChanged;
            // 
            // DelayIn
            // 
            DelayIn.Enabled = false;
            DelayIn.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point);
            DelayIn.Location = new Point(165, 98);
            DelayIn.Name = "DelayIn";
            DelayIn.Size = new Size(33, 21);
            DelayIn.TabIndex = 1;
            DelayIn.Text = "15";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 99);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 0;
            label3.Text = "Seconds";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(282, 95);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(90, 23);
            ConnectButton.TabIndex = 2;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // IPAddressIn
            // 
            IPAddressIn.FormattingEnabled = true;
            IPAddressIn.Location = new Point(12, 43);
            IPAddressIn.Name = "IPAddressIn";
            IPAddressIn.Size = new Size(252, 23);
            IPAddressIn.TabIndex = 0;
            IPAddressIn.KeyPress += IPAddressIn_KeyPress;
            // 
            // TCPConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(IPAddressIn);
            Controls.Add(ConnectButton);
            Controls.Add(DoReconnect);
            Controls.Add(DelayIn);
            Controls.Add(PortIn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TCPConnect";
            Text = "Connect via TCP/IP";
            FormClosed += TCPConnect_FormClosed;
            Load += TCPConnect_Load;
            KeyPress += KeyHandler;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox PortIn;
        private CheckBox DoReconnect;
        private TextBox DelayIn;
        private Label label3;
        private Button ConnectButton;
        private ComboBox IPAddressIn;
    }
}