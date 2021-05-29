using CargoShipping.CoreBusiness;
using System.Collections.Generic;

namespace CargoShipping.UseCases
{
    public interface IViewAllPortsUseCase
    {
        List<Port> Execute();
    }
}