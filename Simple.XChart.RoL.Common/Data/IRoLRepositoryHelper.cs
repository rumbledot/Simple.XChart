using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;

namespace Simple.XChart.RoL.Common.Data
{
    public interface IRoLRepositoryHelper
    {
        Task DeleteAction(int id);
        Task<Chart> GetActiveChart();
        Task<AppInformation?> GetAppInformation(string code);
        Task<string?> GetAppInformationValue(string code);
        Task<Chart> GetChart(int id);
        Task<IEnumerable<ChartPractice>> GetChartPractices(int id);
        Task<IEnumerable<ChartOccurence>> GetOccurences();
        Task<ChartPractice> GetPractice(int id);
        Task<IEnumerable<MyAction>> GetPracticeActions(int id);
        Task<IEnumerable<MyAction>> GetPracticeFirstAction(int id);
        Task<AttachVerse> GetTodayVerse();
        Task SaveAppInformation(string code, string info);
        Task SavePracticeAction(MyAction action);
        Task<BannerImage> TryGetBannerImage();
        Task<AttachVerse> TryGetTodayVerse();
        Task UpdateTodayVerse(TodayVerse verse);
    }
}