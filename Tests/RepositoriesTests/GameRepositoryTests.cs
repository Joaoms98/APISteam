using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.RepositoriesTests
{
    [TestClass]
    public class GameRepositoryTests
    {
        private DataContext context;
        private IGameRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            repository = new GameRepository(context);
        }

        [TestMethod]
        [DataRow(20.00)]
        [DataRow(30.00)]
        public void ListWithSmallerPriceAsync_WhenCalled_ReturnSuccess(double price)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            List<Game> data = SetupData(id);

            //Action
            Task<IEnumerable<Game>> actual = repository.ListWithSmallerPriceAsync(price);

            //Assert
            Random random = new Random();
            Assert.AreEqual(8,actual.Result.Count());
            Assert.IsTrue(actual.Result.ElementAt(random.Next(0,8)).Price <= price);
        }

        private List<Game> SetupData(Guid Id)
        {
           //Set Developer
            Developer developer = new Developer
            {
                Id = Guid.NewGuid(),
                Document = "012.712.584/87",
                Account = "teste teste"
            };

            context.Add(developer);

            //Set Publisher
            Publisher publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = "Publisher"
            };

            context.Add(publisher);

            //Set Franchise
            Franchise franchise = new Franchise
            {
                Id = Guid.NewGuid(),
                Name = "Publisher",
                Image = "url_image"
            };

            context.Add(franchise);
            context.SaveChanges();

            //Set Games
            List<Game> games = new List<Game>();

            for(int i=0;i<10;i++)
            {
                games.Add(
                    new Game{
                        Id = Guid.NewGuid(),
                        DeveloperId = developer.Id,
                        PublisherId = publisher.Id,
                        FranchiseId = franchise.Id,
                        Title = $"Title game test {i}",
                        Price = 19.99,
                        Description = "Description test",
                        Logo = "url logo"
                    }
                );
                games.Add(
                    new Game{
                        Id = Guid.NewGuid(),
                        DeveloperId = developer.Id,
                        PublisherId = publisher.Id,
                        FranchiseId = franchise.Id,
                        Title = $"Title game test {i}",
                        Price = 29.99,
                        Description = "Description test",
                        Logo = "url logo"
                    }
                );
            }

            context.AddRange(games);
            context.SaveChanges();

            //Set Comments

            return games;
        }
    }
}