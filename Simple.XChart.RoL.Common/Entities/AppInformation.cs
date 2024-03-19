using System.ComponentModel.DataAnnotations;

namespace Simple.XChart.RoL.Common.Entities;

public class AppInformation
{
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Code { get; set; }
    [StringLength(200)]
    public string Information { get; set; }
    public DateTime DateUpdated { get; set; }
}
