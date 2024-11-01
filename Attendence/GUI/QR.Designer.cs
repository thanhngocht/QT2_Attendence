namespace Attendence.GUI
{
    partial class QR
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
            txtQRCode = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtQRCode
            // 
            txtQRCode.Location = new Point(111, 23);
            txtQRCode.Name = "txtQRCode";
            txtQRCode.ReadOnly = true;
            txtQRCode.Size = new Size(254, 27);
            txtQRCode.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 23);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(33, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(332, 271);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // QR
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 375);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(txtQRCode);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QR";
            Text = "Mã QR";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQRCode;
        private Label label1;
        private PictureBox pictureBox1;
    }
}