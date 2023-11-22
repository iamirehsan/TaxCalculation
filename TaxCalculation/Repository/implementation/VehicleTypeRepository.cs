using TaxCalculation.Domain;
using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository.implementation
{
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
