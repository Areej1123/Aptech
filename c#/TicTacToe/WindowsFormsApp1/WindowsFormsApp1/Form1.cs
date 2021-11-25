using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool b = true;
        int count = 0;
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (b)
            {
                btn.Text = "X";
                b = false;
                btn.BackColor = Color.Yellow;
            }
            else
            {
                btn.Text = "O";
                b = true;
                btn.BackColor = Color.Green;
            }

            btn.Enabled = false;
            count++;

            if (button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            //-------------------
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            //-------------------
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                MessageBox.Show(btn.Text + " Won the match");
                referesh();
            }
            else
            {
                if (count == 9)
                {
                    MessageBox.Show("Draw the match");
                    referesh();
                }
            }
        }

        private void referesh()
        {
            b = true;
            count = 0;

            Button[] btns = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (var btn in btns)
            {
                btn.Text = "";
                btn.BackColor = Color.White;
                btn.Enabled = true;
            }


        }

    }
}
