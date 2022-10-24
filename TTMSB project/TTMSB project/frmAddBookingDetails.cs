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
    public partial class frmAddBookingDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmAddBookingDetails()
        {
            InitializeComponent();
        }

        private void frmAddBookingDetails_Load(object sender, EventArgs e)
        {
            LoadCombo1();
            LoadCombo2();
            LoadCombo3();
            LoadCombo4();
        }
        private void LoadCombo1()
        {
          
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT clientId,clientName FROM client", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbClientName.DataSource = dt;
            cmbClientName.DisplayMember = "clientName";
            cmbClientName.ValueMember = "clientId";
            con.Close();
        }
        private void LoadCombo2()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT spotId,spotName FROM spot", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbSpotName.DataSource = dt;
            cmbSpotName.DisplayMember = "spotName";
            cmbSpotName.ValueMember = "spotId";
            con.Close();
        }
        private void LoadCombo3()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT hotelId,hotelName FROM hotel", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbHotelName.DataSource = dt;
            cmbHotelName.DisplayMember = "hotelName";
            cmbHotelName.ValueMember = "hotelId";
            con.Close();
        }
        private void LoadCombo4()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT transportId,transportName FROM transportation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbTransportName.DataSource = dt;
            cmbTransportName.DisplayMember = "transportName";
            cmbTransportName.ValueMember = "transportId";
            con.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO bookingDetails VALUES (@cn,@sn,@hn,@tn,@td,@tc,@trn)", con))
            {
                cmd.Parameters.AddWithValue("@cn", cmbClientName.SelectedValue);
                cmd.Parameters.AddWithValue("@sn", cmbSpotName.SelectedValue);
                cmd.Parameters.AddWithValue("@hn", cmbHotelName.SelectedValue);
                cmd.Parameters.AddWithValue("@tn", cmbTransportName.SelectedValue);
                cmd.Parameters.AddWithValue("@td", numTourDuration.Value);
                cmd.Parameters.AddWithValue("@tc", txtTourCost.Text);
                cmd.Parameters.AddWithValue("@trn", numTravellerNumber.Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Inserted Successfully!!!!");
                }
                con.Close();
            }
        }
    }
}
