using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.Plugins.Repository.ADONET
{
    public class SQLHelper
    {
        public static DataTable RunSQLReturnDataTable(string connectionString, string SQL, SqlParameter[] parameters = null)
        {
            DataTable dtResult = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                dataAdapter.SelectCommand = cmd;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                dataAdapter.Fill(dtResult);
            }

            return dtResult;
        }
    }
}
