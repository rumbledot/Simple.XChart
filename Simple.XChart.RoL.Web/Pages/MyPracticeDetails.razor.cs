
using Dapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.JSInterop.Infrastructure;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Helpers;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Web.Helpers;
using Simple.XChart.RoL.Web.Models;
using System.Collections.ObjectModel;

namespace Simple.XChart.RoL.Web.Pages;

public partial class MyPracticeDetails
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
    public string occurenceId { get; set; }
    private ChartOccurence selectedOccurence;
    [Parameter]
    public string practiceId { get; set; }
    private PracticeComponentViewModel practiceVM;
    private ChartPractice practice => practiceVM.practice;

    private ReflectionComponentViewModel currentReflection;
    public RangeEnabledObservableCollection<ReflectionComponentViewModel> practiceActions { get; set; }
    public RangeEnabledObservableCollection<ReflectionComponentViewModel> actions { get; set; }

    public MyAction newReflection { get; set; } = new MyAction();

    protected async override Task OnInitializedAsync()
    {
        practiceActions = new RangeEnabledObservableCollection<ReflectionComponentViewModel>();
        practiceActions.CollectionChanged += async (s, e) => await RefreshUI(s, e);
        actions = new RangeEnabledObservableCollection<ReflectionComponentViewModel>();
        actions.CollectionChanged += async (s, e) => await RefreshUI(s, e);

        await LoadComponent();
    }

    private async Task RefreshUI(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        await InvokeAsync(() => StateHasChanged());
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

    private async Task AddNewReflection()
    {
        newReflection.OccurenceId = selectedOccurence.Id;
        newReflection.PracticeId = practiceVM.practice.Id;
        await db.SavePracticeAction(newReflection);

        var reflectionVM = new ReflectionComponentViewModel();
        reflectionVM.reflection = newReflection;

        actions.Add(reflectionVM);
    }

    private void BackToMain()
    {
        Navigate.NavigateTo("/");
    }

    private async Task SaveReflection()
    {
        await db.SavePracticeAction(currentReflection.reflection);
        currentReflection = new ReflectionComponentViewModel();
        currentReflection.reflection = new MyAction();
        currentReflection.inEditMode = false;
    }

    private void EditReflection(ReflectionComponentViewModel reflectionVM)
    {
        reflectionVM.inEditMode = true;
        newReflection = reflectionVM.reflection;
        currentReflection = reflectionVM;
    }

    private void CancelEditReflection()
    {
        currentReflection.inEditMode = false;
        currentReflection = null;
    }

    private void ClearNewReflection()
    {
        newReflection = new MyAction();
    }

    private async Task DeleteReflection(ReflectionComponentViewModel reflectionVM)
    {
        await db.DeleteAction(reflectionVM.reflection.Id);
        actions.Remove(reflectionVM);
    }

    private async Task LoadComponent()
    {
        practiceVM = new PracticeComponentViewModel();
        if (int.TryParse(practiceId, out int id))
        {
            var practice = await db.GetPractice(id);
            practiceVM.practice = practice;
        }

        var reflections = await db.GetPracticeActions(id);
        practiceVM.reflections = reflections.Select(x => new ReflectionComponentViewModel { reflection = x });

        if (int.TryParse(occurenceId, out id))
        {
            var occurences = await LoadOccurenceCached();

            selectedOccurence = occurences.FirstOrDefault(x => x.Id == id);
            actions.InsertRange(practiceVM.reflections.Where(x => x.reflection.OccurenceId == id));
        }
    }
}
