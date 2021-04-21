using CarsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> opt) : base(opt)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}