using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class ChartPeriodMap
{
    public int ChartPeriodId { get; set; }
    public int MyPracticeId { get; set; }
    public int OccurenceId { get; set; }
    public int DailyReflectionId { get; set; }
}
