using CargoShipping.Repository;
using CargoShipping.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoShipping.Service
{
  public class TripSegmentService : ITripSegmentService
  {
    private ITripSegmentRepository _tripSegmentRepository;

    public TripSegmentService(ITripSegmentRepository tripSegmentRepository)
    {
      _tripSegmentRepository = tripSegmentRepository;
    }

    public List<TripSegmentViewModel> GetTripSegmentsByTripNumber(string tripNumber)
    {
      // Get Trip Segments            
      var listSegments = _tripSegmentRepository.GetTripSegmentsByTripNumber(tripNumber);

      if (listSegments == null || listSegments.Count <= 0) return new List<TripSegmentViewModel>();

      return listSegments.Select(x =>
      {
        decimal? actualHours = null;
        decimal? sailingVariance = null;
        bool warning = false;

        if (x.StartDateTime.HasValue && x.EndDateTime.HasValue)
        {
          // Get Actual Hours                    
          actualHours = (x.EndDateTime - x.StartDateTime).Value.Hours;
          if (actualHours.HasValue && actualHours < 0)
            throw new ApplicationException($"Segment start time and end Time of trip {tripNumber} are incorrect.");

          // Get Sailing Variance in the segment                    
          sailingVariance = actualHours - x.StandardHours;

          // Report warning when sailing variance is more than 10% of the standard time                    
          if (sailingVariance.HasValue && sailingVariance / x.StandardHours > (decimal)0.1)
            warning = true;
        }

        return new TripSegmentViewModel
        {
          TripNumber = x.TripNumber,
          StartPort = x.StartPort,
          EndPort = x.EndPort,
          StandardHours = x.StandardHours,
          SailingSequence = x.SailingSequence,
          ActualHours = actualHours,
          StartDateTime = x.StartDateTime?.ToString("MM/dd/yyyy hh:mm tt") ?? string.Empty,
          EndDateTime = x.EndDateTime?.ToString("MM/dd/yyyy hh:mm tt") ?? string.Empty,
          VarianceWarning = warning
        };
      }).ToList();
    }

  }
}
