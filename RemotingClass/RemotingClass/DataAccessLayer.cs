using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RemotingClass
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection = new SqlConnection();
        public DataAccessLayer()
        {
            //sqlconnection.ConnectionString = "Data Source=.\\sqlexpress; Initial Catalog=Remoting; Integrated Security=True; Connect Timeout=100";
            sqlconnection.ConnectionString = ("Server =DESKTOP-KOATO1B; Database =remoting2; User id =root-turash5; pwd =PasswordPassword!;");
        }
        // open the connection 
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        // close the connection 
        public void Close()
        {
            if (sqlconnection.State != ConnectionState.Closed)
            {
                sqlconnection.Close();
            }
        }

        public DataTable SelectData(string procedureName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Connection = sqlconnection;
            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
            }
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        public void ExecuteCommand(string procedureName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Connection = sqlconnection;
            if (para != null)
            {
                cmd.Parameters.AddRange(para);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
