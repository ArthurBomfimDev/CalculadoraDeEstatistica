using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class.TableClass;

namespace CalculadoraEstatisca.Domain;

public class MedianService : IMedianService
{
    #region NotGrouped
    public double CalculateNotGrouped(List<double> listNumber)
    {
        if (listNumber.Count == 0 || listNumber == null)
            throw new ArgumentException("A lista não pode estar vazia");

        var quantity = listNumber.Count();

        int mid = quantity / 2;

        return quantity % 2 == 0 ? (listNumber[mid] + listNumber[mid - 1]) / 2 : listNumber[mid];
    }
    #endregion

    #region  Grouped
    //public double CalculateGrouped(GroupedTable groupedTable)
    //{
    //    var quantity = groupedTable.ListGroupedLineTable.Last().FAC;

    //    var mid = quantity / 2;
        
    //}
    #endregion

    #region Continuos
    public double CalculateContinuos(Table table)
    {
        var quantity = table.N;
        var C = table.C;
        var K = table.K;

        var mid = table.GetMid();
        var most = table.GetMost();
        most = most == null ? table.ListLineTable.OrderByDescending(i => i.Fi).First() : most;

        int indexMedian = table.ListLineTable.IndexOf(mid);
        int indexMode = table.ListLineTable.IndexOf(most);

        int li = mid.Classe.Li;
        int faca = indexMedian != 0 ? table.ListLineTable[indexMedian - 1].FAC : 0;
        int Fme = mid.Fi;

        double median = Fme != 0 ? li + ((((double)quantity / 2) - faca) / Fme) * C : double.NaN;

        int liMode = most.Classe.Li;
        int fiMode = most.Fi;
        int fiPreviousMode = indexMode != 0 ? table.ListLineTable[indexMode - 1].Fi : 0;
        int fiPosteriorMode = indexMode != K - 1 ? table.ListLineTable[indexMode + 1].Fi : 0;

        return median;
    }
    #endregion
}