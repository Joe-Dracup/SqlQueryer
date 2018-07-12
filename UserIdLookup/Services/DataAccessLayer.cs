using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace UserIdLookup.Services
{
    class DataAccessLayer
    {
        public DataTable findSqlUsers()
        {
            string connectionString = ConfigurationSettings.AppSettings["SqlConnectionString"].ToString();
            string sql = $@"
                SELECT userId,
                fullname 
                FROM [TABLE NAME]";         

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            connection.Open();
            dataadapter.Fill(dt);
            connection.Close();
            return dt;  
        }

        public DataView queryDataTable(string userName, DataTable dt)
        {;
            DataView dv = new DataView(dt);
            dv.RowFilter = $"(fullname like '%{userName}%')";
            return dv;

        }
    }
}
