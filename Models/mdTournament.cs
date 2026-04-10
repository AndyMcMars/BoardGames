public class mdTournament
{
    public int Id { get; set; }
    public string PublicId { get; set; } = null!;
    public string? Name { get; set; }
    public int GameId { get; set; }
    public mdGame Game { get; set; } = null!;
    public bool IsActive { get; set; }
    public List<mdMatch> Matches { get; set; } = new();
    public List<mdReview> Reviews { get; set; } = new();
    public TournamentWinner? Winner =>
        Matches
            .SelectMany(m => m.Results)
            .GroupBy(r => r.PlayerId)
            .Select(g => new TournamentWinner
            {
                PlayerId = g.Key,
                Player = g.First().Player,
                TotalPoints = g.Sum(r => r.Points)
            })
            .OrderByDescending(x => x.TotalPoints)
            .FirstOrDefault();

}

public class TournamentWinner
{
    public int PlayerId { get; set; }
    public mdPlayer Player { get; set; } = null!;
    public int TotalPoints { get; set; }
}