using CargoShipping.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CargoShipping.Repository
{
  public class TripSegmentRepository : ITripSegmentRepository
  {
    private const string connectionString = "Data Source=localhost,1433;Initial Catalog=CargoShipping;Integrated Security=False;User ID=sa;Password=pa55w0rd!";

    private const string SQL = @"SELECT 
                                ts.TripSegmentId,
                                ts.TripId,
                                ts.StartPortId,
                                ts.EndPortId,
                                ts.SailingSequence,
	                            s.TripNumber, 
	                            sp.Name as [StartPort], 
	                            ep.Name as [EndPort], 
	                            ts.StandardHours, 
	                            --Cast(DateDiff(Hour, ts.StartDateTime, ts.EndDateTime) as decimal(6,2)) as [ActualHours], 
	                            ts.StartDateTime, 
	                            ts.EndDateTime
                            FROM TripSegment ts
                            JOIN Trip s on s.tripId = ts.tripId
                            JOIN [Port] sp on ts.StartPortId = sp.PortId
                            JOIN [Port] ep on ts.EndPortId = ep.PortId
                            WHERE TripNumber = @TripNumber Or ISNULL(@TripNumber, '') = ''
                            ORDER BY s.TripNumber, ts.SailingSequence";

    public List<TripSegment> GetTripSegmentsByTripNumber(string tripNumber)
    {

      var listTripSegments = new List<TripSegment>();

      DataTable dtResult = new DataTable();
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        dataAdapter.SelectCommand = cmd;
        cmd.Connection = connection;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = SQL;
        cmd.Parameters.Add(new SqlParameter("@TripNumber", tripNumber.Trim()));

        dataAdapter.Fill(dtResult);
      }

      if (dtResult.Rows == null || dtResult.Rows.Count <= 0) return listTripSegments;


      foreach (DataRow row in dtResult.Rows)
      {
        TripSegment tripSegment = new TripSegment
        {
          TripSegmentId = (int)row["TripSegmentId"],
          TripId = (int)row["TripId"],
          StartPortId = (int)row["StartPortId"],
          EndPortId = (int)row["EndPortId"],
          StartPort = row["StartPort"].ToString(),
          EndPort = row["EndPort"].ToString(),
          SailingSequence = (int)row["SailingSequence"],
          TripNumber = row["TripNumber"].ToString(),
          StandardHours = (decimal)row["StandardHours"],
          StartDateTime = row["StartDateTime"] as DateTime?,
          EndDateTime = row["EndDateTime"] as DateTime?
        };

        listTripSegments.Add(tripSegment);
      }

      return listTripSegments;
    }
  }
}
