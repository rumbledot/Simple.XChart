namespace Simple.XChart.MVC.Models;

public class ApiSettings
{
    public ApiItems ApiUrls { get; set; }
    public ApiItems ApiKeys { get; set; }
}

public class ApiItems
{
    public string Verse { get; set; }
    public string Pexels { get; set; }
}

public class ConnectionSettings
{
    public string DefaultConnection { get; set; }
}