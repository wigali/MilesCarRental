using Microsoft.EntityFrameworkCore;
using MilesCarRental.Models;

namespace MilesCarRental.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
    }
}

