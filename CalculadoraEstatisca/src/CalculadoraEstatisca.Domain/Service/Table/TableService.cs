using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class;
using CalculadoraEstatisca.Arguments.Class.Base;
using CalculadoraEstatisca.Arguments.Class.Table;
using CalculadoraEstatisca.Arguments.Class.TableClass;
using CalculadoraEstatisca.Domain.Interface;

namespace CalculadoraEstatisca.Domain;

public class TableService : ITableService
{
    private readonly IAverageService _averageService;

    public TableService(IAverageService averageService)
    {
        _averageService = averageService;
    }

    public List<double> GetListNumber(InputGroupedTable inputGroupedTable)
    {
        List<double> listNumber = new List<double>();

        foreach (var item in inputGroupedTable.ListGroupedLineTable)
        {
            for (int i = 0; i < item.Fi; i++)
            {
                listNumber.Add(item.Xi);
            }
        }

        return listNumber;
    }

    public Table GetContinuosTable(List<double> listNumber)
    {
        listNumber = listNumber.OrderBy(i => i).ToList();

        var quantity = listNumber.Count();

        var max = listNumber.Max();
        var min = listNumber.Min();

        int K = (int)Math.Round(Math.Sqrt(quantity));

        var AT = max - min;

        int C = (int)Math.Ceiling((double)AT / K);

        Classe interval = new Classe((int)min, (int)min + C);

        var table = new Table(K, AT, C);

        for (int i = 0; i < K; i++)
        {
            var group = (from j in listNumber
                         where j >= interval.Li && j < interval.Ls
                         select j).ToList();

            var quantityGroup = group.Count;

            table.AddNewLine(new Classe(interval.Li, interval.Ls), quantityGroup);

            interval.Li = interval.Ls;
            interval.Ls = interval.Ls + C;
        }

        table.CalculateTotals();

        var average = _averageService.CalculateContinuous(table);

        table.SetAverage(average);

        return table;
    }

    public Table GetContinuosTable(InputTable inputTable)
    {
        var quantity = inputTable.ListInputLineTable.Last().FAC;

        var min = inputTable.ListInputLineTable.First().Classe.Li;
        var max = inputTable.ListInputLineTable.Last().Classe.Ls;

        int K = inputTable.ListInputLineTable.Count;

        var AT = max - min;

        var classe = inputTable.ListInputLineTable.First().Classe;
        int C = classe.Ls - classe.Li;

        Classe interval = new Classe((int)min, (int)min + C);

        var table = new Table(K, AT, C);

        foreach (var item in inputTable.ListInputLineTable)
        {
            table.AddNewLine(item);
        }

        table.CalculateTotals();

        var average = _averageService.CalculateContinuous(table);

        table.SetAverage(average);

        return table;
    }
}
