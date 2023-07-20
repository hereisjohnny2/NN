namespace MicroGrad;

public class Matrix
{
    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Data = new Value[rows, cols];
    }

    public Value[,] Data { get; set; }

    public int Cols { get; set; }

    public int Rows { get; set; }

    public Value Get(int i, int j)
    {
        return Data[i, j];
    }

    public void Insert(int i, int j, Value value)
    {
        Data[i, j] = value;
    }

    public Matrix Add(Matrix other)
    {
        if (!Rows.Equals(other.Rows) || !Cols.Equals(other.Cols))
        {
            throw new ArgumentException("Matrices must have same dimensions");
        }

        var output = new Matrix(Rows, Cols);

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Cols; j++)
            {
                output.Data[i, j] = Data[i, j].Add(other.Data[i, j]);
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

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Cols; j++)
            {
                output.Data[i, j] = Data[i, j].Mul(other.Data[i, j]);
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
                    elm = elm.Add(Data[i, k].Mul(other.Get(k, j)));
                }

                output.Insert(i, j, elm);
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
                output += $"{Data[i, j].Data:0.0000},";
            }

            output += "],\n";
        }

        output += "]";

        return output;
    }
}