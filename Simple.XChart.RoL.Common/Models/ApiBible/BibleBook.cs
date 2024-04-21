namespace Simple.XChart.RoL.Common.Models.ApiBible;

public class BibleBook
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string abbreviation { get; set; }
    public string name { get; set; }
    public string nameLong { get; set; }
    public BibleChapter[] chapters { get; set; }
}

public class BibleChapter
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string number { get; set; }
    public string bookId { get; set; }
    public string reference { get; set; }
}

public class BibleSection
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string bookId { get; set; }
    public string title { get; set; }
    public string firstVerseId { get; set; }
    public string lastVerseId { get; set; }
    public string firstVerseOrgId { get; set; }
    public string lastVerseOrgId { get; set; }
}

public class BiblePassage
{
    public BiblePassageData data { get; set; }
    public BiblePassageMeta meta { get; set; }
}

public class BiblePassageData
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string orgId { get; set; }
    public string content { get; set; }
    public string reference { get; set; }
    public int verseCount { get; set; }
    public string copyright { get; set; }
}

public class BiblePassageMeta
{
    public string fums { get; set; }
    public string fumsId { get; set; }
    public string fumsJsInclude { get; set; }
    public string fumsJs { get; set; }
    public string fumsNoScript { get; set; }
}

public class BibleVerse
{
    public string id { get; set; }
    public string orgId { get; set; }
    public string bibleId { get; set; }
    public string bookId { get; set; }
    public string chapterId { get; set; }
    public string reference { get; set; }
}


public class BibleChapterComplete
{
    public BibleChapterData data { get; set; }
    public BibleChapterMeta meta { get; set; }
}

public class BibleChapterData
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string number { get; set; }
    public string bookId { get; set; }
    public string reference { get; set; }
    public string copyright { get; set; }
    public int verseCount { get; set; }
    public List<BibleChapterVerse> content { get; set; }
    public BibleVerseNavigation next { get; set; }
    public BibleVerseNavigation previous { get; set; }
}

public class BibleVerseNavigation
{
    public string id { get; set; }
    public string number { get; set; }
    public string bookId { get; set; }
}

public class BibleChapterVerse
{
    public string name { get; set; }
    public string type { get; set; }
    public BibleChapterVerseAttr attrs { get; set; }
    public List<BibleChapterVerseItem> items { get; set; }
}

public class BibleChapterVerseAttr
{
    public string style { get; set; }
    public string vid { get; set; }
}

public class BibleChapterVerseItem
{
    public string type { get; set; }
    public string name { get; set; }
    public BibleChapterVerseItemAttr attrs { get; set; }
    public BibleVerseItem[] items { get; set; }
    public string text { get; set; }
}

public class BibleChapterVerseItemAttr
{
    public string number { get; set; }
    public string style { get; set; }
    public string sid { get; set; }
    public string verseId { get; set; }
    public string[] verseOrgIds { get; set; }
}

public class BibleVerseItem
{
    public string text { get; set; }
    public string type { get; set; }
    public BibleVerseItemAttr attrs { get; set; }
}

public class BibleVerseItemAttr
{
    public string verseId { get; set; }
    public string[] verseOrgIds { get; set; }
}

public class BibleChapterMeta
{
    public string fums { get; set; }
    public string fumsId { get; set; }
    public string fumsJsInclude { get; set; }
    public string fumsJs { get; set; }
    public string fumsNoScript { get; set; }
}
