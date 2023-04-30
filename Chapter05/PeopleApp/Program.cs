using PacktLibrary;
using PacktLibraryModern;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace PeopleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new();

            person.Name = "Tony";
            person.DateOfBirth = new DateTime(1965, 12, 22);
            person.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            person.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
                WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

            person.Children.Add(new() { Name = "Zoe" });
            WriteLine($"{person.Name} has {person.Children.Count} children.");

            for (int childIndex = 0; childIndex < person.Children.Count; childIndex++)
            {
                WriteLine($"{person.Children[childIndex].Name}");
            }

            WriteLine($"{person.Name} is a {Person.Species}.");
            WriteLine($"{person.Name} was born on {person.HomePlanet}.");

            BankAccount.InterestRate = 0.12M;

            BankAccount jonesAccount = new();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine(format: "{0} earned {1:C} interest.",
              arg0: jonesAccount.AccountName,
              arg1: jonesAccount.Balance * BankAccount.InterestRate);

            BankAccount gerrierAccount = new();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest.",
              arg0: gerrierAccount.AccountName,
              arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            // Person Constructor
            Person blankPerson = new();
            WriteLine(format:
                "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated);

            Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
            WriteLine(format:
                 "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                 arg0: gunny.Name,
                 arg1: gunny.HomePlanet,
                 arg2: gunny.Instantiated);

            person.WriteToConsole();
            WriteLine(person.GetOrigin());

            // Tuples.
            (string, int) fruit = person.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            var thing2 = (person.Name, person.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children."); // C# > 7.1 names are inferred.

            // Deconstructing a Person
            var (name1, dob1) = person;
            WriteLine($"Deconstructed: {name1}, {dob1}");

            var (name2, dob2, fav2) = person;
            WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

            WriteLine(person.SayHello());
            WriteLine(person.SayHello("Amy"));

            // Optional parameters.
            WriteLine(person.OptionalParameters(number: 52.7, command: "Hide"));
            WriteLine(person.OptionalParameters("poke", active: false)); // Use named parameters to skip over others.

            int a = 10;
            int b = 20;
            int c = 30;

            WriteLine($"Before: a: {a}, b: {b}, c: {c}");
            person.PassingParameters(a, ref b, out c);
            WriteLine($"After: a: {a}, b: {b}, c: {c}");

            int d = 20;
            int e = 30;

            WriteLine($"Before: d: {d}, e: {e}, f doesn't exist yet");
            person.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d: {d}, e: {e}, f: {f}");

            Person sam = new();
            sam.Name = "Sam";
            sam.DateOfBirth = new(1972, 1, 27);
            sam.FavoriteIceCream = "Rockie Road";
            try
            {
                sam.FavoritePrimaryColor = "red";
            }
            catch (System.ArgumentException ae)
            {
                WriteLine(ae.Message);
            }


            WriteLine("");
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);
            WriteLine(sam.FavoriteIceCream);
            WriteLine(sam.FavoritePrimaryColor);

            WriteLine("");
            sam.Children.Add(new() { Name = "Ella" });
            sam.Children.Add(new() { Name = "Charlie" });
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");

            // Pattern matching.

            object[] passengers = {
                new FirstClassPassenger {AirMiles = 1_419},
                new FirstClassPassenger {AirMiles = 16_562},
                new BusinessClassPassenger(),
                new CoachClassPassenger {CarryOnKG = 25.7},
                new CoachClassPassenger {CarryOnKG = 0}
            };

            foreach (object passenger in passengers)
            {
                decimal flightCost = passenger switch
                {
                    /* C# 8 Syntax
                    FirstClassPassenger p when p.AirMiles > 3500 => 1500M,
                    FirstClassPassenger p when p.AirMiles > 1500 => 1750M,
                    FirstClassPassenger _ => 2000M, */

                    // C# 9 Syntax
                    FirstClassPassenger p => p.AirMiles switch
                    {
                        > 3500 => 1500M,
                        > 1500 => 1750M,
                        _ => 2000M
                    },

                    BusinessClassPassenger _ => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger _ => 650M,
                    _ => 800M,
                };
                WriteLine($"Flight costs {flightCost:C} for {passenger}");
            }

            ImmutablePerson jeff = new() { FirstName = "Jeff", LastName = "Winger" };

            /*  Init-only property or indexer 'ImmutablePerson.FirstName' 
                can only be assigned in an object initializer. {get; init;} 
                prevents property from being changes once instantiated. */

            // jeff.FirstName = "Geoff";

            ImmutableVehicle car = new()
            {
                Brand = "Mazda MX-5 RF",
                Color = "Soul Red Crystal Metallic",
                Wheels = 4
            };

            ImmutableVehicle repaintedCar = car with { Color = "Polymetal Grey Metallic" };

            WriteLine($"Original car color was {car.Color}");
            WriteLine($"Repainted car color is {repaintedCar.Color}");
            WriteLine(repaintedCar.Brand);

            WriteLine();

            ImmutableAnimal oscar = new("Oscar", "Labrador");
            var (who, what) = oscar; // Calls deconstruct method.
            WriteLine($"{who} is a {what}.");
        }

    }
}