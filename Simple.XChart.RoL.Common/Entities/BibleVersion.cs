using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class BibleVersion
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string VersionId { get; set; }
    public string Name { get; set; }
    public string Short { get; set; }
    public string Language { get; set; }
    public string LanguageId { get; set; }
}
