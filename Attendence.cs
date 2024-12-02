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

namespace Schoolmanagementsystem
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into attab values (@aid,@studentname,@status)", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
           
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from attab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("update attab set studentname=@studentname,status=@status where aid=@aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
            


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("delete attab where aid=@aid", con);
            cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Successfully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from attab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source= ADESHMULIK7780\SQLSERVER2017;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from attab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
