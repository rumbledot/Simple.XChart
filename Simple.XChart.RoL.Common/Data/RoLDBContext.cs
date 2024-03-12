using Microsoft.EntityFrameworkCore;
using Simple.XChart.RoL.Common.Entities;

namespace Simple.XChart.RoL.Common.Data;

public class RoLDBContext : DbContext
{
    public RoLDBContext(DbContextOptions<RoLDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChartOccurence>().HasData(
            new ChartOccurence { Id = 1, Description = "Daily", DaysCount = 1 },
            new ChartOccurence { Id = 2, Description = "Weekly", DaysCount = 7 },
            new ChartOccurence { Id = 3, Description = "Montly", DaysCount = 30 }
            );

        modelBuilder.Entity<ChartPeriod>().HasData(
            new ChartPeriod { Id = 1, Title = "Lent", Description = "Guide thru Easter", DateStart = DateTime.Now, DateEnd = DateTime.Now.AddDays(120) }
            );

        modelBuilder.Entity<MyGoal>().HasData(
            new MyGoal { Id = 1, Description = "Be With Jesus", TaskPeriodId = 1 },
            new MyGoal { Id = 2, Description = "Become Like Jesus", TaskPeriodId = 1 },
            new MyGoal { Id = 3, Description = "Do what Jesus did", TaskPeriodId = 1 }
            );

        modelBuilder.Entity<MyPractice>().HasData(
            new MyPractice { Id = 1, Description = "Silence & Solitude", GoalId = 1 },
            new MyPractice { Id = 2, Description = "Scripture", GoalId = 1 },
            new MyPractice { Id = 3, Description = "Prayer", GoalId = 1 },
            new MyPractice { Id = 4, Description = "Community", GoalId = 2 },
            new MyPractice { Id = 5, Description = "Sabbath", GoalId = 2 },
            new MyPractice { Id = 6, Description = "Vocation", GoalId = 3 },
            new MyPractice { Id = 7, Description = "Hospitality", GoalId = 3 },
            new MyPractice { Id = 8, Description = "Simplicity", GoalId = 3 }
            );

        modelBuilder.Entity<AppInformation>().HasData(
            new AppInformation { InfoKey = "PhotoTheme", InfoValue = "natural landscape", DateUpdated = DateTime.Now }
            );

        modelBuilder.Entity<AttachVerse>().Property(p => p.BibleId).IsRequired(false);
        modelBuilder.Entity<AttachVerse>().Property(p => p.ChapterId).IsRequired(false);
        modelBuilder.Entity<AttachVerse>().Property(p => p.BookId).IsRequired(false);
        modelBuilder.Entity<AttachVerse>().Property(p => p.VerseId).IsRequired(false);

        modelBuilder.Entity<ChartPeriodMap>().HasNoKey();
        modelBuilder.Entity<MyPRacticeDailyReflectionMap>().HasNoKey();
    }

    public DbSet<ChartPeriod> ChartPeriods { get; set; }
    public DbSet<MyGoal> MyGoals { get; set; }
    public DbSet<MyPractice> MyPractices { get; set; }
    public DbSet<ChartOccurence> Occurences { get; set; }
    public DbSet<MyAction> MyActions { get; set; }
    public DbSet<AppInformation> AppInformations { get; set; }
    public DbSet<BannerImage> BannerImages { get; set; }
    public DbSet<AttachVerse> AttachVerses { get; set; }
    public DbSet<DailyReflection> DailyReflrections { get; set; }
    public DbSet<ChartPeriodMap> ChartPeriodMap { get; set; }
    public DbSet<MyPRacticeDailyReflectionMap> MyPracticeDailyReflrectionMap { get; set; }
}