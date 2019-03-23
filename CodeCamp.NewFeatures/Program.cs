using System;
using System.Collections.Generic;
using System.Linq;
using CodeCamp.NewFeatures.Models;

namespace CodeCamp.NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void OldWayToCast(Vehicle anObject)
        {
            var aircraft = anObject as Aircraft;
            if (aircraft != null)
            {
                Console.WriteLine(aircraft.EngineCount);
            }
        }

        public static void NewWayToCast(Vehicle anObject)
        {
            if (anObject is Aircraft aircraft)
            {
                Console.WriteLine(aircraft.EngineCount);
            }
        }

        public static void OldWayToCast2(Vehicle anObject)
        {
            var aircraft = anObject as Aircraft;
            if (aircraft == null) return;

            Console.WriteLine(aircraft.EngineCount);
        }

        public static void NewWayToCast2(Vehicle anObject)
        {
            if (!(anObject is Aircraft aircraft)) return;

            Console.WriteLine(aircraft.EngineType);
        }

        public static Certification GetRequiredCertificationOld(Vehicle vehicle)
        {
            var aircraft = vehicle as Aircraft;
            if (aircraft != null)
            {
                if (aircraft.EngineType == AircraftEngineType.Turbojet &&
                    aircraft.EngineCount == 4)
                {
                    return Certification.JumboJets;
                }

                return Certification.GeneralAircraft;
            }

            var watercraft = vehicle as Watercraft;
            if (watercraft != null)
            {
                return watercraft.Tonnage > 10000 ? Certification.Ships : Certification.Boats;
            }

            var groundVehicle = vehicle as GroundVehicle;
            if (groundVehicle != null &&
                (groundVehicle.WheelCount > 6 || groundVehicle.GrossVehicleWeightRating > 10000))
            {
                return Certification.OversizeVehicles;
            }

            return Certification.None;
        }

        public static Certification GetRequiredCertificationNew(Vehicle vehicle)
        {
            switch (vehicle)
            {
                case Aircraft a when a.EngineType == AircraftEngineType.Turbojet && a.EngineCount == 4:
                    return Certification.JumboJets;
                case Aircraft a:
                    return Certification.GeneralAircraft;
                case Watercraft w when w.Tonnage > 10000:
                    return Certification.Ships;
                case Watercraft w:
                    return Certification.Boats;
                case GroundVehicle g when g.WheelCount > 6 || g.GrossVehicleWeightRating > 10000:
                    return Certification.OversizeVehicles;
                default:
                    return Certification.None;
            }
        }

        public static int CertificationCostOld(Certification certification)
        {
            switch (certification)
            {
                case Certification.JumboJets:
                    return 100000;
                case Certification.GeneralAircraft:
                    return 25000;
                case Certification.Ships:
                    return 20000;
                case Certification.Boats:
                    return 5000;
                case Certification.OversizeVehicles:
                    return 5000;
                case Certification.None:
                    return 0;
                default:
                    throw new ArgumentException(message: "invalid enum value");
            }
        }

        public List<CategoryAndPrice> GetAveragePriceByCategory(List<Product> products)
        {
            return products
                .GroupBy(
                    p => p.Category,
                    (category, list) => new CategoryAndPrice { Category = category, Price = list.Average(e => e.Price) })
                .ToList();
        }

        public List<Tuple<string, decimal>> GetAveragePriceByCategory2(List<Product> products)
        {
            return products
                .GroupBy(
                    p => p.Category,
                    (category, list) => new Tuple<string, decimal>(category, list.Average(e => e.Price)))
                .ToList();
        }

        public List<(string Category, decimal Price)> GetAveragePriceByCategory3(List<Product> products)
        {
            return products
                .GroupBy(
                    p => p.Category,
                    (category, list) => (Category: category, Price: list.Average(e => e.Price)))
                .ToList();
        }

        public void DoSomethingWithAveragePrices(List<Product> products)
        {
            var prices1 = GetAveragePriceByCategory(products);
            foreach (var pair in prices1)
            {
                Console.WriteLine($"Category: {pair.Category}, Price: {pair.Price}");
            }


            var prices2 = GetAveragePriceByCategory2(products);
            foreach (var pair in prices2)
            {
                Console.WriteLine($"Category: {pair.Item1}, Price: {pair.Item2}");
            }

            var prices3 = GetAveragePriceByCategory3(products);
            foreach (var pair in prices3)
            {
                (string Category, decimal Price) = pair;
                Console.WriteLine($"Category: {Category}, Price: {Price}");
            }
        }

        public static int CertificationCostNew(Certification certification) =>
            certification switch
        {
            Certification.JumboJets => 100000,
            Certification.GeneralAircraft => 25000,
            Certification.Ships => 20000,
            Certification.Boats => 5000,
            Certification.OversizeVehicles => 5000,
            Certification.None => 0,
            _ => throw new ArgumentException(message: "invalid enum value")
        };

        public string RockPaperScissors(string first, string second)
            => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };


        public void MakeProduct()
        {
            var product = new Product("A product", "A category");

            if (product.Upc != null)
            {
                WriteLine(product.Upc);
            }
        }

        public string? GetCategory(Product? product)
        {
            return product?.Category;
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}