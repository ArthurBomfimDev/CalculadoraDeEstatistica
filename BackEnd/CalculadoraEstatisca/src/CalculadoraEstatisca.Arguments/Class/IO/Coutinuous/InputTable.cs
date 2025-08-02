namespace CalculadoraEstatisca.Arguments.Class.Table;

public class InputTable
{
    public List<InputLineTable> ListInputLineTable { get; set; }

    public InputTable() { }

    public InputTable(List<InputLineTable> listInputLineTable)
    {
        ListInputLineTable = listInputLineTable;
    }
}