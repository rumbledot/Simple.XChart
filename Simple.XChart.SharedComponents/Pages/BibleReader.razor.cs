using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.SharedComponents.Pages;

public partial class BibleReader
{
    [Inject]
    private IRoLRepositoryHelper db { get; set; }
    [Inject]
    public NavigationManager Navigate { get; set; }

    protected async override Task OnInitializedAsync()
    {
        
    }
}