using TaxCalculation.Domain;
using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository.implementation
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
