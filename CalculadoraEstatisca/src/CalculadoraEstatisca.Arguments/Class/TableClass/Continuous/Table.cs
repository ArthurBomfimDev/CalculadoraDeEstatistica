using CalculadoraEstatisca.Arguments.Class.Base;
using CalculadoraEstatisca.Arguments.Class.Table;

namespace CalculadoraEstatisca.Arguments;

public class Table
{
    public List<LineTable> ListLineTable { get; set; } = new();
    public int N { get; set; }
    public double TotalXi { get; set; }
    public double TotalXiMultiplyFi { get; set; }
    public int TotalFAC { get; set; }
    public double TotalModuleXiMinusAverageMultiplyFi { get; set; }
    public double TotalSquareXiMinusAverageMultiplyFi { get; set; }
    public int K { get; set; }
    public double AT { get; set; }
    public int C { get; set; }

    public Table() { }

    public Table(int k, double aT, int c)
    {
        K = k;
        AT = aT;
        C = c;
    }

    public void AddNewLine(Classe classe, int fi)
    {
        ListLineTable.Add(new LineTable
            (
                classe,
                fi,
                (classe.Li + classe.Ls) / 2,
                 (from i in ListLineTable
                  select i.Fi).Sum() + fi
            ));
    }

    public void AddNewLine(InputLineTable intputLineTable)
    {
        ListLineTable.Add(new LineTable(
                intputLineTable.Classe,
                intputLineTable.Fi,
                intputLineTable.Xi,
                intputLineTable.FAC
            ));
    }

    public void CalculateTotals()
    {
        N = 0;
        TotalFAC = 0;
        TotalXiMultiplyFi = 0;
        TotalFAC = 0;

        (from i in ListLineTable
         let n = N += i.Fi
         let totalXi = TotalXi += i.Xi
         let totalXiMultiplyfi = TotalXiMultiplyFi += i.XiMultiplyFi
         let totalFAC = TotalFAC += i.Fi
         select true).ToList();
    }

    public LineTable? GetMid()
    {
        int mid = (int)Math.Ceiling(N / 2.0);

        return (from i in ListLineTable
                where i.FAC >= mid
                select i).FirstOrDefault();
    }

    public LineTable? GetMost()
    {
        var listLineOrderned = ListLineTable.OrderByDescending(i => i.Fi);

        if (listLineOrderned.First().Fi == listLineOrderned.Last().Fi)
            return null;

        return listLineOrderned.First();
    }

    public void SetAverage(double average)
    {
        TotalModuleXiMinusAverageMultiplyFi = 0;
        TotalSquareXiMinusAverageMultiplyFi = 0;

        (from i in ListLineTable
         let setAverage = i.AddAverage(average)
         let totalModuleXiMinusAverageMultiplyFi = TotalModuleXiMinusAverageMultiplyFi += i.ModuleXiMinusAverageMultiplyFi
         let totalSquareXiMinusAverageMultiplyFi = TotalSquareXiMinusAverageMultiplyFi += i.SquareXiMinusAverageMultiplyFi
         select true).ToList();

        TotalModuleXiMinusAverageMultiplyFi = Math.Round(TotalModuleXiMinusAverageMultiplyFi, 2);
        TotalSquareXiMinusAverageMultiplyFi = Math.Round(TotalSquareXiMinusAverageMultiplyFi, 2);
    }
}