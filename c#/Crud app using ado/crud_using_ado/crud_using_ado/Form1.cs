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

namespace crud_using_ado
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAB_206_INT_PC\MSSQLSERVER1;Initial Catalog=aptechdb;User ID=sa;Password=1234");

        public Form1()
        {
            InitializeComponent();
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            int age =Convert.ToInt32( txtAge.Text  );
            string pass = txtPassword.Text;
            string country = CB_country.SelectedText;
            string city = CB_City.SelectedText;

            string gender = "Male";
            if (radioButton_female.Checked) gender = "Female";

            string subjects = "";
            if (checkBox_html.Checked) subjects = "HTML";
            if (checkBox_java.Checked) subjects += ",JAVA";
            if (checkBox_swift.Checked) subjects += ",SWIFT";




        }
    }
}
