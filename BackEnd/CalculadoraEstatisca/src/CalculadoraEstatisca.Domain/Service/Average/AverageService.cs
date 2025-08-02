using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class.TableClass;
using CalculadoraEstatisca.Domain.Interface;

namespace CalculadoraEstatisca.Domain.Service.Average;

public class AverageService : IAverageService
{
    public double CalculateContinuous(Table table)
    {
        return Math.Round((table.TotalXiMultiplyFi / table.N), 2);
    }

    public double CalculateNotGrouped(List<double> listNumber)
    {
        int quantity = listNumber.Count();

        double soma = (from i in listNumber
                       select i).Sum(j => j);

        double average = (double)(soma / quantity);

        return average;
    }

    public double CalculateGrouped(InputGroupedTable groupedTable)
    {
        double xiMultiplyFi = 0;
        int N = 0;

        foreach (var item in groupedTable.ListGroupedLineTable)
        {
            xiMultiplyFi += item.Xi * item.Fi;
            N += item.Fi;
        }

        return xiMultiplyFi / 2;
    }
}