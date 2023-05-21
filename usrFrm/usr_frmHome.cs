using System;
using System.Data;
using System.Windows.Forms;

namespace ShreeWellnessCenter.usrFrm
{
    public partial class usr_frmHome : UserControl
    {
        db DB = new db();
        public usr_frmHome()
        {
            InitializeComponent();

            datagrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                datagrid_Items.DataSource = dataSet.Tables[0];
            }
            txtProductName.Text = "";
        }

        private void guna2TextBox4_Click(object sender, EventArgs e)
        {
            if (datagrid_Items.Visible == false)
            { datagrid_Items.Visible = true; }
            else
            { datagrid_Items.Visible = true; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            if (datagrid_Items.Visible == true)
            { datagrid_Items.Visible = false; }
            else { datagrid_Items.Visible = false; }
        }

        private void usr_frmHome_Load(object sender, EventArgs e)
        {
            datagrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                datagrid_Items.DataSource = dataSet.Tables[0];
            }
            txtProductName.Text = "";


        }

        private void usr_frmHome_Leave(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            datagrid_Items.Refresh();
            if (datagrid_Items.Visible == true)
            { datagrid_Items.Visible = false; }
            else
            { datagrid_Items.Visible = false; }

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

        private void datagrid_Items_Click(object sender, EventArgs e)
        {

            datagrid_Items.Refresh();
            string query = "select * from product";
            DataSet dataSet = DB.GetData(query);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                datagrid_Items.DataSource = dataSet.Tables[0];
            }
            txtProductName.Text = "";
        }
    }
}
