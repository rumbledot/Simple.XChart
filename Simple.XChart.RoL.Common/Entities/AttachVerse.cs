﻿using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Simple.XChart.RoL.Common.Entities;

[Table("Verses")]
public class AttachVerse
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string? BibleId { get; set; }
    [StringLength(100)]
    public string? BookId { get; set; }
    [StringLength(100)]
    public string? ChapterId { get; set; }
    [StringLength(100)]
    public string? VerseId { get; set; }
    public string? Text { get; set; }

    public int MyActionId { get; set; }

}
