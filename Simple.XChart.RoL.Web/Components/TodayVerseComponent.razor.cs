using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
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
    private TodayVerseResponse todaysVerse { get; set; }

    protected override void OnInitialized()
    {
        todaysDate = DateTime.Now;
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        var updatedTodayVerse = db.GetTodayVerse();

        if (updatedTodayVerse == null)
        {
            todaysVerse = await verseService.GetTodayVerse();
            db.UpdateTodayVerse(todaysVerse.verse);
        }
        else
        {
            var verseParts = updatedTodayVerse.InfoValue.Split(';');
            todaysVerse = new TodayVerseResponse
            {
                verse = new TodayVerse
                {
                    details = new VerseDetails
                    {
                        text = verseParts[0],
                        reference = verseParts[1],
                        version = verseParts[2]
                    }
                }
            };
        }

        await InvokeAsync(() => StateHasChanged());
    }
}