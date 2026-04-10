public class mdMatch
{
    public int Id { get; set; }
    public string PublicId { get; set; } = null!;

    public int? TournamentId { get; set; }
    public mdTournament? Tournament { get; set; }

    public int LocationId { get; set; }
    public mdLocation? Location { get; set; }

    public int GameId { get; set; }
    public mdGame Game { get; set; } = null!;

    public DateTime Date { get; set; }
    public TimeSpan? Duration { get; set; }

    public List<mdResult> Results { get; set; } = new();
    public List<mdReview> Reviews { get; set; } = new();

    public mdResult? Winner =>
        Results.OrderByDescending(r => r.Points).FirstOrDefault();
    public double? Stars =>
        Reviews.Any()
            ? Math.Round(Reviews.Average(r => r.Stars), 1)
            : 0;

}