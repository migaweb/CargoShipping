using CargoShipping.CoreBusiness;
using CargoShipping.UseCases.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.UseCases.Helpers
{
  public class TripSegmentHelper
  {
    internal static List<TripSegmentViewModel> ProcessSegments(List<TripSegment> listSegments)
    {
      if (listSegments == null || listSegments.Count <= 0) return new List<TripSegmentViewModel>();

      return listSegments.Select(x =>
      {
        decimal? actualHours = null;
        decimal? sailingVariance = null;
        bool warning = false;

        if (!x.IsTimeValid)
          throw new ApplicationException($"Segment start time and/or end Time of trip {x.TripNumber} are invalid.");

        if (x.StartDateTime.HasValue && x.EndDateTime.HasValue)
        {
          // Get Actual Hours                    
          actualHours = (x.EndDateTime - x.StartDateTime).Value.Hours;

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
