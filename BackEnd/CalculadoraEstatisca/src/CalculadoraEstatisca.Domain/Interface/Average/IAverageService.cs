using CalculadoraEstatisca.Arguments;

namespace CalculadoraEstatisca.Domain.Interface;

public interface IAverageService
{
    double CalculateNotGrouped(List<double> listNumber);
    double CalculateContinuous(Table table);
}