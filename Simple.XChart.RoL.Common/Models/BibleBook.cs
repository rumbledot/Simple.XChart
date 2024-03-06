using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Models;

public class BibleBook
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string abbreviation { get; set; }
    public string name { get; set; }
    public string nameLong { get; set; }
    public IEnumerable<BibleChapter> chapters { get; set; }
}

public class BibleChapter
{
    public string id { get; set; }
    public string bibleId { get; set; }
    public string number { get; set; }
    public string bookId { get; set; }
    public string reference { get; set; }
}
