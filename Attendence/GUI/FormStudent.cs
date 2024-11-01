using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core; // Đảm bảo import đúng namespace này

namespace Attendence.GUI
{
    public partial class FormStudent : Form
    {
        private WebView2 webView;
        private double latitude;  // Biến để lưu vĩ độ
        private double longitude; // Biến để lưu kinh độ
        public event Action<double, double> OnGpsDataReceived;
        public FormStudent()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);
            await webView.EnsureCoreWebView2Async(null);
            webView.Source = new Uri(@"file:///C:/xampp/htdocs/Form/check.html"); // Đường dẫn đến file HTML của bạn
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
            // Đăng ký sự kiện khi trang đã tải xong
            webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Gọi hàm JavaScript để lấy GPS ngay khi trang đã tải xong
            webView.ExecuteScriptAsync("getData();"); // Gọi hàm getData() trong HTML
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e) // Sử dụng đúng kiểu
        {
            var message = e.TryGetWebMessageAsString();
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(message);
            latitude = data.latitude;   // Lưu vĩ độ
            longitude = data.longitude;  // Lưu kinh độ
            var result = MessageBox.Show($"Dữ liệu GPS nhận được:\nVĩ độ: {latitude}\nKinh độ: {longitude}\nBạn có muốn gửi dữ liệu này không?", "Xác nhận", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // Gọi sự kiện để gửi dữ liệu về Form A
                OnGpsDataReceived?.Invoke(latitude, longitude);
                this.Close(); // Đóng FormStudent
            }
        }
    }
}