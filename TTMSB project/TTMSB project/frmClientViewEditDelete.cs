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
using System.Drawing.Imaging;
using System.IO;

namespace TTMSB_project
{
    public partial class frmClientViewEditDelete : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmClientViewEditDelete()
        {
            InitializeComponent();
        }

        private void frmClientViewEditDelete_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void btnChooseEdit_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox2.Image = img;
                txtPicturePath.Text = openFileDialog1.FileName;
            }
        }

        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM client", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                SqlCommand cmd = new SqlCommand("SELECT * FROM client where clientId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtEditId.Text = dr.GetInt32(0).ToString();
                    txtEditName.Text = dr.GetString(1);
                    txtEditPhoneNo.Text = dr.GetInt32(2).ToString();
                    txtEditAddress.Text = dr.GetString(3);
                    cmbEditCity.SelectedItem = dr.GetString(4);
                    cmbEditGender.SelectedItem = dr.GetString(5);
                    dateTimePicker1Edit.Value = dr.GetDateTime(6).Date;
                    txtEditEmail.Text = dr.GetString(7);
                    radioButton1.Checked = dr.GetBoolean(8);
                    MemoryStream ms = new MemoryStream((byte[])dr[9]);
                    Image img = Image.FromStream(ms);
                    pictureBox2.Image = img;
                    //txtPicturePath.Text = dr
                }
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(txtPicturePath.Text);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);

            con.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE client SET clientName=@n,phoneNo=@ph,address=@ad,city=@c,gender=@g,dob=@d,email=@e,bengali=@b,picture=@p WHERE clientId=@i", con))
            {
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                cmd.Parameters.AddWithValue("@n", txtEditName.Text);
                cmd.Parameters.AddWithValue("@ph", txtEditPhoneNo.Text);
                cmd.Parameters.AddWithValue("@ad", txtEditAddress.Text);
                cmd.Parameters.AddWithValue("@c", cmbEditCity.SelectedItem);
                cmd.Parameters.AddWithValue("@g", cmbEditGender.SelectedItem);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1Edit.Value);
                cmd.Parameters.AddWithValue("@e", txtEditEmail.Text);

                if (radioButton1.Checked)
                    cmd.Parameters.AddWithValue("@b", 1);
                else
                    cmd.Parameters.AddWithValue("@b", 0);

                cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.VarBinary)
                {
                    Value = ms.ToArray()
                });

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Updated Successfully!!!!");
                }
                con.Close();
                LoadGrid();
                clearAll();
            }
        }
        private void clearAll()
        {
            txtEditName.Clear();
            txtEditAddress.Clear();
            txtEditPhoneNo.Clear();
            cmbEditCity.SelectedIndex = -1;
            cmbEditGender.SelectedIndex = -1;
            txtEditEmail.Clear();
            txtPicturePath.Clear();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM client WHERE clientId=@i", con))
            {
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Deleted Successfully!!!!");
                }
                con.Close();
                LoadGrid();
                clearAll();
            }
        }
    }
}
