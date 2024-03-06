using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Pages;

public partial class ROL_Chart
{
    [Inject]
    public RoLDatabaseHelper db { get; set; }

    public TaskPeriod ActiveTask { get; set; }

    protected async override Task OnInitializedAsync()
    {
        
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        ActiveTask = await db.GetActiveTaskPeriodAsync();
    }
}
