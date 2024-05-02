namespace CleanCode;

public class Unit
{
    private readonly int _ratioToBaseUnit;
    private readonly Unit _baseUnit;

    public Unit()
    {
        _ratioToBaseUnit = 1;
        _baseUnit = this;
    }
        
    public Unit(int ratio, Unit relativeUnit)
    {
        _ratioToBaseUnit = ratio * relativeUnit._ratioToBaseUnit;
        _baseUnit = relativeUnit._baseUnit;
    }
        
    public float ToBaseUnit(float amount)
    {
        return amount * _ratioToBaseUnit;
    }
}