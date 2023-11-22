using System.Reflection.Metadata.Ecma335;

namespace TaxCalculation.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public virtual InitialSetting InitialSetting  { get; set; }

    }

    }
}
