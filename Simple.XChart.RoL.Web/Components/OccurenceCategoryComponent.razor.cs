
using Microsoft.AspNetCore.Components;

namespace Simple.XChart.RoL.Web.Components;

public partial class OccurenceCategoryComponent
{
    [Parameter]
    public string OccurenceType { get; set; }

    protected async override Task OnInitializedAsync()
    {
        
    }
}
