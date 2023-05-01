using static System.Console;

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
}
