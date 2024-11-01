namespace Attendence.GUI
{
    partial class Register
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
            gBRegister = new GroupBox();
            button1 = new Button();
            tBXacNhan = new TextBox();
            tBPassWord = new TextBox();
            tBUserName = new TextBox();
            tBFullName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            gBRegister.SuspendLayout();
            SuspendLayout();
            // 
            // gBRegister
            // 
            gBRegister.Controls.Add(button1);
            gBRegister.Controls.Add(tBXacNhan);
            gBRegister.Controls.Add(tBPassWord);
            gBRegister.Controls.Add(tBUserName);
            gBRegister.Controls.Add(tBFullName);
            gBRegister.Controls.Add(label4);
            gBRegister.Controls.Add(label3);
            gBRegister.Controls.Add(label2);
            gBRegister.Controls.Add(label1);
            gBRegister.Location = new Point(21, 36);
            gBRegister.Name = "gBRegister";
            gBRegister.Size = new Size(755, 387);
            gBRegister.TabIndex = 0;
            gBRegister.TabStop = false;
            gBRegister.Text = "Đăng kí";
            // 
            // button1
            // 
            button1.Location = new Point(327, 321);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "Đăng kí";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tBXacNhan
            // 
            tBXacNhan.Location = new Point(210, 237);
            tBXacNhan.Name = "tBXacNhan";
            tBXacNhan.Size = new Size(521, 31);
            tBXacNhan.TabIndex = 7;
            tBXacNhan.UseSystemPasswordChar = true;
            // 
            // tBPassWord
            // 
            tBPassWord.Location = new Point(210, 183);
            tBPassWord.Name = "tBPassWord";
            tBPassWord.Size = new Size(521, 31);
            tBPassWord.TabIndex = 6;
            tBPassWord.UseSystemPasswordChar = true;
            // 
            // tBUserName
            // 
            tBUserName.Location = new Point(210, 133);
            tBUserName.Name = "tBUserName";
            tBUserName.Size = new Size(521, 31);
            tBUserName.TabIndex = 5;
            // 
            // tBFullName
            // 
            tBFullName.Location = new Point(210, 88);
            tBFullName.Name = "tBFullName";
            tBFullName.Size = new Size(521, 31);
            tBFullName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 240);
            label4.Name = "label4";
            label4.Size = new Size(163, 25);
            label4.TabIndex = 3;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 189);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 139);
            label2.Name = "label2";
            label2.Size = new Size(129, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 91);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gBRegister);
            Name = "Register";
            Text = "Register";
            gBRegister.ResumeLayout(false);
            gBRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gBRegister;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tBXacNhan;
        private TextBox tBPassWord;
        private TextBox tBUserName;
        private TextBox tBFullName;
        private Label label4;
        private Button button1;
    }
}