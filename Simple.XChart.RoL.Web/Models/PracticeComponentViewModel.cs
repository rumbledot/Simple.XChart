using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Models;

public class PracticeComponentViewModel
{
    public ChartPractice practice { get; set; }
    public IEnumerable<MyAction> practiceActions { get; set; }
    public IEnumerable<ReflectionComponentViewModel> reflections { get; set; }
}
