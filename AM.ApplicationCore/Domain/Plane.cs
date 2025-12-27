using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        // Navigation property: One Plane has many Flights
        public ICollection<Flight> Flights { get; set; }

        // Default constructor
        public Plane()
        {
            Flights = new List<Flight>();
        }

        // Parameterized constructor for Q8
        public Plane(PlaneType pt, int capacity, DateTime date) : this()
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

        // Override ToString()
        public override string ToString()
        {
            return $"Plane ID: {PlaneId}, Type: {PlaneType}, Capacity: {Capacity}, Manufacture Date: {ManufactureDate:yyyy-MM-dd}";
        }
    }
}
