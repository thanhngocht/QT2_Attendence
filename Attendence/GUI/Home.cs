using Attendence.BLL;
using Attendence.DTO;
using OfficeOpenXml;
using System.Timers;
using System.Data;
using System.Text;
using Attendence.DAO;


namespace Attendence.GUI
{
    public partial class Home : Form
    {
        private readonly AccountBLL accountBLL = new AccountBLL();
        private readonly FileAccBLL fileBLL = new FileAccBLL();
        private readonly InfoFileBLL infoFileBLL = new InfoFileBLL();
        private readonly AccountDTO account;
        private InfoFileDTO infoFileDTO = new InfoFileDTO();

        private List<string> studentNames = new List<string>();
        private int currentStudentIndex = 0;
        private DataTable fileTable = new DataTable();
        DataTable dataTable = new DataTable();
        private string date = DateTime.Now.ToString("dd/MM/yyyy");
        int countRow = 0;

        private int? numberOfClasses = null;
        private int? percentageOfAbsences = null;
        private int? numberOfAbsences = -1;

        private System.Timers.Timer timer;
        private Random random = new Random();
        private QR displayForm = new QR();
        private double latitude;  // Biến để lưu vĩ độ
        private double longitude; // Biến để lưu kinh độ
        public Home(int accountId)
        {
            InitializeComponent();
            InitializeDataTable();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Cấu hình DataGridView
            ConfigureDataGridViews();

            timer = new System.Timers.Timer(15000); // 15 giây
            timer.Elapsed += OnTimedEvent;
            // Lấy thông tin tài khoản bằng accountId
            account = accountBLL.GetAccountById(accountId);
            if (account != null)
            {
                LoadAccountDetails();
                LoadUserFiles();
            }
            
        }

        private void ConfigureDataGridViews()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            panel_DiemDanh.Visible = false;
            button_Save.Visible = false;
        }

        private void InitializeDataTable()
        {
            fileTable = new DataTable();
            fileTable.Columns.Add("Tên File");
            dataGridView2.DataSource = fileTable;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAccountDetails()
        {
            textBox_Username.Text = account.Username;
            textBox_FullName.Text = account.FullName;
            textBox_FullName.ReadOnly = true;
            textBox_Username.ReadOnly = true;
            textBox_Username.BackColor = Color.White;
            textBox_FullName.BackColor = Color.White;
        }

        private void LoadUserFiles()
        {
            List<string> fileNames = fileBLL.LoadFilesByUser(account.Id);
            foreach (var fileName in fileNames)
            {
                fileTable.Rows.Add(fileName);
            }

            //if (filetable.rows.count > 0)
            //{
            //    string cellvalue = filetable.rows[0][0].tostring();
            //    textbox_namefile.text = cellvalue;

            //    string destinationdirectory = path.combine(appdomain.currentdomain.basedirectory, $"yourdestinationfolder\\{account.id}");
            //    string filepath = path.combine(destinationdirectory, cellvalue);
            //    loaddatafromexcel(filepath);
            //}
        }

        public void InsertFileAcc(string filename)
        {
            fileBLL.InsertFile(new FileAccDTO { FileName = filename, AccountId = account.Id });
        }

        private void LoadDataFromExcel(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File không tồn tại.");
                return;
            }
            string fileName = Path.GetFileName(filePath);
            int fileId = fileBLL.GetFileIdByName(fileName);
            if (fileId == -1) // Giả sử -1 là giá trị không hợp lệ
            {
                MessageBox.Show("Không tìm thấy FileId tương ứng với tên file.");
                return;
            }
            infoFileDTO = infoFileBLL.GetInfoFile(fileId);
            numberOfClasses = infoFileDTO.NumberOfLessons;
            percentageOfAbsences = infoFileDTO.AbsencePercentage;
            numberOfAbsences = (int)((numberOfClasses * percentageOfAbsences) / 100);
            textBox_numberOfAbsences.Text = numberOfAbsences.ToString();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[1]; // Lấy worksheet đầu tiên
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;
                dataTable = new DataTable();

                // Thêm các cột vào DataTable
                for (int col = 1; col <= colCount; col++)
                {
                    dataTable.Columns.Add(worksheet.Cells[1, col].Text); // Lấy tên cột từ hàng đầu tiên
                }

                // Đọc dữ liệu từ các hàng và thêm vào DataTable
                for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2 để bỏ qua tiêu đề
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= colCount; col++)
                    {
                        dataRow[col - 1] = worksheet.Cells[row, col].Text; // Lấy giá trị ô
                    }
                    dataTable.Rows.Add(dataRow); // Thêm hàng vào DataTable
                }

                // Gán DataTable cho DataGridView
                dataGridView1.DataSource = dataTable;
                countRow = dataTable.Columns.Count;
                // Cập nhật số lượng sinh viên
                textBox_TotalSV.Text = dataTable.Rows.Count.ToString(); // Cập nhật Label

                // Tô màu cho các ô trong DataGridView dựa trên màu từ Excel
                for (int row = 2; row <= rowCount; row++) // Bắt đầu từ hàng 2
                {
                    
                    for (int col = 1; col <= colCount; col++)
                    {
                        // Lấy màu nền của ô từ Excel
                        var cell = worksheet.Cells[row, col];
                        if (cell.Style.Fill.PatternType == OfficeOpenXml.Style.ExcelFillStyle.Solid)
                        {
                            // Lấy mã màu HEX từ Excel
                            string hexColor = cell.Style.Fill.BackgroundColor.Rgb;
                            // Chuyển đổi mã màu HEX sang Color

                            // Chuyển đổi mã màu HEX sang ARGB
                            if (!string.IsNullOrEmpty(hexColor))
                            {
                                int argb = int.Parse(hexColor, System.Globalization.NumberStyles.HexNumber);
                                Color cellColor = Color.FromArgb(argb);
                                // Áp dụng màu nền cho ô trong DataGridView
                                dataGridView1.Rows[row - 2].Cells[col - 1].Style.BackColor = cellColor; // Tô màu cho ô tương ứng
                            }
                        }
                    }
                }
            }
        }



        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào hàng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy tên file từ cột đầu tiên
                string fileName = "" + dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @$"YourDestinationFolder\{account.Id}", fileName); // Đường dẫn đầy đủ đến file
                // Gọi hàm để load dữ liệu từ file Excel
                textBox_NameFile.Text = fileName;
                LoadDataFromExcel(filePath);
                resetButton();
            }
        }

        private void resetButton()
        {
            button_CoMat.Enabled = true;
            button_Vang.Enabled = true;
            button_DiemDanh.Enabled = true;
            currentStudentIndex = 0;
            panel_DiemDanh.Visible = false;
        }

        private void button_AddList_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Thư mục khởi đầu
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; // Lọc file
                openFileDialog.Title = "Chọn file để tải lên";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName; // Lấy đường dẫn file đã chọn
                    SaveFile(filePath); // Lưu file
                    LoadDataFromExcel(filePath); // Gọi hàm load dữ liệu từ file Excel
                }
            }
        }

        private void SaveFile(string sourceFilePath)
        {
            string destinationDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"YourDestinationFolder\\{account.Id}"); // Đường dẫn thư mục lưu file
            string fileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

            // Kiểm tra xem thư mục đã tồn tại chưa, nếu chưa thì tạo mới
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Sao chép file từ vị trí đã chọn đến thư mục đích
            File.Copy(sourceFilePath, destinationFilePath, true); // true để ghi đè nếu file đã tồn tại

            // Kiểm tra xem tên file đã tồn tại trong DataGridView chưa
            if (!IsFileNameExists(fileName))
            {
                fileTable.Rows.Add(fileName); // Thêm tên file vào DataTable
                InsertFileAcc(fileName); // Lưu thông tin file vào cơ sở dữ liệu
            }
        }

        private bool IsFileNameExists(string fileName)
        {
            // Duyệt qua tất cả các hàng trong DataGridView để kiểm tra tên file
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value?.ToString() == fileName)
                {
                    return true; // Tên file đã tồn tại
                }
            }
            return false; // Tên file chưa tồn tại
        }

        private void button_DiemDanh_Click(object sender, EventArgs e)
        {
            currentStudentIndex = 0;
            panel_DiemDanh.Visible = !panel_DiemDanh.Visible; // Chuyển đổi trạng thái hiển thị của panel
            LoadStudentNamesFromDataGridView(); // Tải tên sinh viên từ DataGridView
            AddDateColumn(); // Thêm cột ngày tháng
            button_DiemDanh.Enabled = false; // Vô hiệu hóa nút điểm danh
            button_Save.Visible = true; // Hiển thị nút lưu
            button_Save.Enabled = true; // Kích hoạt nút lưu
            ShowNextStudent(); // Hiển thị sinh viên tiếp theo
        }

        private void AddDateColumn()
        {
            string dateColumnName = date.ToString();
            if (!CheckColumnExists(dateColumnName))
            {
                dataTable.Columns.Add(dateColumnName); // Thêm cột ngày tháng nếu chưa tồn tại
                countRow++;
            }
            textBox_CountTotal.Text = CountPresentStudents().ToString(); // Cập nhật số lượng sinh viên có mặt
        }

        private bool CheckColumnExists(string columnName)
        {
            // Duyệt qua tất cả các cột trong DataGridView
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Cột đã tồn tại
                }
            }
            return false; // Cột không tồn tại
        }

        private int CountPresentStudents()
        {
            int count = 0; // Biến đếm số lượng sinh viên có mặt
            int statusColumnIndex = dataTable.Columns.Count - 1; // Chỉ số cột trạng thái

            // Kiểm tra xem cột trạng thái có tồn tại không
            if (statusColumnIndex < 0 || statusColumnIndex >= dataGridView1.Columns.Count)
            {
                MessageBox.Show("Cột trạng thái không hợp lệ." + statusColumnIndex.ToString());
                return count; // Trả về 0 nếu cột không hợp lệ
            }

            // Lặp qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng mới
                {
                    // Kiểm tra giá trị trong cột trạng thái
                    if (row.Cells[statusColumnIndex].Value != null && row.Cells[statusColumnIndex].Value.ToString() == "Có mặt")
                    {
                        count++; // Tăng biến đếm nếu giá trị là "Có mặt"
                    }
                }
            }

            return count; // Trả về số lượng sinh viên có mặt
        }


        private void ShowNextStudent()
        {
            if (currentStudentIndex < studentNames.Count)
            {
                textBox_StudentName.Text = studentNames[currentStudentIndex]; // Hiển thị tên sinh viên tiếp theo
            }
            else
            {
                textBox_StudentName.Text = "Đã điểm danh hết sinh viên."; // Thông báo đã điểm danh hết
                button_CoMat.Enabled = false; // Vô hiệu hóa nút "Có mặt"
                button_Vang.Enabled = false; // Vô hiệu hóa nút "Vắng"
                button_DiemDanh.Enabled = true; // Kích hoạt lại nút điểm danh
            }
        }


        private void LoadStudentNamesFromDataGridView()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng mới
                {
                    // Lấy tên sinh viên từ các ô cụ thể
                    string studentName = $"{row.Cells[1].Value} {row.Cells[2].Value} {row.Cells[3].Value}";
                    studentNames.Add(studentName);
                }
            }
        }

        private void button_CoMat_Click(object sender, EventArgs e)
        {
            MarkAttendance("Có mặt");
        }

        private void button_Vang_Click(object sender, EventArgs e)
        {
            MarkAttendance("Vắng");
        }

        private void MarkAttendance(string status)
        {
            if (currentStudentIndex < studentNames.Count)
            {
                dataGridView1.Rows[currentStudentIndex].Cells[countRow - 1].Value = status; // Đánh dấu trạng thái

                // Kiểm tra số buổi vắng và tô màu
                int absences = CountAbsences(currentStudentIndex); // Hàm này cần được định nghĩa để đếm số buổi vắng
                CheckAttendance(absences, currentStudentIndex); // Kiểm tra và tô màu cho sinh viên

                currentStudentIndex++;
                ShowNextStudent();
                textBox_CountTotal.Text = CountPresentStudents().ToString(); // Cập nhật số lượng sinh viên có mặt
            }
        }

        private void CheckAttendance(int absences, int studentRowIndex)
        {
            // Kiểm tra nếu số buổi học và phần trăm buổi nghỉ không null
            if (numberOfClasses.HasValue && percentageOfAbsences.HasValue)
            {
                // Tính số buổi vắng cho phép
                int allowedAbsences = (int)((numberOfClasses * percentageOfAbsences) / 100);
                // Kiểm tra số buổi vắng
                if (absences > allowedAbsences)
                {
                    // Tô đỏ nếu số buổi vắng vượt quá cho phép
                    HighlightStudent(studentRowIndex, Color.Red);
                }
                else if (absences == allowedAbsences)
                {
                    // Cảnh báo bằng màu vàng nếu vắng vừa đủ
                    HighlightStudent(studentRowIndex, Color.Yellow);
                }
                else
                {
                    // Nếu không vắng, có thể tô màu xanh hoặc không làm gì
                    HighlightStudent(studentRowIndex, Color.White); // Ví dụ tô màu xanh nếu không vắng
                }
            }
            else
            {
                MessageBox.Show("Số buổi học hoặc phần trăm buổi nghỉ chưa được thiết lập.");
            }
        }

        private int CountAbsences(int studentIndex)
        {
            int absencesCount = 0; // Biến đếm số buổi vắng
            int startColumnIndex = 5; // Thay thế bằng chỉ số cột ngày tháng thực tế

            // Lặp qua tất cả các cột từ cột ngày tháng đến cột cuối cùng
            for (int col = startColumnIndex; col < dataGridView1.Columns.Count; col++)
            {
                // Kiểm tra giá trị trong ô tương ứng
                var cellValue = dataGridView1.Rows[studentIndex].Cells[col].Value;
                if (cellValue != null && cellValue.ToString() == "Vắng") // Kiểm tra nếu giá trị là "Vắng"
                {
                    absencesCount++; // Tăng biến đếm nếu sinh viên vắng
                }
            }

            return absencesCount; // Trả về số buổi vắng
        }


        private void HighlightStudent(int rowIndex, Color color)
        {
            // Kiểm tra chỉ số dòng hợp lệ
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    // Áp dụng màu nền cho ô trong hàng
                    dataGridView1.Rows[rowIndex].Cells[col].Style.BackColor = color;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấp vào một ô hợp lệ không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                currentStudentIndex = e.RowIndex; // Lưu chỉ số sinh viên hiện tại
                string studentName = $"{dataGridView1.Rows[e.RowIndex].Cells[1].Value} {dataGridView1.Rows[e.RowIndex].Cells[2].Value} {dataGridView1.Rows[e.RowIndex].Cells[3].Value}";
                textBox_StudentName.Text = studentName; // Hiển thị tên sinh viên trong TextBox
            }
        }

        private void button_QR_Click(object sender, EventArgs e)
        {
            FormStudent formStudent = new FormStudent();
            formStudent.OnGpsDataReceived += FormStudent_OnGpsDataReceived; // Đăng ký sự kiện
            formStudent.Show(); // Hiển thị FormStudent
            
        }

        private void FormStudent_OnGpsDataReceived(double latitudeForm, double longitudeForm)
        {
            latitude = latitudeForm;
            longitude = longitudeForm;
            // Xử lý dữ liệu GPS nhận được từ FormStudent
            MessageBox.Show($"Dữ liệu GPS từ FormStudent:\nVĩ độ: {latitude}\nKinh độ: {longitude}");
            displayForm = new QR();
            displayForm.FormClosing += QR_FormClosing; // Đăng ký sự kiện FormClosed
            timer.Start();
            GenerateAndDisplayQRCode();
            displayForm.Show();
        }

        private void QR_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đóng form?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy bỏ việc đóng form
            }
            if (result == DialogResult.Yes)
            {
                TeacherQRDataBLL teacherQRDataBLL = new TeacherQRDataBLL();
                //teacherQRDataBLL.DeleteAllQRData();
                List<string> listIds = LoadStudentIds();
                AddDateColumn();
                MarkAttendanceQR(listIds);
                timer.Stop();
            }
        }

        private List<string> LoadStudentIds()
        {
            StudentUploadDAO studentUploadDAO = new StudentUploadDAO();
            List<string> studentIds = studentUploadDAO.GetAllStudentIds();
            return studentIds;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            GenerateAndDisplayQRCode();
        }



        private void GenerateAndDisplayQRCode()
        {
            string qrCode = random.Next(10000, 99999).ToString(); // Tạo mã 5 số ngẫu nhiên
            string gpsCoordinates =  longitude + "," + latitude;
            TeacherQRDataBLL teacherQRDataBLL = new TeacherQRDataBLL();
            teacherQRDataBLL.SaveQRCode(qrCode, gpsCoordinates);

            // Cập nhật mã QR trên form hiển thị
            if (displayForm != null && !displayForm.IsDisposed)
            {
                displayForm.UpdateQRCode(qrCode);
            }
        }

        private void MarkAttendanceQR(List<string> listIDs)
        {
            // Duyệt qua từng dòng trong DataGridView
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Lấy mã sinh viên từ cột đầu tiên
                string studentId = dataGridView1.Rows[i].Cells[2].Value?.ToString(); // Sử dụng ? để tránh NullReferenceException

                // Kiểm tra xem mã sinh viên có trong danh sách không
                if (listIDs.Contains(studentId)) {
                    dataGridView1.Rows[i].Cells[countRow - 1].Value = "Có mặt";
                }

                // Cập nhật trạng thái vào cột ngoài cùng bên phải
                if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[countRow - 1].Value.ToString())){
                    dataGridView1.Rows[i].Cells[countRow - 1].Value = "Vắng";
                }

                // Kiểm tra số buổi vắng và tô màu
                int absences = CountAbsences(i); // Hàm này cần được định nghĩa để đếm số buổi vắng
                CheckAttendance(absences, i); // Kiểm tra và tô màu cho sinh viên
            }

            // Cập nhật số lượng sinh viên có mặt
            textBox_CountTotal.Text = CountPresentStudents().ToString();
        }

        

        private void button_Save_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel(); // Xuất dữ liệu từ DataGridView sang Excel
            panel_DiemDanh.Visible = !panel_DiemDanh.Visible; // Chuyển đổi trạng thái hiển thị của panel
            button_DiemDanh.Enabled = true; // Kích hoạt lại nút điểm danh
        }

        private void ExportDataGridViewToExcel()
        {
            if (dataGridView2.CurrentCell == null)
                return; // Kiểm tra xem có ô nào được chọn không

            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            string fileName = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"YourDestinationFolder\\{account.Id}", fileName);

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Thêm tiêu đề cột vào worksheet
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                }

                // Thêm dữ liệu từ DataGridView vào worksheet
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Thêm dữ liệu
                        worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                        Color cellColor = dataGridView1.Rows[i].Cells[j].Style.BackColor;

                        worksheet.Cells[i + 2, j + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[i + 2, j + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(cellColor.R, cellColor.G, cellColor.B));
                    }
                }

                // Lưu file Excel
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
            }
        }



        private void button_In_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; // Lọc file
                saveFileDialog.Title = "Chọn vị trí lưu file";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Lấy đường dẫn file đã chọn
                    ExportToExcel(filePath); // Gọi hàm xuất file Excel
                    MessageBox.Show("File đã được lưu thành công!");
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Tạo Worksheet mới
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Lấy dữ liệu từ DataGridView và thêm vào Worksheet
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText; // Thêm tiêu đề cột
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Thêm dữ liệu
                        worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                        Color cellColor = dataGridView1.Rows[i].Cells[j].Style.BackColor;

                        worksheet.Cells[i + 2, j + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[i + 2, j + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(cellColor.R, cellColor.G, cellColor.B));
                    }
                }

                // Lưu file Excel
                FileInfo fileInfo = new FileInfo(filePath);
                excelPackage.SaveAs(fileInfo);
            }
        }

        private void HighlightAbsentStudents(int totalClasses, double allowedPercentage)
        {
            int allowedAbsences = (int)(totalClasses * (allowedPercentage / 100));
            int countRow = dataTable.Columns.Count - 1; // Giả sử cột trạng thái là cột cuối cùng
            int colorColumnIndex = dataTable.Columns.Count; // Cột để lưu màu sắc

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng mới
                {
                    int absences = CountAbsences(Convert.ToInt32(row.Cells[0].Value) - 1);
                    // Kiểm tra trạng thái của sinh viên
                    // Tô đỏ nếu số buổi nghỉ vượt quá số buổi cho phép
                    if (absences > allowedAbsences)
                    {
                        // Tô đỏ nếu số buổi vắng vượt quá cho phép
                        HighlightStudent(row.Index, Color.Red);
                    }
                    else if (absences == allowedAbsences)
                    {
                        // Cảnh báo bằng màu vàng nếu vắng vừa đủ
                        HighlightStudent(row.Index, Color.Yellow);
                    }
                    else
                    {
                        // Nếu không vắng, có thể tô màu xanh hoặc không làm gì
                        HighlightStudent(row.Index, Color.White); // Ví dụ tô màu xanh nếu không vắng
                    }
                }
            }
        }

        private void button_Setting_Click(object sender, EventArgs e)
        {
            InfForm infoForm = new InfForm();
            if (infoForm.ShowDialog() == DialogResult.OK)
            {
                // Nhận giá trị từ InfoForm
                numberOfClasses = infoForm.Value1;
                percentageOfAbsences = infoForm.Value2;
                numberOfAbsences = (int)((numberOfAbsences * percentageOfAbsences) / 100);
                textBox_numberOfAbsences.Text = numberOfAbsences.ToString();
                infoFileDTO.NumberOfLessons = (int)numberOfClasses;
                infoFileDTO.AbsencePercentage = (int)percentageOfAbsences;
                infoFileBLL.ModifyInfoFile(infoFileDTO);
                HighlightAbsentStudents(infoFileDTO.NumberOfLessons, infoFileDTO.AbsencePercentage);
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.SelectedCells[0].RowIndex; // Lấy chỉ số dòng được chọn
            string fileName = dataGridView2.Rows[rowIndex].Cells["Tên file"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                fileBLL.DeleteFileByName(fileName);
                // Xóa dòng trong DataTable
                DataTable dt = (DataTable)dataGridView2.DataSource; // Giả sử DataSource là DataTable
                dt.Rows[rowIndex].Delete(); // Xóa dòng
                dt.AcceptChanges(); // Cập nhật DataTable
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu nhấn vào một ô
            {
                // Hiển thị menu ngữ cảnh tại vị trí chuột
                contextMenu.Show(dataGridView2, dataGridView2.PointToClient(Cursor.Position));
            }
        }
    }
}
