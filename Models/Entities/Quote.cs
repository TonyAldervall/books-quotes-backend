namespace WebAPI.Models.Entities
{
    public class Quote
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public required string Author { get; set; }
        public ICollection<QuoteFavorite> QuoteFavorites { get; set; } = new List<QuoteFavorite>();
    }
}