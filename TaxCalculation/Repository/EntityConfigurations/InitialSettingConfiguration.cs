using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculation.Domain;
using TaxCalculation.Infrastructure;
using TaxCalculation.Infrastructure.Enum;

namespace TaxCalculation.Repository.EntityConfigurations
{
    public class InitialSettingConfiguration : BaseEntityConfiguration<InitialSetting>
    {
        public void Configure(EntityTypeBuilder<InitialSetting> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(p => p.FreeTaxDates).HasColumnName("freeTaxDates")
    .           HasConversion(
                 data => data.ToJson(),
                 data => ObjectUtils.ParseJson<IEnumerable<DateTime>>(data));

                builder.Property(p => p.FreeTaxVehicleTypes).HasColumnName("freeTaxVehicleTypes")
                 .HasConversion(
                  data => data.ToJson(),
                  data => ObjectUtils.ParseJson<IEnumerable<Guid>>(data));

                builder.Property(p => p.FreeTaxMonth).HasColumnName("freeTaxMonth")
                 .HasConversion(
                  data => data.ToJson(),
                  data => ObjectUtils.ParseJson<IEnumerable<Month>>(data));

                builder.Property(p => p.TaxPrices).HasColumnName("taxPrices")
                    .HasConversion(
                  data => data.ToJson(),
                  data => ObjectUtils.ParseJson<IEnumerable<TaxPrice>>(data));

        }
    }
}
