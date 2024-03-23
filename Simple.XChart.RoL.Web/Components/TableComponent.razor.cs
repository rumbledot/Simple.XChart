using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Components;

public partial class TableComponent
{
    [Inject]
    public RoLRepositoryHelper db { get; set; }

    [CascadingParameter]
    public int chartId { get; set; }

    private IEnumerable<ChartOccurence> occurences { get; set; }
    private IEnumerable<ChartPractice> practices { get; set; }

    protected async override Task OnInitializedAsync()
    {
        occurences = await db.GetOccurences();
        practices = await db.GetChartPractices(chartId);
    }
}
