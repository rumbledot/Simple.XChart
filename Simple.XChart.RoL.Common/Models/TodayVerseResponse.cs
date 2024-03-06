namespace Simple.XChart.RoL.Common.Models;

public class TodayVerseResponse
{
    public TodayVerse verse { get; set; }
}

public class TodayVerse
{
    public VerseDetails details { get; set; }
    public string notice { get; set; }
}

public class VerseDetails
{
    public string text { get; set; }
    public string reference { get; set; }
    public string version { get; set; }
    public string verseurl { get; set; }
}
