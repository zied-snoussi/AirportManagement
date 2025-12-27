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

// ==========================================
// Q7: GetFlightDates using FOREACH loop
// ==========================================
Console.WriteLine("\nQ7: Testing GetFlightDatesForEach() for destination 'Paris'");
List<DateTime> parisDatesForeach = serviceFlight.GetFlightDatesForEach("Paris");
Console.WriteLine($"Found {parisDatesForeach.Count} flights to Paris (using foreach):");
foreach (var date in parisDatesForeach)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

// ==========================================
// Q8: Dynamic filtering
// ==========================================
Console.WriteLine("Q8: Testing GetFlights() with dynamic filtering");
Console.WriteLine("Filter by Destination = 'Madrid':");
List<Flight> madridFlights = serviceFlight.GetFlights("Destination", "Madrid");
foreach (var flight in madridFlights)
{
    Console.WriteLine($"  - {flight.ToString()}");
}
Console.WriteLine();

// ==========================================
// Q9: GetFlightDates using LINQ
// ==========================================
Console.WriteLine("Q9: Testing GetFlightDatesLinq() for destination 'Lisbonne'");
List<DateTime> lisbonneDatesLinq = serviceFlight.GetFlightDatesLinq("Lisbonne");
Console.WriteLine($"Found {lisbonneDatesLinq.Count} flights to Lisbonne (using LINQ):");
foreach (var date in lisbonneDatesLinq)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

// ==========================================
// Q10: Show flight details by plane
// ==========================================
Console.WriteLine("Q10: Testing ShowFlightDetailsByPlane()");
serviceFlight.ShowFlightDetailsByPlane(TestData.BoingPlane);
serviceFlight.ShowFlightDetailsByPlane(TestData.AirbusPlane);
Console.WriteLine();

// ==========================================
// Q11: Weekly flight count
// ==========================================
Console.WriteLine("Q11: Testing GetWeeklyFlightCount()");
DateTime startDate = new DateTime(2024, 6, 15);
int weeklyCount = serviceFlight.GetWeeklyFlightCount(startDate);
Console.WriteLine($"Number of flights in the week starting {startDate:yyyy-MM-dd}: {weeklyCount}");
Console.WriteLine();

Console.WriteLine("Q11.2: Testing GetWeeklyFlightCountQuery() - LINQ Query Syntax");
int weeklyCountQuery = serviceFlight.GetWeeklyFlightCountQuery(startDate);
Console.WriteLine($"Number of flights in the week starting {startDate:yyyy-MM-dd}: {weeklyCountQuery}");
Console.WriteLine("Note: Lambda method uses Count(predicate), Query syntax uses from...where...select");
Console.WriteLine();

// ==========================================
// Q12: Average flight duration
// ==========================================
Console.WriteLine("Q12: Testing GetAverageFlightDuration()");
double avgParis = serviceFlight.GetAverageFlightDuration("Paris");
Console.WriteLine($"Average duration for flights to Paris: {avgParis} minutes");
double avgMadrid = serviceFlight.GetAverageFlightDuration("Madrid");
Console.WriteLine($"Average duration for flights to Madrid: {avgMadrid} minutes");
double avgLisbonne = serviceFlight.GetAverageFlightDuration("Lisbonne");
Console.WriteLine($"Average duration for flights to Lisbonne: {avgLisbonne} minutes");
Console.WriteLine();

Console.WriteLine("Q12.2: Testing GetAverageFlightDurationQuery() - LINQ Query Syntax");
double avgParisQuery = serviceFlight.GetAverageFlightDurationQuery("Paris");
Console.WriteLine($"Average duration for flights to Paris: {avgParisQuery} minutes (Query Syntax)");
double avgMadridQuery = serviceFlight.GetAverageFlightDurationQuery("Madrid");
Console.WriteLine($"Average duration for flights to Madrid: {avgMadridQuery} minutes (Query Syntax)");
Console.WriteLine("Note: Uses ternary operator (? :) for null safety with Any() check");
Console.WriteLine();

// ==========================================
// Q13: Ordered flights by duration
// ==========================================
Console.WriteLine("Q13: Testing GetOrderedFlightsByDuration() - Longest to Shortest");
List<Flight> orderedFlights = serviceFlight.GetOrderedFlightsByDuration();
foreach (var flight in orderedFlights)
{
    Console.WriteLine($"  - Flight {flight.FlightId} to {flight.Destination}: {flight.EstimatedDuration} minutes");
}
Console.WriteLine();

// ==========================================
// Q14: Senior travellers
// ==========================================
Console.WriteLine("Q14: Testing GetSeniorTravellers() for Flight 1");
List<Traveller> seniorTravellers = serviceFlight.GetSeniorTravellers(TestData.Flight1);
Console.WriteLine($"3 oldest travellers in Flight 1:");
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"  - {traveller.FirstName} {traveller.LastName}, Born: {traveller.BirthDate:yyyy-MM-dd}");
}
Console.WriteLine();

// ==========================================
// Q15: Grouped flights by destination
// ==========================================
Console.WriteLine("Q15: Testing ShowFlightsGroupedByDestination()");
serviceFlight.ShowFlightsGroupedByDestination();
Console.WriteLine();

Console.WriteLine("\n========== TP Part 2 All Tests Completed Successfully! ==========");

Console.WriteLine("\n\n========== TP Part 2 - Q16 & Q17 ==========\n");

// ==========================================
// Q16: Section II rewritten with LINQ
// ==========================================
Console.WriteLine("Q16: Testing Section II methods rewritten with LINQ");
Console.WriteLine("\nQ6 Rewritten - GetFlightDatesLinqV2() for 'Paris':");
List<DateTime> parisLinqV2 = serviceFlight.GetFlightDatesLinqV2("Paris");
Console.WriteLine($"Found {parisLinqV2.Count} flights to Paris (LINQ version):");
foreach (var date in parisLinqV2)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

Console.WriteLine("Q7 Rewritten - GetFlightDatesForEachLinq() for 'Madrid':");
List<DateTime> madridLinq = serviceFlight.GetFlightDatesForEachLinq("Madrid");
Console.WriteLine($"Found {madridLinq.Count} flights to Madrid (LINQ version):");
foreach (var date in madridLinq)
{
    Console.WriteLine($"  - {date:yyyy-MM-dd HH:mm}");
}
Console.WriteLine();

Console.WriteLine("Q8 Rewritten - GetFlightsLinq() filtering by Destination='Lisbonne':");
List<Flight> lisbonneFlightsLinq = serviceFlight.GetFlightsLinq("Destination", "Lisbonne");
Console.WriteLine($"Found {lisbonneFlightsLinq.Count} flights to Lisbonne (LINQ version):");
foreach (var flight in lisbonneFlightsLinq)
{
    Console.WriteLine($"  - {flight.ToString()}");
}
Console.WriteLine();

// ==========================================
// Q17: Extension Method - UpperFullName
// ==========================================
Console.WriteLine("Q17: Testing PassengerExtension.UpperFullName()");

// Test with different passenger types
Passenger testPassenger = new Passenger
{
    FirstName = "jean",
    LastName = "dupont",
    Email = "jean.dupont@email.com"
};

Staff testStaff = new Staff
{
    FirstName = "marie",
    LastName = "leclerc",
    Function = "Hostess"
};

Traveller testTraveller = new Traveller
{
    FirstName = "JOHN",
    LastName = "SMITH",
    Nationality = "American"
};

Console.WriteLine($"\nOriginal: {testPassenger.FirstName} {testPassenger.LastName}");
Console.WriteLine($"UpperFullName: {testPassenger.UpperFullName()}");

Console.WriteLine($"\nOriginal: {testStaff.FirstName} {testStaff.LastName}");
Console.WriteLine($"UpperFullName: {testStaff.UpperFullName()}");

Console.WriteLine($"\nOriginal: {testTraveller.FirstName} {testTraveller.LastName}");
Console.WriteLine($"UpperFullName: {testTraveller.UpperFullName()}");

// Test with TestData passengers
Console.WriteLine("\n\nApplying UpperFullName to all passengers in Flight 1:");
foreach (var passenger in TestData.Flight1.Passengers)
{
    Console.WriteLine($"  - {passenger.UpperFullName()} ({passenger.GetType().Name})");
}

Console.WriteLine("\n========== Q16 & Q17 Tests Completed Successfully! ==========");


