using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Entities
{
    public class QuoteFavorite
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Quote")]
        public Guid QuoteId { get; set; }


        public User User { get; set; } = null!;
        public Quote Quote { get; set; } = null!;
    }
}
