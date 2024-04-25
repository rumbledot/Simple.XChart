using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.SharedComponents.Helpers;
using Simple.XChart.SharedComponents.Models;

namespace Simple.XChart.SharedComponents.Pages;

public partial class ChartList : IDisposable
{
    [Inject]
    private IRoLRepositoryHelper db { get; set; }
    [Inject]
    public NavigationManager nav { get; set; }
    [Inject]
    public StateHelper states { get; set; }

    public string ErrorMsg { get; set; }

    public RangeEnabledObservableCollection<Chart> charts { get; set; }

    protected async override Task OnInitializedAsync()
    {
        states.previousPage = "/charts";

        charts = new RangeEnabledObservableCollection<Chart>();
        charts.CollectionChanged += async (s, e) => await RefreshUI(s, e);

        await LoadCharts();
    }

    private void BackToMain()
    {
        nav.NavigateTo("/");
    }

    private async Task LoadCharts()
    {
        charts.Clear();
        var existingCharts = await db.GetAllCharts();
        if (charts is null)
        {
            charts = new RangeEnabledObservableCollection<Chart>();
        }
        charts.InsertRange(existingCharts);
    }

    private void CraftChart(int id)
    {
        if(id == 0) 
        {
            nav.NavigateTo("/editChart");
        }

        nav.NavigateTo($"/editChart/{id}");
    }

    private async void ActivateChart(int id) 
    {
        try
        {
            await db.SetActiveChart(id);
            await LoadCharts();
        }
        catch (Exception ex)
        {
            ErrorMsg = ex.Message;
        }
    }

    private async void DeleteChart(int id) 
    {
        await db.DeleteChart(id);
        await LoadCharts();
    }

    private async Task RefreshUI(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        await InvokeAsync(() => StateHasChanged());
    }

    public void Dispose()
    {
        charts.CollectionChanged -= async (s, e) => await RefreshUI(s, e);
        charts.Clear();
        charts = null;
    }
}