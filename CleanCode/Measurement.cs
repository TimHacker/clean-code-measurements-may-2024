namespace CleanCode;

public abstract class Measurement
{
    public float _amount;

    public Measurement(float amount, Unit unit)
    {
        
    }

    public override string ToString()
    {
        return $"Amount: {_amount.ToString()}";
    }

    public abstract Measurement Add(Measurement other);
}

public class Volume : Measurement
{
    public Volume(float amount, Unit unit) : base(amount, unit)
    {
        _amount = unit.ToBaseUnit(amount);
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
        return new Volume(_amount + other._amount, Volumes.Teaspoon);
    }
}

public class Distance : Measurement
{
    public Distance(float amount, Unit unit) : base(amount, unit)
    {
        _amount = unit.ToBaseUnit(amount);
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
        return new Distance(_amount + other._amount, Distances.Inch);
    }
}

