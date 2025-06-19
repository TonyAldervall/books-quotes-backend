namespace WebAPI.Models.Api
{
    public class CreateQuoteFavoriteModel
    {
        public Guid UserId { get; set; }
        public Guid QuoteId { get; set; }
    }
}
