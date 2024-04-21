using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class BibleCountry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string CountryId { get; set; }
    public string Name { get; set; }
}
