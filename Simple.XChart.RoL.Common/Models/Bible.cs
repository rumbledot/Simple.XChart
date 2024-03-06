using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Models;


public class Bibles
{
    public Bible Bible { get; set; }
}

public class Bible
{
    public string id { get; set; }
    public string dblId { get; set; }
    public string abbreviation { get; set; }
    public string abbreviationLocal { get; set; }
    public string copyright { get; set; }
    public Language language { get; set; }
    public IEnumerable<Country> countries { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
    public string description { get; set; }
    public string descriptionLocal { get; set; }
    public string info { get; set; }
    public string type { get; set; }
    public DateTime updatedAt { get; set; }
    public string relatedDbl { get; set; }
    public IEnumerable<Audiobible> audioBibles { get; set; }
}

public class Language
{
    public string id { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
    public string script { get; set; }
    public string scriptDirection { get; set; }
}

public class Country
{
    public string id { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
}

public class Audiobible
{
    public string id { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
    public string description { get; set; }
    public string descriptionLocal { get; set; }
}
