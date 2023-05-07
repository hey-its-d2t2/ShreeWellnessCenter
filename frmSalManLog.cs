using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class frmSalManLog : Form
    {
        public frmSalManLog()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsrName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblInvalidUsrName_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frm_login frm_Login =   new frm_login();
            this.Hide();
            frm_Login.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain("RetailAssistant");
            frmMain.Show();
            this.Hide();    
        }
    }
}
