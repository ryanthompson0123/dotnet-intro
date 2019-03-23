using System;
using System.Collections.Generic;
using CodeCamp.NewFeatures.Models;
using Bogus;
using System.Linq;

namespace CodeCamp.NewFeatures
{
    public class VehicleHelper
    {
        static Faker<Aircraft> aircrafts = new Faker<Aircraft>()
            .CustomInstantiator(f => new Aircraft(f.Commerce.ProductName(), f.Company.CompanyName()))
            .RuleFor(a => a.EngineCount, f => f.Random.Number(1, 4))
            .RuleFor(a => a.EngineType, f => f.PickRandom<AircraftEngineType>())
            .RuleFor(a => a.MaximumGrossTakeoffWeight, f => f.Random.Number(1000, 100000));

        static Faker<GroundVehicle> groundVehicles = new Faker<GroundVehicle>()
            .CustomInstantiator(f => new GroundVehicle(f.Commerce.ProductName(), f.Company.CompanyName()))
            .RuleFor(g => g.EngineType, f => f.PickRandom<EngineType>())
            .RuleFor(g => g.WheelCount, f => f.Random.Number(4, 18))
            .RuleFor(g => g.GrossVehicleWeightRating, f => f.Random.Number(10000, 40000));

        static Faker<Watercraft> watercrafts = new Faker<Watercraft>()
            .CustomInstantiator(f => new Watercraft(f.Commerce.ProductName(), f.Company.CompanyName()))
            .RuleFor(w => w.ScrewCount, f => f.Random.Number(1, 4))
            .RuleFor(w => w.EngineType, f => f.PickRandom<WatercraftEngineType>())
            .RuleFor(w => w.Tonnage, f => f.Random.Number(1000, 100000));

        public static IEnumerable<Vehicle> CreateVehicles(int count)
        {
            return
                new List<Vehicle>()
                .Concat(aircrafts.Generate(count / 3))
                .Concat(groundVehicles.Generate(count / 3))
                .Concat(watercrafts.Generate(count / 3));
        }
    }
}