using TaxCalculation.Service.Interface;

namespace TaxCalculation.Service
{
    public interface IServiceHolder
    {
        public ITaxCalculator TaxCalculator { get;   }
    }
}
