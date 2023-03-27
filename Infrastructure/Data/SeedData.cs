using Domain.Enums;
using Domain.Models;

namespace Infrastructure.Data;

public static class SeedData
{
    public static List<Vehicle> SetVehiclesSeedData() => new()
    {
        new Vehicle
        {
            Id = 1,
            OwnerId = 1,
            Brand = "Mazda",
            Type = VehicleType.Car,
            Plaque = "AAA-123"
        },
        new Vehicle
        {
            Id = 2,
            OwnerId = 1,
            Brand = "Kawasaki",
            Type = VehicleType.Motorcycle,
            Plaque = "MMM-12D"
        },
        new Vehicle
        {
            Id = 3,
            OwnerId = 1,
            Brand = "Chevrolet",
            Type = VehicleType.Car,
            Plaque = "BBB-456"
        },
        new Vehicle
        {
            Id = 4,
            OwnerId = 2,
            Brand = "Land Rover",
            Type = VehicleType.Car,
            Plaque = "CCC-987"
        },
        new Vehicle
        {
            Id = 5,
            OwnerId = 2,
            Brand = "Kenworth",
            Type = VehicleType.Truck,
            Plaque = "ZZZ-555"
        },
        new Vehicle
        {
            Id = 6,
            OwnerId = 2,
            Brand = "Mack",
            Type = VehicleType.Truck,
            Plaque = "GGG-723"
        },
        new Vehicle
        {
            Id = 7,
            OwnerId = 3,
            Brand = "Mercedes-Benz",
            Type = VehicleType.Car,
            Plaque = "WWW-259"
        },
        new Vehicle
        {
            Id = 8,
            OwnerId = 3,
            Brand = "Mazda",
            Type = VehicleType.Car,
            Plaque = "AAA-123"
        },
        new Vehicle
        {
            Id = 9,
            OwnerId = 3,
            Brand = "Volvo",
            Type = VehicleType.Car,
            Plaque = "VVV-212"
        },
        new Vehicle
        {
            Id = 10,
            OwnerId = 3,
            Brand = "Ducati",
            Type = VehicleType.Motorcycle,
            Plaque = "DDD-889"
        }
    };

    public static List<Owner> SetOwnerSeedData() => new()
    {
        new Owner
        {
            Id = 1,
            Name = "Juanito Alimaña",
            Identification = "123456789",
            Address = "Cll 123 - Medellín",
            Type = OwnerType.Person
        },
        new Owner
        {
            Id = 2,
            Name = "Lola Mento",
            Identification = "987654321",
            Address = "Cll 100 - Bogotá",
            Type = OwnerType.Person
        },
        new Owner
        {
            Id = 3,
            Name = "Odebrecht",
            Identification = "543216789-1",
            Address = "Cll 666 - Ciudad perdida",
            Type = OwnerType.Company
        }
    };

    public static List<Registration> SetRegistrationSeedData() => new()
    {
        new Registration
        {
            Id = 1,
            VehicleId = 1,
            OwnerId = 1,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 2,
            VehicleId = 2,
            OwnerId = 2,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 3,
            VehicleId = 3,
            OwnerId = 3,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 4,
            VehicleId = 4,
            OwnerId = 1,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 5,
            VehicleId = 5,
            OwnerId = 2,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 6,
            VehicleId = 6,
            OwnerId = 3,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {Id = 7,
            VehicleId = 7,
            OwnerId = 1,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 8,
            VehicleId = 8,
            OwnerId = 2,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 9,
            VehicleId = 9,
            OwnerId = 3,
            RegistrationDate = DateTime.Now,
        },
        new Registration
        {
            Id = 10,
            VehicleId = 10,
            OwnerId = 3,
            RegistrationDate = DateTime.Now,
        }
    };

    public static List<Infringement> SetInfringementSeedData() => new()
    {
        new Infringement
        {
            Id = 1,
            Date = DateTime.Now.AddYears(-1),
            InfringementActuated = InfringementActuated.TransitPolice,
            VehicleId = 1
        },
        new Infringement
        {
            Id = 2,
            Date = DateTime.Now.AddYears(-2),
            InfringementActuated = InfringementActuated.TransitPolice,
            VehicleId = 2
        },
        new Infringement
        {
            Id = 3,
            Date = DateTime.Now.AddYears(-3),
            InfringementActuated = InfringementActuated.TransitPolice,
            VehicleId = 3
        },
        new Infringement
        {
            Id = 4,
            Date = DateTime.Now.AddMonths(-3),
            InfringementActuated = InfringementActuated.SecurityCamera,
            VehicleId = 4
        },
        new Infringement
        {
            Id = 5,
            Date = DateTime.Now.AddMonths(-6),
            InfringementActuated = InfringementActuated.SecurityCamera,
            VehicleId = 5
        },
        new Infringement
        {
            Id = 6,
            Date = DateTime.Now.AddMonths(-9),
            InfringementActuated = InfringementActuated.SecurityCamera,
            VehicleId = 6
        },
        new Infringement
        {
            Id = 7,
            Date = DateTime.Now.AddDays(15),
            InfringementActuated = InfringementActuated.TransitPolice,
            VehicleId = 7
        },
    };
}
