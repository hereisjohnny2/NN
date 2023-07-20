namespace MicroGrad;

public delegate void BackwardDelegate();

public class Value
{
    public double Data { get; set; } = 0;
    public HashSet<Value> Children { get; set; }
    public string Op { get; set; }
    public double Grad { get; set; }

    public BackwardDelegate Backward { get; set; }


    public Value(double data) : this(data, new HashSet<Value>(), "")
    {
    }

    private Value(double data, HashSet<Value> children, string op)
    {
        Data = data;
        Children = children;
        Op = op;
        Grad = 0.0;
        Backward = () => { };
    }

    public Value Add(Value other)
    {
        var val = new Value(Data + other.Data) 
        {
            Op = "+",
            Children = new HashSet<Value>()
            {
                this,
                other,
            }
        };
        
        val.Backward = () =>
        {
            Grad = val.Grad;
            other.Grad = val.Grad;
        };

        return val;
    }

    public Value Mul(Value other)
    {
        var val = new Value(Data * other.Data) 
        {
            Op = "*",
            Children = new HashSet<Value>()
            {
                this,
                other,
            }
        };
        
        val.Backward = () =>
        {
            Grad = val.Grad * other.Data;
            other.Grad = val.Grad * Data;
        };

        return val;
    }

    public override string ToString()
    {
        return $"Value(data = {Data})";
    }
}