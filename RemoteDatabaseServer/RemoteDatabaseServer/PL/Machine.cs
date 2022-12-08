using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RemoteDatabaseServer.PL
{
    class Machine
    {
        DataAccessLayer DAL = new DataAccessLayer();
        public DataTable Get_Machines()
        {
            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_Machines", null);
            DAL.Close();
            return dt;
        }

        public void Add_Machine(string Name, string Manufacturer, string MessageProtocol, string Status)
        {
            DAL.Open();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            para[0].Value = Name;
            para[1] = new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50);
            para[1].Value = Manufacturer;
            para[2] = new SqlParameter("@messageprotocol", SqlDbType.NVarChar, 10);
            para[2].Value = MessageProtocol;
            para[3] = new SqlParameter("@status", SqlDbType.NVarChar, 10);
            para[3].Value = Status;
            DAL.ExecuteCommand("Add_Machine", para);
            DAL.Close();
        }
        public void Delete_Machine(int ID)
        {
            DAL.Open();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@ID", SqlDbType.Int);
            para[0].Value = ID;
            DAL.ExecuteCommand("Delete_Machine", para);
            DAL.Close();
        }
        public void Update_Machine(int ID, string Name, string Manufacturer, string MessageProtocol, string Status)
        {
            DAL.Open();
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            para[0].Value = Name;
            para[1] = new SqlParameter("@manufacturer", SqlDbType.NVarChar, 50);
            para[1].Value = Manufacturer;
            para[2] = new SqlParameter("@messageprotocol", SqlDbType.NVarChar, 10);
            para[2].Value = MessageProtocol;
            para[3] = new SqlParameter("@status", SqlDbType.NVarChar, 10);
            para[3].Value = Status;
            para[4] = new SqlParameter("@ID", SqlDbType.Int);
            para[4].Value = ID;
            DAL.ExecuteCommand("Update_Machine", para);
            DAL.Close();
        }

    }
}
