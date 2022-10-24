using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TTMSB_project
{
    public partial class frmAddHotel : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmAddHotel()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO hotel VALUES (@n)", con))
                {
                    cmd.Parameters.AddWithValue("@n", txtName.Text);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully!!!!");
                    }
                    con.Close();
                }
            }
            LoadGrid();
            txtName.Clear();
        }
        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM hotel", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void frmAddHotel_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE hotel SET hotelName=@n WHERE hotelId=@i", con))
            {
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                cmd.Parameters.AddWithValue("@n", txtEditName.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Updated Successfully!!!!");
                }
                con.Close();
                LoadGrid();
                txtEditName.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM hotel WHERE hotelId=@i", con))
            {
                //txtEditId.Enabled = true;
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                cmd.Parameters.AddWithValue("@n", txtEditName.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data deleted Successfully!!!!");
                }
                con.Close();
                LoadGrid();
                txtEditName.Clear();
                txtEditId.Clear();
            }
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                SqlCommand cmd = new SqlCommand("SELECT * FROM hotel where hotelId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtEditId.Text = dr.GetInt32(0).ToString();
                    txtEditName.Text = dr.GetString(1);
                }
                con.Close();
            }
        }
    }
}
