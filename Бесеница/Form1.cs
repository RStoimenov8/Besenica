using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Бесеница
{
    public partial class Form1 : Form
    {
        public static string mode;
        public static string YTS;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            Visible = false;
            f3.ShowDialog();
        }
        string result;

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Изберете опция!");
                return;
            }
            else if (radioButton1.Checked)
            {
                result = "D";
                mode = radioButton1.Text;
            }
            else
            {
                result = "S";
                mode = radioButton2.Text;
            }
            YTS = result;

            Form3 f3 = new Form3();
            Visible = false;
            f3.ShowDialog();

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("                                              Бесеница\r\n" +
               "\r\n" + "При играта „Бесеница“ единият от играчите се опитва да я разгадае думата като налучкват буквите."
                + "\r\n Дължината на всяка дума е обозначена с една чертичка за всяка буква");
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
