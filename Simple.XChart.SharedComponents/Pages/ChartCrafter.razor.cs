using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.SharedComponents.Helpers;
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
    public RangeEnabledObservableCollection<ChartGoal> Goals { get; set; }
    public RangeEnabledObservableCollection<ChartPractice> Practices { get; set; }
    public ChartGoal currentGoal { get; set; }
    public ChartPractice currentPractice { get; set; }

    private int listGoalId;

    protected async override Task OnInitializedAsync()
    {
        activeChart = new Chart();
        currentGoal = new ChartGoal();
        currentPractice = new ChartPractice();
        Goals = new RangeEnabledObservableCollection<ChartGoal>();
        Goals.CollectionChanged += async (s, e) => await RefreshUI(s, e);

        Practices = new RangeEnabledObservableCollection<ChartPractice>();
        Practices.CollectionChanged += async (s, e) => await RefreshUI(s, e);

        if (chartId.HasValue && chartId > 0)
        {
            activeChart = await db.GetChart(chartId.Value);

            var chartGoals = await db.GetChartGoals(chartId.Value);
            if (chartGoals is not null && chartGoals.Count() > 0)
            {
                Goals.InsertRange(chartGoals);
            }

            var chartPractices = await db.GetChartPractices(chartId.Value);
            if (chartPractices is not null && chartPractices.Count() > 0)
            {
                Practices.InsertRange(chartPractices);
            }
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

            Goals.Add(currentGoal);
        }
    }

    private async Task EditGoal(int id)
    {
        currentGoal = await db.GetGoal(id);
        Practices.Clear();
        var goalPractices = await db.GetGoalPractices(id);
        Practices.InsertRange(goalPractices);
    }

    private async Task DeleteGoal(int id)
    {
        await db.DeleteGoal(id);
    }

    private async Task SavePractice()
    {
        if (currentGoal.Id > 0)
        {
            currentPractice.GoalId = currentGoal.Id;
            currentPractice = await db.SavePractice(currentPractice);

            Practices.Add(currentPractice);
        }
    }

    private async Task EditPractice(int id)
    {
        currentPractice = await db.GetPractice(id);
    }

    private async Task DeletePractice(int id)
    {
        await db.DeletePractice(id);
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
