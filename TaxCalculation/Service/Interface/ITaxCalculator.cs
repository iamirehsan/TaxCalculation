namespace TaxCalculation.Service.Interface
{
    public interface ITaxCalculator
    {
        Task<double> Calculate(Guid vehicleId , Guid cityId , int year);
    }
}
