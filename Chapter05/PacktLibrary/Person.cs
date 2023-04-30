using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    public partial class Person
    {
        [Required]
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;

        public List<Person> Children = new();

        // Constants
        // Remember - Value must be known at compile time b/c every reference to
        // the const field is replaced by the literal interpretation. Therefore, 
        // if the value changes in the future ALL  assemblies that reference it must
        // be recompiled. 
        public const string Species = "Homo Sapien";

        // Read-only
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        // Constructors
        public Person()
        {
            // Set default values for fields, 
            // including readonly fields.
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            // Set default values for fields, 
            // including readonly fields.
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // Methods
        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        public (string Name, int Number) GetFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        public void Deconstruct(out string name, out DateTime dob)
        {
            name = Name;
            dob = DateOfBirth;
        }

        public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav)
        {
            name = Name;
            dob = DateOfBirth;
            fav = FavoriteAncientWonder;
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello, {name}!'";
        }

        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true)
        {
            return string.Format(
              format: "command is {0}, number is {1}, active is {2}",
              arg0: command,
              arg1: number,
              arg2: active
            );
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            // out parameters cannot have a default.
            // AND must be initialized inside the method.
            z = 99;

            x++;
            y++;
            z++;
        }

    }
}
