namespace CalculadoraEstatisca.Arguments.Class;

public class GroupedTable
{
    public List<GroupedLineTable>? GroupedLineTable { get; set; }

    public GroupedTable() { }

    public GroupedTable(List<GroupedLineTable>? groupedLineTable)
    {
        GroupedLineTable = groupedLineTable;
    }


}