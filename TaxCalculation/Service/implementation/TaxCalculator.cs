using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculation.Domain;
using TaxCalculation.Infrastructure.Enum;
using TaxCalculation.Repository;
using TaxCalculation.Service.Interface;

namespace TaxCalculation.Service.implementation
{
    public class TaxCalculator : ITaxCalculator
    {
        private IUnitOfWork _unitOfWork;

        public TaxCalculator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<double> Calculate(Guid vehicleId, Guid cityId, int year)
        {
            // Check if initial setting is incomplete
            if (_unitOfWork.initialSettingRepository.Any(z => z.CityId == cityId))
            {
                throw new Exception("Please complete initial setting first");
            }

            // Check if vehicle with the given id exists
            if (_unitOfWork.vehicleRepository.Any(z => z.Id == vehicleId))
            {
                throw new Exception("No vehicle found with this id");
            }

            var initialSetting = await _unitOfWork.initialSettingRepository
                .FirstOrDefaultAsync(z => z.CityId == cityId)
                .ConfigureAwait(false);

            var vehicle = await _unitOfWork.vehicleRepository
                .FirstOrDefaultAsync(z => z.Id == vehicleId)
                .ConfigureAwait(false);

            // Check if the vehicle is eligible for free tax
            if (initialSetting.FreeTaxVehicleTypes.Contains(vehicle.VehicleTypeId))
            {
                return 0;
            }

            var vehicleTaxDates = _unitOfWork.VehicleTaxDateRepository
                .Where(z => z.VehicleId == vehicleId && z.Time.Year.Equals(year));

            var vehicleGroupsByDate = await vehicleTaxDates.GroupBy(z => z.Time.Date).ToListAsync();

            double totalTax = 0;

            foreach (var dateGroup in vehicleGroupsByDate)
            {
                if (initialSetting.FreeTaxMonth.Contains((Month)dateGroup.First().Time.Month) || initialSetting.FreeTaxDates.Contains(dateGroup.First().Time.Date))
                if (initialSetting.FreeTaxMonth.Contains((Month)dateGroup.First().Time.Month) || initialSetting.FreeTaxDates.Contains(dateGroup.First().Time.Date))
                {
                    continue;
                }
                double tax = CalculateTaxForDateGroup(dateGroup, initialSetting);
                totalTax += tax;
            }

            return totalTax;
        }

        // Move this block of code into a separate method for better readability
        private double CalculateTaxForDateGroup(IEnumerable<VehicleTaxDate> dateGroup, InitialSetting initialSetting)
        {
            double tax = 0;
            

            foreach (var innerItem in dateGroup)
            {
                if (tax >= 60)
                    break;

                tax += initialSetting.TaxPrices
                    .First(z => z.StartingTime.CompareTo(innerItem.TimeBaseOnHourAndMinuteAsString) <= 0 &&
                                z.EndingTime.CompareTo(innerItem.TimeBaseOnHourAndMinuteAsString) >= 0)
                    .Price;
            }

            return tax > 60 ? 60 : tax;
        }
    }
}