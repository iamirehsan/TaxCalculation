using TaxCalculation.Domain;
using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository.implementation
{
    public class VehicleTaxDateRepository : Repository<VehicleTaxDate>, IVehicleTaxDateRepository
    {
        public VehicleTaxDateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
