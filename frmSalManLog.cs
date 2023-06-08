using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class frmSalManLog : Form
    {
        db DB = new db();

        public frmSalManLog()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frm_login frm_Login = new frm_login();
            this.Hide();
            frm_Login.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loadingBar.Visible = true;
            lblInvalidUsrName.Visible = false;
            lblInvalidUsrPassword.Visible = false;


            if (txtUsrName.Text != "")
            {
                lblInvalidUsrName.Visible = false;
                if (txtUsrPass.Text != "")
                {
                    lblInvalidUsrName.Visible = false;
                    lblInvalidUsrPassword.Visible = false;
                    string txt = "retail";
                    string usrname = txtUsrName.Text.ToString();
                    string pass = txtUsrPass.Text.ToString();
                    string query1 = "select user_id, password,user_type from user_details where user_type = 'retail'";
                    DataSet dataSet = DB.GetData(query1);

                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            timer1_Tick(sender, new EventArgs());
                            loadingBar.Start();
                            if (dataSet.Tables[0].Rows[i]["User_ID"].ToString() == usrname && dataSet.Tables[0].Rows[i]["Password"].ToString() == pass)
                            {
                                if (dataSet.Tables[0].Rows[i]["user_type"].ToString() == txt)
                                {
                                    frmMain frmMain = new frmMain("RetailAssistant");
                                    loadingBar.Stop();
                                    this.Hide();
                                    frmMain.Show();
                                }
                                else
                                {
                                    MessageBox.Show("उपयोगकर्ता नहीं मिला !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (dataSet.Tables[0].Rows[i]["User_ID"].ToString() != usrname)
                            {
                                lblInvalidUsrName.Visible = true;
                            }
                            else if (dataSet.Tables[0].Rows[i]["Password"].ToString() != pass)
                            {
                                lblInvalidUsrPassword.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("अमान्य विवरण ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtUsrName.Text = "";
                                txtUsrPass.Text = "";
                                lblInvalidUsrName.Visible = false;
                                lblInvalidUsrPassword.Visible = false;
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Database नहीं मिला !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    lblInvalidUsrPassword.Visible = true;
                    lblInvalidUsrPassword.Location = new Point(132, 250);
                    lblInvalidUsrPassword.Text = "उपयोगकर्ता का Password लिखें !";
                    loadingBar.Visible = false;
                }

            }
            else
            {
                lblInvalidUsrName.Visible = true;
                lblInvalidUsrName.Location = new Point(140, 188);
                lblInvalidUsrName.Text = "उपयोगकर्ता का नाम लिखें !";
                loadingBar.Visible = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 10;
            if (circularProgressBar1.Value <= 110)
            {
                timer1.Enabled = false;
                loadingBar.Stop();
            }
        }

        private void txtUsrName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                lblInvalidUsrName.Visible = false;
                loadingBar.Visible = false;
                lblInvalidUsrPassword.Visible = false;
                txtUsrPass.Select();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUsrName.SelectAll();

            }
        }

        private void txtUsrPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                lblInvalidUsrName.Visible = false;
                loadingBar.Visible = false;
                lblInvalidUsrPassword.Visible = false;
                btnLogin.Select();
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

        private void txtUsrName_Click(object sender, EventArgs e)
        {
            lblInvalidUsrName.Visible = false;
            loadingBar.Visible = false;
            lblInvalidUsrPassword.Visible = false;
        }

        private void txtUsrPass_Click(object sender, EventArgs e)
        {
            lblInvalidUsrName.Visible = false;
            loadingBar.Visible = false;
            lblInvalidUsrPassword.Visible = false;
        }

        private void frmSalManLog_Load(object sender, EventArgs e)
        {
            txtUsrName.Select();
        }
    }
}
