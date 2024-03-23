

using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Occurences")]
public class ChartOccurence
{
    [PrimaryKey()]
    public int Id { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    public int DaysCount { get; set; } = 1;
}
