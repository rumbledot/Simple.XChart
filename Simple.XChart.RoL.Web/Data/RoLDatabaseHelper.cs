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

    public void SaveTaskPeriods(TaskPeriod taskPeriod)
    {
        context.TaskPeriods.Add(taskPeriod);
        context.SaveChanges();
    }

    public void UpdateTaskPeriod(TaskPeriod taskPeriod)
    {
        context.Update(taskPeriod);
        context.SaveChanges();
    }

    public IEnumerable<TaskPeriod> GetTaskPeriods()
    {
        return context.TaskPeriods.ToList();
    }
    public async Task<TaskPeriod> GetTaskPeriodAsync(int id)
    {
        return await context.TaskPeriods.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<TaskPeriod> GetActiveTaskPeriodAsync()
    {
        return await context.TaskPeriods.FirstOrDefaultAsync(x=>x.DateStart < DateTime.Now && x.DateEnd > DateTime.Now);
    }

    #endregion TaskPeriod

    #region TobeGoal

    public void SaveTobeGoal(TobeGoal goal)
    {
        context.TobeGoals.Add(goal);
        context.SaveChanges();
    }

    public void UpdateTobeGoal(TobeGoal goal)
    {
        context.Update(goal);
        context.SaveChanges();
    }

    public IEnumerable<TobeGoal> GetTaskPeriodTobeGoals(int taskId)
    {
        return context.TobeGoals.Where( x => x.TaskPeriodId == taskId);
    }

    public Task<TobeGoal> GetTobeGoalAsync(int id)
    {
        return context.TobeGoals.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void DeleteTobeGoal(int id)
    {
        var existing = context.TobeGoals.FirstOrDefault(x => x.Id == id);
        context.TobeGoals.Remove(existing);
        context.SaveChanges();
    }

    public void DeleteTobeGoal(TobeGoal goal)
    {
        context.TobeGoals.Remove(goal);
        context.SaveChanges();
    }

    #endregion TobeGoal

    #region MyPractice

    public void SaveMyPractice(MyPractice myPractice)
    {
        context.MyPractices.Add(myPractice);
        context.SaveChanges();
    }

    public void UpdateMyPracticeAsync(MyPractice myPractice)
    {
        context.Update(myPractice);
        context.SaveChanges();
    }

    public IEnumerable<MyPractice> GetTaskPeriodMyPracticesAsync(int taskId)
    {
        var goalIds = context.TobeGoals.Where(x => x.TaskPeriodId == taskId).Select(x => x.Id);

        return context.MyPractices.Where(x => goalIds.Contains(x.GoalId));
    }

    public async Task<MyPractice> GetMyPracticeAsync(int practiceId)
    {
        return await context.MyPractices.FirstOrDefaultAsync(x => x.Id == practiceId);
    }

    public void DeleteMyPractice(int practiceId)
    {
        var existing = context.MyPractices.FirstOrDefault(x => x.Id == practiceId);
        context.MyPractices.Remove(existing);
        context.SaveChanges();
    }

    public void DeleteMyPractice(MyPractice practice)
    {
        context.Remove(practice);
        context.SaveChanges();
    }

    #endregion MyPractice

    #region MyAction

    public void SaveMyActionAsync(MyAction action)
    {
        context.MyActions.Add(action);
        context.SaveChanges();
    }

    public void UpdateMyActionAsync(MyAction action)
    {
        context.Update(action);
        context.SaveChanges();
    }

    public IEnumerable<MyAction> GetTaskPeriodMyActions(int taskId)
    {
        return context.MyActions.Where(x => x.TaskId == taskId);
    }

    public MyAction GetMyActionAsync(int actionId)
    {
        return context.MyActions.FirstOrDefault(x => x.Id == actionId);
    }

    public void DeleteMyAction(int id)
    {
        var existing = context.MyActions.FirstOrDefault(y => y.Id == id);
        context.MyActions.Remove(existing);
        context.SaveChanges();
    }

    public void DeleteMyAction(MyAction action)
    {
        context.Remove(action);
        context.SaveChanges();
    }

    #endregion MyAction

    public void UpdateTodayVerse(TodayVerse todayVerse)
    {
        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        var existing = GetTodayVerse();

        if (existing != null)
        {
            conn.Execute("UPDATE AppInformations SET InfoValue=@value, DateUpdated=@updated WHERE InfoKey='TodayVerse'"
                , new { @value = $"{todayVerse.details.text};{todayVerse.details.reference};{todayVerse.details.version}", @updated = DateTime.Now });
        }
        else 
        {
            conn.Execute("INSERT INTO AppInformations VALUES (@key, @value, @updated)"
                , new
                {
                    @key = "TodayVerse",
                    @value = $"{todayVerse.details.text};{todayVerse.details.reference};{todayVerse.details.version}",
                    @updated = DateTime.Now
                });
        }
    }

    public AppInformation GetTodayVerse()
    {
        using var conn = new SqlConnection(connectionStrings.DefaultConnection);
        return conn.Query<AppInformation>("SELECT * FROM AppInformations WHERE InfoKey='TodayVerse' AND DateUpdated BETWEEN @startToday AND @endToday",
            new {
                @startToday = DateTime.Now.Date,
                @endToday = DateTime.Now.Date.AddHours(23).AddMinutes(59)
            })
            .FirstOrDefault();
    }
}
