namespace WebAPI.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<QuoteFavorite> QuoteFavorites { get; set; } = new List<QuoteFavorite>();
    }
}
