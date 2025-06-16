using CalculadoraEstatisca.Arguments;

namespace CalculadoraEstatisca.Domain.Interface;

public interface IStandardDeviationService
{
    double CalculateNotGrouped(List<double> listNumber);
    double CalculateContinuos(Table table);
}