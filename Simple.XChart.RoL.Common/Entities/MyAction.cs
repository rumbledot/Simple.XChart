using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

public class MyAction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    public int PracticeId { get; set; }
    public int OccurenceId { get; set; }
}
