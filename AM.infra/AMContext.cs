using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace AM.infra
{
    public class AMContext : DbContext
    {
        // DbSets for entities
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get connection string from environment variables
            string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "AirportManagementDB";
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? "test";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "test";

            // Build connection string
            string connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};";

            // Connect to MySQL
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
}



