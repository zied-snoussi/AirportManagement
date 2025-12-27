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

        // Q7: Get flight dates for a given destination using FOREACH loop
        List<DateTime> GetFlightDatesForEach(string destination);

        // Q8: Dynamic filtering
        List<Flight> GetFlights(string filterType, string filterValue);

        // Q9: Get flight dates using LINQ
        List<DateTime> GetFlightDatesLinq(string destination);

        // Q10: Show flight details by plane
        void ShowFlightDetailsByPlane(Plane plane);

        // Q11: Weekly flight count
        int GetWeeklyFlightCount(DateTime startDate);

        // Q11.2: Weekly flight count using LINQ query syntax
        int GetWeeklyFlightCountQuery(DateTime startDate);

        // Q12: Average flight duration for a destination
        double GetAverageFlightDuration(string destination);

        // Q12.2: Average flight duration using LINQ query syntax
        double GetAverageFlightDurationQuery(string destination);

        // Q13: Ordered flights by duration (longest to shortest)
        List<Flight> GetOrderedFlightsByDuration();

        // Q14: Get 3 senior travellers from a flight
        List<Traveller> GetSeniorTravellers(Flight flight);

        // Q15: Group flights by destination
        void ShowFlightsGroupedByDestination();

        // Q16: Section II rewritten with LINQ methods
        List<DateTime> GetFlightDatesLinqV2(string destination);
        List<DateTime> GetFlightDatesForEachLinq(string destination);
        List<Flight> GetFlightsLinq(string filterType, string filterValue);
    }
}


