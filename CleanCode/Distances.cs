namespace CleanCode;

public class Distances
{
    public static Unit Inch = new();
    public static Unit Foot = new(12, Inch);
    public static Unit Yard = new(3, Foot);
    public static Unit Furlong = new(220, Yard);
    public static Unit Mile = new(8, Furlong);
}