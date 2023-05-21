using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string user)
        {
            InitializeComponent();
            if (user == null)
            {
                this.Show();
            }
            else
            {
                btnHome.Visible = true;
                btnInvoice.Visible = true;
                btnCustomer.Visible = false;
                btnItems.Visible = false;
                btnUser.Visible = false;
            }

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 80;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else if (pnlBtnHolder.Width == 77)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else if (pnlBtnHolder.Width == 77)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnHome.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmHome1.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnInvoice.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmInvoice1.BringToFront();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (pnlBtnHolder.Width == 233)
            {
                pnlBtnHolder.Width = 77;
                guna2Transition1.ShowSync(pnlBtnHolder);
            }
            else if (pnlBtnHolder.Width == 77)
            {
                pnlBtnHolder.Width = 233;
                guna2Transition1.ShowSync(pnlBtnHolder);
            }
            else
            {
                pnlBtnHolder.Width = 233;
                guna2Transition1.ShowSync(pnlBtnHolder);
            }
        }

        private void guna2GradientButton1_MouseHover(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.FromArgb(45, 180, 150);
            pnlBtnSide.Top = btnInvoice.Top;
        }

        private void guna2GradientButton1_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.White;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            frm_login frm_Login = new frm_login();
            this.Close();
            frm_Login.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnHome.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmHome1.BringToFront();

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnCustomer.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmCustomer1.BringToFront();

        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnItems.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmItemDetails1.BringToFront();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            pnlBtnSide.Top = btnUser.Top;
            pnlBtnSide.FillColor = Color.Red;
            usr_frmControlAdm1.BringToFront();
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.FromArgb(45, 180, 150);
            pnlBtnSide.Top = btnHome.Top;
        }

        private void btnCustomer_MouseHover(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.FromArgb(45, 180, 150);
            pnlBtnSide.Top = btnCustomer.Top;
        }

        private void btnItems_MouseHover(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.FromArgb(45, 180, 150);
            pnlBtnSide.Top = btnItems.Top;
        }


        private void btnUser_MouseHover(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.FromArgb(45, 180, 150);
            pnlBtnSide.Top = btnUser.Top;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.Red;

        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.Red;

        }

        private void btnItems_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.Red;

        }

        private void btnPurchase_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.Red;

        }

        private void btnUser_MouseLeave(object sender, EventArgs e)
        {
            pnlBtnSide.FillColor = Color.Red;

        }

        private void usr_frmCustomer2_Load(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHeader_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 80;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else if (pnlBtnHolder.Width == 77)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                if (pnlBtnHolder.Width == 233)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else if (pnlBtnHolder.Width == 77)
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
                else
                {
                    pnlBtnHolder.Width = 233;
                    guna2Transition1.ShowSync(pnlBtnHolder);
                }
            }
        }

        private void usr_frmControlAdm1_Load(object sender, EventArgs e)
        {

        }
    }
}
