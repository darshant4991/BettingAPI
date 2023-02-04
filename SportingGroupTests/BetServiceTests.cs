using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportingGroupAPI.Repository;
using System.Threading.Tasks;
using SportingGroupAPI.Controllers;
using SportingGroupAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SportingGroupTests
{
    [TestClass]
    public class BetServiceTests
    {
        private FixtureBettingContext _context;
        private BettingServiceController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the context
            var options = new DbContextOptionsBuilder<FixtureBettingContext>()
                .UseInMemoryDatabase(databaseName: "AddFixtureTestDB")
                .Options;

            _context = new FixtureBettingContext(options);
            _controller = new BettingServiceController(_context);
        }
        [TestMethod]
        public async Task GetBet_ReturnsExpectedBet()
        {
            // Arrange
            var expectedBet = new Bet
            {
                Id = 1,
                FixtureId = 4,
                Fixture = new Fixture
                {
                    FixId = 4,
                    Sport = "Cricket",
                    Name = "India vs England"
                },
                MatchWinner = "India",
                IsWinner = true
            };

            _context.Bets.Add(expectedBet);
            await _context.SaveChangesAsync();


            // Act
            var bet = await _controller.GetBet(1);

            // Assert
            Assert.IsNotNull(bet);
            Assert.AreEqual(expectedBet.Id, bet.Id);
            Assert.AreEqual(expectedBet.FixtureId, bet.FixtureId);
            Assert.AreEqual(expectedBet.Fixture.FixId, bet.Fixture.FixId);
            Assert.AreEqual(expectedBet.Fixture.Sport, bet.Fixture.Sport);
            Assert.AreEqual(expectedBet.Fixture.Name, bet.Fixture.Name);
            Assert.AreEqual(expectedBet.MatchWinner, bet.MatchWinner);
            Assert.AreEqual(expectedBet.IsWinner, bet.IsWinner);
        }
    }
}
