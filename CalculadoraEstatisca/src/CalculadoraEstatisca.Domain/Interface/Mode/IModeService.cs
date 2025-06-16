using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class.TableClass;

namespace CalculadoraEstatisca.Domain.Interface;

public interface IModeService
{
    List<double>? CalculateNotGrouped(List<double> listNumber);
    public List<double?> CalculateGrouped(InputGroupedTable groupedTable);
    double? CalculateContinuous(Table table);

}
