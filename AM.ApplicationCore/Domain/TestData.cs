using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public static class TestData
    {
        // Static Planes
        public static Plane BoingPlane = new Plane
        {
            PlaneId = 1,
            PlaneType = PlaneType.Boeing,
            Capacity = 150,
            ManufactureDate = new DateTime(2015, 2, 3)
        };

        public static Plane AirbusPlane = new Plane
        {
            PlaneId = 2,
            PlaneType = PlaneType.Airbus,
            Capacity = 250,
            ManufactureDate = new DateTime(2020, 11, 11)
        };

        // Static Staff Members
        public static Staff Captain = new Staff
        {
            PassengerId = 1,
            FirstName = "Captain",
            LastName = "Smith",
            Email = "captain.smith@airline.com",
            BirthDate = new DateTime(1975, 5, 10),
            PassportNumber = "CAP12345",
            Function = "Captain",
            Salary = 8000m,
            EmploymentDate = new DateTime(2005, 1, 15)
        };

        public static Staff Hostess1 = new Staff
        {
            PassengerId = 2,
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane.doe@airline.com",
            BirthDate = new DateTime(1988, 8, 20),
            PassportNumber = "HOS11111",
            Function = "Hostess",
            Salary = 3500m,
            EmploymentDate = new DateTime(2012, 3, 1)
        };

        public static Staff Hostess2 = new Staff
        {
            PassengerId = 3,
            FirstName = "Emily",
            LastName = "Johnson",
            Email = "emily.johnson@airline.com",
            BirthDate = new DateTime(1990, 12, 5),
            PassportNumber = "HOS22222",
            Function = "Hostess",
            Salary = 3500m,
            EmploymentDate = new DateTime(2015, 6, 10)
        };

        // Static Travellers
        public static Traveller Traveller1 = new Traveller
        {
            PassengerId = 4,
            FirstName = "John",
            LastName = "Martin",
            Email = "john.martin@email.com",
            BirthDate = new DateTime(1985, 3, 15),
            PassportNumber = "TRV11111",
            Nationality = "French",
            HealthInformation = "No allergies"
        };

        public static Traveller Traveller2 = new Traveller
        {
            PassengerId = 5,
            FirstName = "Sarah",
            LastName = "Williams",
            Email = "sarah.williams@email.com",
            BirthDate = new DateTime(1992, 7, 22),
            PassportNumber = "TRV22222",
            Nationality = "Spanish",
            HealthInformation = "None"
        };

        public static Traveller Traveller3 = new Traveller
        {
            PassengerId = 6,
            FirstName = "Michael",
            LastName = "Brown",
            Email = "michael.brown@email.com",
            BirthDate = new DateTime(1978, 11, 30),
            PassportNumber = "TRV33333",
            Nationality = "Portuguese",
            HealthInformation = "Diabetic"
        };

        public static Traveller Traveller4 = new Traveller
        {
            PassengerId = 7,
            FirstName = "Lisa",
            LastName = "Garcia",
            Email = "lisa.garcia@email.com",
            BirthDate = new DateTime(1995, 4, 18),
            PassportNumber = "TRV44444",
            Nationality = "American",
            HealthInformation = "No issues"
        };

        public static Traveller Traveller5 = new Traveller
        {
            PassengerId = 8,
            FirstName = "David",
            LastName = "Martinez",
            Email = "david.martinez@email.com",
            BirthDate = new DateTime(1982, 9, 25),
            PassportNumber = "TRV55555",
            Nationality = "French",
            HealthInformation = "Peanut allergy"
        };

        // Static Flights
        public static Flight Flight1 = new Flight
        {
            FlightId = 1,
            Destination = "Paris",
            FlightDate = new DateTime(2024, 6, 15, 10, 0, 0),
            EstimatedArrival = new DateTime(2024, 6, 15, 14, 30, 0),
            EffectiveArrival = new DateTime(2024, 6, 15, 14, 25, 0),
            Plane = BoingPlane,
            Passengers = new List<Passenger> { Traveller1, Traveller2, Traveller3, Traveller4, Traveller5, Captain, Hostess1 }
        };

        public static Flight Flight2 = new Flight
        {
            FlightId = 2,
            Destination = "Madrid",
            FlightDate = new DateTime(2024, 6, 20, 8, 0, 0),
            EstimatedArrival = new DateTime(2024, 6, 20, 12, 0, 0),
            EffectiveArrival = new DateTime(2024, 6, 20, 11, 55, 0),
            Plane = AirbusPlane,
            Passengers = new List<Passenger> { Traveller1, Traveller2, Captain, Hostess2 }
        };

        public static Flight Flight3 = new Flight
        {
            FlightId = 3,
            Destination = "Lisbonne",
            FlightDate = new DateTime(2024, 7, 5, 15, 0, 0),
            EstimatedArrival = new DateTime(2024, 7, 5, 18, 30, 0),
            EffectiveArrival = new DateTime(2024, 7, 5, 18, 40, 0),
            Plane = BoingPlane,
            Passengers = new List<Passenger> { Traveller3, Traveller4, Captain, Hostess1 }
        };

        public static Flight Flight4 = new Flight
        {
            FlightId = 4,
            Destination = "Paris",
            FlightDate = new DateTime(2024, 7, 10, 12, 0, 0),
            EstimatedArrival = new DateTime(2024, 7, 10, 16, 30, 0),
            EffectiveArrival = new DateTime(2024, 7, 10, 16, 20, 0),
            Plane = AirbusPlane,
            Passengers = new List<Passenger> { Traveller2, Traveller5, Captain, Hostess2 }
        };

        public static Flight Flight5 = new Flight
        {
            FlightId = 5,
            Destination = "Madrid",
            FlightDate = new DateTime(2024, 7, 15, 9, 0, 0),
            EstimatedArrival = new DateTime(2024, 7, 15, 13, 0, 0),
            EffectiveArrival = new DateTime(2024, 7, 15, 13, 10, 0),
            Plane = BoingPlane,
            Passengers = new List<Passenger> { Traveller1, Traveller3, Traveller5, Captain, Hostess1 }
        };

        public static Flight Flight6 = new Flight
        {
            FlightId = 6,
            Destination = "Lisbonne",
            FlightDate = new DateTime(2024, 7, 20, 14, 0, 0),
            EstimatedArrival = new DateTime(2024, 7, 20, 17, 30, 0),
            EffectiveArrival = new DateTime(2024, 7, 20, 17, 25, 0),
            Plane = AirbusPlane,
            Passengers = new List<Passenger> { Traveller2, Traveller4, Captain, Hostess2 }
        };

        // Static list of all flights
        public static List<Flight> listFlights = new List<Flight>
        {
            Flight1,
            Flight2,
            Flight3,
            Flight4,
            Flight5,
            Flight6
        };
    }
}
