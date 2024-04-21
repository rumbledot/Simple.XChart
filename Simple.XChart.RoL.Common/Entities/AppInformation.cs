using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

public class AppInformation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Code { get; set; }
    public string Information { get; set; }
    public DateTime DateUpdated { get; set; }
}
