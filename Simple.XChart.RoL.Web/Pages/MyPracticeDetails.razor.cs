
using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Pages;

public partial class MyPracticeDetails
{
    [Inject]
    private RoLDatabaseHelper db { get; set; }
    private RoLDBContext context { get => db.context; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager Navigate { get; set; }

    [Parameter]
    public int MyPracticeId { get; set; }

    private List<string> popup;

    public IEnumerable<DailyReflection> Reflections { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Reflections = await db.GetMyPracticeDailyReflections(MyPracticeId);
        popup = new List<string>();
    }
}
