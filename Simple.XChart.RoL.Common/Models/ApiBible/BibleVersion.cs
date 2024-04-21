using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Models.ApiBible;


public class BibleVersion
{
    public string id { get; set; }
    public string dblId { get; set; }
    public string abbreviation { get; set; }
    public string abbreviationLocal { get; set; }
    public BibleLanguage language { get; set; }
    public BibleCountry[] countries { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
    public string description { get; set; }
    public string descriptionLocal { get; set; }
    public string relatedDbl { get; set; }
    public string type { get; set; }
    public DateTime updatedAt { get; set; }
    public Audiobible[] audioBibles { get; set; }
}

public class BibleLanguage
{
    public string id { get; set; }
    public string name { get; set; }
    public string nameLocal { get; set; }
    public string script { get; set; }
    public string scriptDirection { get; set; }
}

public class BibleCountry
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
