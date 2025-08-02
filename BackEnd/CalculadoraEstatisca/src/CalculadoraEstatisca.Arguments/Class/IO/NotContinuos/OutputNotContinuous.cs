namespace CalculadoraEstatisca.Arguments.Class.Base;

public class OutputNotContinuous
{
    public double? Average { get; set; }
    public double? StandardDeviation { get; set; }
    public double? Median { get; set; }
    public List<double>? Mode { get; set; }

    public OutputNotContinuous() { }

    public OutputNotContinuous(double? average, double? median, List<double>? mode)
    {
        Average = average;
        Median = median;
        Mode = mode;
    }
}
