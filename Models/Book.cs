namespace BookstoreApp.API.Models;

public class Book
{
    public int Index { get; set; }
    public string ISBN { get; set; } = "";
    public string Title { get; set; } = "";
    public List<string> Authors { get; set; } = new();
    public string Publisher { get; set; } = "";
    public int Likes { get; set; }
    public List<Review> Reviews { get; set; } = new();
}
