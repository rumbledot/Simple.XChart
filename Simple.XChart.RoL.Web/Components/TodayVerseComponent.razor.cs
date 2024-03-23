using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Components;

public partial class TodayVerseComponent
{
    [Inject]
    private RoLRepositoryHelper db { get; set; }
    [Inject]
    private VerseService verseService { get; set; }

    private DateTime todaysDate { get; set; }
    private AttachVerse todaysVerse { get; set; }

    protected override void OnInitialized()
    {
        todaysDate = DateTime.Now;
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        var todaysVerse = await db.TryGetTodayVerse();
    }
}