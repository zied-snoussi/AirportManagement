using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("========== AirportManagement TP Part 1 ==========\n");

// ==========================================
// Q7: Default constructor - Initialize attributes using properties
// ==========================================
Console.WriteLine("Q7: Creating Plane using default constructor");
Plane plane1 = new Plane();
plane1.PlaneId = 1;
plane1.PlaneType = PlaneType.Boeing;
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2015, 5, 20);
Console.WriteLine(plane1.ToString());
Console.WriteLine();

// ==========================================
// Q8: Parameterized constructor
// ==========================================
Console.WriteLine("Q8: Creating Plane using parameterized constructor");
Plane plane2 = new Plane(PlaneType.Airbus, 300, new DateTime(2018, 10, 15));
plane2.PlaneId = 2;
Console.WriteLine(plane2.ToString());
Console.WriteLine();

// ==========================================
// Q9: Object initializers (Note: constructor removed for this demo)
// ==========================================
Console.WriteLine("Q9: Creating Plane using object initializers");
Plane plane3 = new Plane
{
    PlaneId = 3,
    PlaneType = PlaneType.Boeing,
    Capacity = 250,
    ManufactureDate = new DateTime(2020, 3, 10)
};
Console.WriteLine(plane3.ToString());
Console.WriteLine("\nNote: Object initializers are more concise than using properties manually.");
Console.WriteLine("Difference: Initializers allow setting properties in one expression at creation time.\n");

// ==========================================
// Q10: Polymorphism by method signature (Overloading)
// ==========================================
Console.WriteLine("Q10: Testing CheckProfile() method overloading");
Passenger passenger1 = new Passenger
{
    PassengerId = 1,
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@email.com",
    BirthDate = new DateTime(1990, 5, 15),
    PassportNumber = "AB123456"
};

Console.WriteLine(passenger1.ToString());
Console.WriteLine($"Check with firstName and lastName: {passenger1.CheckProfile("John", "Doe")}");
Console.WriteLine($"Check with firstName, lastName, and email: {passenger1.CheckProfile("John", "Doe", "john.doe@email.com")}");
Console.WriteLine($"Check with wrong data: {passenger1.CheckProfile("Jane", "Smith", "wrong@email.com")}");
Console.WriteLine();

// ==========================================
// Q11: Polymorphism by inheritance (Overriding)
// ==========================================
Console.WriteLine("Q11: Testing PassengerType() polymorphism");

// Test with base Passenger
Passenger passenger2 = new Passenger
{
    PassengerId = 2,
    FirstName = "Alice",
    LastName = "Smith",
    Email = "alice@email.com",
    BirthDate = new DateTime(1985, 8, 20),
    PassportNumber = "CD789012"
};
Console.WriteLine("Base Passenger:");
Console.WriteLine(passenger2.PassengerType());
Console.WriteLine();

// Test with Staff
Staff staff1 = new Staff
{
    PassengerId = 3,
    FirstName = "Bob",
    LastName = "Johnson",
    Email = "bob.johnson@airline.com",
    BirthDate = new DateTime(1980, 3, 12),
    PassportNumber = "EF345678",
    Function = "Pilot",
    Salary = 5000m,
    EmploymentDate = new DateTime(2010, 6, 1)
};
Console.WriteLine("Staff:");
Console.WriteLine(staff1.PassengerType());
Console.WriteLine(staff1.ToString());
Console.WriteLine();

// Test with Traveller
Traveller traveller1 = new Traveller
{
    PassengerId = 4,
    FirstName = "Emma",
    LastName = "Brown",
    Email = "emma.brown@email.com",
    BirthDate = new DateTime(1995, 11, 30),
    PassportNumber = "GH901234",
    Nationality = "American",
    HealthInformation = "No allergies"
};
Console.WriteLine("Traveller:");
Console.WriteLine(traveller1.PassengerType());
Console.WriteLine(traveller1.ToString());
Console.WriteLine();

// ==========================================
// Demonstrating Navigation Properties (1-to-Many relationship)
// ==========================================
Console.WriteLine("Testing Navigation Properties: Plane <-> Flight");
Plane plane4 = new Plane(PlaneType.Airbus, 180, new DateTime(2019, 7, 20))
{
    PlaneId = 4
};

Flight flight1 = new Flight
{
    FlightId = 1,
    Destination = "Paris",
    FlightDate = new DateTime(2024, 6, 15),
    EstimatedArrival = new DateTime(2024, 6, 15, 14, 30, 0),
    EffectiveArrival = new DateTime(2024, 6, 15, 14, 25, 0),
    Plane = plane4
};

Flight flight2 = new Flight
{
    FlightId = 2,
    Destination = "London",
    FlightDate = new DateTime(2024, 6, 16),
    EstimatedArrival = new DateTime(2024, 6, 16, 16, 00, 0),
    EffectiveArrival = new DateTime(2024, 6, 16, 16, 10, 0),
    Plane = plane4
};

plane4.Flights.Add(flight1);
plane4.Flights.Add(flight2);

Console.WriteLine(plane4.ToString());
Console.WriteLine($"Number of flights for this plane: {plane4.Flights.Count}");
foreach (var flight in plane4.Flights)
{
    Console.WriteLine($"  - {flight.ToString()}");
}
Console.WriteLine();

Console.WriteLine("========== TP Part 1 Completed Successfully! ==========");
Console.WriteLine("\n\n========== AirportManagement TP Part 2 ==========\n");

// ==========================================
// Setup Service with TestData
// ==========================================
ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;

Console.WriteLine("Flights loaded from TestData:");
foreach (var flight in serviceFlight.Flights)
{
    Console.WriteLine($"  - {flight.ToString()}");
}
Console.WriteLine();

// ==========================================
// Q6: GetFlightDates using FOR loop
// ==========================================
Console.WriteLine("Q6: Testing GetFlightDates() for destination 'Paris'");
List<DateTime> parisDates = serviceFlight.GetFlightDates("Paris");
Console.WriteLine($"Found {parisDates.Count} flights to Paris:");
foreach (var date in parisDates)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

Console.WriteLine("Q6: Testing GetFlightDates() for destination 'Madrid'");
List<DateTime> madridDates = serviceFlight.GetFlightDates("Madrid");
Console.WriteLine($"Found {madridDates.Count} flights to Madrid:");
foreach (var date in madridDates)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

Console.WriteLine("Q6: Testing GetFlightDates() for destination 'Lisbonne'");
List<DateTime> lisbonneDates = serviceFlight.GetFlightDates("Lisbonne");
Console.WriteLine($"Found {lisbonneDates.Count} flights to Lisbonne:");
foreach (var date in lisbonneDates)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

Console.WriteLine("========== TP Part 2 Tests Completed! ==========");
