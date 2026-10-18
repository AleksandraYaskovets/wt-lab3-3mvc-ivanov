namespace wt_lab3_3mvc_ivanov.Models;

public class Track
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string ArtistName { get; set; } = "";
    public int DurationSeconds { get; set; }
}