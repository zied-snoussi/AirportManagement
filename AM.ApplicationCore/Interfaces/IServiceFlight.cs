using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface for Flight Service operations
    /// Each operation has both Native (iterative) and LINQ versions for learning comparison
    /// </summary>
    public interface IServiceFlight
    {
        // Property for flights data source
        List<Flight> Flights { get; set; }

        #region Q6: Get Flight Dates by Destination
        List<DateTime> GetFlightDates(string destination);              // Native: FOR loop
        List<DateTime> GetFlightDatesLinq(string destination);          // LINQ: Where + Select
        #endregion

        #region Q7: Get Flight Dates (FOREACH)
        List<DateTime> GetFlightDatesForEach(string destination);       // Native: FOREACH loop
        List<DateTime> GetFlightDatesForEachLinq(string destination);   // LINQ: Same as Q6
        #endregion

        #region Q8: Dynamic Filtering
        List<Flight> GetFlights(string filterType, string filterValue); // Native: FOREACH + Reflection
        List<Flight> GetFlightsLinq(string filterType, string filterValue); // LINQ: Where + Reflection
        #endregion

        #region Q10: Show Flight Details by Plane
        void ShowFlightDetailsByPlane(Plane plane);                     // LINQ: Where + Select (Anonymous Types)
        #endregion

        #region Q11: Weekly Flight Count
        int GetWeeklyFlightCountNative(DateTime startDate);             // Native: Counter loop
        int GetWeeklyFlightCount(DateTime startDate);                   // LINQ: Count with predicate
        int GetWeeklyFlightCountQuery(DateTime startDate);              // LINQ: Query syntax
        #endregion

        #region Q12: Average Flight Duration
        double GetAverageFlightDurationNative(string destination);      // Native: Manual sum/count
        double GetAverageFlightDuration(string destination);            // LINQ: Average with predicate
        double GetAverageFlightDurationQuery(string destination);       // LINQ: Query syntax
        #endregion

        #region Q13: Ordered Flights by Duration
        List<Flight> GetOrderedFlightsByDurationNative();               // Native: List.Sort
        List<Flight> GetOrderedFlightsByDuration();                     // LINQ: OrderByDescending
        #endregion

        #region Q14: Senior Travellers
        List<Traveller> GetSeniorTravellersNative(Flight flight);       // Native: Filter + Sort + Take
        List<Traveller> GetSeniorTravellers(Flight flight);             // LINQ: OfType + OrderBy + Take
        #endregion

        #region Q15: Group Flights by Destination
        void ShowFlightsGroupedByDestinationNative();                   // Native: Dictionary grouping
        void ShowFlightsGroupedByDestination();                         // LINQ: GroupBy + OrderBy
        IEnumerable<IGrouping<string, Flight>> GetFlightsGroupedByDestinationLinq(); // LINQ: GroupBy
        #endregion

        #region Q16: Legacy/Backward Compatibility
        List<DateTime> GetFlightDatesLinqV2(string destination);        // Alias for GetFlightDatesLinq
        #endregion
    }
}



