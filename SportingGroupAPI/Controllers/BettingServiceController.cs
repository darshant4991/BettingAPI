using SportingGroupAPI.Models;
using SportingGroupAPI.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace SportingGroupAPI.Controllers
{
    public class BettingServiceController : ControllerBase
    {
        private readonly FixtureBettingContext _context;

        public BettingServiceController(FixtureBettingContext context)
        {
            _context = context;
        }
        [Microsoft.AspNetCore.Mvc.Route("[controller]/PlaceBet")]
        public async Task<Bet> PlaceBet(int fixtureId, string matchwinner)
        {
            var fixture = await _context.Fixtures.FindAsync(fixtureId);
            if (fixture == null || matchwinner == null)
            {
                return null;
            }

            var existingBet = await _context.Bets.FirstOrDefaultAsync(b => b.FixtureId == fixtureId);
            if (existingBet != null)
            {
                return null;
            }

            var bet = new Bet
            {
                FixtureId = fixtureId,
                Fixture = fixture,
                MatchWinner = matchwinner,
                IsWinner = null
            };

            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();
            return bet;
        }
        [Microsoft.AspNetCore.Mvc.Route("[controller]/GetBet/{id}")]
        public async Task<Bet> GetBet(int id)
        {
            return await _context.Bets.FindAsync(id);
        }
        [Microsoft.AspNetCore.Mvc.Route("[controller]/GetBetResult/{id}")]
        public async Task<bool?> GetBetResult(int id)
        {
            var bet = await _context.Bets.FirstOrDefaultAsync(b => b.Id == id);
            return bet?.IsWinner;
        }
    }
}
