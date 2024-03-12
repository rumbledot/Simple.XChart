using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Components;

public partial class VerticalTable
{
    [Inject]
    public RoLDatabaseHelper dbHelper { get; set; }
    private RoLDBContext context { get => dbHelper.context; }

    [CascadingParameter]
    public int ChartPeriodId { get; set; }

    private IEnumerable<ChartOccurence> Occurences { get; set; }
    private IEnumerable<MyPractice> MyPractices { get; set; }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Occurences = await context.Occurences
                .AsNoTracking()
                .ToListAsync();

            MyPractices = await context.MyPractices
                .AsNoTracking()
                .ToListAsync();

            await InvokeAsync(() => StateHasChanged());
        }
    }
}
