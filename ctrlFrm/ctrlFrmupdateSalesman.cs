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
    public partial class ctrlFrmupdateSalesman : Form
    {
        public ctrlFrmupdateSalesman()
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
        private void msg(string msg)
        {
            string title = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(msg, title, buttons);
            if (result == DialogResult.OK)
            {
            }
            else { }

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtID.Text != "")
                {
                    lblErrID.Visible = false;
                    txtPass.Select();
                }
                else
                {
                    lblErrID.Visible = true;
                    txtID.Clear();
                }

            }
            else if (e.KeyCode == Keys.Escape)

            {
                txtID.SelectAll();
            }
            else if(e.KeyCode == Keys.Up) {
                txtID.SelectAll();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtPass.Text != "")
                {
                    lblErrPass.Visible = false;
                    radAdmin.Select();
                }
                else
                {
                    lblErrPass.Visible = true; txtPass.Clear();
                }

            }
            else if (e.KeyCode == Keys.Escape)

            {
                txtPass.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtID.Select();
            }

        }


        private void ctrlFrmupdateSalesman_Load(object sender, EventArgs e)
        {
            txtID.Select();
        }

        private void ctrlFrmupdateSalesman_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlFrmupdateSalesman_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtID_Click(object sender, EventArgs e)
        {
            if(txtID.Text !="")
            {
                lblErrID.Visible = false;
                txtID.SelectAll();
            }
            else
            {
                lblErrID.Visible = false;
                txtID.Clear();  
            }
        }

        private void btnUpdateSalesMan_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                lblErrID.Visible = false;
                if (txtPass.Text != "")
                {
                    lblErrPass.Visible = false;
                    db DB = new db();
                    //Query for comparing data from database recard
                    string usrname = txtID.Text.ToString();
                    string upass = txtPass.Text.ToString();
                    string query1 = "select user_id, password,user_type from user_details";
                    DataSet dataSet = DB.GetData(query1);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            if (dataSet.Tables[0].Rows[i]["User_ID"].ToString() == txtID.Text.ToString())
                            {
                                lblErrID.Visible = false;
                                if(radAdmin.Checked)
                                {
                                    string rad = "admin";
                                    try
                                    {
                                        //query for uppdate
                                        string query2 = "update user_details set password ='" + upass + "',user_type = '"+rad+"' where user_id = '" + usrname + "'";
                                        DataSet dataSet2 = DB.GetData(query2);
                                        DialogResult = MessageBox.Show("अपडेट Sucessfull !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (DialogResult == DialogResult.OK)
                                        {
                                            txtID.Clear();
                                            txtPass.Clear();
                                            this.Close();
                                           
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("अपडेट Fail !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Clear();
                                        txtPass.Clear();

                                    }
                                }
                                else if(radSale.Checked)
                                {
                                    string rad = "retail";
                                    try
                                    {
                                        //query for uppdate
                                        string query2 = "update user_details set password ='" + upass + "',user_type = '" + rad + "' where user_id = '" + usrname + "'";
                                        DataSet dataSet2 = DB.GetData(query2);
                                        DialogResult = MessageBox.Show("अपडेट Sucessfull !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (DialogResult == DialogResult.OK)
                                        {
                                            txtID.Clear();
                                            txtPass.Clear();
                                            this.Close();

                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("अपडेट Fail !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtID.Clear();
                                        txtPass.Clear();

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("उपयोगकर्ता प्रकार चुने !", "सुचना", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                lblErrID.Text = "ID नहीं मिला !";
                                lblErrID.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Update विफल !", "सुचना", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                { lblErrPass.Visible = true; txtPass.Select(); }
            }
            else
            {
                lblErrID.Visible = true; txtID.Select();
            }


        }
    }
}
