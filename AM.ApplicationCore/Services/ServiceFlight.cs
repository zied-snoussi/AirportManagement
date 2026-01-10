using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    /// <summary>
    /// Service class for managing flight operations and queries
    /// Demonstrates both iterative (native) and LINQ approaches for each operation
    /// </summary>
    public class ServiceFlight : IServiceFlight
    {
        // Flights data source - initialized as empty list
        public List<Flight> Flights { get; set; }

        // Constructor
        public ServiceFlight()
        {
            Flights = new List<Flight>();
        }

        #region ========== Q6: Get Flight Dates by Destination ==========

        /// <summary>
        /// Q6: Get flight dates for a given destination using FOR loop (Native/Iterative)
        /// Approach: Traditional imperative programming with index-based loop
        /// </summary>
        /// <param name="destination">Destination city name</param>
        /// <returns>List of flight dates</returns>
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            // Iterate through flights using index-based for loop
            for (int i = 0; i < Flights.Count; i++)
            {
                // Filter by destination (case-insensitive)
                if (Flights[i].Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(Flights[i].FlightDate);
                }
            }

            return flightDates;
        }

        /// <summary>
        /// Q6 - LINQ Version: Get flight dates using LINQ query
        /// Approach: Declarative programming with functional style
        /// Best Practice: More readable, concise, and expressive
        /// </summary>
        public List<DateTime> GetFlightDatesLinq(string destination)
        {
            return Flights
                .Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                .Select(f => f.FlightDate)
                .ToList();
        }

        #endregion

        #region ========== Q7: Get Flight Dates (FOREACH) ==========

        /// <summary>
        /// Q7: Get flight dates using FOREACH loop (Native/Iterative)
        /// Approach: Simpler than FOR loop, more readable for collection iteration
        /// </summary>
        public List<DateTime> GetFlightDatesForEach(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            // Iterate through flights using foreach (more readable than for)
            foreach (Flight flight in Flights)
            {
                if (flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }

        /// <summary>
        /// Q7 - LINQ Version: Same as Q6 LINQ (reuse)
        /// Best Practice: DRY principle - Don't Repeat Yourself
        /// </summary>
        public List<DateTime> GetFlightDatesForEachLinq(string destination)
        {
            return GetFlightDatesLinq(destination);
        }

        #endregion

        #region ========== Q8: Dynamic Filtering by Property ==========

        /// <summary>
        /// Q8: Dynamic filtering by any Flight property (Native/Iterative with Reflection)
        /// Approach: Uses reflection to dynamically access properties
        /// Use Case: Generic filtering when property name is determined at runtime
        /// </summary>
        /// <param name="filterType">Property name (e.g., "Destination", "FlightId")</param>
        /// <param name="filterValue">Value to filter by</param>
        /// <returns>Filtered flights</returns>
        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();

            foreach (Flight flight in Flights)
            {
                // Use reflection to get property value dynamically
                var property = typeof(Flight).GetProperty(filterType);
                if (property != null)
                {
                    var value = property.GetValue(flight);
                    // Null-safe comparison
                    if (value != null && value.ToString()!.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredFlights.Add(flight);
                    }
                }
            }

            return filteredFlights;
        }

        /// <summary>
        /// Q8 - LINQ Version: Dynamic filtering with LINQ
        /// Best Practice: Combines functional programming with reflection
        /// More concise and expressive than iterative approach
        /// </summary>
        public List<Flight> GetFlightsLinq(string filterType, string filterValue)
        {
            return Flights
                .Where(flight =>
                {
                    var property = typeof(Flight).GetProperty(filterType);
                    if (property != null)
                    {
                        var value = property.GetValue(flight);
                        return value != null && value.ToString()!.Equals(filterValue, StringComparison.OrdinalIgnoreCase);
                    }
                    return false;
                })
                .ToList();
        }

        #endregion

        #region ========== Q9: LINQ Query (Already Covered in Q6) ==========

        // Q9 is the same as Q6 LINQ version - demonstrating LINQ fundamentals
        // See GetFlightDatesLinq() above

        #endregion

        #region ========== Q10: Show Flight Details by Plane ==========

        /// <summary>
        /// Q10: Display flight details for a specific plane (LINQ with Anonymous Types)
        /// Best Practice: Uses Select to project only needed properties
        /// Demonstrates: Anonymous types, method chaining
        /// </summary>
        /// <param name="plane">Plane to query flights for</param>
        public void ShowFlightDetailsByPlane(Plane plane)
        {
            // LINQ query with projection to anonymous type
            var flightDetails = plane.Flights
                .Select(f => new
                {
                    FlightDate = f.FlightDate,
                    Destination = f.Destination
                });

            Console.WriteLine($"\nFlights for Plane ID {plane.PlaneId} ({plane.PlaneType}):");
            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"  Date: {detail.FlightDate:yyyy-MM-dd HH:mm}, Destination: {detail.Destination}");
            }
        }

        #endregion

        #region ========== Q11: Weekly Flight Count ==========

        /// <summary>
        /// Q11: Count flights within 7 days (Native/Iterative)
        /// Approach: Traditional counter with if condition
        /// </summary>
        public int GetWeeklyFlightCountNative(DateTime startDate)
        {
            int count = 0;
            DateTime endDate = startDate.AddDays(7);

            foreach (Flight flight in Flights)
            {
                if (flight.FlightDate >= startDate && flight.FlightDate < endDate)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Q11 - LINQ Version (Method Syntax): Count with predicate
        /// Best Practice: Single line, no extra variables, highly readable
        /// </summary>
        public int GetWeeklyFlightCount(DateTime startDate)
        {
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7));
        }

        /// <summary>
        /// Q11.2 - LINQ Version (Query Syntax): SQL-like syntax
        /// Use Case: When team prefers SQL-style queries
        /// </summary>
        public int GetWeeklyFlightCountQuery(DateTime startDate)
        {
            return (from f in Flights
                    where f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7)
                    select f).Count();
        }

        #endregion

        #region ========== Q12: Average Flight Duration ==========

        /// <summary>
        /// Q12: Calculate average flight duration (Native/Iterative)
        /// Approach: Manual sum and count calculation
        /// </summary>
        public double GetAverageFlightDurationNative(string destination)
        {
            double sum = 0;
            int count = 0;

            foreach (Flight flight in Flights)
            {
                if (flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    sum += flight.EstimatedDuration;
                    count++;
                }
            }

            return count > 0 ? sum / count : 0;
        }

        /// <summary>
        /// Q12 - LINQ Version (Method Syntax): Using Average() aggregation
        /// Best Practice: Ternary operator for null safety
        /// </summary>
        public double GetAverageFlightDuration(string destination)
        {
            var destinationFlights = Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
            return destinationFlights.Any() ? destinationFlights.Average(f => f.EstimatedDuration) : 0;
        }

        /// <summary>
        /// Q12.2 - LINQ Version (Query Syntax): Projects only needed property before averaging
        /// Best Practice: More memory efficient, projects integers instead of full Flight objects
        /// </summary>
        public double GetAverageFlightDurationQuery(string destination)
        {
            var result = (from f in Flights
                          where f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)
                          select f.EstimatedDuration);
            return result.Any() ? result.Average() : 0;
        }

        #endregion

        #region ========== Q13: Ordered Flights by Duration ==========

        /// <summary>
        /// Q13: Get flights ordered by duration (Native/Iterative)
        /// Approach: Manual sorting using List.Sort with comparison delegate
        /// </summary>
        public List<Flight> GetOrderedFlightsByDurationNative()
        {
            List<Flight> orderedFlights = new List<Flight>(Flights);
            // Sort in descending order (longest first)
            orderedFlights.Sort((f1, f2) => f2.EstimatedDuration.CompareTo(f1.EstimatedDuration));
            return orderedFlights;
        }

        /// <summary>
        /// Q13 - LINQ Version: OrderByDescending
        /// Best Practice: Declarative, single line, very readable
        /// </summary>
        public List<Flight> GetOrderedFlightsByDuration()
        {
            return Flights
                .OrderByDescending(f => f.EstimatedDuration)
                .ToList();
        }

        #endregion

        #region ========== Q14: Senior Travellers ==========

        /// <summary>
        /// Q14: Get 3 oldest travellers from a flight (Native/Iterative)
        /// Approach: Filter, sort, and take first 3
        /// </summary>
        public List<Traveller> GetSeniorTravellersNative(Flight flight)
        {
            // Step 1: Filter only Traveller type passengers
            List<Traveller> travellers = new List<Traveller>();
            foreach (var passenger in flight.Passengers)
            {
                if (passenger is Traveller traveller)
                {
                    travellers.Add(traveller);
                }
            }

            // Step 2: Sort by birth date (oldest first)
            travellers.Sort((t1, t2) => t1.BirthDate.CompareTo(t2.BirthDate));

            // Step 3: Take first 3
            List<Traveller> senior = new List<Traveller>();
            int count = Math.Min(3, travellers.Count);
            for (int i = 0; i < count; i++)
            {
                senior.Add(travellers[i]);
            }

            return senior;
        }

        /// <summary>
        /// Q14 - LINQ Version: Type filtering, ordering, and limiting
        /// Best Practice: Chain of operations, very readable
        /// Demonstrates: OfType, OrderBy, Take
        /// </summary>
        public List<Traveller> GetSeniorTravellers(Flight flight)
        {
            return flight.Passengers
                .OfType<Traveller>()           // Filter by type
                .OrderBy(t => t.BirthDate)     // Sort by birth date (oldest = earliest date)
                .Take(3)                        // Limit to 3 results
                .ToList();
        }

        #endregion

        #region ========== Q15: Group Flights by Destination ==========

        /// <summary>
        /// Q15: Group and display flights by destination (Native/Iterative)
        /// Approach: Manual grouping using Dictionary
        /// </summary>
        public void ShowFlightsGroupedByDestinationNative()
        {
            // Step 1: Group flights manually
            Dictionary<string, List<Flight>> groups = new Dictionary<string, List<Flight>>();

            foreach (var flight in Flights)
            {
                if (!groups.ContainsKey(flight.Destination))
                {
                    groups[flight.Destination] = new List<Flight>();
                }
                groups[flight.Destination].Add(flight);
            }

            // Step 2: Sort destinations
            var sortedDestinations = groups.Keys.OrderBy(k => k).ToList();

            // Step 3: Display results
            Console.WriteLine("\n=== Flights Grouped by Destination (Native) ===");
            foreach (var destination in sortedDestinations)
            {
                Console.WriteLine($"\nDestination: {destination}");
                Console.WriteLine($"Number of flights: {groups[destination].Count}");
                foreach (var flight in groups[destination])
                {
                    Console.WriteLine($"  - Flight {flight.FlightId}: {flight.FlightDate:yyyy-MM-dd HH:mm}, Duration: {flight.EstimatedDuration} min");
                }
            }
        }

        /// <summary>
        /// Q15 - LINQ Version: GroupBy with OrderBy
        /// Best Practice: Much simpler and more readable than manual grouping
        /// Demonstrates: GroupBy, IGrouping iteration
        /// </summary>
        public void ShowFlightsGroupedByDestination()
        {
            var groupedFlights = Flights
                .GroupBy(f => f.Destination)
                .OrderBy(g => g.Key);

            Console.WriteLine("\n=== Flights Grouped by Destination ===");
            foreach (var group in groupedFlights)
            {
                Console.WriteLine($"\nDestination: {group.Key}");
                Console.WriteLine($"Number of flights: {group.Count()}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"  - Flight {flight.FlightId}: {flight.FlightDate:yyyy-MM-dd HH:mm}, Duration: {flight.EstimatedDuration} min");
                }
            }
        }

        public IEnumerable<IGrouping<string, Flight>> GetFlightsGroupedByDestinationLinq()
        {
            var lambda = Flights
                .GroupBy(f => f.Destination)
                .OrderBy(g => g.Key);

            Console.WriteLine(
                "\n=== Flights Grouped by Destination (IEnumerable<IGrouping>) ===");
            foreach (var group in lambda)
            {
                Console.WriteLine($"\nDestination: {group.Key}");
                Console.WriteLine($"Number of flights: {group.Count()}");
                foreach (var flight in group)
                {
                    Console.WriteLine(
                        $"  - Flight {flight.FlightId}: {flight.FlightDate:yyyy-MM-dd HH:mm}, Duration: {flight.EstimatedDuration} min");
                }
            }
            return lambda;
        }

        #endregion

        #region ========== Q16: Legacy Methods (For Compatibility) ==========

        // These are aliases/wrappers for backward compatibility
        public List<DateTime> GetFlightDatesLinqV2(string destination) => GetFlightDatesLinq(destination);

        #endregion
    }
}



