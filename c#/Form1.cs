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
        List<Person> lst = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            Person person = new Person();
            person.Name = name;
            person.Phone = phone;
            person.Email = email;
            person.Password = password;

            lst.Add(person);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lst;


            txtName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";


        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Phone{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }

    }



}
