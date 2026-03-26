public class mdReview
{
    public int Id { get; set; }

    public int PlayerId { get; set; }
    public mdPlayer Player { get; set; } = null!;

    public int MatchId { get; set; }
    public mdMatch Match { get; set; } = null!;

    public int Stars { get; set; }
    public string? Comment { get; set; }
}