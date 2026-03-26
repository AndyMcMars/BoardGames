public class mdResult
{
    public int Id { get; set; }

    public int MatchId { get; set; }
    public mdMatch Match { get; set; } = null!;

    public int PlayerId { get; set; }
    public mdPlayer Player { get; set; } = null!;

    public int? FactionId { get; set; }
    public mdFaction? Faction { get; set; }

    public int Points { get; set; }
}