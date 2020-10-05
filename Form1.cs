using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquawkBank
{
    public partial class Form1 : Form
    {
        public static int startSquawk;
        public static int lastSquawk;
        public static int endSquawk;
        public Form1()
        {
            InitializeComponent();
            startSquawk = int.Parse(textBox1.Text);
            endSquawk = int.Parse(textBox2.Text);
            lastSquawk = int.Parse(textBox1.Text);
            label4.Text = lastSquawk.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            startSquawk = int.Parse(textBox1.Text);
            lastSquawk = int.Parse(textBox1.Text);
            label4.Text = lastSquawk.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            endSquawk = int.Parse(textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public void button1_Click(object sender, MouseEventArgs e)
        {
            label4.Text = lastSquawk.ToString();
            IncrementSquawk();
        }

        public static int IncrementSquawk()
        {
            int num1;
            int num2;
            int num3;
            int num4;

            lastSquawk++;

            num4 = lastSquawk % 10;
            num3 = (lastSquawk % 100) - num4;
            num2 = (lastSquawk % 1000) - num4 - num3;
            num1 = (lastSquawk % 10000) - num4 - num3 - num2;

            if (lastSquawk.ToString().Contains(8.ToString())) {
                if (num4 == 8)
                {
                    num4 = 0;
                    num3 = num3 + 10;
                }
                if (num3 == 80)
                {
                    num3 = 0;
                    num2 = num2 + 100;
                }
                if (num2 == 800)
                {
                    num2 = 0;
                    num1 = num1 + 1000;
                }
            }

            lastSquawk = num1 + num2 + num3 + num4;

            return lastSquawk;
        }

        public static void updateLabel2()
        {
            label4.Text = lastSquawk.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static void sendNewSquawk()
        {
            int sender = lastSquawk - 1;
            SendKeys.SendWait("{BACKSPACE}" + sender);
        }
    }
}
