using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Web.Components;

public partial class PracticeComponent
{
    [Inject]
    private RoLDatabaseHelper db { get; set; }
    private RoLDBContext context { get => db.context; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager Navigate { get; set; }

    [CascadingParameter]
    public int ChartPeriodId { get; set; }
    [Parameter]
    public int MyPracticeId { get; set; }


    private string[] popupFlag { get; set; } = new string[3] { "", "" ,"" };
    private int[] reflectionCount { get; set; }

    private MyPractice MyPractice { get; set; }
    public string practiceTitle => MyPractice?.Description ?? string.Empty;

    private Dictionary<int, Tuple<int, DailyReflection>> DailyReflections { get; set; }
    private DailyReflection Daily;
    private DailyReflection Weekly;
    private DailyReflection Monthly;

    protected async override Task OnInitializedAsync()
    {
        MyPractice = await context.MyPractices.FirstOrDefaultAsync(x => x.Id == MyPracticeId);

        DailyReflections = await db.GetMyPracticesAsync(ChartPeriodId, MyPracticeId);
        Daily = DailyReflections.ContainsKey(1) && DailyReflections[1].Item2 != null ? DailyReflections[1].Item2 : new DailyReflection();
        Weekly = DailyReflections.ContainsKey(2) && DailyReflections[2].Item2 != null ? DailyReflections[2].Item2 : new DailyReflection();
        Monthly = DailyReflections.ContainsKey(3) && DailyReflections[3].Item2 != null ? DailyReflections[3].Item2 : new DailyReflection();

        reflectionCount = new int[3] 
        {
            DailyReflections.ContainsKey(1) && DailyReflections[1].Item1 != null ? DailyReflections[1].Item1 : 0,
            DailyReflections.ContainsKey(2) && DailyReflections[2].Item1 != null ? DailyReflections[2].Item1 : 0,
            DailyReflections.ContainsKey(3) && DailyReflections[3].Item1 != null ? DailyReflections[3].Item1 : 0,
        };
    }

    private void SetEditMode(int occurenceId)
    {
        popupFlag[occurenceId - 1] = string.IsNullOrEmpty(popupFlag[occurenceId - 1]) ? "popup" : "";
    }

    private async Task UpdateDailyPractice()
    {
        await db.SaveMyPracticeDailyReflection(ChartPeriodId, MyPracticeId, 1, Daily);

        popupFlag[0] = "";
    }

    private async Task UpdateWeeklyPractice()
    {
        await db.SaveMyPracticeDailyReflection(ChartPeriodId, MyPracticeId, 2, Weekly);

        popupFlag[1] = "";
    }

    private async Task UpdateMonthlyPractice()
    {
        await db.SaveMyPracticeDailyReflection(ChartPeriodId, MyPracticeId, 3, Monthly);

        popupFlag[2] = "";
    }

    private async Task ViewMyPracticeDetails()
    {
        Navigate.NavigateTo($"/practice/{MyPracticeId}");
    }
}