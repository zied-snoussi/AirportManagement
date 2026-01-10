using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AM.infra
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staff> Travellers { get; set; }
    }
}
