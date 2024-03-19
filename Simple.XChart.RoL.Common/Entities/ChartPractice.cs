using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class ChartPractice
{
    [Key]
    public int Id { get; set; }
    [StringLength(200)]
    public string? Description { get; set; }

    public int GoalId { get; set; }
}
