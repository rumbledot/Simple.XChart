using Simple.XChart.RoL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.SharedComponents.Models;

public class ChartViewModel
{
    public int ChartId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool isActive { get; set; }
    public IEnumerable<ChartGoalViewModel> Goals { get; set; }
    public IEnumerable<ChartPracticeViewModel> Practices { get; set; }
}
