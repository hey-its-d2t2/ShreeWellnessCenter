using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
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

                    if(txtSP.Text !="")
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

                                    if (txtProductName.Text != "" && txtSP.Text != "" && txtDP.Text != "")
                                    {
                                        try
                                        {
                                            string query = "INSERT INTO product(product_name, quantity, sp, dp, amount) VALUES ('" + uppercasetxt + "'," + qty + "," + sp + ", " + dp + "," + pr + ")";
                                            DB.SetData(query, txtPname + Environment.NewLine + "एक प्रॉडक्ट जोड़ा गया !...");
                                            datagrid_Items.Refresh();
                                            clearAllFields();
                                        }
                                        catch
                                        {
                                            msg("अमान्य विवरण !...");
                                            clearAllFields();
                                            datagrid_Items.Refresh();

                                        }
                                    }
                                    else
                                    {
                                        msg("अमान्य विवरण !...");
                                        clearAllFields();
                                        datagrid_Items.Refresh();
                                    }

                                }
                                else { msg("DP का value अमान्य है !..."); }
                            }
                            else
                            {
                                msg("DP का value लिखें !...");
                                txtDP.Text = "";
                                txtDP.Select();
                            }
                        }
                        else { msg("SP का value अमान्य है !...");  }
                    }
                    else
                    {
                        msg("SP का value लिखें !...");
                        txtSP.Text = "";
                        txtSP.Select();
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
        private void getMyData()
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
        private void usr_frmItemDetails_Load(object sender, EventArgs e)
        {

            getMyData();
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
            datagrid_Items.Refresh();
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
            try
            {
                getMyData();

            }
            catch
            {
                datagrid_Items.Refresh();
            }
           
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
           if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtProductName.Text != "")
                {
                    dropQuty.Select();
                }
                else
                {
                    msg("प्रॉडक्ट का नाम लिखें ! ..."); txtSP.Text = "";
                }

            }
           

        }

        private void dropQuty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (dropQuty.Value >= 0)
                {
                    txtSP.Select();
                }
                else
                {
                    msg("अमान्य Quantity !...");
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtProductName.Select();
            }

        }

        private void txtSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtSP.Text != "")
                {
                    double nuSP = 0.0;
                    bool isNumber = double.TryParse(txtSP.Text.ToString(), out nuSP);
                    if (isNumber)
                    {
                        txtDP.Select();
                    }
                    else { msg("SP का value अमान्य है !..."); txtSP.Text = "";txtSP.Select(); }
                }
                else
                {
                    msg("SP का value लिखें !...");
                    txtSP.Text = "";
                    txtSP.Select();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                dropQuty.Select();
            }
        }

        private void txtDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtDP.Text != "")
                {
                    double nuDP = 0.0;
                    bool isNumber = double.TryParse(txtDP.Text.ToString(), out nuDP);
                    if (isNumber)
                    {
                        txtDP.Select();
                        Int64 qty = Int64.Parse(dropQuty.Value.ToString());
                        double dp = Int64.Parse(txtDP.Text.ToString());
                        double pr = qty * dp;
                        lblPrice.Text = string.Format(pr.ToString());
                        btnAdd.Select();
                    }
                    else { msg("DP का value अमान्य है !..."); txtDP.Text = "";txtDP.Select(); }
                }
                else
                {

                    msg("DP का value लिखें !...");
                    txtDP.Text = "";
                    txtDP.Select();

                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtSP.Select();
            }
        }
    

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            guna2GradientButton1_Click(sender, e);

        }

        //------------------------------------------- Page 2 --------------------------------------------



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
        {   try
            {
                datdGrid_Items.Refresh();
                txtxSLNO.Text = datdGrid_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtProductNm.Text = datdGrid_Items.Rows[e.RowIndex].Cells[1].Value.ToString();
                dropQtyVal.Value = int.Parse(datdGrid_Items.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtSPVal.Text = datdGrid_Items.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDPVal.Text = datdGrid_Items.Rows[e.RowIndex].Cells[4].Value.ToString();
                lblAmtVal.Text = datdGrid_Items.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { datdGrid_Items.Refresh(); }
          
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
                    if (txtSPVal.Text != "")
                    {
                        double nuSP = 0.0;
                        double sp = 0.0;
                        bool isNumber = double.TryParse(txtSPVal.Text.ToString(), out nuSP);
                        if (isNumber) 
                        {
                            sp = nuSP; 

                            if(txtDPVal.Text != "")
                            {
                                double nuDP = 0.0;
                                double dp = 0.0;
                                bool isNumber1 = double.TryParse(txtDPVal.Text.ToString(), out nuDP);
                                if (isNumber1) 
                                {
                                    dp = nuDP;
                                    double pr = qty * dp;
                                    lblAmtVal.Text = string.Format(pr.ToString());
                                    try
                                    {
                                        if (txtProductNm.Text != "" && txtSPVal.Text != "" && txtDPVal.Text != "")
                                        {
                                            string query = "UPDATE product SET product_name ='" + uppercasetxt + "', quantity = " + qty + ", sp = " + sp + ", dp = " + dp + ", amount = " + pr + " WHERE  sl_no = " + slno + "";

                                            DB.SetData(query, txtPname + Environment.NewLine + "एक प्रॉडक्ट अपडेट किया गया !...");
                                            datdGrid_Items.Refresh();
                                            getMyData();
                                            ClearP();
                                        }
                                        else
                                        {
                                            pMsg("अमान्य विवरण !...");
                                            ClearP();
                                            datdGrid_Items.Refresh();
                                        }
                                    }
                                    catch
                                    {

                                        pMsg("अमान्य विवरण !...");
                                        ClearP();
                                        datdGrid_Items.Refresh();

                                    }

                                }
                                else 
                                {
                                    msg("DP का value अमान्य है !...");
                                    txtDPVal.Text = "";
                                    txtDPVal.Select();
                                   
                                }

                            }
                            else
                            {
                                msg("DP का value लिखें !...");
                            }

                        }
                        else
                        {
                            msg("SP का value अमान्य है !...");
                            txtSPVal.Text = "";
                            txtSPVal.Select();
                        
                        }
                    }
                    else
                    {
                        msg("SP का value लिखें !...");
                    }
                }
                else
                {
                    pMsg("प्रॉडक्ट का नाम लिखें !...");
                    ClearP();
                    datdGrid_Items.Refresh();

                }
            }
            catch
            {
                pMsg("अमान्य विवरण !...");
                ClearP();
                datdGrid_Items.Refresh();
                getMyData();
            }
        }
        private void btnClearP_Click(object sender, EventArgs e)
        {
            ClearP();
            datdGrid_Items.Refresh();
            getMyData();
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
            try
            {
                if (txtProductNm.Text != "")
                {
                    int slno = int.Parse(txtxSLNO.Text.ToString());

                    string query = "DELETE FROM PRODUCT WHERE SL_NO = " + slno + "";

                    DB.SetData(query, txtProductNm.Text + Environment.NewLine + "एक प्रॉडक्ट डिलीट किया गया !...");
                    datdGrid_Items.Refresh();
                    getMyData();
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
                pMsg("अमान्य विवरण !...");
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
                datdGrid_Items.Refresh();
            }
            else
            {

                ClearP();
                datdGrid_Items.Refresh();
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
            dtadGrid_Items_3.Refresh(); getMyData();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            datdGrid_Items.Refresh();            getMyData();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();           getMyData(); ;
        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
            datdGrid_Items.Refresh(); getMyData();
        }

        private void guna2TabControl1_Click(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();
            getMyData();
        }

        private void guna2TabControl1_Leave(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();
            getMyData();
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            dtadGrid_Items_3.Refresh();
            getMyData();
        }

        private void txtProductNm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9
                || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtProductNm.Text != "")
                {
                    dropQtyVal.Select();
                }
                else
                {
                    pMsg("प्रॉडक्ट का नाम लिखें !...");
                }
            }
        }

        private void dropQtyVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9 
                || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (dropQtyVal.Value >= 0)
                {
                    txtSPVal.Select();
                }
                else
                {
                    pMsg("अमान्य Quantity !...");
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtProductNm.SelectAll();
            }
        }

        private void txtSPVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9
                || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtSPVal.Text != "")
                {
                    double nuSP = 0.0;
                    bool isNumber = double.TryParse(txtSPVal.Text.ToString(), out nuSP);
                    if (isNumber)
                    {
                        txtDPVal.Select();
                    }
                    else
                    {

                        msg("SP का value अमान्य है !...");
                        txtSPVal.Text = "";
                        txtSPVal.Select();
                    }
                }
                else
                {
                    msg("SP का value लिखें !...");
                }
            }
            else if(e.KeyCode == Keys.Up)
            {
                dropQtyVal.Select();
            }

        }

        private void txtDPVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9
                || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtDPVal.Text != "")
                {
                    double nuDP = 0.0;
                    bool isNumber = double.TryParse(txtDPVal.Text.ToString(), out nuDP);
                    if (isNumber)
                    {
                        Int64 qty = Int64.Parse(dropQtyVal.Value.ToString());
                        double dp = Int64.Parse(txtDPVal.Text.ToString());
                        double pr = qty * dp;
                        lblAmtVal.Text = string.Format(pr.ToString());
                        btnUpdate.Select();
                    }
                    else
                    {
                        msg("DP का value अमान्य है !...");
                        txtDPVal.Text = "";
                        txtDPVal.Select();
                    }
                }
                else
                {
                    msg("DP का value लिखें !...");
                }
            }
            else if(e.KeyCode == Keys.Up)
            {
                txtSPVal.SelectAll();
            }

        }

        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == 13 || e.KeyValue == (char)Keys.Tab || e.KeyValue == 9)
            {
                btnUpdate_Click(sender, e);

            }
        }

        private void datdGrid_Items_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            datagrid_Items.Refresh(); getMyData();
        }

        private void btnRefUPrd_Click(object sender, EventArgs e)
        {
            datagrid_Items.Refresh(); getMyData();
        }

        private void btnRefUPrd_MouseHover(object sender, EventArgs e)
        {
            datagrid_Items.Refresh(); getMyData();
        }

        private void btnRefPP_Click(object sender, EventArgs e)
        {
            datagrid_Items.Refresh(); getMyData();
        }

        private void btnRefPP_MouseHover(object sender, EventArgs e)
        {
            datagrid_Items.Refresh(); getMyData();
        }
    }
}
