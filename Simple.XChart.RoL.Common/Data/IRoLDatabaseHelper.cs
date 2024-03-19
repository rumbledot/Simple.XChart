using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Data;

public interface IRoLDatabaseHelper
{
    Task CreateChartPeriods(Chart taskPeriod);
    Task UpdateChartPeriod(Chart taskPeriod);
    Task<IEnumerable<Chart>> GetChartPeriods();
    Task<Chart> GetCharteriodAsync(int id);
    Task<Chart> GetActiveChartPeriodAsync();

    Task CreateMyGoal(ChartGoal goal);
    Task UpdateMyGoal(ChartGoal goal);
    IEnumerable<ChartGoal> GetChartPeriodMyGoals(int taskId);
    Task<ChartGoal> GetMyGoalAsync(int id);
    Task DeleteMyGoal(int id);
    Task DeleteMyGoal(ChartGoal goal);

    Task CreateMyPractice(ChartPractice myPractice);
    Task UpdateMyPracticeAsync(ChartPractice myPractice);
    IEnumerable<ChartPractice> GetChartPeriodMyPracticesAsync(int taskId);
    Task<ChartPractice> GetMyPracticeAsync(int practiceId);
    Task DeleteMyPractice(int practiceId);
    Task DeleteMyPractice(ChartPractice myPractice);

    Task CreateMyActionAsync(MyAction action);
    Task UpdateMyActionAsync(MyAction action);
    IEnumerable<MyAction> GetChartPeriodMyActions(int taskId);
    Task<MyAction> GetMyActionAsync(int actionId);
    Task DeleteMyAction(int id);
    Task DeleteMyAction(MyAction action);

    Task<AttachVerse> GetTodayVerseAsync();
    Task UpdateTodayVerseAsync(TodayVerse verse);
    Task<IEnumerable<AppInformation>> GetAppInformation(string key);
}
