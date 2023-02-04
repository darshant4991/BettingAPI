using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportingGroupAPI.Repository;
using System.Threading.Tasks;
using SportingGroupAPI.Models;
using Moq;
using System.Collections.Generic;
using SportingGroupAPI.Controllers;
using Microsoft.EntityFrameworkCore;


namespace SportingGroupTests
{
    [TestClass]
    public class FixtureServiceTests
    {
        private FixtureBettingContext _context;
        private FixtureServiceController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the context
            var options = new DbContextOptionsBuilder<FixtureBettingContext>()
                .UseInMemoryDatabase(databaseName: "AddFixtureTestDB")
                .Options;

            _context = new FixtureBettingContext(options);
            _controller = new FixtureServiceController(_context);
        }

        [TestMethod]
        public async Task TestAddFixture_WhenAddedWithValidData_ReturnAddedFixture()
        {
            // Arrange
            var fixture = new Fixture
            {
                FixId = 1,
                Sport = "Football",
                Name = "Barcelona vs Real Madrid"
            };

            // Act
            var result = await _controller.AddFixture(fixture);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(fixture.FixId, result.FixId);
            Assert.AreEqual(fixture.Sport, result.Sport);
            Assert.AreEqual(fixture.Name, result.Name);
        }
        [TestMethod]
        public async Task GetFixture_WhenCalledWithValidId_ReturnsFixture()
        {
            // Arrange
            var fixtures = new List<Fixture>
            {
                new Fixture { FixId = 2, Sport = "Football", Name = "England vs Brazil" },
                new Fixture { FixId = 3, Sport = "Basketball", Name = "USA vs Wales" }
            };
            _context.Fixtures.AddRange(fixtures);
            _context.SaveChanges();

            // Act
            var result = await _controller.GetFixture(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.FixId);
            Assert.AreEqual("Basketball", result.Sport);
            Assert.AreEqual("USA vs Wales", result.Name);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

    }
}
