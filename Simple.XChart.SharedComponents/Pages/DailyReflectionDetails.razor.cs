using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.SharedComponents.Pages;

public partial class DailyReflectionDetails
{
    [Inject]
    private IRoLRepositoryHelper db { get; set; }
    [Inject]
    public NavigationManager Navigate { get; set; }

    [CascadingParameter]
    public int chartId { get; set; }
    [Parameter]
    public string occurenceId { get; set; }
    public int occurenceIdInt { get; set; } = 0;
    private ChartOccurence selectedOccurence;
    [Parameter]
    public string practiceId { get; set; }
    public int practiceIdInt { get; set; } = 0;
    private ChartPractice practice;
    [Parameter]
    public string reflectionId { get; set; }
    public int reflectionIdInt { get; set; } = 0;
    private MyAction currentReflection;

    public async override Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        currentReflection = new MyAction();
        int id = 0;
        if(int.TryParse(practiceId,out id)) 
        {
            practiceIdInt = id;
            currentReflection.PracticeId = practiceIdInt;
            practice = await db.GetPractice(practiceIdInt);
        }

        if(int.TryParse(occurenceId, out id)) 
        {
            occurenceIdInt = id;
            currentReflection.OccurenceId = occurenceIdInt;
        }


        if (!string.IsNullOrEmpty(reflectionId) && int.TryParse(reflectionId, out id)) 
        {
            reflectionIdInt = id;
            if (id > 0)
            {
                currentReflection = await db.GetAction(reflectionIdInt);
            }
        }
    }

    protected async override Task OnInitializedAsync()
    {
        
    }

    private async Task Save()
    {
        currentReflection.OccurenceId = occurenceIdInt;
        currentReflection.PracticeId = practiceIdInt;
        await db.SavePracticeAction(currentReflection);
    }

    private async Task SaveAndBack()
    {
        currentReflection.OccurenceId = occurenceIdInt;
        currentReflection.PracticeId = practiceIdInt;
        await db.SavePracticeAction(currentReflection);

        BackTo();
    }

    private void ClearNewReflection()
    {
        currentReflection = new MyAction();
        currentReflection.OccurenceId = occurenceIdInt;
        currentReflection.PracticeId = practiceIdInt;
    }

    private void BackTo()
    {
        Navigate.NavigateTo($"/practice/{practiceId}/{occurenceId}");
    }
}
