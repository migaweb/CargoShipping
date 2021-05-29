using CargoShipping.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.UseCases.RepositoryPlugins
{
    public interface IPortRepository
    {
        List<Port> GetPorts();
    }
}
