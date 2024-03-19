﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Helpers;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Web.Models;
using System;

namespace Simple.XChart.RoL.Web.Components;

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

    private void ToggleEditMode(PracticeActionViewModel action)
    {
        currentAction = action;

        action.inEditMode = true;
        newReflection = action.practiceAction;
    }

    private void CancelEditMode(PracticeActionViewModel action)
    {
        currentAction = null;

        action.inEditMode = false;
        newReflection = new MyAction();
    }

    private async Task UpdateAction()
    {
        await db.SavePracticeAction(newReflection);

        currentAction.inEditMode = false;
        newReflection = new MyAction();

        await InvokeAsync(() => StateHasChanged());
    }

    private async Task ViewMyPracticeDetails(int occurenceId)
    {
        Navigate.NavigateTo($"/practice/{practiceId}/{occurenceId}");
    }
}