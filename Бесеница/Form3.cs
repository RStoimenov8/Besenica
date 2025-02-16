using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
//XxStreAmeRbgXx//

namespace Бесеница
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Paint += Form3_Paint;
            //Load += Form3_Load;
        }
        
        string name;
        Random r = new Random();
        Button[] alphabetButtons;


        List<Label> labels = new List<Label>();
        bool ignore;
        int stage = 0;
        string file;

        private void btn_click(object sender, EventArgs e)
        {
            if (ignore)
                return;
            Button b = (Button)sender;
            b.Enabled = false;

            foreach (var lbl in labels)
            {
                if (lbl.Tag.ToString() == b.Text)
                {
                    lbl.Text = b.Text;
                    count--;
                }

            }
            if (count == 0)
            {
                Thread.Sleep(500);
                MessageBox.Show("Браво!");
                Thread.Sleep(1000);
                
                Form3 f3 = new Form3();
                Form1 f1 = new Form1();
                f3.Visible = false;
                f1.ShowDialog();
                Close();
                return;
            }
            for (int x = 1; x <= labels.Count - 1; x++)
            {
                labels[x].Left = labels[x - 1].Right;
            }

            if (labels[labels.Count - 1].Right > this.ClientSize.Width - 14)
            {
                this.SetClientSizeCore(labels[labels.Count - 1].Right + 14, 381);

            }
            stage += !labels.Any(lbl => lbl.Text == b.Text) ? 1 : 0;
            ignore = labels.All(lbl => lbl.Text != " ") || stage == 10;

            this.Invalidate();
        }
           
        public void Form3_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (stage >= 1)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);    
            }
            if (stage >= 2)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
                
            }
            if (stage >= 3)
            {
                
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
               
            }
            if (stage >= 4)
            {
               
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
                
            }
            if (stage >= 5)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(188, 70, 20, 20));
                
            }
            if (stage >= 6)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 90, 198, 130);
                
            }
            if (stage >= 7)
            {
               
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 183, 115);
                
            }
            if (stage >= 8)
            {
                
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 95, 213, 115);
                
            }
            if (stage >= 9)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 183, 170);
            }
            if (stage >= 10)
            {
                 e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 130, 213, 170);
                Thread.Sleep(500);
                MessageBox.Show("Губиш!!!"); 
                Thread.Sleep(1000);
                Visible = false;
                Close();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }

        }

        
        
        private void Button31_Click(object sender, EventArgs e)
        {
            Close();
            Form1 f1 = new Form1();
            f1.Visible = true;
        }
        string[] words;
        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.mode;
            label1.Text = Form1.YTS;
            

            if (label1.Text == "D")
            {
                label2.Text = "darjavi.txt";
                name = "Държави";
            }
            if (label1.Text == "S")
            {
                label2.Text = "stolici.txt";
                name = "Столици";
            }

            file = label2.Text; 

            StreamReader sr = new StreamReader(file, Encoding.GetEncoding("windows-1251"));
            this.Text = name;
            words = sr.ReadToEnd().Split(new[] { "\n", "\r" },
            StringSplitOptions.RemoveEmptyEntries);
            
            sr.Close();

            this.DoubleBuffered = true;
            alphabetButtons = this.Controls.OfType<Button>().Except(new Button[] { button32 }).ToArray();
            Array.ForEach(alphabetButtons, b => b.Click += btn_click);
            button32.PerformClick();
        }
        int count;
        public void Button32_Click(object sender, EventArgs e)
        {
            this.SetClientSizeCore(546, 381);
            string word = words[r.Next(0, words.Length)].ToUpper();
            count = word.Length;
            Array.ForEach(this.Controls.OfType<Label>().ToArray(), lbl => lbl.Dispose());
            Array.ForEach(alphabetButtons, b => b.Enabled = true);
            labels = new List<Label>();
            int startX = 14;
            foreach (char c in word)
            {
                Label lbl = new Label();
                lbl.Text = " ";
                lbl.Font = new Font(this.Font.Name, 35, FontStyle.Underline);
                lbl.Location = new Point(startX, 250);
                lbl.Tag = c.ToString();
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
                labels.Add(lbl);
                startX = lbl.Right;
            }
            ignore = false;
            stage = 0;
            this.Invalidate();
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            Close();
            Form1 f1 = new Form1();
            f1.Visible = true;
            Form3 f3 = new Form3();
            f3.Close();
            return;
        }
    }
}
