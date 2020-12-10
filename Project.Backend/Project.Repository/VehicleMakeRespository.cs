using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.DAL.Entities;
using Project.Repository.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class VehicleMakeRespository : Repository<VehicleMakeEntity>, IVehicleMakeRespository
    {
        public VehicleMakeRespository(VehicleDbContext context) : base(context)
        {
        }
    }
}
