using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        // Flights data source - initialized as empty list
        public List<Flight> Flights { get; set; }

        // Constructor
        public ServiceFlight()
        {
            Flights = new List<Flight>();
        }

        // Q6: Get flight dates for a given destination using FOR loop
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(Flights[i].FlightDate);
                }
            }

            return flightDates;
        }

        // Q7: Get flight dates for a given destination using FOREACH loop
        public List<DateTime> GetFlightDatesForEach(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            foreach (Flight flight in Flights)
            {
                if (flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }

        // Q8: Dynamic filtering by attribute
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
                    if (value != null && value.ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredFlights.Add(flight);
                    }
                }
            }

            return filteredFlights;
        }

        // Q9: Get flight dates using LINQ
        public List<DateTime> GetFlightDatesLinq(string destination)
        {
            return Flights
                .Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                .Select(f => f.FlightDate)
                .ToList();
        }

        // Q10: Show flight details by plane
        public void ShowFlightDetailsByPlane(Plane plane)
        {
            var flightDetails = Flights
                .Where(f => f.Plane.PlaneId == plane.PlaneId)
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

        // Q11: Weekly flight count starting from a given date
        public int GetWeeklyFlightCount(DateTime startDate)
        {
            // Lambda expression approach - inline calculation
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7));
        }

        // Q11.2: Alternative LINQ query syntax
        public int GetWeeklyFlightCountQuery(DateTime startDate)
        {
            return (from f in Flights
                    where f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7)
                    select f).Count();
        }

        // Q12: Average flight duration for a given destination
        public double GetAverageFlightDuration(string destination)
        {
            // Lambda expression approach - direct Average with predicate
            var destinationFlights = Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
            return destinationFlights.Any() ? destinationFlights.Average(f => f.EstimatedDuration) : 0;
        }

        // Q12.2: Alternative LINQ query syntax
        public double GetAverageFlightDurationQuery(string destination)
        {
            var result = (from f in Flights
                          where f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)
                          select f.EstimatedDuration);
            return result.Any() ? result.Average() : 0;
        }


    }
}


