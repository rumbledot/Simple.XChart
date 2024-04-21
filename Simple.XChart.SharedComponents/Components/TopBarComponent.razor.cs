using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.SharedComponents.Components;

public partial class TopBarComponent
{
    [Inject]
    public NavigationManager nav { get; set; }

    private bool isOpen { get; set; } = false;
    private string toggleMenuIcon => isOpen ? "fa-solid fa-xmark" : "fa-solid fa-bars";
    public string containerClass => isOpen ? "top-bar-menu-container" : "top-bar-menu-container-hide";

    private void toggleMenu()
    {
        isOpen = !isOpen;
    }

    private void OpenChart()
    {
        toggleMenu();
        nav.NavigateTo("/");
    }

    private void OpenChartCrafter()
    {
        toggleMenu();
        nav.NavigateTo("/editChart");
    }

    private void OpenCharts()
    {
        toggleMenu();
        nav.NavigateTo("/charts");
    }

    private void OpenAbout()
    {
        toggleMenu();
        nav.NavigateTo("/about");
    }

    private void OpenRoL()
    {
        toggleMenu();
        var uri = new Uri("https://ruleoflife.com/the-invitation/");
        nav.NavigateTo("https://ruleoflife.com/the-invitation/");
    }

    private void OpenPracticingTheWay()
    {
        toggleMenu();
        var uri = new Uri("https://practicingthewayarchives.org/unhurrying-with-a-rule-of-life/workbook#:~:text=A%20rule%20of%20life%20is,our%20deepest%20passions%20and%20priorities.");
        nav.NavigateTo("https://practicingthewayarchives.org/unhurrying-with-a-rule-of-life/workbook#:~:text=A%20rule%20of%20life%20is,our%20deepest%20passions%20and%20priorities.");
    }
}
