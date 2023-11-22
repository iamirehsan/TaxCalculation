using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculation.Domain
{
    public class VehicleTaxDate : BaseEntity
    {
        [ForeignKey("Vehicle")]
        public Guid VehicleId{ get; set; }
        public DateTime Time{ get; set; }
        [NotMapped]
        public string TimeBaseOnHourAndMinuteAsString => $"{Time.Hour}:{Time.Minute}";
    }
}
