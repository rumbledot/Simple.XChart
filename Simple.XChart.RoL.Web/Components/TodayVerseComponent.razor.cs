using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Components;

public partial class TodayVerseComponent
{
    [Inject]
    private RoLDatabaseHelper db { get; set; }
    private RoLDBContext context { get => db.context; }
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
        var updatedTodayVerse = await db.GetTodayVerseAsync();

        if (updatedTodayVerse == null)
        {
            var todaysVerseResponse = await verseService.GetTodayVerse();
            await db.UpdateTodayVerseAsync(todaysVerseResponse.verse);

            todaysVerse = new AttachVerse()
            {
                Text = todaysVerseResponse.verse.details.text,
                BibleId = todaysVerseResponse.verse.details.version,
                VerseId = todaysVerseResponse.verse.details.reference
            };
        }
        else
        {
            todaysVerse = updatedTodayVerse;
        }

        await InvokeAsync(() => StateHasChanged());
    }
}