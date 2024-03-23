using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.SharedComponents.Models;

public class PracticeComponentViewModel
{
    public ChartPractice practice { get; set; }
    public IEnumerable<MyAction> practiceActions { get; set; }
    public IEnumerable<ReflectionComponentViewModel> reflections { get; set; }
}
