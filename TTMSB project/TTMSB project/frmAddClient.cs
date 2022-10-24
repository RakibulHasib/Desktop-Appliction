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
using System.IO;
using System.Drawing.Imaging;

namespace TTMSB_project
{
    public partial class frmAddClient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmAddClient()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
            {
                Image img = Image.FromFile(txtPicturePath.Text);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Bmp);

                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO client VALUES (@n,@ph,@ad,@c,@g,@d,@e,@b,@p)", con))
                {
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@ph", txtPhnNo.Text);
                    cmd.Parameters.AddWithValue("@ad", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@c", cmbCity.SelectedItem);
                    cmd.Parameters.AddWithValue("@g", cmbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@e", txtEmail.Text);

                    if (radioButton1.Checked)
                        cmd.Parameters.AddWithValue("@b", 1);
                    else
                        cmd.Parameters.AddWithValue("@b", 0);

                    cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.VarBinary) { 
                        Value = ms.ToArray()
                    });

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully!!!!");
                    }
                    con.Close();
                    clearAll();
                }
            }
        }
        private void clearAll()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhnNo.Clear();
            cmbCity.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtPicturePath.Clear();
        }
        private void btnPhotoUploader_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox1.Image = img;
                txtPicturePath.Text = openFileDialog1.FileName;
            }    
        }

        private void frmAddClient_Load(object sender, EventArgs e)
        {

        }
    }
}
