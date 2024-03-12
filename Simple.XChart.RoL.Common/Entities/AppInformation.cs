using Microsoft.EntityFrameworkCore;
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
    [StringLength(200)]
    public string InfoKey { get; set; }
    [StringLength(200)]
    public string InfoValue { get; set; }
    public DateTime DateUpdated { get; set; }
}
