using BookArchiveAPI.Models;

namespace BookArchiveAPI.Data
{
    public class DataSeeder
    {
        public static void Seed(BookArchiveDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "1984",
                        Author = "George Orwell",
                        Genre = BookGenre.Dystopian,
                        YearPublished = 1949,
                        Summary = "A dystopian novel set in a totalitarian society under constant surveillance.",
                        Note = "A classic of modern literature.",
                        CoverImageUrl = "https://example.com/1984.jpg",
                        Publisher = "Secker & Warburg",
                        PageCount = 328,
                        CreatedAt = DateTime.UtcNow,
                        Format = BookFormat.Hardcover,
                        Language = BookLanguage.English
                    },
                    new Book
                    {
                        Title = "Animal Farm",
                        Author = "George Orwell",
                        Genre = BookGenre.PoliticalSatire,
                        YearPublished = 1945,
                        Summary = "A satirical allegory of the Russian Revolution and the rise of Stalinism.",
                        Note = "A powerful critique of totalitarianism.",
                        CoverImageUrl = "https://example.com/animal_farm.jpg",
                        Publisher = "Secker & Warburg",
                        PageCount = 112,
                        CreatedAt = DateTime.UtcNow,
                        Format = BookFormat.Paperback,
                        Language = BookLanguage.English
                    },
                    new Book
                    {
                        Title = "Brave New World",
                        Author = "Aldous Huxley",
                        Genre = BookGenre.ScienceFiction,
                        YearPublished = 1932,
                        Summary = "A dystopian novel that explores a technologically advanced society that sacrifices individuality for stability.",
                        Note = "A thought-provoking exploration of technology and society.",
                        CoverImageUrl = "https://example.com/brave_new_world.jpg",
                        Publisher = "Chatto & Windus",
                        PageCount = 268,
                        CreatedAt = DateTime.UtcNow,
                        Format = BookFormat.Ebook,
                        Language = BookLanguage.English
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
