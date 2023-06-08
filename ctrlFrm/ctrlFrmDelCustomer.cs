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
    public partial class ctrlFrmDelCustomer : Form
    {
        public ctrlFrmDelCustomer()
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

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtName.Text != "")
                {
                    lblErrName.Visible = false;
                    txtID.Select();
                }
                else
                {
                    lblErrName.Visible = true;
                    txtID.Text = "";
                }

            }
            else if (e.KeyCode == Keys.Escape)

            {
                txtName.SelectAll();
                lblErrName.Visible = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtName.Select();
                lblErrName.Visible = false;
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                txtID.SelectAll();
                lblErrName.Visible = false;
            }
            {
                lblErrName.Visible = false;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtID.Text != "")
                {
                    lblErrId.Visible = false;
                    btnDelUsSal.Select();
                }
                else
                {
                    lblErrId.Visible = true;
                    txtID.Text = "";
                }

            }
            else if (e.KeyCode == Keys.Escape)
            {
                lblErrId.Visible = false;
                txtID.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lblErrId.Visible = false;
                txtName.Select();
            }

        }

        private void txtID_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                txtID.SelectAll();
                lblErrId.Visible = false;
            }
            else
            {
                lblErrId.Visible = false;
            }
        }

        private void btnDelUsSal_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                lblErrName.Visible = false;
                if (txtID.Text != "")
                {
                    lblErrId.Visible = false;
                    db DB = new db();
                    //Query for comparing data from database recard
                    string usrname = txtName.Text.ToString();
                    string uid = txtID.Text.ToString();
                    string query1 = "select user_id, name from customer";
                    DataSet dataSet = DB.GetData(query1);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            //query for delete
                            if (dataSet.Tables[0].Rows[i]["name"].ToString() == usrname.ToUpper())
                            {
                                lblErrName.Visible = false;
                                if (dataSet.Tables[0].Rows[i]["user_id"].ToString() == uid.ToUpper())
                                {
                                    lblErrId.Visible = false;
                                    string query2 = "delete from customer where user_id = '" + uid.ToUpper() + "' and name = '" + usrname.ToUpper() + "'";
                                    DataSet dataSet2 = DB.GetData(query2);
                                    DialogResult = MessageBox.Show("Delete Sucessfull !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (DialogResult == DialogResult.OK)
                                    {
                                        txtID.Clear();
                                        txtName.Clear();
                                        System.Threading.Thread.Sleep(1000);
                                        this.Close();

                                    }

                                }
                                else
                                {
                                    lblErrId.Text = "ID नहीं मिला !";
                                    lblErrId.Location = new Point(210, 210);
                                    lblErrId.Visible = true;
                                    txtID.Select();
                                }
                            }
                            else
                            {
                                lblErrName.Text = "नाम नहीं मिला !";
                                lblErrName.Location = new Point(210, 140);
                                lblErrName.Visible = true;
                                txtName.Select();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Delete विफल !", "सुचना", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    lblErrId.Visible = true;
                    txtID.Select();
                }
            }
            else
            {
                lblErrName.Visible = true;
                txtName.Select();
            }
        }
    
    }
}
