
using GL = System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            int table = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i <= 20; i++)
            {
                richTextBox1.Text += $"{table} X {i} = {i * table}\n";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            float s = richTextBox1.Font.Size;
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, ++s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float s = richTextBox1.Font.Size;
            richTextBox1.Font = new Font(FontFamily.GenericMonospace, --s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int r=random.Next(255);
            int g=random.Next(255);
            int b=random.Next(255);

            
            richTextBox1.BackColor = Color.FromArgb(r,g,b);
        }
    }
}
