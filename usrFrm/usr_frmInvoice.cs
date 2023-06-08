using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ShreeWellnessCenter.usrFrm
{
    public partial class usr_frmInvoice : UserControl
    {
         db DB = new db();
        public usr_frmInvoice()
        {
            InitializeComponent();
           
        }
        private void myGetData()
        {
            string query = "SELECT * FROM customer";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridCustomerDetails.DataSource = dataSet.Tables[0];
            }

            string query1 = "SELECT * FROM product";
            DataSet dataSet1 = DB.GetData(query1);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                dataGridProductName.DataSource = dataSet1.Tables[0];
            }
        }

        private void usr_frmInvoice_Load(object sender, EventArgs e)
        {

            myGetData();
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy hh: mm tt");
            lblCurDDMMYY.Text = formattedDateTime;
        }
        private void btnClearItemDetails_Click(object sender, EventArgs e)
        {
            clearProductDetails();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            lblErrPN.Visible = false;
            dataGridProductName.Visible = true;
        }


        //-----------------------My Functions -------------------

        private void clearProductDetails()
        {
            txtProductName.Text = "";
            txtQty.Value = 0;
            txtSP.Text = "";
            txtDP.Text = "";
        }
        private void clearAll()
        {
            clearProductDetails();
            txtCID.Text = "";
            combIDGreen.SelectedIndex = -1;
            txtCName.Text = "";
            txtCMobile.Text = "";
            txtCAddress.Text = "";

            combBillApproved.SelectedIndex = -1;
            combProductStatus.SelectedIndex = -1;
            combRepurchase.SelectedIndex = -1;
            combSP.SelectedIndex = -1;

            txtCash.Text = "";
            combPaymentrStatus.SelectedIndex = -1;
            lblReturn.Visible = false;

            txtBankName.Text = "";
            txtBrancName.Text = "";
            txtChecqueNo.Text = "";
            txtChqAmount.Text = "";
            txtChqDate.Text = "";

        }
        private void msg(string msg)
        {
            string title = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(msg, title, buttons);
            if (result == DialogResult.OK)
            {
               
            }
            else
            {
                
            }

        }

        //--------------------- Key Down -------------------------------------

        private void txtCID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtCID.Text != "")
                {
            
                    combIDGreen.Select();
                    dataGridCustomerDetails.Visible = false;
                }
                else
                {
                    msg("ID लिखें !...");
                    dataGridCustomerDetails.Visible = false;
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                txtCID.SelectAll();
            }
           
           
        }

        private void combIDGreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combIDGreen.SelectedItem != "")
                {
                    txtCName.Select();
                }
                else
                {
                    msg("Value चुनें...");
                }
            }
            else if(e.KeyCode ==Keys.Up)
            {
                txtCID.Select();
            }
        }

        private void txtCName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if(txtCName.Text !="")
                {
                    txtCMobile.Select();
                }
                else
                {
                    msg("Customer का नाम लिखें !...");
                    txtCName.SelectAll();
                }
            }
            else if( e.KeyCode == Keys.Escape)
            {
                txtCName.SelectAll() ;  
            }
            else if(e.KeyCode == Keys.Up)
            {
                combIDGreen.Select();
            }
        }

        private void txtCMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if(txtCMobile.Text != "")
                {
                    txtCAddress.Select();
                }
                else
                {
                    string title = "Information";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show("ग्राहक का Mobile No. खाली छोड़ें !...", title, buttons);
                    if (result == DialogResult.OK)
                    {
                        txtCAddress.Select();
                    }
                    else 
                    { txtCMobile.SelectAll(); 
                    }

                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                txtCMobile.SelectAll();
            }
            else if(e.KeyCode == Keys.Up)
            {
                txtCName.Select();
            }
        }

        private void txtCAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtCAddress.Text != "")
                {
                    txtProductName.Select();
                }
                else
                {
                    string title = "Information";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show("ग्राहक का  Address खाली छोड़ें !...", title, buttons);
                    if (result == DialogResult.OK)
                    {
                        txtProductName.Select();
                    }
                    else
                    {
                        txtCAddress.SelectAll();
                    }

                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtCAddress.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtCMobile.Select();
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if(txtProductName.Text !="")
                {
                    txtQty.Select();
                }
                else
                {
                    lblErrPN.Visible = true;
                    txtProductName.SelectAll();

                }
            }
            else if(e.KeyCode ==Keys.Escape)
            {
                txtProductName.SelectAll();
            }    
            else if(e.KeyCode == Keys.Up)
            {
                txtCAddress.Select();
            }
        }

        private void txtProductName_Click(object sender, EventArgs e)
        {
            dataGridProductName.Visible = true;
            lblErrPN.Visible = false;
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if(txtQty.Value >0)
                {
                    txtSP.Select();
                    if(txtSP.Text != "" && txtDP.Text !="")
                    {
                        Int64 qty = Int64.Parse(txtQty.Value.ToString());
                        double dp = Int64.Parse(txtDP.Text.ToString());
                        double pr = qty * dp;
                        lblProductPrice.Text = string.Format(pr.ToString());
                        btnAddItem.Select();
                    }

                }
                else
                {
                    msg("Quantity बताएं...");
                    txtQty.Select();
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                txtQty.Select();
            }
            else if(e.KeyCode ==Keys.Up)
            {
                txtProductName.Select();
            }

        }

        private void txtSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtSP.Text !="")
                {
                    txtDP.Select();

                }
                else
                {
                    msg("SP बताएं...");
                    txtSP.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSP.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtQty.Select();
            }
        }

        private void txtDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtDP.Text != "")
                {
                    btnAddItem.Select();
                    try
                    {
                        if (txtDP.Text != "")
                        {
                            Int64 qty = Int64.Parse(txtQty.Value.ToString());
                            double dp = Int64.Parse(txtDP.Text.ToString());
                            double pr = qty * dp;
                            lblProductPrice.Text = string.Format(pr.ToString());
                            btnAddItem.Select();
                        }
                        else
                        {
                            msg("DP बताएं...");
                            txtDP.Select();
                        }
                    }
                    catch
                    {

                    }
                }
                else
                {
                    msg("DP बताएं...");
                    txtDP.Select();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDP.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtDP.Select();
            }

        }

        private void combBillApproved_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combBillApproved.SelectedItem != "")
                {
                    combProductStatus.Select();
                }
                else
                {
                    msg("Bill Status बताएं...");
                    combBillApproved.SelectAll();
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                combBillApproved.SelectAll();
            }
            else if(e.KeyCode == Keys.Up)
            {
                txtProductName.Select();
            }
        }

        private void combProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combProductStatus.SelectedItem != "")
                {
                    combRepurchase.Select();
                }
                else
                {
                    msg("Product Status बताएं...");
                    combProductStatus.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                combProductStatus.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
               combBillApproved.Select();
            }

        }

        private void combRepurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combRepurchase.SelectedItem != "")
                {
                    combSP.Select();
                }
                else
                {
                    msg("Re-Purchase Staus बताएं...");
                    combRepurchase.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                combRepurchase.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                combProductStatus.Select();
            }
        }

        private void combSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combSP.SelectedItem != "")
                {
                    txtCash.Select();
                }
                else
                {
                    msg("SP Status बताएं...");
                    combSP.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                combSP.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                combRepurchase.Select();
            }
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtCash.Text != "")
                {
                    combPaymentrStatus.Select();
                }
                else
                {
                    msg("ग्राहक द्वारा दिये गये Amount को लिखें ...");
                    txtCash.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtCash.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                combSP.Select();
            }
        }

        private void combPaymentrStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (combPaymentrStatus.SelectedItem != "")
                {
                    txtBankName.Select();
                }
                else
                {
                    msg("Payment Status बताएं...");
                    combPaymentrStatus.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                combPaymentrStatus.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtCash.Select();
            }
        }

        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtBankName.Text != "")
                {
                    txtBrancName.Select();
                }
                else
                {
                    string title = "Information";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result = MessageBox.Show("Bank का नाम खाली छोड़ें !...", title, buttons);
                    if (result == DialogResult.OK)
                    {
                        txtBrancName.Select();
                    }
                    else
                    {
                        txtBankName.SelectAll();
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtBankName.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                combPaymentrStatus.Select();
            }
        }

        private void txtBrancName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtBrancName.Text != "")
                {
                    txtChecqueNo.Select();
                }
                else
                {
                    if (txtBankName.Text !="")
                    {
                        string title = "Information";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show("Branch का नाम खाली छोड़ें !...", title, buttons);
                        if (result == DialogResult.OK)
                        {
                            txtChecqueNo.Select();
                        }
                        else
                        {
                            txtBrancName.SelectAll();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtBrancName.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtBankName.Select();
            }
        }

        private void txtChecqueNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtChecqueNo.Text != "")
                {
                    txtChqAmount.Select();
                }
                else
                {
                    if (txtBrancName.Text != "" || txtBankName.Text !="")
                    {
                        string title = "Information";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show("Checque No. खाली छोड़ें !...", title, buttons);
                        if (result == DialogResult.OK)
                        {
                            txtChqAmount.Select();
                        }
                        else
                        {
                            txtChecqueNo.SelectAll();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtChecqueNo.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtBrancName.Select();
            }
        }

        private void txtChqAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtChqAmount.Text != "")
                {
                    txtChqDate.Select();
                }
                else
                {
                    if (txtBrancName.Text != "" || txtBankName.Text != "" || txtChecqueNo.Text!="")
                    {
                        string title = "Information";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show("Checque amount खाली छोड़ें !...", title, buttons);
                        if (result == DialogResult.OK)
                        {
                            txtChqDate.Select();
                        }
                        else
                        {
                            txtChqAmount.SelectAll();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtChqAmount.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtChecqueNo.Select();
            }
        }

        private void txtChqDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                if (txtChqDate.Text != "")
                {
                    btnPrint.Select();
                }
                else
                {
                    if (txtBrancName.Text != "" || txtBankName.Text != "" || txtChecqueNo.Text != ""||txtChqAmount.Text!="")
                    {
                        string title = "Information";
                        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                        DialogResult result = MessageBox.Show("Checque Date खाली छोड़ें !...", title, buttons);
                        if (result == DialogResult.OK)
                        {
                            btnPrint.Select();
                        }
                        else
                        {
                            txtChqDate.SelectAll();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtChqDate.SelectAll();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtChqAmount.Select();
            }
        }

        private void txtCID_TextChanged(object sender, EventArgs e)
        {
            dataGridCustomerDetails.Visible = true;

            dataGridCustomerDetails.Refresh();
            string input = txtCID.Text;
            string uppercasetxt = input.ToUpper();
            string query = "select * from  customer where user_id like '" + uppercasetxt + "%'";
            DataSet ds = DB.GetData(query);
            dataGridCustomerDetails.DataSource = ds.Tables[0];
            //dataGridCustomerDetails.Refresh();
        }

        private void txtCID_Leave(object sender, EventArgs e)
        {
            dataGridCustomerDetails.Visible = false;
        }

        private void txtCID_Click(object sender, EventArgs e)
        {
            dataGridCustomerDetails.Visible = true;
            txtCID.SelectAll();
            
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            dataGridProductName.Visible = false;
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                dataGridProductName.Visible = false;
            }
        }

        private void txtCID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                dataGridCustomerDetails.Visible = false;
            }
        }


        private void dataGridCustomerDetails_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCID.Text = dataGridCustomerDetails.Rows[e.RowIndex].Cells[0].Value.ToString();
                combIDGreen.SelectedItem = dataGridCustomerDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCName.Text = dataGridCustomerDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCMobile.Text = dataGridCustomerDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCAddress.Text = dataGridCustomerDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                dataGridCustomerDetails.Visible = false;
            }
            catch
            {
              //  myGetData();
            }
         
        }

        private void dataGridProductName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtProductName.Text = dataGridProductName.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSP.Text = dataGridProductName.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDP.Text = dataGridProductName.Rows[e.RowIndex].Cells[3].Value.ToString();
                dataGridProductName.Visible = false;
          
            }
            catch
            {
                //myGetData();
            }

        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSP.Select();
                if (txtSP.Text != "" && txtDP.Text != "")
                {
                    Int64 qty = Int64.Parse(txtQty.Value.ToString());
                    double dp = Int64.Parse(txtDP.Text.ToString());
                    double pr = qty * dp;
                    lblProductPrice.Text = string.Format(pr.ToString());
                    btnAddItem.Select();
                }
            }
            catch
            {

            }
        }

        private void txtDP_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDP.Text != "")
                {
                    Int64 qty = Int64.Parse(txtQty.Value.ToString());
                    double dp = Int64.Parse(txtDP.Text.ToString());
                    double pr = qty * dp;
                    lblProductPrice.Text = string.Format(pr.ToString());
                    btnAddItem.Select();
                }
                else
                {
                    msg("DP बताएं...");
                    txtDP.Select();
                }
            }
            catch
            {

            }
        }
        private void tempTable()
        {
            string query = "DROP TABLE temp_order_details";
            DB.SetData(query);

            string query1 = "CREATE GLOBAL TEMPORARY TABLE temp_order_details (sl_no NUMBER GENERATED ALWAYS AS IDENTITY (START WITH 1), user_id VARCHAR2(10), product_name VARCHAR2(35), " +
                "   Qty NUMBER,Sp NUMBER(6,2), Dp NUMBER(6,2),total NUMBER(6,2)) ON COMMIT PRESERVE ROWS";
            DB.SetData(query1);

            string userID = txtCID.Text.ToUpper();

            string query2 = "INSERT INTO temp_order_details(user_id, product_name, Qty, Sp, Dp, total) SELECT  user_id, product_name, Qty, Sp, Dp, total FROM Order_Details WHERE user_id = '" + userID + "'";
            DB.SetData(query2);

            string query3 = "SELECT product_name, Qty, Sp, Dp, total FROM temp_order_details";
            DB.SetData(query3);
            DataSet dataSet1 = DB.GetData(query3);
            if (dataSet1.Tables[0].Rows.Count > 0)
            {
                dataGrid_OrderedItems.DataSource = dataSet1.Tables[0];
            }

        }
        private void myOrder()
        {

            Int64 qty = Int64.Parse(txtQty.Value.ToString());
            double dp = Int64.Parse(txtDP.Text.ToString());
            double pr = qty * dp;
            lblProductPrice.Text = string.Format(pr.ToString());

            string userID = txtCID.Text.ToUpper();
            string productName = txtProductName.Text.ToUpper();
           // Int64 qty = Int64.Parse(txtQty.Value.ToString());
            double sp = double.Parse(txtSP.Text.ToString());
            //double  dp =double.Parse(txtDP.Text.ToString());
            double total = double.Parse(lblProductPrice.Text.ToString());
            string query = "INSERT INTO Order_Details(user_id, product_name, Qty, Sp, Dp, total) VALUES ('"+userID+"','"+productName+"',"+qty+","+sp+","+dp+","+pr+")";
            DB.SetData(query);
            dataGrid_OrderedItems.Refresh();

            tempTable();

          //  string query2 = "INSERT INTO temp_order_details(user_id, product_name, Qty, Sp, Dp, total) SELECT user_id, product_name, Qty, Sp, Dp, total FROM Order_Details WHERE user_id = '" + userID + "'";
          //  DB.SetData(query2);

          //  string query1 = "SELECT product_name, Qty, Sp, Dp, total FROM temp_order_details";
          //  DB.SetData(query1);
          ////  string query1 = "SELECT  sl_no,product_name,qty,sp,dp,total FROM order_details";
          //  DataSet dataSet1 = DB.GetData(query1);
          //  if (dataSet1.Tables[0].Rows.Count > 0)
          //  {
          //      dataGrid_OrderedItems.DataSource = dataSet1.Tables[0];
           // }

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
          
                if (txtProductName.Text != "")
                {
                    if (txtQty.Value > 0)
                    {
                        if (txtSP.Text != "")
                        {
                            if (txtDP.Text != "")
                            {
                                myOrder();
                            }
                            else
                            {
                                msg("DP की Value लिखें...");
                                txtDP.Select();
                            }
                        }
                        else
                        {
                            msg("SP की Value लिखें...");
                            txtSP.Select();
                        }
                    }
                    else
                    {
                        msg("Product Quantity को 1 या अधिक करें...");
                        txtQty.Select();
                    }
                }
                else
                {
                    lblErrPN.Visible = true;
                    txtProductName.Select();
                }
       
        }
    }
}
