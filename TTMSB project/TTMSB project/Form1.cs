using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMSB_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddClient fac = new frmAddClient();
            fac.Show();
            fac.MdiParent = this;
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddTransport fat = new frmAddTransport();
            fat.Show();
            fat.MdiParent = this;
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAddHotel fah = new frmAddHotel();
            fah.Show();
            fah.MdiParent = this;
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddSpot fas = new frmAddSpot();
            fas.Show();
            fas.MdiParent = this;
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmAddBookingDetails fabd = new frmAddBookingDetails();
            fabd.Show();
            fabd.MdiParent = this;
        }

        private void editDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientViewEditDelete fcved = new frmClientViewEditDelete();
            fcved.Show();
            fcved.MdiParent = this;
        }

        private void editDeleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmEditDeleteBookingDetails fedbd = new frmEditDeleteBookingDetails();
            fedbd.Show();
            fedbd.MdiParent = this;
        }

        private void netPropitPerMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmForTransaction fat1 = new frmForTransaction();
            fat1.Show();
            fat1.MdiParent = this;
        }

        private void bookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBookingDetailsReport fbdr = new frmBookingDetailsReport();
            fbdr.Show();
            fbdr.MdiParent = this;
        }

        private void monthViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthView fmv = new frmMonthView();
            fmv.Show();
            fmv.MdiParent = this;
        }

        private void netPropitViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNetPropit fnp = new frmNetPropit();
            fnp.Show();
            fnp.MdiParent = this;
        }
    }
}
