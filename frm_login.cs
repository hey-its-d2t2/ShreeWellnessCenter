using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class frm_login : Form
    {
        frmMain frmMain = new frmMain();
        public frm_login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            lblSalesmanLogin.ForeColor = Color.FromArgb(45, 180, 150);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            lblSalesmanLogin.ForeColor = Color.FromArgb(51, 51, 51);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.FromArgb(45, 180, 150);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.FromArgb(51, 51, 51);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loadingBar.Visible = true;
            loadingBar.Start();
            for (int i = 0; i < 10; i++)
            {
                loadingBar.Stop();

            }
            loadingBar.Stop();
            this.Hide();
            frmMain.Show();
        }

        private void lblSalesmanLogin_Click(object sender, EventArgs e)
        {
            frmSalManLog frmSalManLog = new frmSalManLog();
            this.Hide();
            frmSalManLog.Show();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgotPass frmForgotPass = new frmForgotPass();
            this.Hide();
            frmForgotPass.Show();
        }


    }
}
