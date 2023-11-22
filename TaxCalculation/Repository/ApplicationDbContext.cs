using Microsoft.EntityFrameworkCore;
using TaxCalculation.Domain;
using TaxCalculation.Repository.EntityConfigurations;
using TaxCalculation.Repository.Interface;

namespace TaxCalculation.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<InitialSetting> InitialSetting { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleTaxDate> VehicleTaxDate { get; set; }
        public DbSet<City> City{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTaxDateConfiguration());
            modelBuilder.ApplyConfiguration(new InitialSettingConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());


        }
    }
}
