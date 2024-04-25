using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.SharedComponents.Helpers;
using Simple.XChart.SharedComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.SharedComponents.Pages;

public partial class ChartCrafter : IDisposable
{
    [Inject]
    private IRoLRepositoryHelper db { get; set; }
    [Inject]
    public NavigationManager nav { get; set; }
    [Inject]
    public StateHelper states { get; set; }

    [Parameter]
    public int? chartId { get; set; }

    public Chart activeChart { get; set; }
    public RangeEnabledObservableCollection<ChartGoalViewModel> Goals { get; set; }
    public RangeEnabledObservableCollection<ChartPracticeViewModel> Practices { get; set; }
    public ChartGoal currentGoal { get; set; }
    public ChartPractice currentPractice { get; set; }
    public string newGoal { get; set; }
    public string newPractice { get; set; }

    private int listGoalId;

    protected async override Task OnInitializedAsync()
    {
        activeChart = new Chart();
        currentGoal = new ChartGoal();
        currentPractice = new ChartPractice();

        if (chartId.HasValue && chartId > 0)
        {
            activeChart = await db.GetChart(chartId.Value);
        }

        Goals = new RangeEnabledObservableCollection<ChartGoalViewModel>();
        Goals.CollectionChanged += async (s, e) => await RefreshUI(s, e);
        await LoadGoals();

        Practices = new RangeEnabledObservableCollection<ChartPracticeViewModel>();
        Practices.CollectionChanged += async (s, e) => await RefreshUI(s, e);
        await LoadPractices();
    }

    private async Task LoadGoals()
    {
        if (!chartId.HasValue || chartId <= 0)
        {
            return;
        }

        var chartGoals = await db.GetChartGoals(chartId.Value);
        if (chartGoals is not null && chartGoals.Count() > 0)
        {
            Goals.Clear();
            Goals.InsertRange(chartGoals.Select(x => new ChartGoalViewModel { Goal = x, IsEditing = false }));
        }
    }

    private async Task LoadPractices()
    {
        if (!chartId.HasValue || chartId <= 0)
        {
            return;
        }

        var chartPractices = await db.GetChartPractices(chartId.Value);
        if (chartPractices is not null && chartPractices.Count() > 0)
        {
            Practices.Clear();
            Practices.InsertRange(chartPractices.Select(x => new ChartPracticeViewModel { Practice = x, IsEditing = false }));
        }
    }

    private void BackToMain()
    {
        if (string.IsNullOrEmpty(states.previousPage))
        {
            nav.NavigateTo("/");
            return;
        }

        nav.NavigateTo(states.previousPage);
    }

    private async Task Save()
    {
        activeChart = await db.SaveChart(activeChart);
    }

    private async Task SaveGoal()
    {
        if (chartId.HasValue)
        {
            currentGoal.ChartId = chartId.Value;
            currentGoal = await db.SaveGoal(currentGoal);

            Goals.Add(new ChartGoalViewModel { Goal = currentGoal, IsEditing = false });
        }
    }

    private async Task EditGoal(ChartGoalViewModel goal)
    {
        currentGoal = null;
        newGoal = "";
        goal.IsEditing = !goal.IsEditing;
        if (goal.IsEditing)
        {
            newGoal = goal.Goal.Description;
            currentGoal = goal.Goal;
        }
    }

    private void AddGoalPracticeToggle(ChartGoalViewModel goal)
    {
        newPractice = "";
        goal.IsAddNewPractice = !goal.IsAddNewPractice;
    }

    private async Task AddGoalPractice(ChartGoalViewModel goal)
    {
        currentPractice.GoalId = goal.Goal.Id;
        currentPractice.Description = newPractice;
        currentPractice = await db.SavePractice(currentPractice);

        goal.IsAddNewPractice = false;
        newPractice = "";

        await LoadPractices();
    }

    private async Task DeleteGoal(int id)
    {
        await db.DeleteGoal(id);
        await LoadGoals();
        await LoadPractices();
    }

    private async Task SavePractice()
    {
        currentPractice.Description = newPractice;
        currentPractice = await db.SavePractice(currentPractice);

        await LoadPractices();
    }

    private async Task EditPractice(ChartPracticeViewModel practice)
    {
        currentPractice = null;
        newPractice = "";
        practice.IsEditing = !practice.IsEditing;
        if (practice.IsEditing)
        {
            newPractice = practice.Practice.Description;
            currentPractice = practice.Practice;
        }
    }

    private async Task DeletePractice(int id)
    {
        await db.DeletePractice(id);
        await LoadPractices();
    }

    private async Task RefreshUI(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        await InvokeAsync(() => StateHasChanged());
    }

    public void Dispose()
    {
        Goals.CollectionChanged -= async (s, e) => await RefreshUI(s, e);
        Goals.Clear();
        Goals = null;

        Practices.CollectionChanged -= async (s, e) => await RefreshUI(s, e);
        Practices.Clear();
        Practices = null;
    }
}
