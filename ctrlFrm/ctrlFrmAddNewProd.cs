using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ShreeWellnessCenter.ctrlFrm
{
    public partial class ctrlFrmAddNewProd : Form
    {
        public ctrlFrmAddNewProd()
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

        private void txtPName_Click(object sender, EventArgs e)
        {
            if(txtPName.Text !="")
            {
                lblProdMsg.Visible =false;
                txtPName.SelectAll();
            }
            lblProdMsg.Visible =false;
        }

        private void txtPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtPName.Text != "")
                {
                    lblProdMsg.Visible =false;
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
                lblQtyMsg.Visible=false;
            }
            else if(e.KeyCode == Keys.Escape);
            {
                //dropQuty.Value = 0;
                lblQtyMsg.Visible = false;
            }
        }

        private void dropQuty_Click(object sender, EventArgs e)
        {
            if(dropQuty.Value >= 0) 
            {
                lblQtyMsg.Visible = false;
            }
            lblQtyMsg.Visible = false;
        }

        private void txtSP_Click(object sender, EventArgs e)
        {
            if(txtSP.Text !="")
            {
                lblSpMsg.Visible = false;
            }
            lblSpMsg.Visible = false;
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

        private void txtDP_Click(object sender, EventArgs e)
        {
            if(txtDP.Text !="")
            {
                lblDPMsg.Visible =false;

            }
            lblDPMsg.Visible = false;
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
                        lblPrice.Text = pr.ToString() ;
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

        private void btnAddNewProd_Click(object sender, EventArgs e)
        {
            db DB = new db();
            try
            {
                if (txtPName.Text != "")
                {
                    string txtPname = txtPName.Text.ToString();
                    string uppercasetxt = txtPname.ToUpper();


                    Int64 qty = Int64.Parse(dropQuty.Value.ToString());

                    if (txtSP.Text != "")
                    {
                        double nuSP = 0.0;
                        double sp = 0.0;
                        bool isNumber = double.TryParse(txtSP.Text.ToString(), out nuSP);
                        if (isNumber)
                        {
                            sp = nuSP;
                            if (txtDP.Text != "")
                            {
                                double nuDP = 0.0;
                                double dp = 0.0;
                                bool isNumber1 = double.TryParse(txtDP.Text.ToString(), out nuDP);
                                if (isNumber1)
                                {
                                    dp = nuDP;
                                    double pr = qty * dp;
                                    lblPrice.Text = string.Format(pr.ToString());

                                    if (txtPName.Text != "" && txtSP.Text != "" && txtDP.Text != "" && dropQuty.Value >=0)
                                    {
                                        lblPrice.Text = pr.ToString();
                                        try
                                        {
                                            string query = "INSERT INTO PRODUCT(product_name, qty, sp, dp, total) VALUES ('" + uppercasetxt + "'," + qty + "," + sp + ", " + dp + "," + pr + ")";
                                            DB.SetData(query, txtPname + Environment.NewLine + "एक प्रॉडक्ट जोड़ा गया !...");
                                            System.Threading.Thread.Sleep(1500);
                                            this.Close();
                                        }
                                        catch
                                        {
                                            string message = "हो सकता है की यह प्रॉडक्ट पहले से उपलब्ध होगा !" + Environment.NewLine + "प्रॉडक्ट जोड़ना विफल...";
                                            string title = "Information";
                                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                                            DialogResult result = MessageBox.Show(message, title, buttons);
                                            if (result == DialogResult.OK)
                                            {
                                                txtSP.Text = "";
                                                txtDP.Text = "";
                                            }

                                        }
                                    }
                                    else
                                    {
                                        lblInv.Visible = true;
                                        System.Threading.Thread.Sleep(1000);
                                        lblInv.Visible =false;
                                        txtSP.Clear();
                                        txtDP.Clear();
                                        txtPName.Clear();
                                        lblPrice.Text = "0";
                                    }

                                }
                                else 
                                {
                                    lblDPMsg.Visible = true;
                                    txtDP.Text = "";
                                    txtDP.Select();
                                }
                            }
                            else
                            {
                                lblDPMsg.Visible = true;
                                txtDP.Text = "";
                                txtDP.Select();
                            }
                        }
                        else
                        {
                            lblSpMsg.Visible = true;
                            txtSP.Text = "";
                            txtSP.Select();
                        }
                    }
                    else
                    {
                        lblSpMsg.Visible = true;
                        txtSP.Text = "";
                        txtSP.Select();
                    }

                }
                else { lblProdMsg.Visible = true; }
            }
            catch
            {
                string message = "हो सकता है की यह प्रॉडक्ट पहले से उपलब्ध होगा !" + Environment.NewLine + "प्रॉडक्ट जोड़ना विफल...";
                string title = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    txtSP.Text = "";
                    txtDP.Text = "";
                }
              
            }
        }
    }
}
