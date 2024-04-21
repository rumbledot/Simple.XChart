using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;

namespace Simple.XChart.RoL.Common.Data
{
    public interface IRoLRepositoryHelper
    {
        Task SaveAppInformation(string code, string info);
        Task<AppInformation?> GetAppInformation(string code);
        Task<string?> GetAppInformationValue(string code);
        Task<BannerImage> TryGetBannerImage();
        Task UpdateTodayVerse(TodayVerse verse);
        Task<AttachVerse> GetTodayVerse();
        Task<AttachVerse> TryGetTodayVerse();
        Task<Chart> SaveChart(Chart chart);
        Task<IEnumerable<Chart>> GetAllCharts();
        Task<Chart> GetActiveChart();
        Task SetActiveChart(int id);
        Task<Chart> GetChart(int? chartId);
        Task DeleteChart(int id);
        Task<ChartGoal> SaveGoal(ChartGoal goal);
        Task<IEnumerable<ChartGoal>> GetChartGoals(int chartId);
        Task<ChartGoal> GetGoal(int goalId);
        Task DeleteGoal(int goalId);
        Task<ChartPractice> SavePractice(ChartPractice practice);
        Task<IEnumerable<ChartPractice>> GetChartPractices(int chartId);
        Task<IEnumerable<ChartOccurence>> GetOccurences();
        Task<IEnumerable<ChartPractice>> GetGoalPractices(int goalId);
        Task<ChartPractice> GetPractice(int practiceId);
        Task DeletePractice(int practiceId);
        Task SavePracticeAction(MyAction action);
        Task<IEnumerable<MyAction>> GetPracticeActions(int practiceId);
        Task<IEnumerable<MyAction>> GetPracticeFirstAction(int practiceId);
        Task<MyAction> GetAction(int actionId);
        Task DeleteAction(int actionId);
    }
}