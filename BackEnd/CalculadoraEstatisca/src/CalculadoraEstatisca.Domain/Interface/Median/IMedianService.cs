using CalculadoraEstatisca.Arguments;

namespace CalculadoraEstatisca.Domain;

public interface IMedianService
{
    double CalculateNotGrouped(List<double> listNumber);
    double CalculateContinuos(Table table);
}