﻿using static System.Console;

namespace PacktLibrary;
public class Person : object
{
  // Fields.
  public string? Name;
  public DateTime DateOfBirth;
  public List<Person> Children = new();

  // Methods.
  public void WriteToConsole()
  {
    WriteLine($"{Name} WaitHandleExtensions born on a {DateOfBirth:dddd}.");
  }

  // Static method to "multiply".
  public static Person Procreate(Person p1, Person p2)
  {
    Person baby = new()
    {
      Name = $"Baby of {p1.Name} and {p2.Name}"
    };

    p1.Children.Add(baby);
    p2.Children.Add(baby);

    return baby;
  }

  // Instance method to "multiply".
  public Person ProcreateWith(Person partner)
  {
    return Procreate(this, partner);
  }

  // Operator to "multiply".
  public static Person operator *(Person p1, Person p2)
  {
    return Person.Procreate(p1, p2);
  }

  // Method with a local function.
  public static int Factorial(int number)
  {
    if (number < 0)
    {
      throw new ArgumentException(
        $"{nameof(number)} cannot be less than zero.");
    }
    return localFactorial(number);

    // Local function.
    int localFactorial(int localNumber)
    {
      if (localNumber < 1) return 1;
      return localNumber * localFactorial(localNumber - 1);
    }
  }
}