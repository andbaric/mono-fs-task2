using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL
{
    public interface IVehicleDbContext
    {
        DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        DbSet<VehicleModelEntity> VehicleModels { get; set; }
    }
}
