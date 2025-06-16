using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Domain.Interface;

namespace CalculadoraEstatisca.Domain.Service;

public class StandardDeviationService : IStandardDeviationService
{
    private readonly IAverageService _averageService;

    public StandardDeviationService(IAverageService averageService)
    {
        _averageService = averageService;
    }

    public double CalculateNotGrouped(List<double> listNumber)
    {
        var quantity = listNumber.Count();

        if (quantity < 2)
            return 0;

        var valueAndFrequency = (from i in listNumber
                                 group i by i into frequency
                                 select new
                                 {
                                     Number = frequency.Key,
                                     Frequency = frequency.Count()
                                 }).ToList();

        var avarage = _averageService.CalculateNotGrouped(listNumber);

        double TotalSquareXiMinusAverageMultiplyFi = 0;

        foreach (var item in valueAndFrequency)
        {
            TotalSquareXiMinusAverageMultiplyFi += Math.Pow(item.Number - avarage, 2) * item.Frequency;
        }

        return Math.Sqrt(TotalSquareXiMinusAverageMultiplyFi / (quantity - 1)); ;
    }
    public double CalculateContinuos(Table table)
    {
        if (table.N == 0)
            return table.TotalSquareXiMinusAverageMultiplyFi;

        return Math.Sqrt(table.TotalSquareXiMinusAverageMultiplyFi / (table.N - 1));
    }

}