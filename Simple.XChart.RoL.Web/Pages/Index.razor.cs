using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Pages;

public partial class Index
{
    [Inject]
    private RoLDatabaseHelper db { get; set; }
    private RoLDBContext context { get => db.context; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager nav { get; set; }

    private IEnumerable<TobeGoal> goals { get; set; }
    private int activeGoal { get; set; }
    private IEnumerable<MyPractice> practices { get; set; }
    private int activePractice { get; set; }
    private IEnumerable<MyAction> myActions { get; set; }
    private DateTime todaysDate { get; set; }
    private TodayVerseResponse todaysVerse { get; set; }

    protected async override Task OnInitializedAsync()
    {
        todaysDate = DateTime.Now;
    }

    private void SetupChart()
    {
        nav.NavigateTo("/rol");
    }
}
