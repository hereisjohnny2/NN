using MicroGrad;

Console.WriteLine("MicroGrad - Testing");
var a = new Value(2.0);
var b = new Value(-3.0);
var c = new Value(10.0);

var d = c.Add(a.Mul(b));
var e = new Value(-2.0);

var output = d.Mul(e);
output.Grad = 1.0;

Console.WriteLine($"Final Output: {output}");

var mA = new Matrix(2, 2)
{
    Data = new Value[,] { { new(3), new(2) }, { new(5), new(-1) } }
};

var mB = new Matrix(2, 2)
{
    Data = new Value[,] { { a, a }, { b, b } }
};

var mC = new Matrix(2, 3)
{
    Data = new Value[,] { { new(6), new(4), new (-2) }, { new(0), new (7), new(1) } }
};

Console.WriteLine($"mA + mB = {mA.Add(mB)}");
Console.WriteLine($"mA * mB = {mA.Mul(mB)}");
Console.WriteLine($"mA . mB = {mA.Dot(mC)}");
