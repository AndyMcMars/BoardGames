public class mdGame
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }

    public List<mdFaction> Factions { get; set; } = new();
}