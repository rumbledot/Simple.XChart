using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.MVC.Models.Views;

public class IndexViewModel
{
    public Chart chart { get; set; }
    public IEnumerable<ChartOccurence> occurences { get; set; }
    public IEnumerable<PracticeComponentViewModel> practices { get; set; }
    public BannerImage image { get; set; }
    public string bannerTextColor { get; set; }
}
