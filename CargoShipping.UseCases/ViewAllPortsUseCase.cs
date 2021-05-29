using CargoShipping.CoreBusiness;
using CargoShipping.UseCases.RepositoryPlugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.UseCases
{
  public class ViewAllPortsUseCase : IViewAllPortsUseCase
  {
    private readonly IPortRepository portRepository;

    public ViewAllPortsUseCase(IPortRepository portRepository)
    {
      this.portRepository = portRepository;
    }

    public List<Port> Execute()
    {
      var ports = portRepository.GetPorts();
      ports.Insert(0, new Port { PortId = 0, Name = "All Ports" });

      return ports;
    }
  }
}
