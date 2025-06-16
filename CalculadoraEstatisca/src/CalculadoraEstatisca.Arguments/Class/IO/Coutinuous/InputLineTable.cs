using CalculadoraEstatisca.Arguments.Class.Base;

namespace CalculadoraEstatisca.Arguments.Class.Table;

public class InputLineTable
{
    public Classe Classe { get; set; }
    public int Fi { get; set; } // Frequência
    public double Xi { get; set; } // Ponto médio
    public int FAC { get; set; }  // Frequência acumulada

    public InputLineTable() { }

    public InputLineTable(Classe classe, int fi, double xi, int fAC)
    {
        Classe = classe;
        Fi = fi;
        Xi = xi;
        FAC = fAC;
    }

}