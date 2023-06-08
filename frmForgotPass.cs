using System;
using System.Data;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class frmForgotPass : Form
    {
        public frmForgotPass()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblInvalidUsrPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frm_login frm_Login = new frm_login();
            this.Hide();
            frm_Login.Show();
        }

        private void frmForgotPass_Load(object sender, EventArgs e)
        {
            txtSecretKey.Select();
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if(txtSecretKey.Text == "0292")
            {
                lblInvalidKey.Visible = false;
                if (txtUsrName.Text != "")
                {
                    db DB = new db();
                    //Query for comparing data from database recard
                    string txt = "admin";
                    string usrname = txtUsrName.Text.ToString();
                    string upass = txtUsrPass.Text.ToString();
                    string pass = txtUsrPass.Text.ToString();
                    string query1 = "select user_id, password,user_type from user_details where user_type = 'admin'";
                    DataSet dataSet = DB.GetData(query1);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            if (dataSet.Tables[0].Rows[i]["User_ID"].ToString() == usrname)
                            {
                                lblInvalidUsrName.Visible = false;
                                if (txtUsrPass.Text != "")
                                {
                                    lblPas.Visible = false;
                                    try
                                    {
                                        //query for uppdate
                                        string query2 = "update user_details set password ='" + upass + "' where user_id = '" + usrname + "'";
                                        DataSet dataSet2 = DB.GetData(query2);
                                        DialogResult = MessageBox.Show("अपडेट Sucessfull !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (DialogResult == DialogResult.OK)
                                        {
                                            txtSecretKey.Text = "";
                                            txtUsrName.Text = "";
                                            txtUsrPass.Text = "";
                                            this.Close();
                                            frm_login lf = new frm_login();
                                            lf.Show();
                                        }
                                    }
                                    catch
                                    {
                                        MessageBox.Show("अपडेट Fail !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtSecretKey.Text = "";
                                        txtUsrName.Text = "";
                                        txtUsrPass.Text = "";
                                    }
                                }

                                else
                                {

                                    lblPas.Visible = true;
                                    txtUsrPass.Select();
                                }

                            }
                            else
                            {
                                if (txtUsrName.Text == "")
                                {
                                    lblInvalidUsrName.Visible = true;
                                    txtUsrName.Select();
                                }
                                else
                                {
                                    lblInvalidUsrName.Visible = true;
                                    lblInvalidUsrName.Text = "अमान्य उपयोगकर्ता !";
                                    txtUsrName.Select();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(" अमान्य विवरण !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    lblInvalidUsrName.Visible = true;
                    txtUsrName.Select();
                }
            }
            else
            {
                if (txtSecretKey.Text != "")
                {
                    lblInvalidKey.Text = "अमान्य कुंजी !";
                    lblInvalidKey.Visible = true;
                    txtSecretKey.Select();
                }
                else
                {
                    lblInvalidKey.Text = "कुंजी लिखें !";
                    lblInvalidKey.Visible = true;
                    txtSecretKey.Select();
                }
            }
        }

        private void txtSecretKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter ||e.KeyCode == Keys.Down || e.KeyCode== Keys.Tab) 
            {
                if(txtSecretKey.Text !="")
                {
                    lblInvalidKey.Visible=false;
                    txtUsrName.Select();
                }
                else
                {
                    lblInvalidKey.Text = "कुंजी लिखें !";
                    lblInvalidKey.Visible = true;
                    txtSecretKey.Select();
                }
            }
            else if(e.KeyCode == Keys.Escape|| e.KeyCode == Keys.Up) { txtSecretKey.SelectAll(); }
        }

        private void txtSecretKey_Click(object sender, EventArgs e)
        {
            lblInvalidKey.Visible = false;
        }

        private void txtUsrName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtUsrName.Text != "")
                {
                    lblInvalidUsrName.Visible=false;
                    txtUsrPass.Select();
                }
                else
                {
                 lblInvalidUsrName.Visible = true;
                    txtUsrName.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape )
            {
                txtUsrName.SelectAll();
            }
            else if(e.KeyCode == Keys.Up ) 
            {
                txtSecretKey.Select();
            }
        }

        private void txtUsrName_Click(object sender, EventArgs e)
        {
            lblInvalidUsrName.Visible = false;
        }

        private void txtUsrPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (txtUsrPass.Text != "")
                {
                    lblPas.Visible = false;
                    btnUpdatePass.Select();
                }
                else
                {
                    lblPas.Visible = true;
                    txtUsrPass.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUsrPass.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtUsrName.Select();
            }
        }

        private void txtUsrPass_Click(object sender, EventArgs e)
        {
            lblPas.Visible=false;
        }
    }
}
