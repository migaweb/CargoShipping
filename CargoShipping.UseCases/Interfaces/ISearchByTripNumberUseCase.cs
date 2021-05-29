using CargoShipping.UseCases.ViewModels;
using System.Collections.Generic;

namespace CargoShipping.UseCases
{
    public interface ISearchByTripNumberUseCase
    {
        List<TripSegmentViewModel> Execute(string tripNumber);
    }
}