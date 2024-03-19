using Simple.XChart.RoL.EFCore;

try
{
	var db = new RoLDBContext();

	Console.WriteLine("EFCore OK");
}
catch (Exception ex)
{
	Console.WriteLine($"EFCore failed {ex}");
}
