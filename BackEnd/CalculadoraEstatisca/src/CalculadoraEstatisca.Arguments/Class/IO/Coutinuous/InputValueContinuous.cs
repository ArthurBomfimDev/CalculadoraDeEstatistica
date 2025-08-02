using CalculadoraEstatisca.Arguments.Class.Table;

namespace CalculadoraEstatisca.Arguments.Class.Base;

public class InputValueContinuous
{
    public InputTable inputTable { get; set; }
    public bool Average { get; set; }
    public bool Median { get; set; }
    public bool Mode { get; set; }
    public bool StandardDeviation { get; set; }

    public InputValueContinuous() { }

    public InputValueContinuous(InputTable inputTable, bool average, bool median, bool mode, bool standardDeviation)
    {
        this.inputTable = inputTable;
        Average = average;
        Median = median;
        Mode = mode;
        StandardDeviation = standardDeviation;
    }
}
