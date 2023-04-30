namespace PacktLibrary
{
    public partial class Person
    {
        // Property defined using C# 1-5 syntax.
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        // Two properties defined using C# 6+ lambda expression body syntax.
        public string Greeting => $"{Name} says 'Hello!'";

        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string? FavoriteIceCream { get; set; }

        private string? favoritePrimaryColor;

        public string? FavoritePrimaryColor
        {
            get { return favoritePrimaryColor; }
            set
            {
                switch (value?.ToLower())
                {
                    case "red":
                    case "blue":
                    case "green":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException(
                            $"{value} is not a primary color. " +
                            "Choose from: red, blue, green");

                }
            }
        }

        // Indexers.
        public Person this[int index]
        {
            get { return Children[index]; } // Pass on to the List<T> indexer.
            set { Children[index] = value; }
        }
    }
}