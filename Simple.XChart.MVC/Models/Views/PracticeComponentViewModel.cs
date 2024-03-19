using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.MVC.Models.Views;

public class PracticeComponentViewModel
{
    public ChartPractice practice { get; set; }
    public IEnumerable<MyAction> actions { get; set; }
}
