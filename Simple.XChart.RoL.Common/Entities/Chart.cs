using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Charts")]
public class Chart
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
