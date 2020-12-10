using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class VehicleDbContext : DbContext, IVehicleDbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DecribeRelationships();
            modelBuilder.SeedData();
        }
    }
}
