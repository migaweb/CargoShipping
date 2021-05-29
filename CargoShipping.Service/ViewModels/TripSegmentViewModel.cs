using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoShipping.Service.ViewModels
{
  public class TripSegmentViewModel
  {
    public string TripNumber { get; set; }
    public string StartPort { get; set; }
    public string EndPort { get; set; }
    public decimal StandardHours { get; set; }
    public decimal? ActualHours { get; set; }
    public int SailingSequence { get; set; }
    public string StartDateTime { get; set; }
    public string EndDateTime { get; set; }
    public bool VarianceWarning { get; set; }
  }
}
