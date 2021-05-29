using CargoShipping.UseCases.Helpers;
using CargoShipping.UseCases.RepositoryPlugins;
using CargoShipping.UseCases.ViewModels;
using System;
using System.Collections.Generic;

namespace CargoShipping.UseCases
{
  public class SearchByPortUseCase : ISearchByPortUseCase
  {
    private readonly ITripSegmentRepository tripSegmentRepository;

    public SearchByPortUseCase(ITripSegmentRepository tripSegmentRepository)
    {
      this.tripSegmentRepository = tripSegmentRepository;
    }

    public List<TripSegmentViewModel> Execute(int portId)
    {
      var listSegments = tripSegmentRepository.GetTripSegmentsByPort(portId);
      return TripSegmentHelper.ProcessSegments(listSegments);
    }
  }
}
