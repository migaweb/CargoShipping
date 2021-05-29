using System;

namespace CargoShipping.Domain
{
  public class TripSegment
  {
    public int TripSegmentId { get; set; }
    public int TripId { get; set; }
    public int StartPortId { get; set; }
    public int EndPortId { get; set; }
    public string TripNumber { get; set; }
    public string StartPort { get; set; }
    public string EndPort { get; set; }
    public int SailingSequence { get; set; }
    public decimal StandardHours { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
  }
}
