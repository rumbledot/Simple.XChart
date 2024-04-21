using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Goals")]
public class ChartGoal
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }

    public int ChartId { get; set; }
}
