using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Components;

public partial class DailyReflectionComponent
{
    [Parameter]
    public int dailyReflectionId { get; set; }
    private DailyReflection dailyReflection { get; set; }

    [Inject]
    public RoLDatabaseHelper db { get; set; }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
    }
}
