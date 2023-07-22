namespace MicroGrad;

public class Matrix
{
    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Data = Enumerable.Repeat(new Value(0.0), rows * cols).ToArray();
    }

    public Matrix(int rows, int cols, Value[] data)
    {
        if (data.Length != rows * cols)
        {
            throw new ArgumentException("data length should be equals to rows * cols");
        }

        Rows = rows;
        Cols = cols;
        Data = data;
    }

    public Value[] Data { get; set; }

    public int Cols { get; set; }

    public int Rows { get; set; }

    public Value Get(int row, int col)
    {
        return Data[row * Cols + col];
    }

    public void InsertAt(int row, int col, Value value)
    {
        if (row >= Rows || col >= Cols)
        {
            throw new ArgumentException("position out of bounds");
        }

        Data[row * Cols + col] = value;
    }

    public Matrix Add(Matrix other)
    {
        if (!Rows.Equals(other.Rows) || !Cols.Equals(other.Cols))
        {
            throw new ArgumentException("matrices must have same dimensions");
        }

        var output = new Matrix(Rows, Cols);

        for (var i = 0; i < Rows; ++i)
        {
            for (var j = 0; j < Cols; ++j)
            {
                var pos = i * Cols + j;
                output.Data[pos] = Data[pos].Add(other.Data[pos]);
            }
        }

        return output;
    }
    
    public Matrix Mul(Matrix other)
    {
        if (!Rows.Equals(other.Rows) || !Cols.Equals(other.Cols))
        {
            throw new ArgumentException("Matrices must have same dimensions");
        }
    
        var output = new Matrix(Rows, Cols);
    
        for (var i = 0; i < Rows; ++i)
        {
            for (var j = 0; j < Cols; ++j)
            {
                var pos = i * Cols + j;
                output.Data[pos] = Data[pos].Mul(other.Data[pos]);
            }
        }
    
        return output;
    }
    
    public Matrix Dot(Matrix other)
    {
        if (!Cols.Equals(other.Rows))
        {
            throw new ArgumentException("Matrix A number of rows should be equal to Matrix B number of columns");
        }
    
        var output = new Matrix(Rows, other.Cols);
    
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < other.Cols; j++)
            {
                var elm = new Value(0);
                for (var k = 0; k < Cols; k++)
                {
                    var pos = i * Cols + k;
                    elm = elm.Add(Data[pos].Mul(other.Get(k, j)));
                }
    
                output.InsertAt(i, j, elm);
            }
        }
    
        return output;
    }
    
    public override string ToString()
    {
        var output = "[\n";
        for (var i = 0; i < Rows; i++)
        {
            output += "\t[";
            for (var j = 0; j < Cols; j++)
            {
                var pos = i * Cols + j;
                output += $"{Data[pos].Data:0.0000},";
            }
    
            output += "],\n";
        }
    
        output += "]";
    
        return output;
    }
    
    public Value Det()
    {
        
        return new Value(0.0);
    }
}