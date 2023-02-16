
using APISteam.Core.Enums;
using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.RepositoriesTests
{   
    [TestClass]
    public class GenreRepositoryTest
    {
        private DataContext context;
        private IGenreRepository repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            repository = new GenreRepository(context);
        }

        [TestMethod]
        public void ListAllGenreAsync_WhenCalled_ReturnSuccess()
        {
            //Arrange
            SetupGenres();

            //Action
            IEnumerable<Genre> actual = repository.ListAllAsync();

            //Assert   
            Assert.AreEqual(actual.Count(), 25);
            Assert.AreEqual(actual.ElementAt(1).Type, 0);
        }

        [TestMethod]
        public void ListAllGenreAsync_WhenCalled_ReturnEmpty()
        {
            //Arrange
            DropDataBase();

            //Action
            IEnumerable<Genre> actual = repository.ListAllAsync();

            //Assert   
            Assert.AreEqual(0, actual.Count());
        }

        private void SetupGenres()
        {
            var genres = new List<Genre>();

            for(int i=0; i<25; i++)
            {
                genres.Add(new Genre
                {
                    Id= Guid.NewGuid(),
                    Type= (int)GenreTypeEnum.Action,
                    Image= $"Url_image{i}"
                });
            }
            
            context.AddRange(genres);
            context.SaveChanges();
        }

        private void DropDataBase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}