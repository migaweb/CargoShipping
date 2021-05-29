using CargoShipping.Domain;
using System.Collections.Generic;

namespace CargoShipping.Repository
{
  public interface ITripSegmentRepository
  {
    List<TripSegment> GetTripSegmentsByTripNumber(string tripNumber);
  }
}