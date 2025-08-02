namespace CalculadoraEstatisca.Arguments.Class;

public class GroupedLineTable
{
    public double Xi { get; set; }
    public int Fi { get; set; }
    public int FAC { get; set; }
    public double XiMultiplyFi { get; set; }
    public double SquareXiMinusAverageMultiplyFi { get; set; }

    public GroupedLineTable() { }

    public GroupedLineTable(double xi, int fi, int fAC)
    {
        Xi = xi;
        Fi = fi;
        FAC = fAC;
        XiMultiplyFi = xi * fi;
    }

    public bool AddAverage(double average)
    {
        SquareXiMinusAverageMultiplyFi = Math.Round((Math.Pow(Math.Abs(Xi - average), 2) * Fi), 2);
        return true;
    }
}