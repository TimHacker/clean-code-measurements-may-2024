namespace CleanCode;

public class Volumes
{
    public static Unit Teaspoon = new();
    public static Unit Tablespoon = new(3, Teaspoon);
    public static Unit Ounce = new(2, Tablespoon);
    public static Unit Cup = new(8, Ounce);
    public static Unit Pint = new(2, Cup);
    public static Unit Quart = new(2, Pint);
    public static Unit Gallon = new(4, Quart);
}