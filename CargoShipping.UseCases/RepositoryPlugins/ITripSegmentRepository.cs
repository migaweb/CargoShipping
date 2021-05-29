using CargoShipping.CoreBusiness;
using System.Collections.Generic;

namespace CargoShipping.UseCases.RepositoryPlugins
{
    public interface ITripSegmentRepository
    {
        List<TripSegment> GetTripSegmentsByTripNumber(string tripNumber);
        List<TripSegment> GetTripSegmentsByPort(int portId);
    }
}