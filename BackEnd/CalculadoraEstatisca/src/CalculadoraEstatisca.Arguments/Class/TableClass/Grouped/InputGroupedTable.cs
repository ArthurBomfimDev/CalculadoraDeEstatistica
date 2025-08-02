namespace CalculadoraEstatisca.Arguments.Class.TableClass;

public class InputGroupedTable
{
    public List<InputGroupedLineTable> ListGroupedLineTable { get; set; }

    public InputGroupedTable() { }

    public InputGroupedTable(List<InputGroupedLineTable> listGroupedLineTable)
    {
        ListGroupedLineTable = listGroupedLineTable;
    }
}