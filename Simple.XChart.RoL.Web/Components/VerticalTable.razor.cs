using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Helpers;

namespace Simple.XChart.RoL.Web.Components;

public partial class VerticalTable
{
    [Inject]
    public RoLRepositoryHelper db { get; set; }

    [CascadingParameter]
    public int chartId { get; set; }

    private IEnumerable<ChartOccurence> occurences { get; set; }
    private IEnumerable<ChartPractice> practices { get; set; }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            occurences = await db.GetOccurences();
            practices = await db.GetChartPractices(chartId);

            await InvokeAsync(() => StateHasChanged());
        }
    }
}
