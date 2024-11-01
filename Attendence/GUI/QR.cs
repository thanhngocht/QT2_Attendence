using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;
using System.Windows.Forms;
using Attendence.BLL;

namespace Attendence.GUI
{
    public partial class QR : Form
    {
        private PictureBox pictureBox = new PictureBox();
        private string link = "Hello";
        public QR()
        {
            this.Controls.Add(pictureBox);
            InitializeComponent();
            GenerateQRCode(link);
        }

        public void GenerateQRCode(string link)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    pictureBox1.Image = ResizeImage(qrCodeImage, pictureBox1.Width, pictureBox1.Height);
                }
            }
        }

        private Bitmap ResizeImage(Bitmap img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }
        public void UpdateQRCode(string qrCode)
        {
            if (txtQRCode.InvokeRequired)
            {
                txtQRCode.Invoke(new Action(() => txtQRCode.Text = qrCode));
            }
            else
            {
                txtQRCode.Text = qrCode;
            }
            // Cập nhật Label hiển thị mã QR
        }

    }
}
