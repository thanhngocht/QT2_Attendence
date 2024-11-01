using Attendence.BLL;
using Attendence.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendence.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private int PerformLogin(string username, string password)
        {
            AccountBLL accountBLL = new AccountBLL();
            return accountBLL.geGetUserId(username, password);
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = txt_TenDangNhap.Text;
            string password = txt_MatKhau.Text;
            int idUser = PerformLogin(username, password);
            if (idUser != -1)
            {
                Home f = new Home(idUser);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }

        }

        private void button_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }
    }
}
