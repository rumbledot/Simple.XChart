using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class BibleChapter
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string BibleId { get; set; }
    public string BookId { get; set; }
    public string Number { get; set; }
}
