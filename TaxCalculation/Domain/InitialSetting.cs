using TaxCalculation.Infrastructure;
using TaxCalculation.Infrastructure.Enum;

namespace TaxCalculation.Domain
{
    public class InitialSetting : BaseEntity
    {
        public bool TaxFreeOnHolidays{ get; set; }
        public double? MaximumTaxPerDay { get; set; }
        public IEnumerable<DateTime> FreeTaxDates { get; set; }
        public IEnumerable<Month> FreeTaxMonth { get; set; }
        public IEnumerable<Guid> FreeTaxVehicleTypes { get; set; }
        public IEnumerable<TaxPrice> TaxPrices { get; set; }
        public virtual City City { get; set; }
        public Guid CityId { get; set; }


    }
    public class TaxPrice
    {
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
        public double Price { get; set; }
    }
}
