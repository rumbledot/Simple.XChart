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
    Task CreateChartPeriods(ChartPeriod taskPeriod);
    Task UpdateChartPeriod(ChartPeriod taskPeriod);
    Task<IEnumerable<ChartPeriod>> GetChartPeriods();
    Task<ChartPeriod> GetCharteriodAsync(int id);
    Task<ChartPeriod> GetActiveChartPeriodAsync();

    Task CreateMyGoal(MyGoal goal);
    Task UpdateMyGoal(MyGoal goal);
    IEnumerable<MyGoal> GetChartPeriodMyGoals(int taskId);
    Task<MyGoal> GetMyGoalAsync(int id);
    Task DeleteMyGoal(int id);
    Task DeleteMyGoal(MyGoal goal);

    Task CreateMyPractice(MyPractice myPractice);
    Task UpdateMyPracticeAsync(MyPractice myPractice);
    IEnumerable<MyPractice> GetChartPeriodMyPracticesAsync(int taskId);
    Task<MyPractice> GetMyPracticeAsync(int practiceId);
    Task DeleteMyPractice(int practiceId);
    Task DeleteMyPractice(MyPractice myPractice);
    Task SaveMyPracticeDailyReflection(int chartPeriodId, int myPracticeId, int occurenceId, DailyReflection dailyReflection);
    Task<IEnumerable<DailyReflection>> GetMyPracticeDailyReflections(int myPracticeId);

    Task CreateMyActionAsync(MyAction action);
    Task UpdateMyActionAsync(MyAction action);
    IEnumerable<MyAction> GetChartPeriodMyActions(int taskId);
    Task<MyAction> GetMyActionAsync(int actionId);
    Task DeleteMyAction(int id);
    Task DeleteMyAction(MyAction action);

    Task CreateDailyReflection(DailyReflection reflection);
    Task UpdateDailyReflection(DailyReflection reflrection);
    Task<DailyReflection> GetDailyReflection(int id);
    Task DeleteDailyReflection(int id);
    Task DeleteDailyReflection(DailyReflection reflrection);
    Task<Dictionary<int, Tuple<int, DailyReflection>>> GetMyPracticesAsync(int chartPeriodId, int myPracticeId);

    Task<AttachVerse> GetTodayVerseAsync();
    Task UpdateTodayVerseAsync(TodayVerse verse);
    Task<IEnumerable<AppInformation>> GetAppInformation(string key);
}
