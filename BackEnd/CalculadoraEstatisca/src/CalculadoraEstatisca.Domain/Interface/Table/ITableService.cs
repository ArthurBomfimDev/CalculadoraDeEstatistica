using CalculadoraEstatisca.Arguments;
using CalculadoraEstatisca.Arguments.Class;
using CalculadoraEstatisca.Arguments.Class.Table;
using CalculadoraEstatisca.Arguments.Class.TableClass;
namespace CalculadoraEstatisca.Domain.Interface;

public interface ITableService
{
    //Table GetTable(List<double> listNumber);
    Table GetContinuosTable(InputTable inputTable);
    //GroupedTable GetGroupedTable(InputGroupedTable inputGroupedTable);
    List<double> GetListNumber(InputGroupedTable inputGroupedTable);
}