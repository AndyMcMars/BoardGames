public class mdFaction
{
    public int Id { get; set; }

    public int GameId { get; set; }
    public mdGame Game { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
}