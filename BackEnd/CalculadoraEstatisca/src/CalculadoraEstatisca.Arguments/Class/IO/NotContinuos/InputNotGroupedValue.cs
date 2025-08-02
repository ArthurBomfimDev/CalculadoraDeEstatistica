namespace CalculadoraEstatisca.Arguments.Class.Base;

public class InputNotGroupedValue
{
    public List<double> ListNumber { get; set; }
    public bool Average { get; set; }
    public bool Median { get; set; }
    public bool Mode { get; set; }
    public bool StandardDeviation { get; set; }

    public InputNotGroupedValue() { }

    public InputNotGroupedValue(List<double> listNumber, bool average, bool median, bool mode, bool standardDeviationService)
    {
        ListNumber = listNumber;
        Average = average;
        Median = median;
        Mode = mode;
        StandardDeviation = standardDeviationService;
    }
}