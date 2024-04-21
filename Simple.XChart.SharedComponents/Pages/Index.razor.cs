using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.SharedComponents.Helpers;

namespace Simple.XChart.SharedComponents.Pages;

public partial class Index
{
    [Inject]
    private IRoLRepositoryHelper db { get; set; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager nav { get; set; }
    [Inject]
    public StateHelper states { get; set; }

    [Parameter]
    public int chartId { get; set; }

    public int activeChartId { get => chart?.Id ?? 1; }
    public Chart chart { get; set; }

    protected async override Task OnInitializedAsync()
    {
        states.previousPage = "/";
        chart = await db.GetChart(null);

        if (chart is null)
        {
            nav.NavigateTo("editChart");
        }
    }
}
