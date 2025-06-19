using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Api;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteFavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuoteFavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("favorites/{userId}")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetFavoriteQuoteIds(Guid userId)
        {
            var favoriteQuotes = await _context.QuoteFavorites
                .Where(qf => qf.UserId == userId)
                .Include(qf => qf.Quote)
                .Select(qf => qf.Quote)
                .ToListAsync();

            return Ok(favoriteQuotes);
        }

        [HttpPost]
        public async Task<IActionResult> PostFavorite([FromBody] CreateQuoteFavoriteModel model)
        {
            var user = await _context.Users.FindAsync(model.UserId);
            if (user == null)
                return NotFound("Användaren hittades inte");

            var quote = await _context.Quotes.FindAsync(model.QuoteId);
            if (quote == null)
                return NotFound("Citat hittades inte");

            var favorite = new QuoteFavorite
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                QuoteId = model.QuoteId
            };

            _context.QuoteFavorites.Add(favorite);
            await _context.SaveChangesAsync();

            return Ok(new { favorite.Id });
        }

        [HttpDelete("{userId}/{quoteId}")]
        public async Task<IActionResult> DeleteFavorite(Guid userId, Guid quoteId)
        {
            var favorite = await _context.QuoteFavorites
                .FirstOrDefaultAsync(qf => qf.UserId == userId && qf.QuoteId == quoteId);

            if (favorite == null)
            {
                return NotFound("Favoriten hittades inte");
            }

            _context.QuoteFavorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
