using CargoShipping.Repository;
using CargoShipping.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CargoShipping.WinForms
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var services = new ServiceCollection();
      ConfigureServices(services);

      using (ServiceProvider serviceProvider = services.BuildServiceProvider())
      {
        var frmTrips = serviceProvider.GetRequiredService<frmTrips>();
        Application.Run(frmTrips);
      }
    }

    static void ConfigureServices(ServiceCollection services)
    {
      services.AddTransient<frmTrips>();
      services.AddTransient<ITripSegmentService, TripSegmentService>();
      services.AddTransient<ITripSegmentRepository, TripSegmentRepository>();
    }
  }
}
