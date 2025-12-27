using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public DateTime EstimatedArrival { get; set; }

        // Navigation property: Many Flights belong to one Plane
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        // Navigation property: Many-to-Many relationship with Passenger
        public ICollection<Passenger> Passengers { get; set; }

        // Default constructor
        public Flight()
        {
            Passengers = new List<Passenger>();
        }

        // Override ToString()
        public override string ToString()
        {
            return $"Flight ID: {FlightId}, Destination: {Destination}, Date: {FlightDate:yyyy-MM-dd}, Estimated Arrival: {EstimatedArrival:yyyy-MM-dd HH:mm}";
        }
    }
}
