namespace Attendence.GUI
{
    partial class Home
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel_account = new Panel();
            textBox_FullName = new TextBox();
            textBox_Username = new TextBox();
            label_savedList = new Label();
            dataGridView2 = new DataGridView();
            label_FullName = new Label();
            label2 = new Label();
            label_NameLogin = new Label();
            label_NameInf = new Label();
            panel_List = new Panel();
            textBox_numberOfAbsences = new TextBox();
            label_numberOfAbsences = new Label();
            textBox_NameFile = new TextBox();
            panel_DiemDanh = new Panel();
            label_HienDien = new Label();
            textBox_CountTotal = new TextBox();
            button_Vang = new Button();
            button_CoMat = new Button();
            textBox_StudentName = new TextBox();
            textBox_TotalSV = new TextBox();
            label_TotalSV = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            button_AddList = new Button();
            button_DiemDanh = new Button();
            button_In = new Button();
            button_Save = new Button();
            button_QR = new Button();
            button_Setting = new Button();
            contextMenu = new ContextMenuStrip(components);
            deleteItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel_account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel_List.SuspendLayout();
            panel_DiemDanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel_account
            // 
            panel_account.Controls.Add(textBox_FullName);
            panel_account.Controls.Add(textBox_Username);
            panel_account.Controls.Add(label_savedList);
            panel_account.Controls.Add(dataGridView2);
            panel_account.Controls.Add(label_FullName);
            panel_account.Controls.Add(label2);
            panel_account.Controls.Add(label_NameLogin);
            panel_account.Controls.Add(label_NameInf);
            panel_account.Location = new Point(0, 0);
            panel_account.Name = "panel_account";
            panel_account.Size = new Size(250, 488);
            panel_account.TabIndex = 0;
            // 
            // textBox_FullName
            // 
            textBox_FullName.Location = new Point(9, 156);
            textBox_FullName.Name = "textBox_FullName";
            textBox_FullName.Size = new Size(222, 27);
            textBox_FullName.TabIndex = 7;
            // 
            // textBox_Username
            // 
            textBox_Username.Location = new Point(12, 77);
            textBox_Username.Name = "textBox_Username";
            textBox_Username.Size = new Size(222, 27);
            textBox_Username.TabIndex = 6;
            // 
            // label_savedList
            // 
            label_savedList.AutoSize = true;
            label_savedList.Location = new Point(38, 227);
            label_savedList.Name = "label_savedList";
            label_savedList.Size = new Size(123, 20);
            label_savedList.TabIndex = 5;
            label_savedList.Text = "Danh sách đã lưu";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(3, 264);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(247, 224);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellClick += DataGridView2_CellClick;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // label_FullName
            // 
            label_FullName.AutoSize = true;
            label_FullName.Location = new Point(12, 117);
            label_FullName.Name = "label_FullName";
            label_FullName.Size = new Size(73, 20);
            label_FullName.TabIndex = 3;
            label_FullName.Text = "Họ và tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 140);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 2;
            // 
            // label_NameLogin
            // 
            label_NameLogin.AutoSize = true;
            label_NameLogin.Location = new Point(3, 54);
            label_NameLogin.Name = "label_NameLogin";
            label_NameLogin.Size = new Size(107, 20);
            label_NameLogin.TabIndex = 1;
            label_NameLogin.Text = "Tên đăng nhập";
            // 
            // label_NameInf
            // 
            label_NameInf.AutoSize = true;
            label_NameInf.Location = new Point(38, 9);
            label_NameInf.Name = "label_NameInf";
            label_NameInf.Size = new Size(141, 20);
            label_NameInf.TabIndex = 0;
            label_NameInf.Text = "Thông tin tài khoản ";
            // 
            // panel_List
            // 
            panel_List.Controls.Add(textBox_numberOfAbsences);
            panel_List.Controls.Add(label_numberOfAbsences);
            panel_List.Controls.Add(textBox_NameFile);
            panel_List.Controls.Add(panel_DiemDanh);
            panel_List.Controls.Add(textBox_TotalSV);
            panel_List.Controls.Add(label_TotalSV);
            panel_List.Controls.Add(dataGridView1);
            panel_List.Controls.Add(panel1);
            panel_List.Location = new Point(256, -2);
            panel_List.Name = "panel_List";
            panel_List.Size = new Size(731, 488);
            panel_List.TabIndex = 1;
            // 
            // textBox_numberOfAbsences
            // 
            textBox_numberOfAbsences.Location = new Point(376, 2);
            textBox_numberOfAbsences.Name = "textBox_numberOfAbsences";
            textBox_numberOfAbsences.Size = new Size(103, 27);
            textBox_numberOfAbsences.TabIndex = 9;
            // 
            // label_numberOfAbsences
            // 
            label_numberOfAbsences.AutoSize = true;
            label_numberOfAbsences.Location = new Point(278, 10);
            label_numberOfAbsences.Name = "label_numberOfAbsences";
            label_numberOfAbsences.Size = new Size(96, 20);
            label_numberOfAbsences.TabIndex = 8;
            label_numberOfAbsences.Text = "Số buổi nghỉ:";
            // 
            // textBox_NameFile
            // 
            textBox_NameFile.Location = new Point(11, 2);
            textBox_NameFile.Name = "textBox_NameFile";
            textBox_NameFile.Size = new Size(240, 27);
            textBox_NameFile.TabIndex = 7;
            // 
            // panel_DiemDanh
            // 
            panel_DiemDanh.Controls.Add(label_HienDien);
            panel_DiemDanh.Controls.Add(textBox_CountTotal);
            panel_DiemDanh.Controls.Add(button_Vang);
            panel_DiemDanh.Controls.Add(button_CoMat);
            panel_DiemDanh.Controls.Add(textBox_StudentName);
            panel_DiemDanh.Location = new Point(8, 40);
            panel_DiemDanh.Name = "panel_DiemDanh";
            panel_DiemDanh.Size = new Size(720, 73);
            panel_DiemDanh.TabIndex = 6;
            // 
            // label_HienDien
            // 
            label_HienDien.AutoSize = true;
            label_HienDien.Location = new Point(23, 3);
            label_HienDien.Name = "label_HienDien";
            label_HienDien.Size = new Size(73, 20);
            label_HienDien.TabIndex = 4;
            label_HienDien.Text = "Hiện diện";
            // 
            // textBox_CountTotal
            // 
            textBox_CountTotal.Location = new Point(102, -1);
            textBox_CountTotal.Name = "textBox_CountTotal";
            textBox_CountTotal.Size = new Size(125, 27);
            textBox_CountTotal.TabIndex = 3;
            // 
            // button_Vang
            // 
            button_Vang.Location = new Point(567, 30);
            button_Vang.Name = "button_Vang";
            button_Vang.Size = new Size(94, 29);
            button_Vang.TabIndex = 2;
            button_Vang.Text = "Vắng";
            button_Vang.UseVisualStyleBackColor = true;
            button_Vang.Click += button_Vang_Click;
            // 
            // button_CoMat
            // 
            button_CoMat.Location = new Point(422, 32);
            button_CoMat.Name = "button_CoMat";
            button_CoMat.Size = new Size(94, 29);
            button_CoMat.TabIndex = 1;
            button_CoMat.Text = "Có mặt";
            button_CoMat.UseVisualStyleBackColor = true;
            button_CoMat.Click += button_CoMat_Click;
            // 
            // textBox_StudentName
            // 
            textBox_StudentName.Location = new Point(3, 32);
            textBox_StudentName.Name = "textBox_StudentName";
            textBox_StudentName.Size = new Size(355, 27);
            textBox_StudentName.TabIndex = 0;
            // 
            // textBox_TotalSV
            // 
            textBox_TotalSV.Location = new Point(633, 0);
            textBox_TotalSV.Name = "textBox_TotalSV";
            textBox_TotalSV.Size = new Size(89, 27);
            textBox_TotalSV.TabIndex = 5;
            // 
            // label_TotalSV
            // 
            label_TotalSV.AutoSize = true;
            label_TotalSV.Location = new Point(504, 5);
            label_TotalSV.Name = "label_TotalSV";
            label_TotalSV.Size = new Size(123, 20);
            label_TotalSV.TabIndex = 4;
            label_TotalSV.Text = "Tổng số sinh viên";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(728, 371);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.Location = new Point(737, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 488);
            panel1.TabIndex = 2;
            // 
            // button_AddList
            // 
            button_AddList.Location = new Point(1029, 45);
            button_AddList.Name = "button_AddList";
            button_AddList.Size = new Size(94, 29);
            button_AddList.TabIndex = 4;
            button_AddList.Text = "Thêm";
            button_AddList.UseVisualStyleBackColor = true;
            button_AddList.Click += button_AddList_Click;
            // 
            // button_DiemDanh
            // 
            button_DiemDanh.Location = new Point(1029, 108);
            button_DiemDanh.Name = "button_DiemDanh";
            button_DiemDanh.Size = new Size(94, 29);
            button_DiemDanh.TabIndex = 2;
            button_DiemDanh.Text = "Điểm Danh";
            button_DiemDanh.UseVisualStyleBackColor = true;
            button_DiemDanh.Click += button_DiemDanh_Click;
            // 
            // button_In
            // 
            button_In.Location = new Point(1029, 176);
            button_In.Name = "button_In";
            button_In.Size = new Size(94, 29);
            button_In.TabIndex = 5;
            button_In.Text = "In";
            button_In.UseVisualStyleBackColor = true;
            button_In.Click += button_In_Click;
            // 
            // button_Save
            // 
            button_Save.Location = new Point(1029, 253);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(94, 29);
            button_Save.TabIndex = 6;
            button_Save.Text = "Lưu";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button_QR
            // 
            button_QR.Location = new Point(1029, 319);
            button_QR.Name = "button_QR";
            button_QR.Size = new Size(94, 29);
            button_QR.TabIndex = 7;
            button_QR.Text = "QR";
            button_QR.UseVisualStyleBackColor = true;
            button_QR.Click += button_QR_Click;
            // 
            // button_Setting
            // 
            button_Setting.Location = new Point(1029, 386);
            button_Setting.Name = "button_Setting";
            button_Setting.Size = new Size(94, 29);
            button_Setting.TabIndex = 8;
            button_Setting.Text = "Thiết lập";
            button_Setting.UseVisualStyleBackColor = true;
            button_Setting.Click += button_Setting_Click;
            // 
            // contextMenu
            // 
            contextMenu.ImageScalingSize = new Size(20, 20);
            contextMenu.Items.AddRange(new ToolStripItem[] { deleteItem });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(105, 28);
            // 
            // deleteItem
            // 
            deleteItem.Name = "deleteItem";
            deleteItem.Size = new Size(104, 24);
            deleteItem.Text = "Xóa";
            deleteItem.Click += DeleteItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 505);
            Controls.Add(button_Setting);
            Controls.Add(button_QR);
            Controls.Add(button_Save);
            Controls.Add(button_In);
            Controls.Add(button_AddList);
            Controls.Add(button_DiemDanh);
            Controls.Add(panel_List);
            Controls.Add(panel_account);
            Name = "Home";
            Text = "Form1";
            panel_account.ResumeLayout(false);
            panel_account.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel_List.ResumeLayout(false);
            panel_List.PerformLayout();
            panel_DiemDanh.ResumeLayout(false);
            panel_DiemDanh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_account;
        private Label label_FullName;
        private Label label2;
        private Label label_NameLogin;
        private Label label_NameInf;
        private Panel panel_List;
        private Panel panel1;
        private Label label_TotalSV;
        private DataGridView dataGridView1;
        private Button button_AddList;
        private Button button_DiemDanh;
        private Label label_savedList;
        private DataGridView dataGridView2;
        private TextBox textBox_TotalSV;
        private Panel panel_DiemDanh;
        private Button button_Vang;
        private Button button_CoMat;
        private TextBox textBox_StudentName;
        private Button button_In;
        private TextBox textBox_CountTotal;
        private Label label_HienDien;
        private Button button_Save;
        private TextBox textBox_FullName;
        private TextBox textBox_Username;
        private Button button_QR;
        private TextBox textBox_NameFile;
        private Button button_Setting;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem deleteItem;
        private TextBox textBox_numberOfAbsences;
        private Label label_numberOfAbsences;
        private ContextMenuStrip contextMenuStrip1;
    }
}