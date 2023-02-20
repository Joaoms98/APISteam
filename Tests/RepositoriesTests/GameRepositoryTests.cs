using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using APISteam.Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace Tests.RepositoriesTests
{
    [TestClass]
    public class GameRepositoryTests
    {
        private DataContext context;
        private FeaturedAndRecommendsFilter filter;
        private IGameRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            filter = new FeaturedAndRecommendsFilter(context);
            repository = new GameRepository(context, filter);
        }

        [TestMethod]
        [DataRow(20.00)]
        [DataRow(30.00)]
        public void ListWithSmallerPrice_WhenCalled_ReturnSuccess(double price)
        {
            //Arrange
            DropDataBase();
            Guid id = Guid.NewGuid();
            (List<Game>, User) data = SetupData(id);

            //Action
            IEnumerable<Game> actual = repository.ListWithSmallerPriceAsync(price);

            //Assert
            Random random = new Random();
            Assert.AreEqual(8,actual.Count());
            Assert.AreEqual("url logo game assert",actual.ElementAt(0).Logo);
            Assert.IsTrue(actual.ElementAt(random.Next(0,8)).Price <= price);
        }

        [TestMethod]
        public void ListWithSmallerPrice_WhenCalled_ReturnEmpty()
        {
            //Arrange
            DropDataBase();
            Guid id = Guid.NewGuid();
            (List<Game>, User) data = SetupData(id);

            //Action
            IEnumerable<Game> actual = repository.ListWithSmallerPriceAsync(2);

            //Assert
            Assert.AreEqual(0,actual.Count());
        }

        [TestMethod]
        public void ListByRelevance_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            Guid id = Guid.NewGuid();
            (List<Game>, User) data = SetupData(id);

            //Action
            IEnumerable<Game> actual = repository.ListByRelevance(Guid.Empty);

            //Assert
            Assert.AreEqual(id,actual.ElementAt(0).Id);
        }

        [TestMethod]
        public void ListByRelevance_WhenCalledWithUserId_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            Guid id = Guid.NewGuid();
            (List<Game>, User) data = SetupData(id);

            //Action
            IEnumerable<Game> actual = repository.ListByRelevance(data.Item2.Id);

            //Assert
            Assert.AreEqual(id,actual.ElementAt(0).Id);
        }

        private (List<Game>, User) SetupData(Guid id)
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

            //Set Genres
            List<Genre> genres = new List<Genre>();

            genres.Add(new Genre
            {
                Id = Guid.NewGuid(),
                Type = 1,
                Image = "url image"
            });

            genres.Add(new Genre
            {
                Id = Guid.NewGuid(),
                Type = 2,
                Image = "url image"
            });

            genres.Add(new Genre
            {
                Id = Guid.NewGuid(),
                Type = 3,
                Image = "url image"
            });

            context.AddRange(genres);
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
                        Logo = "url logo",
                        PredominantGenre = 1
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

            var gameAssert =  new Game{
                    Id = id,
                    DeveloperId = developer.Id,
                    PublisherId = publisher.Id,
                    FranchiseId = franchise.Id,
                    Title = $"Title game test",
                    Price = 18.99,
                    Description = "Description test",
                    Logo = "url logo game assert",
                    PredominantGenre = 1
                };

            context.AddRange(games);
            context.Add(gameAssert);
            context.SaveChanges();

            //Set GameGenre
            List<GameGenre> gameGenres = new List<GameGenre>();

            gameGenres.Add(new GameGenre
            {
                Id = Guid.NewGuid(),
                GameId = gameAssert.Id,
                GenreId = genres[0].Id
            });

            gameGenres.Add(new GameGenre
            {
                Id = Guid.NewGuid(),
                GameId = gameAssert.Id,
                GenreId = genres[0].Id
            });

            context.AddRange(gameGenres);
            context.SaveChanges();

            //Set Comments
            List<Comment> comments = new List<Comment>();

            comments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                GameId = gameAssert.Id,
                Description = "achei fera",
                Review = true
            });

            comments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                GameId = gameAssert.Id,
                Description = "achei massa",
                Review = true
            });

            context.AddRange(comments);
            context.SaveChanges();

            //Set Videos
            List<Video> videos = new List<Video>();

            videos.Add(new Video
            {   
                GameId = gameAssert.Id,
                Link ="url_Link"
            });

            videos.Add(new Video
            {   
                GameId = gameAssert.Id,
                Link ="url_Link"
            });

            context.AddRange(videos);
            context.SaveChanges();

            //Set Images
            List<Image> images = new List<Image>();

            images.Add(new Image{
                GameId = gameAssert.Id,
                Link = "url_Link"
            });

            images.Add(new Image{
                GameId = gameAssert.Id,
                Link = "url_Link"
            });

            context.AddRange(images);
            context.SaveChanges();

            //Set User
            var user = new User
            {
                Id = Guid.NewGuid(),
                NickName = "RicardoBr",
                Email = "RicardoBr@gmail.com",
                Password = "RicardoBr123",
                Photo = "12312415125"
            };
            context.Add(user);
            context.SaveChanges();

            //Set Library
            List<Library> libraries = new List<Library>(); 
            
            libraries.Add(new Library{
                GameId = gameAssert.Id,
                UserId = user.Id,
                GameHours = 50
            });

            libraries.Add(new Library{
                GameId = games[0].Id,
                UserId = user.Id,
                GameHours = 50
            });

            context.AddRange(libraries);
            context.SaveChanges();

            // //Set SystemRequirements
            // List<SystemRequirement> systemRequirements = new List<SystemRequirement>();

            // systemRequirements.Add(new SystemRequirement{
            //     Id = Guid.NewGuid(),
            //     GameId = gameAssert.Id,
            //     MinMax = 1,
            //     Processor = "Intel core i7",
            //     Memory = "8GB",
            //     Graphics = "Nvidia GForce ",
            //     DirectX = "12X",
            //     Storage = "124GB",
            //     AdditionalInfo = "need a banana hat"
            // });

            // context.AddRange(systemRequirements);
            // context.SaveChanges();

            return (games, user);
        }

        private void DropDataBase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}