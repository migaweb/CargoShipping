using CargoShipping.Service.ViewModels;
using System.Collections.Generic;

namespace CargoShipping.Service
{
  public interface ITripSegmentService
  {
    List<TripSegmentViewModel> GetTripSegmentsByTripNumber(string tripNumber);
  }
}