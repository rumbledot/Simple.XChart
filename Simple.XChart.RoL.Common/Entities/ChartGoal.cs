using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Goals")]
public class ChartGoal
{
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string Description { get; set; }

    public int ChartId { get; set; }
}
