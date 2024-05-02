namespace CleanCode;

public abstract class Measurement
{
    //Need make it open for extension, closed for modification. Only one place where this changes
    public enum Measure
    {
        Teaspoon,
        Tablespoon, 
        Ounce,
        Cup,
        Pint,
        Quart,
        Gallon,

        Inch,
        Foot,
        Yard,
        Furlong,
        Mile
    }

    protected readonly Dictionary<Measure, int> _conversionFactors = new();
    public float _amount;

    public Measurement(float amount, Measure measure)
    {
        
    }

    public bool Equals(Measurement other)
    {
        return _amount == other._amount;
    }

    public override string ToString()
    {
        return $"Amount: {_amount.ToString()}";
    }

    protected float ToBaseUnit(float amount, Measure measure)
    {
        return amount * _conversionFactors[measure];
    }

    public abstract Measurement Add(Measurement other);

    public override int GetHashCode()
    {
        return HashCode.Combine(_conversionFactors, _amount);
    }
}

public class Volume : Measurement
{
    public Volume(float amount, Measure measure) : base(amount, measure)
    {
        _conversionFactors.Add(Measure.Teaspoon, 1);
        _conversionFactors.Add(Measure.Tablespoon, 3);
        _conversionFactors.Add(Measure.Ounce, 6);
        _conversionFactors.Add(Measure.Cup, 48);
        _conversionFactors.Add(Measure.Pint, 96);
        _conversionFactors.Add(Measure.Quart, 192);
        _conversionFactors.Add(Measure.Gallon, 768);
        
        _amount = ToBaseUnit(amount, measure);
    }
    
    public bool Equals(Measurement other)
    {
        if (other is not Volume)
        {
            return false;
        }
        return _amount == other._amount;
    }
    
    public override bool Equals(object? other)
    {
        if (other is not Volume otherMeasure)
        {
            return false;
        }
        return this.Equals(otherMeasure);
    }

    public override Measurement Add(Measurement other)
    {
        return new Volume(_amount + other._amount, Measure.Teaspoon);
    }
}

public class Distance : Measurement
{
    public Distance(float amount, Measure measure) : base(amount, measure)
    {
        _conversionFactors.Add(Measure.Inch, 1);
        _conversionFactors.Add(Measure.Foot, 12);
        _conversionFactors.Add(Measure.Yard, 36);
        _conversionFactors.Add(Measure.Furlong, 7920);
        _conversionFactors.Add(Measure.Mile, 63360);
        
        _amount = ToBaseUnit(amount, measure);
    }
    
    public bool Equals(Measurement other)
    {
        if (other is not Distance)
        {
            return false;
        }
        return _amount == other._amount;
    }
    
    public override bool Equals(object? other)
    {
        if (other is not Distance otherMeasure)
        {
            return false;
        }
        return this.Equals(otherMeasure);
    }
    
    public override Measurement Add(Measurement other)
    {
        return new Distance(_amount + other._amount, Measure.Inch);
    }
}