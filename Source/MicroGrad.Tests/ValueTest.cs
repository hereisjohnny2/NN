namespace MicroGrad.Tests;

public class ValueTest
{
    [Test]
    public void TestValueOperations()
    {
        var a = new Value(2.0);
        var b = new Value(-3.0);
        var c = new Value(10.0);
        
        var d = c.Add(a.Mul(b));
        Assert.That(d.Data, Is.EqualTo(4.0));
        
        var e = new Value(-2.0);
        var output = d.Mul(e);
        Assert.That(output.Data, Is.EqualTo(-8.0));
    }
}