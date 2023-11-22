using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository.implementation
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
