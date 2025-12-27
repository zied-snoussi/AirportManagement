using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    // Q17: Extension methods for Passenger
    public static class PassengerExtension
    {
        // Extension method to capitalize first letter of FirstName and LastName
        public static string UpperFullName(this Passenger passenger)
        {
            if (passenger == null)
                return string.Empty;

            string firstName = passenger.FirstName ?? string.Empty;
            string lastName = passenger.LastName ?? string.Empty;

            // Capitalize first letter of FirstName
            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = char.ToUpper(firstName[0]) + firstName.Substring(1).ToLower();
            }

            // Capitalize first letter of LastName
            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = char.ToUpper(lastName[0]) + lastName.Substring(1).ToLower();
            }

            return $"{firstName} {lastName}".Trim();
        }
    }
}
