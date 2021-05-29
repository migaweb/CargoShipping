namespace CargoShipping.UseCases.ViewModels
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
