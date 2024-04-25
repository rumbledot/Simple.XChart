using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.SharedComponents.Models;

public class ChartGoalViewModel
{
    public bool IsEditing { get; set; } = false;
    public bool IsAddNewPractice { get; set; } = false;
    public ChartGoal Goal { get; set; }
}