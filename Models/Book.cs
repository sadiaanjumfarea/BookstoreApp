namespace BookstoreApp.API.Models;

public class Book
{
    public int Index { get; set; }
    public string ISBN { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<string> Authors { get; set; } = new();
    public string Publisher { get; set; } = null!;
    public int Likes { get; set; }
    public List<Review> Reviews { get; set; } = new();
}