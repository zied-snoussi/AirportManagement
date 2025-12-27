using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        // Property for flights data source
        List<Flight> Flights { get; set; }

        // Q6: Get flight dates for a given destination using FOR loop
        List<DateTime> GetFlightDates(string destination);
    }
}
