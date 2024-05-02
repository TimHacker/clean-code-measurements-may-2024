namespace CleanCode.Test;



public class MeasurementTests
{

    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void CanCheckEqualityAcrossTypes_TablespoonToTeaspoon_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Tablespoon).Equals(new Volume(3, Volumes.Teaspoon)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_OunceToTablespoon_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Ounce).Equals(new Volume(2, Volumes.Tablespoon)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_CupToOunce_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Cup).Equals(new Volume(8, Volumes.Ounce)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_PintToCup_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Pint).Equals(new Volume(2, Volumes.Cup)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_QuartToPint_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Quart).Equals(new Volume(2, Volumes.Pint)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_GallonToQuart_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Gallon).Equals(new Volume(4, Volumes.Quart)), true);
    }

    [Test]
    public void CanCheckEqualityAcrossTypes_QuartToCup_Equal()
    {
        Assert.AreEqual(new Volume(1, Volumes.Quart).Equals(new Volume(4, Volumes.Cup)), true);
    }


    // [Test]
    // [TestCase(1, Measurement.Unit.Teaspoon, 1, Measurement.Unit.Teaspoon, true)]
    // [TestCase(1, Measurement.Unit.Teaspoon, 2, Measurement.Unit.Teaspoon, false)]
    // [TestCase(0.5f, Measurement.Unit.Pint, 1, Measurement.Unit.Cup, true)]
    // public void CanCheckEquality(float amount, Measurement.Unit unit, float otherAmount, Measurement.Unit otherUnit, bool isEqual)
    // {
    //     Assert.That(new Volume(amount, unit).Equals(new Volume(otherAmount, otherUnit)) == isEqual);
    // }
    //
    // [Test]
    // [TestCase(1, Measurement.Unit.Tablespoon, 3, Measurement.Unit.Teaspoon, true)]
    // [TestCase(1, Measurement.Unit.Ounce,2, Measurement.Unit.Tablespoon, true)]
    // [TestCase(1, Measurement.Unit.Cup,8, Measurement.Unit.Ounce, true)]
    // [TestCase(1, Measurement.Unit.Pint,2, Measurement.Unit.Cup, true)]
    // [TestCase(1, Measurement.Unit.Quart,2, Measurement.Unit.Pint, true)]
    // [TestCase(1, Measurement.Unit.Gallon,4, Measurement.Unit.Quart, true)]
    // [TestCase(1, Measurement.Unit.Quart,4, Measurement.Unit.Cup, true)]
    // public void CanCheckEqualityAcrossTypes(int amount, Measurement.Unit unit, int otherAmount, Measurement.Unit otherUnit, bool isEqual)
    // {
    //     Assert.AreEqual(new Volume(amount, unit).Equals(new Volume(otherAmount, otherUnit)), isEqual);
    // }
    //
    // [Test]
    // [TestCase(1, Measurement.Unit.Teaspoon,4, Measurement.Unit.Teaspoon, 5, Measurement.Unit.Teaspoon)]
    // [TestCase(5, Measurement.Unit.Cup, 8, Measurement.Unit.Ounce, 288, Measurement.Unit.Teaspoon)]
    // [TestCase(0.7f, Measurement.Unit.Gallon, 1.3f, Measurement.Unit.Tablespoon, 541.5f, Measurement.Unit.Teaspoon)]
    // [TestCase(0.1f, Measurement.Unit.Teaspoon,0.06f, Measurement.Unit.Teaspoon, 0.16f, Measurement.Unit.Teaspoon)]
    // [TestCase(0.3f, Measurement.Unit.Teaspoon,0.16f, Measurement.Unit.Teaspoon, 0.46f, Measurement.Unit.Teaspoon)]
    // public void CanAddVolumes(float amount, Measurement.Unit unit, float otherAmount, Measurement.Unit otherUnit,float expectedAmount, Measurement.Unit expectedUnit)
    // {
    //     Assert.AreEqual(new Volume(amount, unit).Add(new Volume(otherAmount,otherUnit)), new Volume(expectedAmount,expectedUnit));
    // }
    //
    // [TestCase(1, Measurement.Unit.Inch,1, Measurement.Unit.Foot, 13, Measurement.Unit.Inch)]
    // public void CanAddLengths(float amount, Measurement.Unit unit, float otherAmount, Measurement.Unit otherUnit,float expectedAmount, Measurement.Unit expectedUnit)
    // {
    //     Assert.AreEqual(new Distance(amount, unit).Add(new Distance(otherAmount,otherUnit)), new Distance(expectedAmount,expectedUnit));
    // }
    //
    // [Test]
    // [TestCase(1, Measurement.Unit.Inch, 1, Measurement.Unit.Inch, true)]
    // [TestCase(12, Measurement.Unit.Inch, 1, Measurement.Unit.Foot, true)]
    // [TestCase(3, Measurement.Unit.Foot, 1, Measurement.Unit.Yard, true)]
    // [TestCase(220, Measurement.Unit.Yard, 1, Measurement.Unit.Furlong, true)]
    // [TestCase(8, Measurement.Unit.Furlong, 1, Measurement.Unit.Mile, true)]
    // public void CanCheckEqualityOfDistances(float amount, Measurement.Unit unit, float otherAmount, Measurement.Unit otherUnit, bool isEqual)
    // {
    //     Assert.That(new Distance(amount, unit).Equals(new Distance(otherAmount, otherUnit)) == isEqual);
    // }

    [Test]
    public void CanConvertAmountInBaseUnit()
    {
        var baseUnit = new Unit();

        var subUnit = new Unit(2, baseUnit);

        var subSubUnit = new Unit(3, subUnit);
        
        Assert.AreEqual(1, baseUnit.ToBaseUnit(1));
        Assert.AreEqual(12, subUnit.ToBaseUnit(6));
        Assert.AreEqual(144, subSubUnit.ToBaseUnit(24));
    }

    [Test]
    public void CannotCompareDifferentTypesOfMeasurements()
    {
        Assert.False(new Volume(1, Volumes.Teaspoon).Equals(new Distance(1, Distances.Inch)));
    }
}