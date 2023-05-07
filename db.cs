using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShreeWellnessCenter
{
    internal class db
    {
        protected OracleConnection GetConnection()
        {
            OracleConnection conn = new OracleConnection
            {
                ConnectionString = "Data Source=localhost:1521/XEPDB1; User ID= shree_db; Password=db_shreeWC"
            };
            return conn;
        }
        public DataSet GetData(string query)
        {
            OracleConnection conn = GetConnection();
           OracleCommand cmd = new OracleCommand
            {
                Connection = conn,
                CommandText = query
            };
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            return dataSet;
        }
        public void SetData(string query, string msg)
        {
            OracleConnection conn = GetConnection();
            OracleCommand cmd = new OracleCommand
            {
                Connection = conn
            };
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void SetData(string query)
        {
            OracleConnection conn = GetConnection();
            OracleCommand cmd = new OracleCommand
            {
                Connection = conn
            };
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

      
    }
    
}
