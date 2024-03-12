using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class ChartOccurence
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    public int DaysCount { get; set; }
}
