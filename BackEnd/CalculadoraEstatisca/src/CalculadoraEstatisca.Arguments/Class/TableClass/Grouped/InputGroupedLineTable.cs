namespace CalculadoraEstatisca.Arguments.Class.TableClass;

public class InputGroupedLineTable
{
    public double Xi { get; set; }
    public int Fi { get; set; }

    public InputGroupedLineTable() { }

    public InputGroupedLineTable(int fi, double xi)
    {
        Fi = fi;
        Xi = xi;
    }
}