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
            this.QRCodeBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // QRCodeBox
            // 
            this.QRCodeBox.Location = new System.Drawing.Point(250, 131);
            this.QRCodeBox.Name = "QRCodeBox";
            this.QRCodeBox.Size = new System.Drawing.Size(250, 250);
            this.QRCodeBox.TabIndex = 0;
            this.QRCodeBox.TabStop = false;
            // 
            // QRCodePair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.QRCodeBox);
            this.Name = "QRCodePair";
            this.Text = "QRCodePair";
            this.Load += new System.EventHandler(this.QRCodePair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox QRCodeBox;
    }
}