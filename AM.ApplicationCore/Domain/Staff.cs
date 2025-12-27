using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }
        public decimal Salary { get; set; }
        public DateTime EmploymentDate { get; set; }

        // Q11: Override PassengerType() - reuse base class method
        public override string PassengerType()
        {
            return base.PassengerType() + " I am a Staff Member";
        }

        // Override ToString()
        public override string ToString()
        {
            return base.ToString() + $", Function: {Function}, Salary: {Salary}, Employment Date: {EmploymentDate:yyyy-MM-dd}";
        }
    }
}
