using Attendence.BLL;
using Attendence.DAO;
using Attendence.DTO;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Register : Form
    {
        private AccountBLL accountBLL;
      
        public Register()
        {
            InitializeComponent();
       
            accountBLL = new AccountBLL(); 

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            string fullName = tBFullName.Text;
            string userName = tBUserName.Text;
            string passWord = tBPassWord.Text;
            string xacNhan = tBXacNhan.Text;

            
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(passWord) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (passWord != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
            
                accountBLL.CreateAccount(userName, passWord, fullName);
                MessageBox.Show("Đăng kí tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                Login f = new Login();
                this.Hide();  
                f.ShowDialog(); 
                this.Close();  
            }
            catch (Exception ex)
            {
         
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
