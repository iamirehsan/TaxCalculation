using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository
{
    public interface IUnitOfWork
    {
        public IInitialSettingRepository initialSettingRepository { get; }
        public ICityRepository City { get; }
        public IVehicleTaxDateRepository VehicleTaxDateRepository { get; }
        public IVehicleRepository  vehicleRepository { get; }
        public IVehicleTypeRepository vehicleTypeRepository { get; }
        public Task SaveAsync();
        public void Dispose();
        public Task CommitAsync();
        public void Commit();
    }
}
