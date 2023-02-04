using SportingGroupAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SportingGroupAPI.Repository
{
    public class FixtureBettingContext : DbContext
    {
        public FixtureBettingContext(DbContextOptions<FixtureBettingContext> options) : base(options)
        {
        }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}
