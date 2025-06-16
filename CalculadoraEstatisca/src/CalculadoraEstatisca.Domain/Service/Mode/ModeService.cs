using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class.TableClass;
using CalculadoraEstatisca.Domain.Interface;

namespace CalculadoraEstatisca.Domain.Service;

public class ModeService : IModeService
{
    public double? CalculateContinuous(Table table)
    {
        var C = table.C;
        var K = table.K;

        var most = table.GetMost();

        if (most == null)
            return null;

        int indexMode = table.ListLineTable.IndexOf(most);

        int liMode = most.Classe.Li;
        int fiMode = most.Fi;
        int fiPreviousMode = indexMode != 0 ? table.ListLineTable[indexMode - 1].Fi : 0;
        int fiPosteriorMode = indexMode != K - 1 ? table.ListLineTable[indexMode + 1].Fi : 0;

        var delta1 = fiMode - fiPreviousMode;
        var delta2 = fiMode - fiPosteriorMode;

        double mode = (delta1 + delta2) != 0 ? liMode + ((double)delta1 / (delta1 + delta2)) * C : double.NaN;

        return mode;
    }

    public List<double?> CalculateGrouped(InputGroupedTable groupedTable)
    {
        var listLine = groupedTable.ListGroupedLineTable.OrderByDescending(i => i.Fi).ToList(); ;

        var most = listLine.Max(i => i.Fi);

        if (listLine.First().Fi == listLine.Last().Fi)
            return null;

        return (from i in groupedTable.ListGroupedLineTable
                    where i.Fi == most
                    select (double?)i.Xi).ToList();
    }

    public List<double>? CalculateNotGrouped(List<double> listNumber)
    {
        var listFrequency = (from i in listNumber
                             group i by i into frequency
                             select new
                             {
                                 Number = frequency.Key,
                                 Frequency = frequency.Count()
                             }).ToList();

        int maxFrequency = listFrequency.Max(x => x.Frequency);
        bool equalFrequency = listFrequency.All(x => x.Frequency == maxFrequency);

        if (maxFrequency == 1 || equalFrequency)
            return null;

        var mode = (from i in listFrequency
                    where i.Frequency == maxFrequency
                    select i.Number).ToList();

        return mode;
    }
}
