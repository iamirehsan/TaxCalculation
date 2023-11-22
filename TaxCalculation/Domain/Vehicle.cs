using System;
using TaxCalculation.Domain;

public class Vehicle : BaseEntity
{
    public string? Name { get; set; }
    public Guid VehicleTypeId { get; set; }
    public virtual VehicleType? VehicleType { get; set; }
}