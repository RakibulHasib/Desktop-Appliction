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
    public partial class frmEditDeleteBookingDetails : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TTMSB;Trusted_connection=True");
        public frmEditDeleteBookingDetails()
        {
            InitializeComponent();
        }

        private void frmEditDeleteBookingDetails_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadComboForEdit();
        }
        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT bd.bookingId,c.clientName,s.spotName,h.hotelName,t.transportName,bd.tourDuration,bd.tourCost,bd.travellerNumber,bd.totalCost FROM bookingDetails bd INNER JOIN client c ON c.clientId = bd.clientName INNER JOIN spot s ON s.spotId = bd.spotName INNER JOIN hotel h ON h.hotelId = bd.hotelName INNER JOIN transportation t ON t.transportId = bd.transportName", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void LoadComboForEdit()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT clientId,clientName FROM client", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmbEditClientName.DisplayMember = "clientName";
            cmbEditClientName.ValueMember = "clientId";
            cmbEditClientName.DataSource = dt;

            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT spotId,spotName FROM spot", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            cmbEditSpotName.DisplayMember = "spotName";
            cmbEditSpotName.ValueMember = "spotId";
            cmbEditSpotName.DataSource = dt1;

            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT hotelId,hotelName FROM hotel", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            cmbEditHotelName.DisplayMember = "hotelName";
            cmbEditHotelName.ValueMember = "hotelId";
            cmbEditHotelName.DataSource = dt2;

            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT transportId,transportName FROM transportation", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            cmbEditTransportName.DisplayMember = "transportName";
            cmbEditTransportName.ValueMember = "transportId";
            cmbEditTransportName.DataSource = dt3;
            con.Close();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                SqlCommand cmd = new SqlCommand("SELECT * FROM bookingDetails where bookingId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtEditId.Text = dr.GetInt32(0).ToString();
                    cmbEditClientName.SelectedValue = dr.GetInt32(1).ToString();
                    cmbEditSpotName.SelectedValue = dr.GetInt32(2).ToString();
                    cmbEditHotelName.SelectedValue = dr.GetInt32(3).ToString();
                    cmbEditTransportName.SelectedValue = dr.GetInt32(4).ToString();
                    txtTourDuration.Text = dr.GetInt32(5).ToString();
                    txtEditTourCost.Text = dr.GetDecimal(6).ToString();
                    txtEditTravellerNumber.Text = dr.GetInt32(7).ToString();
                }
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE bookingDetails SET clientName=@cn,spotName=@sn,hotelName=@hn,transportName=@tn,tourDuration=@td,tourCost=@tc,travellerNumber=@trn WHERE bookingId=@i", con);
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                cmd.Parameters.AddWithValue("@cn", cmbEditClientName.SelectedValue);
                cmd.Parameters.AddWithValue("@sn", cmbEditSpotName.SelectedValue);
                cmd.Parameters.AddWithValue("@hn", cmbEditHotelName.SelectedValue);
                cmd.Parameters.AddWithValue("@tn", cmbEditTransportName.SelectedValue);
                cmd.Parameters.AddWithValue("@td", txtTourDuration.Text);
                cmd.Parameters.AddWithValue("@tc", txtEditTourCost.Text);
                cmd.Parameters.AddWithValue("@trn", txtEditTravellerNumber.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Updated Successfully!!!!");
                }
            con.Close();
            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM bookingDetails WHERE bookingId=@i", con))
            {
                cmd.Parameters.AddWithValue("@i", txtEditId.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Data Deleted Successfully!!!!");
                }
                con.Close();
                LoadGrid();
            }
        }
    }
}
