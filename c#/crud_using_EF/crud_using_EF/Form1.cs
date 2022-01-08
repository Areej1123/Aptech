using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_using_EF
{
    public partial class Form1 : Form
    {
        aptechdbEntities db = new aptechdbEntities();

        List<string> lstCountry = new List<string> { "Pakistan", "China", "Turkey" };
        List<string> PakCities = new List<string> { "Islamabad", "Multan", "Sialkot" };
        List<string> ChinaCities = new List<string> { "Shanghai", "bejing", "Malta" };
        List<string> TurkishCities = new List<string> { "Istanbol", "Anatolia", "Lifkosha" };

        public Form1()
        {
            InitializeComponent();
            CB_country.DataSource = lstCountry;
            fetchStudents();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            int age = Convert.ToInt32(txtAge.Text);
            string pass = txtPassword.Text;
            string country = CB_country.SelectedValue + "";
            string city = CB_City.SelectedValue + "";

            string gender = "Male";
            if (radioButton_female.Checked)
                gender = "Female";

            string subjects = "";
            if (checkBox_html.Checked)
                subjects = "HTML";

            if (checkBox_java.Checked)
                subjects += ",JAVA";

            if (checkBox_swift.Checked)
                subjects += ",SWIFT";


            Student std = new Student {
                Name=name,
                Phone=phone,
                Email=email,
                Password=pass,
                Age=age,
                City=city,
                Country=country,
                Gender=gender,
                Subjects=subjects
            };

            db.Students.Add(std);
            int res=db.SaveChanges();
            if (res > 0)
            {
                MessageBox.Show("record inserted successfuly...");
                txtName.Text = txtPhone.Text = txtEmail.Text = txtAge.Text = txtPassword.Text = "";
                radioButton_male.Checked = true;
                checkBox_html.Checked = checkBox_java.Checked = checkBox_swift.Checked = false;
                fetchStudents();
            }
            else
            {
                MessageBox.Show("Error...");
            }


        }

        private void CB_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            var country = CB_country.SelectedValue + "";
            CB_City.DataSource = null;
            switch (country)
            {
                case "Pakistan":
                    CB_City.DataSource = PakCities;
                    break;
                case "China":
                    CB_City.DataSource = ChinaCities;
                    break;
                case "Turkey":
                    CB_City.DataSource = TurkishCities;
                    break;
            }
        }

        public void fetchStudents()
        {
            var students = db.Students.ToList();
            dataGridView_students.DataSource = null;
            dataGridView_students.DataSource = students;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var str = txtSearch.Text;
            var students = db.Students.Where(x=>x.Name.Contains(str) || x.Gender.Contains(str) || x.Phone.Contains(str) || x.Subjects.Contains(str)).ToList();
            dataGridView_students.DataSource = null;
            dataGridView_students.DataSource = students;
        }

        private void dataGridView_students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = dataGridView_students.CurrentCell.RowIndex;
            var id = dataGridView_students.Rows[rowIndex].Cells[0].Value+"";
            var name = dataGridView_students.Rows[rowIndex].Cells[1].Value + "";
            var phone = dataGridView_students.Rows[rowIndex].Cells[2].Value + "";
            var age = dataGridView_students.Rows[rowIndex].Cells[3].Value + "";
            var email = dataGridView_students.Rows[rowIndex].Cells[4].Value + "";
            var pass = dataGridView_students.Rows[rowIndex].Cells[5].Value + "";
            var country = dataGridView_students.Rows[rowIndex].Cells[6].Value + "";
            var city = dataGridView_students.Rows[rowIndex].Cells[7].Value + "";
            var gender = dataGridView_students.Rows[rowIndex].Cells[8].Value + "";
            var subjects = dataGridView_students.Rows[rowIndex].Cells[9].Value + "";

            lbl_id.Text = id;
            txtName.Text = name;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            txtPassword.Text = pass;
            txtAge.Text = age;
            //CB_country.SelectedIndex = country;
            //CB_City.SelectedValue = city;
            if (gender == "Male") radioButton_male.Checked = true;
            if (gender == "Female") radioButton_female.Checked = true;
            checkBox_html.Checked = subjects.Contains("HTML");
            checkBox_java.Checked = subjects.Contains("JAVA");
            checkBox_swift.Checked = subjects.Contains("SWIFT");

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32( lbl_id.Text);
            var student = db.Students.FirstOrDefault(x=>x.Id==id);
            db.Students.Remove(student);
            int res=db.SaveChanges();
            if (res > 0)
            {
                MessageBox.Show("Record Deleted successfuly...");
                lbl_id.Text = "";
                fetchStudents();
            }
            else
            {
                MessageBox.Show("Error...");
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            // Update record
            var id =Convert.ToInt32( lbl_id.Text);
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            int age = Convert.ToInt32(txtAge.Text);
            string pass = txtPassword.Text;
            string country = CB_country.SelectedValue + "";
            string city = CB_City.SelectedValue + "";

            string gender = "Male";
            if (radioButton_female.Checked) gender = "Female";

            string subjects = "";
            if (checkBox_html.Checked) subjects = "HTML";
            if (checkBox_java.Checked) subjects += ",JAVA";
            if (checkBox_swift.Checked) subjects += ",SWIFT";

            var obj = db.Students.FirstOrDefault(x => x.Id == id);
            obj.Name = name;
            obj.Phone = phone;
            obj.Email = email;
            obj.Age = age;
            obj.Password = pass;
            obj.Country = country;
            obj.City = city;
            obj.Gender = gender;
            obj.Subjects = subjects;
            int res = db.SaveChanges();
            if (res > 0)
            {
                MessageBox.Show("record updated successfuly...");
                txtName.Text = txtPhone.Text = txtEmail.Text = txtAge.Text = txtPassword.Text = "";
                radioButton_male.Checked = true;
                checkBox_html.Checked = checkBox_java.Checked = checkBox_swift.Checked = false;
                fetchStudents();
            }
            else
            {
                MessageBox.Show("Error...");
            }

        }
    }
}
