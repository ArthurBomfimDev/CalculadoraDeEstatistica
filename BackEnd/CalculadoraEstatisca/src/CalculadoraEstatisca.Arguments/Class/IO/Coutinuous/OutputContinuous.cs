namespace CalculadoraEstatisca.Arguments.Class;

public class OutputContinuous
{
    public CalculadoraEstatisca.Arguments.Table? Table { get; set; }
    public double? Median { get; set; }
    public double? StandardDeviation { get; set; }
    public double? Average { get; set; }
    public double? Mode { get; set; }

    public OutputContinuous() { }

    public OutputContinuous(CalculadoraEstatisca.Arguments.Table? table, double? median, double? standardDeviation, double? average, double? mode)
    {
        Table = table;
        Median = median;
        StandardDeviation = standardDeviation;
        Average = average;
        Mode = mode;
    }
}