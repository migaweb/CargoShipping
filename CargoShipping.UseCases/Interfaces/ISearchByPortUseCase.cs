using CargoShipping.UseCases.ViewModels;
using System.Collections.Generic;

namespace CargoShipping.UseCases
{
    public interface ISearchByPortUseCase
    {
        List<TripSegmentViewModel> Execute(int portId);
    }
}