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

        modelBuilder.Entity<Occurence>().HasData(
            new Occurence { Id = 1, Description = "Daily", DaysCount = 1 },
            new Occurence { Id = 2, Description = "Weekly", DaysCount = 7 },
            new Occurence { Id = 3, Description = "Montly", DaysCount = 30 }
            );

        modelBuilder.Entity<AppInformation>().HasNoKey();
    }

    public DbSet<TaskPeriod> TaskPeriods { get; set; }
    public DbSet<TobeGoal> TobeGoals { get; set; }
    public DbSet<MyPractice> MyPractices { get; set; }
    public DbSet<Occurence> Occurences { get; set; }
    public DbSet<MyAction> MyActions { get; set; }
    public DbSet<AppInformation> AppInformations { get; set; }
    public DbSet<BannerImage> BannerImages { get; set; }
    public DbSet<AttachVerse> AttachVerses { get; set; }
}