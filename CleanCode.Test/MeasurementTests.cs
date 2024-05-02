namespace CleanCode.Test;



public class MeasurementTests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1, Measurement.Measure.Teaspoon, 1, Measurement.Measure.Teaspoon, true)]
    [TestCase(1, Measurement.Measure.Teaspoon, 2, Measurement.Measure.Teaspoon, false)]
    [TestCase(0.5f, Measurement.Measure.Pint, 1, Measurement.Measure.Cup, true)]
    public void CanCheckEquality(float amount, Measurement.Measure measure, float otherAmount, Measurement.Measure otherMeasure, bool isEqual)
    {
        Assert.That(new Volume(amount, measure).Equals(new Volume(otherAmount, otherMeasure)) == isEqual);
    }

    [Test]
    [TestCase(1, Measurement.Measure.Tablespoon, 3, Measurement.Measure.Teaspoon, true)]
    [TestCase(1, Measurement.Measure.Ounce,2, Measurement.Measure.Tablespoon, true)]
    [TestCase(1, Measurement.Measure.Cup,8, Measurement.Measure.Ounce, true)]
    [TestCase(1, Measurement.Measure.Pint,2, Measurement.Measure.Cup, true)]
    [TestCase(1, Measurement.Measure.Quart,2, Measurement.Measure.Pint, true)]
    [TestCase(1, Measurement.Measure.Gallon,4, Measurement.Measure.Quart, true)]
    [TestCase(1, Measurement.Measure.Quart,4, Measurement.Measure.Cup, true)]
    public void CanCheckEqualityAcrossTypes(int amount, Measurement.Measure measure, int otherAmount, Measurement.Measure otherMeasure, bool isEqual)
    {
        Assert.AreEqual(new Volume(amount, measure).Equals(new Volume(otherAmount, otherMeasure)), isEqual);
    }
    
    [Test]
    [TestCase(1, Measurement.Measure.Teaspoon,4, Measurement.Measure.Teaspoon, 5, Measurement.Measure.Teaspoon)]
    [TestCase(5, Measurement.Measure.Cup, 8, Measurement.Measure.Ounce, 288, Measurement.Measure.Teaspoon)]
    [TestCase(0.7f, Measurement.Measure.Gallon, 1.3f, Measurement.Measure.Tablespoon, 541.5f, Measurement.Measure.Teaspoon)]
    [TestCase(0.1f, Measurement.Measure.Teaspoon,0.06f, Measurement.Measure.Teaspoon, 0.16f, Measurement.Measure.Teaspoon)]
    [TestCase(0.3f, Measurement.Measure.Teaspoon,0.16f, Measurement.Measure.Teaspoon, 0.46f, Measurement.Measure.Teaspoon)]
    public void CanAddVolumes(float amount, Measurement.Measure measure, float otherAmount, Measurement.Measure otherMeasure,float expectedAmount, Measurement.Measure expectedMeasure)
    {
        Assert.AreEqual(new Volume(amount, measure).Add(new Volume(otherAmount,otherMeasure)), new Volume(expectedAmount,expectedMeasure));
    }
    
    [TestCase(1, Measurement.Measure.Inch,1, Measurement.Measure.Foot, 13, Measurement.Measure.Inch)]
    public void CanAddLengths(float amount, Measurement.Measure measure, float otherAmount, Measurement.Measure otherMeasure,float expectedAmount, Measurement.Measure expectedMeasure)
    {
        Assert.AreEqual(new Distance(amount, measure).Add(new Distance(otherAmount,otherMeasure)), new Distance(expectedAmount,expectedMeasure));
    }
    
    [Test]
    [TestCase(1, Measurement.Measure.Inch, 1, Measurement.Measure.Inch, true)]
    [TestCase(12, Measurement.Measure.Inch, 1, Measurement.Measure.Foot, true)]
    [TestCase(3, Measurement.Measure.Foot, 1, Measurement.Measure.Yard, true)]
    [TestCase(220, Measurement.Measure.Yard, 1, Measurement.Measure.Furlong, true)]
    [TestCase(8, Measurement.Measure.Furlong, 1, Measurement.Measure.Mile, true)]
    public void CanCheckEqualityOfDistances(float amount, Measurement.Measure measure, float otherAmount, Measurement.Measure otherMeasure, bool isEqual)
    {
        Assert.That(new Distance(amount, measure).Equals(new Distance(otherAmount, otherMeasure)) == isEqual);
    }

    [Test]
    public void CannotCompareDifferentTypesOfMeasurements()
    {
        Assert.False(new Volume(1, Measurement.Measure.Teaspoon).Equals(new Distance(1, Measurement.Measure.Inch)));
    }
   
}