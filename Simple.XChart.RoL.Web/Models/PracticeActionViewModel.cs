using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Web.Models;

public class PracticeActionViewModel
{
    public MyAction practiceAction { get; set; }
    public ChartOccurence occurence { get; set; }
    public bool inEditMode { get; set; } = false;
    public string popUpFlag { get => inEditMode ? "popup" : ""; }
    public int reflectionCount { get; set; } = 0;
}
