using SQLite;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Verses")]
public class AttachVerse
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? BibleId { get; set; }
    public string? BookId { get; set; }
    public string? ChapterId { get; set; }
    public string? VerseId { get; set; }
    public string? Text { get; set; }

    public int MyActionId { get; set; }

}
