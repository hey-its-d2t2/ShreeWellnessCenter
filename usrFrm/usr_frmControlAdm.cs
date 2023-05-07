using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShreeWellnessCenter.usrFrm
{
    public partial class usr_frmControlAdm : UserControl
    {
        public usr_frmControlAdm()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
            
            usr_frmInvoice frmInvoice = new usr_frmInvoice();
            this.SendToBack();

            frmInvoice.BringToFront();
        }
    }
}
