using CargoShipping.CoreBusiness;
using CargoShipping.UseCases.RepositoryPlugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CargoShipping.Plugins.Repository.ADONET
{
    public class TripSegmentRepository : ITripSegmentRepository
    {
        private const string connectionString = "Data Source=localhost,1433;Initial Catalog=CargoShipping;Integrated Security=False;User ID=sa;Password=pa55w0rd!";

        private const string SQL_SearchByTripNumber = @"SELECT 
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

        private const string SQL_SearchByPort = @"SELECT
                                ts.TripSegmentId,
                                ts.TripId,
                                ts.StartPortId,
                                ts.EndPortId,
                                ts.SailingSequence,
	                            s.TripNumber, 
	                            sp.Name as [StartPort], 
	                            ep.Name as [EndPort], 
	                            ts.StandardHours, 	                            
	                            ts.StartDateTime, 
	                            ts.EndDateTime
                            FROM TripSegment ts
                            JOIN Trip s on s.tripId = ts.tripId
                            JOIN [Port] sp on ts.StartPortId = sp.PortId
                            JOIN [Port] ep on ts.EndPortId = ep.PortId
                            WHERE s.TripNumber in
                            (
                                SELECT distinct s.TripNumber                                
                                FROM TripSegment ts
                                JOIN Trip s on s.tripId = ts.tripId
                                JOIN [Port] sp on ts.StartPortId = sp.PortId
                                JOIN [Port] ep on ts.EndPortId = ep.PortId
                                WHERE sp.PortId = @PortID or ep.PortID = @PortID or @PortID = 0
                            )";

        public List<TripSegment> GetTripSegmentsByTripNumber(string tripNumber)
        {
            var listTripSegments = new List<TripSegment>();

            DataTable dtResult = new DataTable();
            dtResult = SQLHelper.RunSQLReturnDataTable(
                connectionString,
                SQL_SearchByTripNumber,
                new SqlParameter[] { new SqlParameter("@TripNumber", tripNumber.Trim()) });

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

        public List<TripSegment> GetTripSegmentsByPort(int portId)
        {
            var listTripSegments = new List<TripSegment>();

            DataTable dtResult = new DataTable();
            dtResult = SQLHelper.RunSQLReturnDataTable(
                connectionString,
                SQL_SearchByPort,
                new SqlParameter[] { new SqlParameter("@PortID", portId) });

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
