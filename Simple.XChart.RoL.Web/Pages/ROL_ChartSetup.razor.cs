using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Pages;

public partial class ROL_ChartSetup
{
    [Inject]
    private RoLDatabaseHelper db { get; set; }
    private RoLDBContext context { get => db.context; }
    [Inject]
    public NavigationManager nav { get; set; }

    public ChartPeriod TaskPeriod { get; set; } = new ChartPeriod();
    public IEnumerable<MyGoal> Goals { get; set; } = Enumerable.Empty<MyGoal>();
    public IEnumerable<MyPractice> Practices { get; set; } = Enumerable.Empty<MyPractice>();

    protected override void OnInitialized()
    {
        TaskPeriod = new ChartPeriod();
        TaskPeriod.DateStart = DateTime.Now;
        TaskPeriod.DateEnd = DateTime.Now.AddDays(30);
    }

    private void CreateChart()
    {

    }
}