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
    public partial class frmForTransaction : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmForTransaction()
        {
            InitializeComponent();
        }

        private void btnInsertAll_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlTransaction ts = con.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = ts;
                cmd.CommandText = "INSERT INTO monthAndDay VALUES(@month,@days) SELECT @@IDENTITY";

                cmd.Parameters.AddWithValue("@month", txtMonthName.Text);
                cmd.Parameters.AddWithValue("@days", txtDays.Text);

                int id = Convert.ToInt32(cmd.ExecuteScalar());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if(dataGridView1.Rows[i].Cells["spot"].Value!=null && dataGridView1.Rows[i].Cells["NetPropit"].Value != null)
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con;
                        cmd2.Transaction = ts;
                        cmd2.CommandText = "INSERT INTO NetPropit(monthId,spotId,netpropit) VALUES(@monthId,@spotId,@netpropit)";
                        cmd2.Parameters.AddWithValue("@monthId", id);
                        cmd2.Parameters.AddWithValue("@spotId", dataGridView1.Rows[i].Cells["spot"].Value);
                        cmd2.Parameters.AddWithValue("@netpropit", dataGridView1.Rows[i].Cells["NetPropit"].Value);
                        cmd2.ExecuteNonQuery();
                    }
                }
                ts.Commit();
                MessageBox.Show("Data Saved Successfully!!!");
            }
            catch (Exception ex)
            {
                ts.Rollback();
                MessageBox.Show(ex.Message + "\nData Not Saved!!!");
            }
            con.Close();
        }

        private void frmForTransaction_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT spotId,spotName FROM spot", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            spot.DataSource = dt;
            spot.DisplayMember = "spotName";
            spot.ValueMember = "spotId";
            con.Close();
        }
    }
}
