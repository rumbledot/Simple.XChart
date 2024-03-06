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
    void SaveTaskPeriods(TaskPeriod taskPeriod);
    void UpdateTaskPeriod(TaskPeriod taskPeriod);
    IEnumerable<TaskPeriod> GetTaskPeriods();
    Task<TaskPeriod> GetTaskPeriodAsync(int id);
    Task<TaskPeriod> GetActiveTaskPeriodAsync();

    void SaveTobeGoal(TobeGoal goal);
    void UpdateTobeGoal(TobeGoal goal);
    IEnumerable<TobeGoal> GetTaskPeriodTobeGoals(int taskId);
    Task<TobeGoal> GetTobeGoalAsync(int id);
    void DeleteTobeGoal(int id);
    void DeleteTobeGoal(TobeGoal goal);

    void SaveMyPractice(MyPractice myPractice);
    void UpdateMyPracticeAsync(MyPractice myPractice);
    IEnumerable<MyPractice> GetTaskPeriodMyPracticesAsync(int taskId);
    Task<MyPractice> GetMyPracticeAsync(int practiceId);
    void DeleteMyPractice(int practiceId);
    void DeleteMyPractice(MyPractice myPractice);

    void SaveMyActionAsync(MyAction action);
    void UpdateMyActionAsync(MyAction action);
    IEnumerable<MyAction>GetTaskPeriodMyActions(int taskId);
    MyAction GetMyActionAsync(int actionId);
    void DeleteMyAction(int id);
    void DeleteMyAction(MyAction action);

    AppInformation GetTodayVerse();
    void UpdateTodayVerse(TodayVerse verse);
}
