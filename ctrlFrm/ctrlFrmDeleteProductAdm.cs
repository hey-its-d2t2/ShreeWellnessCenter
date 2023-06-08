using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShreeWellnessCenter.ctrlFrm
{
    public partial class ctrlFrmDeleteProductAdm : Form
    {
        public ctrlFrmDeleteProductAdm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtPName.Text != "")
                {
                    lblProdMsg.Visible = false;
                    dropQuty.Select();
                }
                else
                {
                    lblProdMsg.Visible = true;
                    txtPName.Select();
                }

            }
            else if (e.KeyCode == Keys.Escape)

            {
                lblProdMsg.Visible = false;
                txtPName.SelectAll();
            }
        }

        private void txtPName_Click(object sender, EventArgs e)
        {
           if(txtPName.Text != "")
            {
                lblProdMsg.Visible = false;
                txtPName.SelectAll();
            }
            lblProdMsg.Visible = false;
        }

        private void dropQuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (dropQuty.Value >= 0)
                {
                    lblQtyMsg.Visible = false;
                    txtSP.Select();
                }
                else
                {
                    lblQtyMsg.Visible = true;
                    dropQuty.Select();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtPName.Select();
                lblQtyMsg.Visible = false;
            }
            else if (e.KeyCode == Keys.Escape) ;
            {
                //dropQuty.Value = 0;
                lblQtyMsg.Visible = false;
            }
        }

        private void dropQuty_Click(object sender, EventArgs e)
        {

            if (dropQuty.Value >= 0)
            {
                lblQtyMsg.Visible = false;
            }
            lblQtyMsg.Visible = false;
        }

        private void txtSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtSP.Text != "")
                {
                    lblSpMsg.Visible = false;
                    double nuSP = 0.0;
                    bool isNumber = double.TryParse(txtSP.Text.ToString(), out nuSP);
                    if (isNumber)
                    {
                        txtDP.Select();
                    }
                    else
                    {
                        lblSpMsg.Visible = true;
                        txtSP.Text = ""; txtSP.Select();
                    }
                }
                else
                {
                    lblSpMsg.Visible = true;
                    txtSP.Text = "";
                    txtSP.Select();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                dropQuty.Select();
            }
        }

        private void txtSP_Click(object sender, EventArgs e)
        {
            if (txtSP.Text != "")
            {
                lblSpMsg.Visible = false;
            }
            lblSpMsg.Visible = false;

        }

        private void txtDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtDP.Text != "")
                {
                    lblDPMsg.Visible = false;
                    double nuDP = 0.0;
                    bool isNumber = double.TryParse(txtDP.Text.ToString(), out nuDP);
                    if (isNumber)
                    {
                        Int64 qty = Int64.Parse(dropQuty.Value.ToString());
                        double dp = Int64.Parse(txtDP.Text.ToString());
                        double pr = qty * dp;
                        lblPrice.Text = string.Format(pr.ToString());
                        lblPrice.Text = pr.ToString();
                        btnAddNewProd.Select();
                    }
                    else
                    {
                        lblDPMsg.Visible = true;
                        txtDP.Text = ""; txtDP.Select();
                    }
                }
                else
                {
                    lblDPMsg.Visible = true;
                    txtDP.Text = "";
                    txtDP.Select();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtSP.Select();
            }
        }

        private void txtDP_Click(object sender, EventArgs e)
        {
            if (txtDP.Text != "")
            {
                lblDPMsg.Visible = false;

            }
            lblDPMsg.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtPName.Text!="")
            {
                lblProdMsg.Visible = false;
                lblQtyMsg.Visible = false;
                lblSpMsg.Visible = false; ;lblDPMsg.Visible = false;lblInv.Visible=false;
                string pn = txtPName.Text.ToUpper();

            }
            else
            {
                lblProdMsg.Visible = true;
                txtPName.Select();
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
