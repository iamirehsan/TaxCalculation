namespace TaxCalculation.Domain
{
    public class VehicleType : BaseEntity
    {
        public string? Name { get; set; }
        public  bool IsTaxFree { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
