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
    public partial class InfForm : Form
    {
        public int Value1 { get; private set; }
        public int Value2 { get; private set; }

        public InfForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            // Lưu giá trị từ TextBox vào các biến
            Value1 = (int)numericUpDown1.Value;
            Value2 = (int)numericUpDown2.Value;

            this.DialogResult = DialogResult.OK; // Đặt kết quả của form là OK
            this.Close(); // Đóng form
        }
    }
}
