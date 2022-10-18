namespace WorkShopContext.Models;

public class Spielekonsole : IEntityBase
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
}
