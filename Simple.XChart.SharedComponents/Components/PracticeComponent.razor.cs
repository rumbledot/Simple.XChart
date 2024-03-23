using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.SharedComponents.Models;

namespace Simple.XChart.SharedComponents.Components;

public partial class PracticeComponent
{
    [Inject]
    private RoLRepositoryHelper db { get; set; }
    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public NavigationManager Navigate { get; set; }
    [Inject]
    public IMemoryCache cache { get; set; }

    [CascadingParameter]
    public int chartId { get; set; }
    [Parameter]
    public int practiceId { get; set; }

    private ChartPractice myPractice { get; set; }    
    public string practiceTitle => myPractice?.Description ?? string.Empty;

    private IEnumerable<PracticeActionViewModel> practiceActions { get; set; }
    private MyAction newReflection { get; set; }
    private PracticeActionViewModel currentAction { get; set; }

    protected async override Task OnInitializedAsync()
    {
        myPractice = await db.GetPractice(practiceId);
        var occurences = await LoadOccurenceCached();
        var actions = await db.GetPracticeFirstAction(practiceId);
        List<PracticeActionViewModel> practiceActions = new List<PracticeActionViewModel>();
        PracticeActionViewModel action;
        foreach (var occurence in occurences)
        {
            action = new PracticeActionViewModel();
            action.occurence = occurence;
            action.practiceAction = actions.FirstOrDefault(x => x.OccurenceId == occurence.Id) ?? new MyAction { OccurenceId = occurence.Id, PracticeId = practiceId, Id = 0 };

            practiceActions.Add(action);
        }

        this.practiceActions = practiceActions;
    }

    private async Task<IEnumerable<ChartOccurence>> LoadOccurenceCached()
    {
        if (cache.Get("occurences") == null)
        {
            var occurences = await db.GetOccurences();
            cache.Set("occurence", occurences);
        }

        return cache.Get<IEnumerable<ChartOccurence>>("occurence");
    }

    private async Task ViewMyPracticeDetails(int occurenceId)
    {
        Navigate.NavigateTo($"/practice/{practiceId}/{occurenceId}");
    }
}