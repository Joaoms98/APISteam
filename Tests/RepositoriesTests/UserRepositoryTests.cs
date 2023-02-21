using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.RepositoriesTests
{   
    [TestClass]
    public class UserRepositoryTests
    {
        private DataContext context;
        private IUserRepository repository;


      [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            repository = new UserRepository(context);
        }    
        
        [TestMethod]
        public void CreatedUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            var email = "Ok@gmail.com";
            //Action
            repository.Create(email: email,password: "1234",nickName: "RicardoBr",country: "Brasil");
            //Assert
            Assert.AreEqual(email,context.User.Where(u => u.Email == email).FirstOrDefault().Email);
        }

        [TestMethod]
        public void UpdateUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            User user = SetupUsers();
            //Action
            repository.Update(user.Id,"CanelaArg","12345","Victor","Um cara legal","Argentina","Santa Fé",
            "Venado Tuerto","1231254251asdasdasda");
            //Assert
            var actual = context.User.Find(user.Id);
            Assert.AreEqual("CanelaArg",actual.NickName);
            Assert.AreEqual("Um cara legal",actual.Resume);
            Assert.AreEqual("Argentina",actual.Country);

        }
        
        private User SetupUsers()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                NickName = "CanelinhaBr",
                Email = "canelabr@gmail.com",
                Password = "1235",
                Country = "Brasil"
            };
            context.Add(user);
            context.SaveChanges();

            return user;
        }
        
        
        }
}