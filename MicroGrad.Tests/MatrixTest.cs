using NUnit.Framework.Interfaces;

namespace MicroGrad.Tests;

[TestFixture]
public class MatrixTest
{
    [Test]
    public void TestCreateMatrix()
    {
        var m = new Matrix(5, 2);

        Assert.That(m.Cols, Is.EqualTo(2));
        Assert.That(m.Rows, Is.EqualTo(5));
        Assert.That(m.Data[0].Data, Is.EqualTo(0.0));
    }

    [Test]
    public void TestCreateMatrixFromData()
    {
        var data = new[]
        {
            new Value(1), new Value(3), new Value(4),
            new Value(8), new Value(2), new Value(10),
        };
        var m1 = new Matrix(2, 3, data);

        Assert.That(m1.Cols, Is.EqualTo(3));
        Assert.That(m1.Rows, Is.EqualTo(2));
        Assert.That(m1.Data[0].Data, Is.EqualTo(1));

        Assert.Throws<ArgumentException>(() =>
        {
            var _ = new Matrix(1, 1, data);
        });
    }

    [TestCase(0, 0, 1)]
    [TestCase(0, 1, 3)]
    [TestCase(0, 2, 4)]
    [TestCase(1, 0, 8)]
    [TestCase(1, 1, 2)]
    [TestCase(1, 2, 10)]
    public void TestGetMatrixElement(int row, int col, double expected)
    {
        var m = new Matrix(2, 3)
        {
            Data = new Value[]
            {
                new(1), new(3), new(4),
                new(8), new(2), new(10),
            }
        };

        var got = m.Get(row, col);
        Assert.That(got.Data, Is.EqualTo(expected));
    }

    [Test]
    public void TestInsertAt()
    {
        var m = new Matrix(5, 2);

        m.InsertAt(1, 1, new Value(3));
        Assert.That(m.Get(1, 1).Data, Is.EqualTo(3));

        Assert.Throws<ArgumentException>(() => m.InsertAt(10, 1, new Value(3)));
        Assert.Throws<ArgumentException>(() => m.InsertAt(1, 10, new Value(3)));
    }

    [Test]
    public void TestSumMatrices()
    {
        var data1 = new Value[]
        {
            new(1), new(3), new(4),
            new(8), new(2), new(10),
        };
        var m1 = new Matrix(2, 3, data1);
        
        var data2 = new Value[]
        {
            new(5), new(10), new(5),
            new(6), new(1), new(3),
        };
        var m2 = new Matrix(2, 3, data2);
        
        var expectedData = new Value[]
        {
            new(6), new(13), new(9),
            new(14), new(3), new(13),
        };

        var output = m1.Add(m2);

        Assert.That(expectedData, Is.EqualTo(output.Data));
    }
    
    [Test]
    public void TestMulMatrices()
    {
        var data1 = new Value[]
        {
            new(1), new(3), new(4),
            new(8), new(2), new(10),
        };
        var m1 = new Matrix(2, 3, data1);
        
        var data2 = new Value[]
        {
            new(5), new(10), new(5),
            new(6), new(1), new(3),
        };
        var m2 = new Matrix(2, 3, data2);
        
        var expectedData = new Value[]
        {
            new(5), new(30), new(20),
            new(48), new(2), new(30),
        };

        var output = m1.Mul(m2);

        Assert.That(expectedData, Is.EqualTo(output.Data));
    }
    
    [Test]
    public void TestDotMatrices()
    {
        var data1 = new Value[]
        {
            new(1), new(3),
            new(8), new(2),
        };
        var m1 = new Matrix(2, 2, data1);
        
        var data2 = new Value[]
        {
            new(5), new(10), new(5),
            new(6), new(1), new(3),
        };
        var m2 = new Matrix(2, 3, data2);
        
        var expectedData = new Value[]
        {
            new(23), new(13), new(14),
            new(52), new(82), new(46),
        };

        var output = m1.Dot(m2);

        Assert.That(expectedData, Is.EqualTo(output.Data));
    }
}
