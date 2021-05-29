using CargoShipping.CoreBusiness;
using CargoShipping.UseCases.RepositoryPlugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.Plugins.Repository.ADONET
{
    public class PortRepository : IPortRepository
    {
        private const string connectionString = "Data Source=localhost,1433;Initial Catalog=CargoShipping;Integrated Security=False;User ID=sa;Password=pa55w0rd!";

        private const string SQL = "SELECT * FROM Port";

        public List<Port> GetPorts()
        {
            var dtResult = SQLHelper.RunSQLReturnDataTable(connectionString, SQL);

            var listPorts = new List<Port>();
            foreach (DataRow row in dtResult.Rows)
            {
                Port port = new Port
                {
                    PortId = (int)row["PortId"],                    
                    Name = row["Name"].ToString()                    
                };

                listPorts.Add(port);
            }

            return listPorts;
        }
    }
}
