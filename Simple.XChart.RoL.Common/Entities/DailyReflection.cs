using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class DailyReflection
{
    public int Id { get; set; }
    public DateTime DateUpdated { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public string Description { get; set; }
}
