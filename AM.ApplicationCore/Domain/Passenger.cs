using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }

        // Navigation property: Many-to-Many relationship with Flight
        public ICollection<Flight> Flights { get; set; }

        // Default constructor
        public Passenger()
        {
            Flights = new List<Flight>();
        }

        // Q10: Polymorphism by method signature (Overloading)
        // Method 1: Check profile with firstName and lastName
        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

        // Method 2: Check profile with firstName, lastName, and email
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && Email == email;
        }

        // Q11: Polymorphism by inheritance (virtual method for overriding)
        public virtual string PassengerType()
        {
            return "I am a passenger";
        }

        // Override ToString()
        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Email: {Email}, Passport: {PassportNumber}, BirthDate: {BirthDate:yyyy-MM-dd}";
        }
    }
}
