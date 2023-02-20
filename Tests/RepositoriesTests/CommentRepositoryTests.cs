using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.RepositoriesTests
{
    [TestClass]
    public class CommentRepositoryTests
    {

        private DataContext context;
        private ICommentRepository repository;


        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            repository = new CommentRepository(context);
        }

        [TestMethod]
        public void ListCommentsById_WhenCalled_ReturnSuccess()
        {
            //Arrange
            Guid id = Guid.NewGuid();     
            (List<Comment>,List<Game>) data = SetupData(id);

            //Action
            IEnumerable<Comment> actual = repository.ListByGameId(id);

            //Assert
            Assert.AreEqual("achei fera", actual.ElementAt(0).Description);

        }

        [TestMethod]
        public void ListCommentsById_WhenCalled_ReturnEmpty()
        {
            //Arrange
            Guid id = Guid.NewGuid();     
            (List<Comment>,List<Game>) data = SetupData(id);

            //Action
            IEnumerable<Comment> actual = repository.ListByGameId(data.Item2[0].Id);

            //Assert
            Assert.AreEqual(0, actual.Count());
            

        } 

        private(List<Comment>,List<Game>) SetupData(Guid id)
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

            List<Game> games = new List<Game>();

            for (int i = 0; i < 10; i++)
            {
                games.Add(
                    new Game
                    {
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
                    new Game
                    {
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
                    Logo = "url logo game assert"
                };            

            context.AddRange(games);
            context.Add(gameAssert);            
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


            //Set Comments
            List<Comment> comments = new List<Comment>();

            comments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                GameId = gameAssert.Id,
                Description = "achei fera",
                Review = true,
                CreatedAt = DateTime.Now
            });

            comments.Add(new Comment
            {
                Id = Guid.NewGuid(),
                GameId = gameAssert.Id,
                Description = "achei massa",
                Review = true,
                CreatedAt = DateTime.Now
            });

            context.AddRange(comments);
            context.SaveChanges();

            return (comments,games);
        }


    }
}