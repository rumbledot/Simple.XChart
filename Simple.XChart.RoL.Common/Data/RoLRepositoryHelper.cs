using System.Data;
using SQLite;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;

namespace Simple.XChart.RoL.Common.Data;

public class RoLRepositoryHelper : IRoLRepositoryHelper
{
    private readonly string connectionString;
    private readonly PexelsService pexelsService;
    private readonly VerseService verseService;

    //SQLite PCL
    //https://github.com/praeclarum/sqlite-net?WT.mc_id=friends-0000-jamont
    private SQLiteAsyncConnection connection;

    public RoLRepositoryHelper(string connectionString, PexelsService pexelService, VerseService verseService)
    {
        this.connectionString = connectionString;
        pexelsService = pexelService;
        this.verseService = verseService;
    }

    private async Task<SQLiteAsyncConnection> GetConnection()
    {
        if(connection is null) 
        {
            await DatabaseInitialize();
        }

        return connection;
    }

    private async Task DatabaseInitialize()
    {
        var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RoLDB.db");

        connection = new SQLiteAsyncConnection(databasepath);

        if (!File.Exists(databasepath))
        {
            await connection.CreateTableAsync<AppInformation>();
            await connection.CreateTableAsync<AttachVerse>();
            await connection.CreateTableAsync<BannerImage>();
            await connection.CreateTableAsync<Chart>();
            await connection.CreateTableAsync<ChartGoal>();
            await connection.CreateTableAsync<ChartOccurence>();
            await connection.CreateTableAsync<ChartPractice>();
            await connection.CreateTableAsync<MyAction>();

            var appInformation = new AppInformation
            {
                Code = "PhotoTheme",
                Information = "Natural Landscape",
                DateUpdated = DateTime.Now,
            };
            await connection.InsertAsync(appInformation);

            var chart = new Chart 
            { 
                Title = "Lent",
                Description = "Guide to Easter",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(180),
            };
            await connection.InsertAsync(chart);

            var goals = new List<ChartGoal>() 
            {
                new ChartGoal {
                    Description = "Be With Jesus",
                    ChartId = 1
                },
                new ChartGoal {
                    Description = "Become Like Jesus",
                    ChartId = 1
                },
                new ChartGoal {
                    Description = "Do what Jesus did",
                    ChartId = 1
                },
            };
            await connection.InsertAllAsync(goals);

            var occurences = new List<ChartOccurence>() 
            {
                new ChartOccurence
                {
                    Description ="Daily",
                    DaysCount = 1,
                },
                new ChartOccurence
                {
                    Description ="Weekly",
                    DaysCount = 7,
                },
                new ChartOccurence
                {
                    Description ="Montly",
                    DaysCount = 30,
                },
            };
            await connection.InsertAllAsync(occurences);

            var practices = new List<ChartPractice>() 
            {
                new ChartPractice
                {
                    Description = "Silence & Solitude",
                    GoalId = 1,
                },
                new ChartPractice
                {
                    Description = "Scripture",
                    GoalId = 1,
                },
                new ChartPractice
                {
                    Description = "Prayer",
                    GoalId = 1,
                },
                new ChartPractice
                {
                    Description = "Community",
                    GoalId = 2,
                },
                new ChartPractice
                {
                    Description = "Sabbath",
                    GoalId = 2,
                },
                new ChartPractice
                {
                    Description = "Vocation",
                    GoalId = 3,
                },
                new ChartPractice
                {
                    Description = "Hospitality",
                    GoalId = 3,
                },
                new ChartPractice
                {
                    Description = "Simplicity",
                    GoalId = 3,
                },
            };
            await connection.InsertAllAsync(practices);
        }
    }

    public async Task<string?> GetAppInformationValue(string code)
    {
        return (await (await GetConnection()).Table<AppInformation>().FirstOrDefaultAsync(x => x.Code.Equals(code)))?.Information ?? "";
    }

    public async Task<AppInformation?> GetAppInformation(string code)
    {
        return await (await GetConnection()).Table<AppInformation>().FirstOrDefaultAsync(x => x.Code.Equals(code));
    }

    public async Task SaveAppInformation(string code, string info)
    {
        var existing = await GetAppInformation(code);
        if (existing != null)
        {
            existing.Information = info;
            existing.DateUpdated = DateTime.Now;
            await (await GetConnection()).UpdateAsync(existing);

            return;
        }

        existing = new AppInformation();
        existing.Code = code;
        existing.Information = info;
        existing.DateUpdated = DateTime.Now;
        await (await GetConnection()).InsertAsync(existing);
    }

    public async Task<BannerImage> TryGetBannerImage()
    {
        try
        {

            var random = new Random(DateTime.Now.Millisecond);
            int idx = 0;

            var bannerIds = (await (await GetConnection()).Table<BannerImage>().ToListAsync()).Select(x => x.Id);
            if (bannerIds is not null && bannerIds.Count() > 0)
            {
                idx = random.Next(0, bannerIds.Count() - 1);
                var id = bannerIds.ElementAt(idx);
                return await (await GetConnection()).Table<BannerImage>().FirstOrDefaultAsync(x => x.Id == id);
            }

            var photoTheme = await GetAppInformationValue("PhotoTheme");
            var bannerImages = await pexelsService.GetBannerImages(string.IsNullOrEmpty(photoTheme) ? "Nature" : photoTheme);
            foreach (var bannerImage in bannerImages)
            {
                await (await GetConnection()).InsertAsync(bannerImage);
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

        return await (await GetConnection()).Table<AttachVerse>().FirstOrDefaultAsync(x => x.MyActionId == -1);
    }

    public async Task UpdateTodayVerse(TodayVerse verse)
    {
        try
        {
            var todayVerse = await GetTodayVerse();
            await SaveAppInformation("TodayVerse", "Updated");


            if (todayVerse is null)
            {
                var attachVerse = new AttachVerse()
                {
                    Text = verse.details.text,
                    VerseId = verse.details.reference,
                    BibleId = verse.details.version,
                    MyActionId = -1
                };
                await (await GetConnection()).InsertAsync(attachVerse);

                return;
            }

            todayVerse.Text = verse.details.text;
            todayVerse.VerseId = verse.details.reference;
            todayVerse.BibleId = verse.details.version;
            await (await GetConnection()).UpdateAsync(todayVerse);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Chart> GetActiveChart()
    {

        return await (await GetConnection()).Table<Chart>().FirstOrDefaultAsync(x => x.Id == 1);
    }

    public async Task<Chart> GetChart(int id)
    {

        return await (await GetConnection()).Table<Chart>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ChartOccurence>> GetOccurences()
    {

        return await (await GetConnection()).Table<ChartOccurence>().ToListAsync();
    }

    public async Task<IEnumerable<ChartPractice>> GetChartPractices(int id)
    {

        var goalIds = (await (await GetConnection()).Table<ChartGoal>().Where(x => x.ChartId == id).ToListAsync()).Select(x => x.Id);
        return await (await GetConnection()).Table<ChartPractice>().Where(x => goalIds.Contains(x.GoalId)).ToListAsync();
    }

    public async Task<ChartPractice> GetPractice(int id)
    {

        return await (await GetConnection()).Table<ChartPractice>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<MyAction>> GetPracticeFirstAction(int id)
    {

        return await (await GetConnection()).Table<MyAction>().Where(x => x.Id == id).OrderBy(x => x.DateCreated).ToListAsync();
    }

    public async Task<IEnumerable<MyAction>> GetPracticeActions(int id)
    {
        return await (await GetConnection()).Table<MyAction>().Where(x => x.PracticeId == id).ToListAsync();
    }

    public async Task SavePracticeAction(MyAction action)
    {
        try
        {

            if (action.Id == 0)
            {
                action.DateCreated = DateTime.Now;
                action.DateUpdated = DateTime.Now;
                await (await GetConnection()).InsertAsync(action);

                return;
            }

            action.DateUpdated = DateTime.Now;
            await (await GetConnection()).UpdateAsync(action);
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

            await (await GetConnection()).Table<MyAction>().DeleteAsync(x => x.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<MyAction> GetAction(int id)
    {
        try
        {

            return await (await GetConnection()).Table<MyAction>().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
