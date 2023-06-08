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
    public partial class ctrlFrmAddNewCust : Form
    {
        public ctrlFrmAddNewCust()
        {
            InitializeComponent();
        }

        private void ctrlFrmAddNewCust_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            lblInvalidUsrName.Visible = false;
            if (txtName.Text != "")
            {
                txtName.SelectAll();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtName.Text != "")
                {
                    lblInvalidUsrName.Visible = false;

                    txtID.Select();
                }
                else
                {
                    lblInvalidUsrName.Visible = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblInvalidUsrName.Visible = false;
                txtName.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblInvalidUsrName.Visible = false;
                txtName.SelectAll();
            }
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            lblErrID.Visible = false;
            if (txtID.Text != "")
            {
                txtID.SelectAll();
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtID.Text != "")
                {
                    lblErrID.Visible = false;
                    dropIDGreen.Select();
                }
                else
                {
                    lblErrID.Visible = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblErrID.Visible = false;
                txtID.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblErrID.Visible = false;
                txtName.Select();
            }
        }

        private void dropIDGreen_Click(object sender, EventArgs e)
        {
            if (dropIDGreen.Text != "")
            {
                lblerrIIDGR.Visible = false;
            }
            lblerrIIDGR.Visible = false;
        }

        private void dropIDGreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (dropIDGreen.Text != "")
                {
                    lblerrIIDGR.Visible = false;
                    txtMobile.Select();
                }
                else
                {
                    lblerrIIDGR.Visible = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblerrIIDGR.Visible = false;
                dropIDGreen.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblerrIIDGR.Visible = false;
                txtID.Select();
            }
        }

        private void txtMobile_Click(object sender, EventArgs e)
        {

            if (txtMobile.Text != "")
            {
                lblMobMsg.Visible = false;
                txtMobile.SelectAll();
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtMobile.Text != "")
                {
                    lblMobMsg.Visible = false;
                    txtAdd.Select();
                }
                else
                {
                    lblMobMsg.Visible = true;
                    txtAdd.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblMobMsg.Visible = false;
                txtMobile.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblerrIIDGR.Visible = false;
                dropIDGreen.Select();
            }
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {

            if (txtAdd.Text != "")
            {
                lblAddMsg.Visible = false;
            }
        }

        private void txtAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtAdd.Text != "")
                {
                    lblAddMsg.Visible = false;
                    btnAddNewCust.Select();
                }
                else
                {
                    lblAddMsg.Visible = true;
                    btnAddNewCust.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblAddMsg.Visible = false;
                txtAdd.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblAddMsg.Visible = false;
                txtMobile.Select();
            }
        }
        private void myQueryInsert()
        {
            string txtid = txtID.Text.ToString();
            string upperCustID = txtid.ToUpper();

            string valDrop = dropIDGreen.SelectedItem.ToString();
            string upperIDGreen = valDrop.ToUpper();

            string txtPname = txtName.Text.ToString();
            string upperCustName = txtPname.ToUpper();

            string mob = txtMobile.Text.ToString();
            string upperMob = mob.ToUpper();

            string add = txtAdd.Text.ToString();
            string upperAdd = add.ToUpper();

            db DB = new db();

            string query = "INSERT INTO CUSTOMER(USER_ID,ID_GREENING, NAME, MOBILE, ADDRESS) " +
               "VALUES ('" + upperCustID + "','" + upperIDGreen + "', '" + upperCustName + "','" + upperMob + "','" + upperAdd + "')";

            DB.SetData(query, txtPname + Environment.NewLine + "एक ग्राहक जोड़ा गया !...");
            System.Threading.Thread.Sleep(1000);
            this.Close();
        }

        private void btnAddNewCust_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                if (txtID.Text != "")
                {
                    if (dropIDGreen.SelectedItem != "")
                    {
                        if (txtMobile.Text == "")
                        {
                            lblMobMsg.Visible = true;
                            if (txtAdd.Text == "")
                            {
                                lblAddMsg.Visible = true;
                                myQueryInsert();
                            }
                            else
                            {
                                lblAddMsg.Visible = false;
                                myQueryInsert();
                            }
                        }
                        else
                        {
                            if (txtAdd.Text == "")
                            {
                                lblAddMsg.Visible = true;
                                myQueryInsert();
                            }
                            else
                            {
                                myQueryInsert();
                            }
                        }
                    }
                    else
                    {
                        lblerrIIDGR.Visible = true;
                        dropIDGreen.Select();
                    }
                }
                else
                {
                    lblErrID.Visible = true;
                    txtID.Select();
                }
            }
            else
            {
                lblInvalidUsrName.Visible = true;
                txtName.Select();
            }
        }
    }
}
