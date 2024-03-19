using Microsoft.EntityFrameworkCore;
using Simple.XChart.RoL.Common.Entities;
namespace Simple.XChart.RoL.EFCore;

public class RoLDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=CAKRAWALA;Initial Catalog=RuleOfLife;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChartOccurence>().HasData(
            new ChartOccurence { Id = 1, Description = "Daily", DaysCount = 1 },
            new ChartOccurence { Id = 2, Description = "Weekly", DaysCount = 7 },
            new ChartOccurence { Id = 3, Description = "Montly", DaysCount = 30 }
            );

        modelBuilder.Entity<Chart>().HasData(
            new Chart { Id = 1, Title = "Lent", Description = "Guide thru Easter", DateStart = DateTime.Now, DateEnd = DateTime.Now.AddDays(120) }
            );

        modelBuilder.Entity<ChartGoal>().HasData(
            new ChartGoal { Id = 1, Description = "Be With Jesus", ChartId = 1 },
            new ChartGoal { Id = 2, Description = "Become Like Jesus", ChartId = 1 },
            new ChartGoal { Id = 3, Description = "Do what Jesus did", ChartId = 1 }
            );

        modelBuilder.Entity<ChartPractice>().HasData(
            new ChartPractice { Id = 1, Description = "Silence & Solitude", GoalId = 1 },
            new ChartPractice { Id = 2, Description = "Scripture", GoalId = 1 },
            new ChartPractice { Id = 3, Description = "Prayer", GoalId = 1 },
            new ChartPractice { Id = 4, Description = "Community", GoalId = 2 },
            new ChartPractice { Id = 5, Description = "Sabbath", GoalId = 2 },
            new ChartPractice { Id = 6, Description = "Vocation", GoalId = 3 },
            new ChartPractice { Id = 7, Description = "Hospitality", GoalId = 3 },
            new ChartPractice { Id = 8, Description = "Simplicity", GoalId = 3 }
            );

        modelBuilder.Entity<AppInformation>().HasData(
            new AppInformation { Code = "PhotoTheme", Information = "natural landscape", DateUpdated = DateTime.Now }
            );
    }

    public DbSet<Chart> Charts { get; set; }
    public DbSet<ChartGoal> Goals { get; set; }
    public DbSet<ChartPractice> Practices { get; set; }
    public DbSet<ChartOccurence> Occurences { get; set; }
    public DbSet<MyAction> MyActions { get; set; }
    public DbSet<AppInformation> AppInformations { get; set; }
    public DbSet<BannerImage> BannerImages { get; set; }
    public DbSet<AttachVerse> AttachVerses { get; set; }
}
