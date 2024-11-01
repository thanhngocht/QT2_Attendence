namespace Attendence.GUI
{
    partial class InfForm
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

        private void InitializeComponent()
        {
            button_OK = new Button();
            label1 = new Label();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // button_OK
            // 
            button_OK.Location = new Point(120, 138);
            button_OK.Margin = new Padding(3, 4, 3, 4);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(75, 29);
            button_OK.TabIndex = 2;
            button_OK.Text = "OK";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += button_OK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 3;
            label1.Text = "Số buổi học:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(178, 20);
            label2.TabIndex = 4;
            label2.Text = "Phần trăm nghỉ cho phép:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Minimum = 0;

            numericUpDown1.Location = new Point(196, 39);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(124, 27);
            numericUpDown1.TabIndex = 5;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Minimum = 0;
            numericUpDown2.Value = 30;
            numericUpDown2.Location = new Point(196, 86);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(124, 27);
            numericUpDown2.TabIndex = 6;
            // 
            // InfForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 200);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_OK);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InfForm";
            Text = "Nhập Thông Tin";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
    }
}