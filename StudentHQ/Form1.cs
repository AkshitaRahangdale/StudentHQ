using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace StudentHQ
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            string str = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(str);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into student values(@name,@city,@percentage)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@nm", txtName.Text);
                cmd.Parameters.AddWithValue("@city", Convert.ToChar(txtCity.Text));
                cmd.Parameters.AddWithValue("@percent", Convert.ToDecimal(txtPercentage.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "update student set name=@nm , City=@ct , Percentage=@percent where Rollno=@rollno";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@nm", txtName.Text);
                cmd.Parameters.AddWithValue("@ct", Convert.ToDecimal(txtCity.Text));
                cmd.Parameters.AddWithValue("@percent", Convert.ToInt32(txtPercentage.Text));
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtRollNo.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "delete from student where Rollno=@rollno";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtRollNo.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student where Rollno=@rollno";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtRollNo.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtName.Text = dr["name"].ToString();
                        txtCity.Text = dr["city"].ToString();
                        txtPercentage.Text = dr["percentage"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);// take dr & convert to table format
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
