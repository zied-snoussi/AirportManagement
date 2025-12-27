using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string Nationality { get; set; }
        public string HealthInformation { get; set; }

        // Q11: Override PassengerType() - reuse base class method
        public override string PassengerType()
        {
            return base.PassengerType() + " I am a traveller";
        }

        // Override ToString()
        public override string ToString()
        {
            return base.ToString() + $", Nationality: {Nationality}, Health Info: {HealthInformation}";
        }
    }
}
