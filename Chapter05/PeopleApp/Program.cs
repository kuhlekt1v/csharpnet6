using PacktLibrary;
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
        }
    }
}