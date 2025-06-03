using Bogus;
using BookstoreApp.API.Models;

namespace BookstoreApp.API.Generators;

public class BookGenerator
{
    public static List<Book> GenerateBooks(string locale, int seed, int page, double avgLikes, double avgReviews, int pageSize = 20)
{
    var fullSeed = seed + page;
    Randomizer.Seed = new Random(fullSeed);


    var faker = new Faker(locale);

    var books = new List<Book>();

    for (int i = 0; i < pageSize; i++)
    {
        int index = ((page - 1) * pageSize) + i + 1;
        var bookSeed = fullSeed + i;

        var bookFaker = new Faker(locale);
        bookFaker.Random = new Randomizer(bookSeed);

        var reviewFaker = new Faker(locale);
        reviewFaker.Random = new Randomizer(bookSeed + 1000);

        var authors = new List<string>();
        authors.Add(bookFaker.Name.FullName());

        if (bookFaker.Random.Double() > 0.7)
        {
            authors.Add(bookFaker.Name.FullName());
        }

        var book = new Book
        {
            Index = index,
            ISBN = faker.Random.Replace("###-#-##-######-#"),
            Title = bookFaker.Lorem.Sentence(3, 5),
            Authors = authors,
            Publisher = bookFaker.Company.CompanyName(),
            Likes = GetProbabilisticCount(avgLikes, bookSeed + 2000),
            Reviews = Enumerable.Range(0, 5)
                        .Where(_ => reviewFaker.Random.Double() < avgReviews / 5.0)
                        .Select(_ => new Review
                        {
                            Reviewer = reviewFaker.Name.FullName(),
                            Content = reviewFaker.Lorem.Sentence()
                        }).ToList()
        };

        books.Add(book);
    }

    return books;
}

private static int GetProbabilisticCount(double avg, int seed)
{
    int floor = (int)Math.Floor(avg);
    double chance = avg - floor;

    var rnd = new Random(seed);
    return floor + (rnd.NextDouble() < chance ? 1 : 0);
}

}
