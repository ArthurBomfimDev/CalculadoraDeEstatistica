using CalculadoraEstatisca.Arguments.Class.TableClass;

namespace CalculadoraEstatisca.Arguments.Class.Base;

public class InputGroupedValue
{
    public InputGroupedTable InputGroupedTable { get; set; }
    public bool Average { get; set; }
    public bool Median { get; set; }
    public bool Mode { get; set; }
    public bool StandardDeviation { get; set; }

    public InputGroupedValue() { }

    public InputGroupedValue(InputGroupedTable groupedTable, bool average, bool median, bool mode, bool standardDeviation)
    {
        InputGroupedTable = groupedTable;
        Average = average;
        Median = median;
        Mode = mode;
        StandardDeviation = standardDeviation;
    }
}