namespace AndroCtrl.Dialogs
{
    partial class QRCodePair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRCodePair));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.QRPairing = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.QRCodeBox = new System.Windows.Forms.PictureBox();
            this.ManualPairing = new System.Windows.Forms.TabPage();
            this.Pair = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PairCode = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.HostName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.QRPairing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).BeginInit();
            this.ManualPairing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.QRPairing);
            this.tabControl1.Controls.Add(this.ManualPairing);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 561);
            this.tabControl1.TabIndex = 1;
            // 
            // QRPairing
            // 
            this.QRPairing.Controls.Add(this.label1);
            this.QRPairing.Controls.Add(this.Title);
            this.QRPairing.Controls.Add(this.QRCodeBox);
            this.QRPairing.Location = new System.Drawing.Point(4, 24);
            this.QRPairing.Name = "QRPairing";
            this.QRPairing.Padding = new System.Windows.Forms.Padding(3);
            this.QRPairing.Size = new System.Drawing.Size(376, 533);
            this.QRPairing.TabIndex = 0;
            this.QRPairing.Text = "Pair with QR Code";
            this.QRPairing.UseVisualStyleBackColor = true;
            this.QRPairing.Enter += new System.EventHandler(this.QRPairing_Enter);
            this.QRPairing.Leave += new System.EventHandler(this.QRPairing_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 90);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(0, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(376, 25);
            this.Title.TabIndex = 2;
            this.Title.Text = "Pair New Devices with QR Code";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRCodeBox
            // 
            this.QRCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QRCodeBox.Location = new System.Drawing.Point(80, 285);
            this.QRCodeBox.Name = "QRCodeBox";
            this.QRCodeBox.Size = new System.Drawing.Size(200, 200);
            this.QRCodeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QRCodeBox.TabIndex = 1;
            this.QRCodeBox.TabStop = false;
            // 
            // ManualPairing
            // 
            this.ManualPairing.Controls.Add(this.Pair);
            this.ManualPairing.Controls.Add(this.label6);
            this.ManualPairing.Controls.Add(this.label5);
            this.ManualPairing.Controls.Add(this.label4);
            this.ManualPairing.Controls.Add(this.PairCode);
            this.ManualPairing.Controls.Add(this.Port);
            this.ManualPairing.Controls.Add(this.HostName);
            this.ManualPairing.Controls.Add(this.label2);
            this.ManualPairing.Controls.Add(this.label3);
            this.ManualPairing.Location = new System.Drawing.Point(4, 24);
            this.ManualPairing.Name = "ManualPairing";
            this.ManualPairing.Padding = new System.Windows.Forms.Padding(3);
            this.ManualPairing.Size = new System.Drawing.Size(376, 533);
            this.ManualPairing.TabIndex = 1;
            this.ManualPairing.Text = "Pair with Pairing Code";
            this.ManualPairing.UseVisualStyleBackColor = true;
            this.ManualPairing.Enter += new System.EventHandler(this.ManualPairing_Enter);
            this.ManualPairing.Leave += new System.EventHandler(this.ManualPairing_Leave);
            // 
            // Pair
            // 
            this.Pair.Location = new System.Drawing.Point(230, 337);
            this.Pair.Name = "Pair";
            this.Pair.Size = new System.Drawing.Size(100, 23);
            this.Pair.TabIndex = 12;
            this.Pair.Text = "Pair Device";
            this.Pair.UseVisualStyleBackColor = true;
            this.Pair.Click += new System.EventHandler(this.Pair_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pairing Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Host Name/IP Address";
            // 
            // PairCode
            // 
            this.PairCode.Location = new System.Drawing.Point(23, 337);
            this.PairCode.Name = "PairCode";
            this.PairCode.Size = new System.Drawing.Size(127, 23);
            this.PairCode.TabIndex = 9;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(230, 285);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(100, 23);
            this.Port.TabIndex = 8;
            // 
            // HostName
            // 
            this.HostName.Location = new System.Drawing.Point(23, 285);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(189, 23);
            this.HostName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 120);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pair New Devices with Pairing Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QRCodePair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "QRCodePair";
            this.Text = "QRCodePair";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QRCodePair_FormClosed);
            this.Load += new System.EventHandler(this.QRCodePair_Load);
            this.tabControl1.ResumeLayout(false);
            this.QRPairing.ResumeLayout(false);
            this.QRPairing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).EndInit();
            this.ManualPairing.ResumeLayout(false);
            this.ManualPairing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage QRPairing;
        private TabPage ManualPairing;
        private PictureBox QRCodeBox;
        private Label Title;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private TextBox PairCode;
        private TextBox Port;
        private TextBox HostName;
        private Label label6;
        private Button Pair;
    }
}