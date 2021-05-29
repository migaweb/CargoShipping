using CargoShipping.UseCases.Helpers;
using CargoShipping.UseCases.RepositoryPlugins;
using CargoShipping.UseCases.ViewModels;
using System.Collections.Generic;

namespace CargoShipping.UseCases
{
  public class SearchByTripNumberUseCase : ISearchByTripNumberUseCase
  {
    private ITripSegmentRepository tripSegmentRepository;

    public SearchByTripNumberUseCase(ITripSegmentRepository tripSegmentRepository)
    {
      this.tripSegmentRepository = tripSegmentRepository;
    }

    public List<TripSegmentViewModel> Execute(string tripNumber)
    {
      // Get Trip Segments            
      var listSegments = tripSegmentRepository.GetTripSegmentsByTripNumber(tripNumber);
      return TripSegmentHelper.ProcessSegments(listSegments);
    }

  }
}
