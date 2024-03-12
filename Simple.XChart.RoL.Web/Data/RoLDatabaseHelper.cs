using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Web.Models;

namespace Simple.XChart.RoL.Common.Data;

public class RoLDatabaseHelper : IRoLDatabaseHelper
{
    public RoLDBContext context { get; private set; }
    private readonly ConnectionStrings connectionStrings;

    public RoLDatabaseHelper(RoLDBContext db, ConnectionStrings connectionStrings)
    {
        this.context = db;
        this.connectionStrings = connectionStrings;
    }

    #region TaskPeriod

    public async Task CreateChartPeriods(ChartPeriod taskPeriod)
    {
        context.ChartPeriods.Add(taskPeriod);
        await context.SaveChangesAsync();
    }

    public async Task UpdateChartPeriod(ChartPeriod taskPeriod)
    {
        context.Update(taskPeriod);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ChartPeriod>> GetChartPeriods()
    {
        return context.ChartPeriods.ToList();
    }
    public async Task<ChartPeriod> GetCharteriodAsync(int id)
    {
        return await context.ChartPeriods.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ChartPeriod> GetActiveChartPeriodAsync()
    {
        return await context.ChartPeriods.FirstOrDefaultAsync(x=>x.DateStart < DateTime.Now && x.DateEnd > DateTime.Now);
    }

    #endregion TaskPeriod

    #region TobeGoal

    public async Task CreateMyGoal(MyGoal goal)
    {
        context.MyGoals.Add(goal);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMyGoal(MyGoal goal)
    {
        context.Update(goal);
        await context.SaveChangesAsync();
    }

    public IEnumerable<MyGoal> GetChartPeriodMyGoals(int taskId)
    {
        return context.MyGoals.Where( x => x.TaskPeriodId == taskId);
    }

    public async Task<MyGoal> GetMyGoalAsync(int id)
    {
        return await context.MyGoals.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteMyGoal(int id)
    {
        var existing = context.MyGoals.FirstOrDefault(x => x.Id == id);
        context.MyGoals.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMyGoal(MyGoal goal)
    {
        context.MyGoals.Remove(goal);
        await context.SaveChangesAsync();
    }

    #endregion TobeGoal

    #region MyPractice

    public async Task CreateMyPractice(MyPractice myPractice)
    {
        context.MyPractices.Add(myPractice);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMyPracticeAsync(MyPractice myPractice)
    {
        context.Update(myPractice);
        await context.SaveChangesAsync();
    }

    public IEnumerable<MyPractice> GetChartPeriodMyPracticesAsync(int taskId)
    {
        var goalIds = context.MyGoals.Where(x => x.TaskPeriodId == taskId).Select(x => x.Id);

        return context.MyPractices.Where(x => goalIds.Contains(x.GoalId));
    }

    public async Task<MyPractice> GetMyPracticeAsync(int practiceId)
    {
        return await context.MyPractices.FirstOrDefaultAsync(x => x.Id == practiceId);
    }

    public async Task DeleteMyPractice(int practiceId)
    {
        var existing = context.MyPractices.FirstOrDefault(x => x.Id == practiceId);
        context.MyPractices.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMyPractice(MyPractice practice)
    {
        context.Remove(practice);
        await context.SaveChangesAsync();
    }

    public async Task SaveMyPracticeDailyReflection(int chartPeriodId, int myPracticeId, int occurenceId, DailyReflection dailyReflection)
    {
        if (dailyReflection.Id > 0)
        {
            dailyReflection.DateUpdated = DateTime.Now;
            context.DailyReflrections.Update(dailyReflection);
            await context.SaveChangesAsync();

            return;
        }
        
        dailyReflection.DateUpdated = DateTime.Now;
        context.DailyReflrections.Add(dailyReflection);
        await context.SaveChangesAsync();

        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"INSERT INTO ChartPeriodMap 
            (ChartPeriodId, MyPracticeId, OccurenceId, DailyReflectionId) 
            VALUES 
            (@chartPeriodId, @myPracticeId, @occurenceId, @dailyReflectionId)";
        cmd.Parameters.Add(new SqlParameter("@chartPeriodId", chartPeriodId));
        cmd.Parameters.Add(new SqlParameter("@myPracticeId", myPracticeId));
        cmd.Parameters.Add(new SqlParameter("@occurenceId", occurenceId));
        cmd.Parameters.Add(new SqlParameter("@dailyReflectionId", dailyReflection.Id));
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<IEnumerable<DailyReflection>> GetMyPracticeDailyReflections(int myPracticeId)
    {
        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        var reflectionIds = await conn.QueryAsync<int>(
                @"SELECT DailyReflectionId 
                FROM MyPracticeDailyReflrectionMap 
                WHERE MyPracticeId=@myPracticeId", new { myPracticeId });

        return context.DailyReflrections
            .Where(x => reflectionIds.Contains(x.Id))
            .OrderBy(x => x.DateUpdated)
            .AsNoTracking();
    }

    #endregion MyPractice

    #region MyAction

    public async Task CreateMyActionAsync(MyAction action)
    {
        context.MyActions.Add(action);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMyActionAsync(MyAction action)
    {
        context.Update(action);
        await context.SaveChangesAsync();
    }

    public IEnumerable<MyAction> GetChartPeriodMyActions(int taskId)
    {
        return context.MyActions.Where(x => x.ChartPeriodId == taskId);
    }

    public async Task<MyAction> GetMyActionAsync(int actionId)
    {
        return await context.MyActions.FirstOrDefaultAsync(x => x.Id == actionId);
    }

    public async Task DeleteMyAction(int id)
    {
        var existing = context.MyActions.FirstOrDefault(y => y.Id == id);
        context.MyActions.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMyAction(MyAction action)
    {
        context.Remove(action);
        await context.SaveChangesAsync();
    }

    #endregion MyAction

    #region Daily Reflection

    public async Task CreateDailyReflection(DailyReflection reflection)
    {
        context.DailyReflrections.Add(reflection);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDailyReflection(DailyReflection reflrection)
    {
        context.Update(reflrection);
        await context.SaveChangesAsync();
    }

    public async Task<DailyReflection> GetDailyReflection(int id)
    {
        return await context.DailyReflrections.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteDailyReflection(int id)
    {
        var existing = await context.DailyReflrections.FirstOrDefaultAsync(x => x.Id == id);
        if(existing != null) 
        {
            context.Remove(existing);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteDailyReflection(DailyReflection reflrection)
    {
        context.Remove(reflrection);
        await context.SaveChangesAsync();
    }

    #endregion Daily Reflection

    public async Task<AttachVerse> GetTodayVerseAsync()
    {
        return await context.AttachVerses.FirstOrDefaultAsync(x => x.DailyReflectionId == -1);
    }

    public async Task UpdateTodayVerseAsync(TodayVerse todayVerse)
    {
        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        var existing = await GetTodayVerseAsync();

        if (existing is not null)
        {
            await conn.ExecuteAsync("UPDATE AttachVerses SET Text=@text, BibleId=@ref, VerseId=@verse WHERE DailyReflectionId=-1"
                , new { @text = todayVerse.details.text, @verse = todayVerse.details.reference, @ref = todayVerse.details.version });
        }
        else 
        {
            await conn.ExecuteAsync("INSERT INTO AttachVerses (Text, BibleId, VerseId, DailyReflectionId) VALUES (@text, @ref, @verse, -1)"
                , new
                {
                    @text = todayVerse.details.text,
                    @verse = todayVerse.details.reference,
                    @ref = todayVerse.details.version
                });
        }
    }

    public async Task<IEnumerable<AppInformation>> GetAppInformation(string key)
    {
        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        return await conn.QueryAsync<AppInformation>("SELECT * FROM AppInformations WHERE InfoKey=@key", new { key });
    }

    public async Task<Dictionary<int, Tuple<int, DailyReflection>>> GetMyPracticesAsync(int chartPeriodId, int myPracticeId)
    {
        var dailyReflectionIds = await context.ChartPeriodMap
            .Where(x => x.ChartPeriodId == chartPeriodId && x.MyPracticeId == myPracticeId)
            .ToListAsync();

        var result = new Dictionary<int, Tuple<int, DailyReflection>> ();
        foreach (var item in dailyReflectionIds)
        {
            var dailyReflection = await context.DailyReflrections.FirstOrDefaultAsync(x => x.Id == item.DailyReflectionId);
            var count = await context.MyPracticeDailyReflrectionMap.CountAsync(x=>x.MyPracticeId == myPracticeId);
            var dailyReflectionCount = new Tuple<int, DailyReflection>(count, dailyReflection);

            result.Add(item.OccurenceId, dailyReflectionCount);
        }

        return result;
    }
}
