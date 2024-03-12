using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Simple.XChart.RoL.Common.Entities;

public class AttachVerse
{
    [Key]
    public int Id { get; set; }
    public int DailyReflectionId { get; set; }
    [StringLength(200), AllowNull()]
    public string BibleId { get; set; }
    [StringLength(100), AllowNull()]
    public string BookId { get; set; }
    [StringLength(100), AllowNull()]
    public string ChapterId { get; set; }
    [StringLength(100), AllowNull()]
    public string VerseId { get; set; }
    public string Text { get; set; }

}
