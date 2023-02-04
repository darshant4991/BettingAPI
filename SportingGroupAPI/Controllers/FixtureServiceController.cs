using SportingGroupAPI.Models;
using SportingGroupAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace SportingGroupAPI.Controllers
{
    public class FixtureServiceController : ControllerBase
    {
        private readonly FixtureBettingContext _context;

        public FixtureServiceController(FixtureBettingContext context)
        {
            _context = context;
        }
        [Microsoft.AspNetCore.Mvc.Route("[controller]/AddFixture")]
        public async Task<Fixture> AddFixture(Fixture fixture)
        {
            _context.Fixtures.Add(fixture);
            await _context.SaveChangesAsync();
            return fixture;
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/GetFixture/{id}")]
        public async Task<Fixture> GetFixture(int id)
        {
            return await _context.Fixtures.FindAsync(id);
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/GetFixtures")]
        public async Task<List<Fixture>> GetFixtures()
        {
            List<Fixture> fixtures = new List<Fixture>();
            fixtures = await _context.Fixtures.ToListAsync();
            return fixtures;
        }
    }
}
