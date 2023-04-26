using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    public class Person : object
    {
        public string? Name;
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

    }
}
