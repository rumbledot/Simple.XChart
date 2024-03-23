using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Pages;

public partial class Index
{
    [Inject]
    private RoLRepositoryHelper db { get; set; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager nav { get; set; }

    public int chartId { get => chart?.Id ?? 1; }
    public Chart chart { get; set; }

    protected async override Task OnInitializedAsync()
    {
        chart = await db.GetChart(1);
    }
}
