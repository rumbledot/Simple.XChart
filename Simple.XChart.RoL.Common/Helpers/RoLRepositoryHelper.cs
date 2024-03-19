using System.Data.Common;
using System.Data.SQLite;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Simple.XChart.RoL.Common.Helpers;

public class RoLRepositoryHelper : IRoLRepositoryHelper
{
    private readonly string connectionString;
    private readonly PexelsService pexelsService;
    private readonly VerseService verseService;
    private readonly bool useSqlite;

    public RoLRepositoryHelper(string connectionString, PexelsService pexelService, VerseService verseService, bool useSqlite = false)
    {
        this.connectionString = connectionString;
        this.pexelsService = pexelService;
        this.verseService = verseService;
        this.useSqlite = useSqlite;
    }

    private IDbConnection GetConnection()
    {
        if (useSqlite)
        {
            return new SQLiteConnection(connectionString);
        }

        return new SqlConnection(connectionString);
    }

    public async Task<string?> GetAppInformationValue(string code)
    {
        //using var conn = new SqlConnection(connectionString);
        using var conn = GetConnection();
        return await conn.ExecuteScalarAsync<string>("SELECT Information FROM AppInformations WHERE Code=@code"
            , new { code });
    }

    public async Task<AppInformation?> GetAppInformation(string code)
    {
        using var conn = GetConnection();
        return await conn.QueryFirstOrDefaultAsync<AppInformation>("SELECT * FROM AppInformations WHERE Code=@code"
            , new { code });
    }

    public async Task SaveAppInformation(string code, string info)
    {
        using var conn = GetConnection();
        var existing = await GetAppInformation(code);
        if (existing != null)
        {
            existing.Information = info;
            existing.DateUpdated = DateTime.Now;
            await conn.UpdateAsync(existing);

            return;
        }

        existing = new AppInformation();
        existing.Code = code;
        existing.Information = info;
        existing.DateUpdated = DateTime.Now;
        await conn.InsertAsync(existing);
    }

    public async Task<BannerImage> TryGetBannerImage()
    {
        try
        {
            using var conn = GetConnection();
            var random = new Random(DateTime.Now.Millisecond);
            int idx = 0;

            var bannerIds = await conn.QueryAsync<int>("SELECT Id FROM BannerImages");
            if (bannerIds is not null && bannerIds.Count() > 0)
            {
                idx = random.Next(0, bannerIds.Count() - 1);
                var id = bannerIds.ElementAt(idx);
                return await conn.QueryFirstOrDefaultAsync<BannerImage>("SELECT * FROM BannerImages WHERE Id=@id"
                    , new { id });
            }

            var photoTheme = await GetAppInformationValue("PhotoTheme");
            var bannerImages = await pexelsService.GetBannerImages(string.IsNullOrEmpty(photoTheme) ? "Nature" : photoTheme);
            foreach (var bannerImage in bannerImages)
            {
                conn.Insert(bannerImage);
            }

            idx = random.Next(0, bannerImages.Count() - 1);
            return bannerImages.ElementAt(idx);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<AttachVerse> TryGetTodayVerse()
    {
        try
        {
            var lastTodayVerse = await GetAppInformation("TodayVerse");

            if (lastTodayVerse is null || lastTodayVerse.DateUpdated < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
            {
                var todaysVerseResponse = await verseService.GetTodayVerse();
                await UpdateTodayVerse(todaysVerseResponse.verse);

                return new AttachVerse()
                {
                    Text = todaysVerseResponse.verse.details.text,
                    BibleId = todaysVerseResponse.verse.details.version,
                    VerseId = todaysVerseResponse.verse.details.reference
                };
            }

            return await GetTodayVerse();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<AttachVerse> GetTodayVerse()
    {
        using var conn = GetConnection();
        return await conn.QueryFirstOrDefaultAsync<AttachVerse>("SELECT * FROM AttachVerses WHERE MyActionId=-1");
    }

    public async Task UpdateTodayVerse(TodayVerse verse)
    {
        try
        {
            var todayVerse = await GetTodayVerse();
            await SaveAppInformation("TodayVerse", "Updated");

            using var conn = GetConnection();
            if (todayVerse is null)
            {
                var attachVerse = new AttachVerse()
                {
                    Text = verse.details.text,
                    VerseId = verse.details.reference,
                    BibleId = verse.details.version,
                    MyActionId = -1
                };
                await conn.InsertAsync(attachVerse);

                return;
            }

            todayVerse.Text = verse.details.text;
            todayVerse.VerseId = verse.details.reference;
            todayVerse.BibleId = verse.details.version;
            await conn.UpdateAsync(todayVerse);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Chart> GetActiveChart()
    {
        using var conn = GetConnection();
        return await conn.QueryFirstAsync<Chart>("SELECT * FROM Charts WHERE Id=1");
    }

    public async Task<Chart> GetChart(int id)
    {
        using var conn = GetConnection();
        return await conn.QueryFirstAsync<Chart>("SELECT * FROM Charts WHERE Id=@id", new { id });
    }

    public async Task<IEnumerable<ChartOccurence>> GetOccurences()
    {
        using var conn = GetConnection();
        return await conn.GetAllAsync<ChartOccurence>();
    }

    public async Task<IEnumerable<ChartPractice>> GetChartPractices(int id)
    {
        using var conn = GetConnection();
        var goalIds = await conn.QueryAsync<int>("SELECT Id FROM Goals WHERE ChartId=@id", new { id });
        return await conn.QueryAsync<ChartPractice>("SELECT * FROM Practices WHERE GoalId IN @goalIds", new { goalIds });
    }

    public async Task<ChartPractice> GetPractice(int id)
    {
        using var conn = GetConnection();
        return await conn.QueryFirstOrDefaultAsync<ChartPractice>("SELECT * FROM Practices WHERE Id=@id", new { id });
    }

    public async Task<IEnumerable<MyAction>> GetPracticeFirstAction(int id)
    {
        using var conn = GetConnection();
        return await conn.QueryAsync<MyAction>("SELECT * FROM MyActions WHERE PracticeId=@id ORDER BY DateCreated", new { id });
    }

    public async Task<IEnumerable<MyAction>> GetPracticeActions(int id)
    {
        using var conn = GetConnection();
        return await conn.QueryAsync<MyAction>("SELECT * FROM MyActions WHERE PracticeId=@id", new { id });
    }

    public async Task SavePracticeAction(MyAction action)
    {
        try
        {
            using var conn = GetConnection();
            if (action.Id == 0)
            {
                action.DateCreated = DateTime.Now;
                action.DateUpdated = DateTime.Now;
                await conn.InsertAsync(action);

                return;
            }

            action.DateUpdated = DateTime.Now;
            await conn.UpdateAsync(action);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAction(int id)
    {
        try
        {
            using var conn = GetConnection();
            await conn.QueryAsync("DELETE FROM MyActions WHERE Id=@id", new { id });
        }
        catch (Exception)
        {
            throw;
        }
    }
}
