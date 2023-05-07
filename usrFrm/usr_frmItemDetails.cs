using System;
using System.Data;
using System.Drawing;
using System.Security.Claims;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ShreeWellnessCenter.usrFrm
{
    public partial class usr_frmItemDetails : UserControl
    {
        db DB = new db();

        public usr_frmItemDetails()
        {
            InitializeComponent();

            datagrid_Items.Refresh();
            dtadGrid_Items_3.Refresh();
            datdGrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dtadGrid_Items_3.DataSource = datdGrid_Items.DataSource = datagrid_Items.DataSource = dataSet.Tables[0];

            }
            datagrid_Items.Refresh();
            dtadGrid_Items_3.Refresh();
            datdGrid_Items.Refresh();
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    string txtPname = txtProductName.Text.ToString();
                    string uppercasetxt = txtPname.ToUpper();


                    Int64 qty = Int64.Parse(dropQuty.Value.ToString());

                    double nuSP = 0.0;
                    double sp = 0.0;
                    bool isNumber = double.TryParse(txtSP.Text.ToString(), out nuSP);
                    if (isNumber) { sp = nuSP; }
                    else { msg("SP का value अमान्य है !..."); ; }

                    double nuDP = 0.0;
                    double dp = 0.0;
                    bool isNumber1 = double.TryParse(txtDP.Text.ToString(), out nuDP);
                    if (isNumber1) { dp = nuDP; }
                    else { msg("DP का value अमान्य है !..."); }

                    double pr = qty * dp;
                    lblPrice.Text = string.Format(pr.ToString());

                    if (txtProductName.Text != "" && txtSP.Text !="" && txtDP.Text !="")
                    {
                        string query = "INSERT INTO product(product_name, quantity, sp, dp, amount) VALUES ('" + uppercasetxt + "'," + qty + "," + sp + ", " + dp + "," + pr + ")";
                        DB.SetData(query, txtPname + Environment.NewLine + "एक प्रॉडक्ट जोड़ा गया !...");
                        datagrid_Items.Refresh();
                        clearAllFields();
                    }
                    else
                    {
                        msg("Invalid credentials.");
                        clearAllFields();
                        datagrid_Items.Refresh();
                    }

                }
                else { lblErrPN.Visible = true; }
            }
            catch
            {
                string message = "यह प्रॉडक्ट पहले से उपलब्ध है !" + Environment.NewLine + "प्रॉडक्ट अपडेट करें...";
                string title = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    txtSP.Text = "";
                    txtDP.Text = "";
                }
                else { clearAllFields(); datagrid_Items.Refresh(); }
            }
        }

        private void msg(string msg)
        {
            string title = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(msg, title, buttons);
            if (result == DialogResult.OK)
            {
                txtSP.Text = "";
                txtDP.Text = "";
            }
            else { clearAllFields(); datagrid_Items.Refresh(); }

        }
        private void usr_frmItemDetails_Load(object sender, EventArgs e)
        {

            datagrid_Items.Refresh();
            dtadGrid_Items_3.Refresh();
            datdGrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dtadGrid_Items_3.DataSource = datdGrid_Items.DataSource = datagrid_Items.DataSource = dataSet.Tables[0];

            }
            datagrid_Items.Refresh();
            dtadGrid_Items_3.Refresh();
            datdGrid_Items.Refresh();
        }
       
        private void clearAllFields()
        {
            txtProductName.Text = "";
            txtSP.Text = "";
            txtDP.Text = "";
            dropQuty.Value = 0;
            lblPrice.Text = "0.0";

        }

        private void btnCleaar_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        private void txtProductName_Click(object sender, EventArgs e)
        {
            if (lblErrPN.Visible == true)
            {
                lblErrPN.Visible = false;
                clearAllFields();
                datagrid_Items.Refresh();
            }
            else
            {
                lblErrPN.Visible = false;
                clearAllFields();
                datagrid_Items.Refresh();
            }
        }

        private void datagrid_Items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            datagrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                datagrid_Items.DataSource = dataSet.Tables[0];
            }
            txtProductName.Text = "";
            datagrid_Items.Refresh();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();
            string input = txtProductName.Text;
            string uppercasetxt = input.ToUpper();
            string query = "select * from  product where product_name like '" + uppercasetxt + "%'";
            DataSet ds = DB.GetData(query);
            datagrid_Items.DataSource = ds.Tables[0];
            datagrid_Items.Refresh();
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9)
            {
                txtProductName.SelectNextControl(dropQuty, true, false, false, false);
            }
        }

        private void dropQuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9)
            {
                txtProductName.SelectNextControl(txtSP, true, false, false, false);
            }

        }

        private void txtSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9)
            {
                txtProductName.SelectNextControl(txtDP, true, false, false, false);
            }

        }

        private void txtDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9)
            {
                Int64 qty = Int64.Parse(dropQuty.Value.ToString());
                double dp = Int64.Parse(txtDP.Text.ToString());
                double pr = qty * dp;
                lblPrice.Text = string.Format(pr.ToString());

            }
        }



        //------------------------------------------- Page 2 --------------------------------------------


        private void datdGrid_Items_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            datdGrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                datdGrid_Items.DataSource = dataSet.Tables[0];
            }

            datdGrid_Items.Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
     
            datdGrid_Items.Refresh();
            string input = txtSearch.Text;
            string uppercasetxt = input.ToUpper();
            string query = "select * from  product where product_name like '" + uppercasetxt + "%'";
            DataSet ds = DB.GetData(query);
            datdGrid_Items.DataSource = ds.Tables[0];
            datdGrid_Items.Refresh();
        }

        private void datdGrid_Items_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            datdGrid_Items.Refresh();
            int slno = int.Parse(datagrid_Items.Rows[e.RowIndex].Cells[0].Value.ToString());
            string prductName = datagrid_Items.Rows[e.RowIndex].Cells[1].Value.ToString();
            int quty = int.Parse(datagrid_Items.Rows[e.RowIndex].Cells[2].Value.ToString());
            double sp = double.Parse(datagrid_Items.Rows[e.RowIndex].Cells[3].Value.ToString());
            double dp = double.Parse(datagrid_Items.Rows[e.RowIndex].Cells[4].Value.ToString());
            double amount = double.Parse(datagrid_Items.Rows[e.RowIndex].Cells[5].Value.ToString());

            txtxSLNO.Text = slno.ToString();
            txtProductNm.Text = prductName;
            dropQtyVal.Value = quty;
            txtSPVal.Text = sp.ToString();
            txtDPVal.Text = dp.ToString();
            lblAmtVal.Text = amount.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductNm.Text != "")
                {
                    int slno = int.Parse(txtxSLNO.Text.ToString());

                    string txtPname = txtProductNm.Text.ToString();
                    string uppercasetxt = txtPname.ToUpper();


                    Int64 qty = Int64.Parse(dropQtyVal.Value.ToString());

                    double nuSP = 0.0;
                    double sp = 0.0;
                    bool isNumber = double.TryParse(txtSPVal.Text.ToString(), out nuSP);
                    if (isNumber) { sp = nuSP; }
                    else { msg("SP का value अमान्य है !..."); }

                    double nuDP = 0.0;
                    double dp = 0.0;
                    bool isNumber1 = double.TryParse(txtDPVal.Text.ToString(), out nuDP);
                    if (isNumber1) { dp = nuDP; }
                    else { msg("DP का value अमान्य है !..."); }

                    double pr = qty * dp;
                    lblAmtVal.Text = string.Format(pr.ToString());

                    if (txtProductNm.Text != "" && txtSPVal.Text != "" && txtDPVal.Text != "")
                    {
                        string query = "UPDATE product SET product_name ='" + uppercasetxt + "', quantity = " + qty + ", sp = " + sp + ", dp = " + dp + ", amount = " + pr + " WHERE  sl_no = " + slno + "";

                        DB.SetData(query, txtPname + Environment.NewLine + "एक प्रॉडक्ट अपडेट किया गया !...");
                        datagrid_Items.Refresh();
                        ClearP();
                    }
                    else
                    {
                        pMsg("Invalid credentials...");
                        ClearP();
                        datdGrid_Items.Refresh();

                    }
                }
                else
                {
                    pMsg("कोई बदलाव नहीं किया गया !");
                    ClearP();
                    datdGrid_Items.Refresh();

                }
            }
            catch
            {
                pMsg("Invalid credentials...");
                ClearP();
                datdGrid_Items.Refresh();
            }
        }
        private void btnClearP_Click(object sender, EventArgs e)
        {
            ClearP();
            datdGrid_Items.Refresh();
        }
        private void ClearP()
        {
            txtSearch.Text = "";
            txtxSLNO.Text = "";
            txtProductNm.Text = "";
            dropQtyVal.Value = 0;
            txtSPVal.Text = "";
            txtDPVal.Text = "";
            lblAmtVal.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try { 
                if (txtProductNm.Text != "")
                {
                    int slno = int.Parse(txtxSLNO.Text.ToString());

                    string query = "DELETE FROM PRODUCT WHERE SL_NO = " + slno + "";

                    DB.SetData(query,txtProductNm.Text+Environment.NewLine +"एक प्रॉडक्ट डिलीट किया गया !...");
                    datagrid_Items.Refresh();
                    ClearP();
                }
                else
                {
                    pMsg("कोई भी प्रॉडक्ट डिलीट नहीं किया गया !");
                    ClearP();
                    datdGrid_Items.Refresh();

                }
            }
            catch
            {
                pMsg("Invalid credentials...");
                ClearP();
                datdGrid_Items.Refresh();

            }
        } 

        private void pMsg(string pmsg)
        {
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(pmsg, title, buttons);
            if (result == DialogResult.OK)
            {
                ClearP();
            }
            else
            {

                ClearP();
            }

        }
//------------------------------------------------------- Page 3 -----------------------------------------------------
        private void lblPIM_Click(object sender, EventArgs e)
        {

            lblPIM.ForeColor = Color.Red;
            lblPMsgHin.Visible = true;
            lblPMsgEng.Visible = true;
            dtadGrid_Items_3.Refresh();
        }

        private void lblPIM_MouseHover(object sender, EventArgs e)
        {
            lblPIM.ForeColor = Color.Red;
            lblPMsgHin.Visible = true;
            lblPMsgEng.Visible = true;
            dtadGrid_Items_3.Refresh();
        }

        private void lblPIM_MouseLeave(object sender, EventArgs e)
        {
            lblPIM.ForeColor = Color.Red;
            lblPMsgHin.Visible = false;
            lblPMsgEng.Visible = false;
            dtadGrid_Items_3.Refresh();
        }


        //------------------------------- 
        private void tabPage3_Click(object sender, EventArgs e)
        {
            dtadGrid_Items_3.Refresh();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            datdGrid_Items.Refresh();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();
        }

     
    }
}
