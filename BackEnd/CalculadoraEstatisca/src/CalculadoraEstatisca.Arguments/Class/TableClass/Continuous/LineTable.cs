using CalculadoraEstatisca.Arguments.Class.Base;

namespace CalculadoraEstatisca.Arguments;

public class LineTable
{
    public Classe Classe { get; set; } // (limiteInferior, limiteSuperior) 
    public int Fi { get; set; } // Frequência
    public double Xi { get; set; } // Ponto médio
    public double XiMultiplyFi { get; set; } // fᵢ * xᵢ
    public int FAC { get; set; }  // Frequência acumulada
    public double ModuleXiMinusAverageMultiplyFi { get; set; } // Modulo da diferença entre Xi e Média vezes Frequencia
    public double SquareXiMinusAverageMultiplyFi { get; set; } // Modulo da diferença ao quadrado entre Xi e Média vezes Frequencia

    public LineTable() { }

    public LineTable(Classe classe, int fi, double xi, int fAC)
    {
        Classe = classe;
        Fi = fi;
        Xi = xi;
        XiMultiplyFi = Fi * Xi;
        FAC = fAC;
    }

    public bool AddAverage(double average)
    {
        ModuleXiMinusAverageMultiplyFi = Math.Round((Math.Abs(Xi - average) * Fi), 2);
        SquareXiMinusAverageMultiplyFi = Math.Round((Math.Pow(Math.Abs(Xi - average), 2) * Fi), 2);
        return true;
    }
}