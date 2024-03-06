using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class AppInformation
{
    [Key]
    public string InfoKey { get; set; }
    public string InfoValue { get; set; }
    public DateTime DateUpdated { get; set; }
}
