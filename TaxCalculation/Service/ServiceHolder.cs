using TaxCalculation.Repository;
using TaxCalculation.Service.implementation;
using TaxCalculation.Service.Interface;

namespace TaxCalculation.Service
{
    public class ServiceHolder : IServiceHolder
    {
        private IUnitOfWork _unitOfWork;
        private TaxCalculator _taxCalculator;

        public ServiceHolder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ITaxCalculator TaxCalculator => _taxCalculator = _taxCalculator ?? new TaxCalculator(_unitOfWork);
    }
}
