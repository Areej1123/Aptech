using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        List<Person> lst = new List<Person>() {
            new Person{Id=101,Name="Ali" },
            new Person{Id=102,Name="Ali" },
            new Person{Id=103,Name="malik" },
            new Person{Id=104,Name="Ali" },
            new Person{Id=105,Name="Ali" }
        };

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person {
                Id=Convert.ToInt32( txtId.Text),
                Name=txtName.Text
            };

            lst.Add(person);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lst;

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Person person = lst.FirstOrDefault(x=>x.Id== id);
            lst.Remove(person);


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lst;

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Person person = lst.FirstOrDefault(x => x.Id == id);
            person.Name = txtName.Text;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lst;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           // bool isExist = lst.Any(x=>x.Name==txtName.Text);
            bool isExist = lst.Select(x => x.Name).Contains(txtName.Text);
            if (isExist)
            {
                MessageBox.Show($"Yes {txtName.Text} is Exist in your collection.");
            }
            else
            {
                MessageBox.Show($"No {txtName.Text} is not Exist in your collection.");
            }
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


}
