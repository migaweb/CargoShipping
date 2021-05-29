using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargoShipping.WinForms
{
    public partial class frmTrips : Form
    {
        string conString = "Data Source=localhost,1433;Initial Catalog=CargoShipping;Integrated Security=False;User ID=sa;Password=pa55w0rd!";

        public frmTrips()
        {
            InitializeComponent();
        }

        private void btnSearchByTripNumber_Click(object sender, EventArgs e)
        {
            string SQL = @"SELECT 
	                            s.TripNumber, 
	                            sp.Name as [StartPort], 
	                            ep.Name as [EndPort], 
	                            ts.StandardHours, 
	                            Cast(DateDiff(Hour, ts.StartDateTime, ts.EndDateTime) as decimal(6,2)) as [ActualHours], 
	                            ts.StartDateTime, 
	                            ts.EndDateTime
                            FROM TripSegment ts
                            JOIN Trip s on s.tripId = ts.tripId
                            JOIN [Port] sp on ts.StartPortId = sp.PortId
                            JOIN [Port] ep on ts.EndPortId = ep.PortId
                            WHERE TripNumber = @TripNumber Or ISNULL(@TripNumber, '') = ''
                            ORDER BY s.TripNumber, ts.SailingSequence";

            DataTable dtResult = new DataTable();
            using (SqlConnection connection = new SqlConnection(conString))
            {                
                SqlDataAdapter dataAdapter = new SqlDataAdapter();                
                SqlCommand cmd = new SqlCommand();
                dataAdapter.SelectCommand = cmd;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Parameters.Add(new SqlParameter("@TripNumber", txtTripNumber.Text.Trim()));

                dataAdapter.Fill(dtResult);
            }

            gvTrips.DataSource = dtResult.DefaultView;
        }        

        private void gvTrips_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!gvTrips.Columns.Contains("Warning"))
            {
                var warningColumn = new DataGridViewButtonColumn
                {
                    Text = "Warning",
                    Name = "Warning",
                    Width = 140
                };
                gvTrips.Columns.Add(warningColumn);
            }
        }

        private void gvTrips_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //display warning sign if variance is greater than 10%

            DataTable data = ((DataView)gvTrips.DataSource).Table;

            if (e.RowIndex < 0 || 
                e.RowIndex >= data.Rows.Count ||
                DBNull.Value.Equals(data.Rows[e.RowIndex]["ActualHours"]) ||
                DBNull.Value.Equals(data.Rows[e.RowIndex]["StandardHours"])) return;

            decimal? standardHours = null, actualHours = null;
            actualHours = (decimal?)data.Rows[e.RowIndex]["ActualHours"];
            standardHours = (decimal?)data.Rows[e.RowIndex]["StandardHours"];            

            if (standardHours.HasValue && actualHours.HasValue && (actualHours - standardHours) / standardHours > (decimal)0.1)
            {
                if (e.ColumnIndex >= 0 && gvTrips.Columns[e.ColumnIndex].Name == "Warning" && e.RowIndex >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);                    
                    e.Graphics.DrawImage(Resource.Warning, //(e.CellBounds.Width - 15) + e.CellBounds.Left, e.CellBounds.Top);
                        (int)((e.CellBounds.Width / 2) - (Resource.Warning.Width / 2)) + e.CellBounds.Left,
                        (int)((e.CellBounds.Height / 2) - (Resource.Warning.Height / 2)) + e.CellBounds.Top);
                    e.Handled = true;
                }
            }            
        }
    }
}
