using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Occurences")]
public class ChartOccurence
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Description { get; set; }
    public int DaysCount { get; set; } = 1;

    public int ChartId { get; set; }
}
