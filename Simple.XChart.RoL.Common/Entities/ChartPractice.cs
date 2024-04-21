using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

public class ChartPractice
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Text { get; set; }
    public string? Description { get; set; }

    public int GoalId { get; set; }
}
