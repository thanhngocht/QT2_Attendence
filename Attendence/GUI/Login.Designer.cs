namespace Attendence.GUI
{
    partial class Login
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
            groupBox1 = new GroupBox();
            buttonLogin = new Button();
            txt_MatKhau = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txt_TenDangNhap = new TextBox();
            groupBox2 = new GroupBox();
            button_register = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_register);
            groupBox1.Controls.Add(buttonLogin);
            groupBox1.Controls.Add(txt_MatKhau);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_TenDangNhap);
            groupBox1.Location = new Point(41, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(623, 371);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đăng nhập";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(333, 283);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(98, 35);
            buttonLogin.TabIndex = 10;
            buttonLogin.Text = "Đăng nhập";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // txt_MatKhau
            // 
            txt_MatKhau.Location = new Point(116, 199);
            txt_MatKhau.Name = "txt_MatKhau";
            txt_MatKhau.Size = new Size(415, 27);
            txt_MatKhau.TabIndex = 6;
            txt_MatKhau.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 158);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 5;
            label1.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 71);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên đăng nhập";
            // 
            // txt_TenDangNhap
            // 
            txt_TenDangNhap.Location = new Point(116, 107);
            txt_TenDangNhap.Name = "txt_TenDangNhap";
            txt_TenDangNhap.Size = new Size(415, 27);
            txt_TenDangNhap.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(139, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(42, 8);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // button_register
            // 
            button_register.Location = new Point(168, 286);
            button_register.Name = "button_register";
            button_register.Size = new Size(94, 29);
            button_register.TabIndex = 11;
            button_register.Text = "Đăng kí";
            button_register.UseVisualStyleBackColor = true;
            button_register.Click += button_register_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Login";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenDangNhap;
        private System.Windows.Forms.Button buttonLogin;
        private Button button_register;
    }
}