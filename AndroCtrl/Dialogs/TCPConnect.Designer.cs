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
            this.label1 = new System.Windows.Forms.Label();
            this.IPAddressIn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortIn = new System.Windows.Forms.TextBox();
            this.DoReconnect = new System.Windows.Forms.CheckBox();
            this.DelayIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host name or IP Address:";
            // 
            // IPAddressIn
            // 
            this.IPAddressIn.Location = new System.Drawing.Point(12, 43);
            this.IPAddressIn.Name = "IPAddressIn";
            this.IPAddressIn.Size = new System.Drawing.Size(252, 23);
            this.IPAddressIn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            // 
            // PortIn
            // 
            this.PortIn.Location = new System.Drawing.Point(282, 43);
            this.PortIn.Name = "PortIn";
            this.PortIn.Size = new System.Drawing.Size(90, 23);
            this.PortIn.TabIndex = 1;
            this.PortIn.Text = "5555";
            // 
            // DoReconnect
            // 
            this.DoReconnect.AutoSize = true;
            this.DoReconnect.Location = new System.Drawing.Point(12, 98);
            this.DoReconnect.Name = "DoReconnect";
            this.DoReconnect.Size = new System.Drawing.Size(147, 19);
            this.DoReconnect.TabIndex = 2;
            this.DoReconnect.Text = "Auto-Reconnect every:";
            this.DoReconnect.UseVisualStyleBackColor = true;
            this.DoReconnect.CheckedChanged += new System.EventHandler(this.DoReconnect_CheckedChanged);
            // 
            // DelayIn
            // 
            this.DelayIn.Enabled = false;
            this.DelayIn.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DelayIn.Location = new System.Drawing.Point(165, 98);
            this.DelayIn.Name = "DelayIn";
            this.DelayIn.Size = new System.Drawing.Size(33, 21);
            this.DelayIn.TabIndex = 1;
            this.DelayIn.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seconds";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(282, 95);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(90, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TCPConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.DoReconnect);
            this.Controls.Add(this.DelayIn);
            this.Controls.Add(this.PortIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPAddressIn);
            this.Controls.Add(this.label1);
            this.Name = "TCPConnect";
            this.Text = "Connect via TCP/IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox IPAddressIn;
        private Label label2;
        private TextBox PortIn;
        private CheckBox DoReconnect;
        private TextBox DelayIn;
        private Label label3;
        private Button ConnectButton;
    }
}