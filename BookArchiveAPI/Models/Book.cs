using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookArchiveAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookGenre Genre { get; set; }

        public int? YearPublished { get; set; }
        public string? Summary { get; set; }
        public string? Note { get; set; }
        public string PreviewImage { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? Publisher { get; set; }
        public int? PageCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookFormat Format { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookLanguage Language { get; set; }
    }

    public enum BookGenre
    {
        Fiction,
        NonFiction,
        Mystery,
        ScienceFiction,
        Fantasy,
        Biography,
        History,
        Romance,
        Thriller,
        Horror,
        SelfHelp,
        Children,
        YoungAdult,
        Dystopian,
        PoliticalSatire,
    }

    public enum BookFormat
    {
        Hardcover,
        Paperback,
        Ebook,
        Audiobook
    }

    public enum BookLanguage
    {
        English,
        German,
        Russian,
        Arabic,
    }
}
