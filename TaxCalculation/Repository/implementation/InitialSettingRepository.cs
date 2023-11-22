using TaxCalculation.Domain;
using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository.implementation
{
    public class InitialSettingRepository : Repository<InitialSetting>, IInitialSettingRepository
    {
        public InitialSettingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
