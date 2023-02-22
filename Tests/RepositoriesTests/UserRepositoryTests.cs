using APISteam.Domain.Entities;
using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using APISteam.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.Helpers;

namespace Tests.RepositoriesTests
{   
    [TestClass]
    public class UserRepositoryTests
    {
        private DataContext context;
        private IUserRepository repository;
        private FakeDataHelper fakeDataHelper;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            fakeDataHelper = new FakeDataHelper(context);
            context = new DataContext(options);
            repository = new UserRepository(context);
        }    
        
        [TestMethod]
        public void CreatedUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            var email="Ok@gmail.com";
            //Action
            repository.Create(email: email,password: "1234",nickName: "RicardoBr",country: "Brasil");
            //Assert
            Assert.AreEqual(email,context.User.Where(u => u.Email == email).FirstOrDefault().Email);
        }

        [TestMethod]
        public void UpdateUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            var id = Guid.NewGuid();
            User user = fakeDataHelper.SetupUser(new User{Id=id});

            //Action
            repository.Update(id,"CanelaArg","12345","Victor","Um cara legal","Argentina","Santa Fé",
            "Venado Tuerto","1231254251asdasdasda");

            //Assert
            var actual = context.User.Find(id);
            Assert.AreEqual("CanelaArg",actual.NickName);
            Assert.AreEqual("Um cara legal",actual.Resume);
            Assert.AreEqual("Argentina",actual.Country);
        }

        [TestMethod]
        public void DeleteUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            User user = SetupUser();
            //Action
            repository.Delete(user.Id);
            //Assert
            var actual = context.User.Find(user.Id);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetUserById_WhenCalled_ReturnSuccess()
        {
            //Arrange
            User user = SetupUser();
            //Action
            var actual = repository.GetById(user.Id);
            //Assert
            Assert.AreEqual(actual.Id,user.Id);
        }

        [TestMethod]
        public void ListAllUsers_WhenCalled_ReturnSucess()
        {
            //Arrange
            List<User> user = SetupListUsers();
            //Action
            var actual = repository.ListAll();
            //Assert
            Assert.AreEqual(actual.Count(),user.Count());
        }

        [TestMethod]
        public void ListUserByNickName_WhenCalled_ReturnSucess()
        {
            //Arrange
            List<User> users = SetupListUsers();
            //Action
            var actual = repository.ListByNickName("Canela");
            //Assert
            Assert.IsTrue(actual.Where(a => a.NickName.Contains("Canela")).Count() == 10);
        }
        
        private User SetupUser()
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
        
        private List<User> SetupListUsers()
        {
            List<User> users = new List<User>();

            for(int i=0;i<10;i++)
            {
                users.Add
                (
                 new User
                 {
                    Id = Guid.NewGuid(),
                    Email = $"canelinha{i}@gmail.com",
                    Password = "1234",
                    Country = "Brasil",
                    NickName = $"CanelaBr{i}"
                 }
                );
            }

             var user = new User()
            {
                Id = Guid.NewGuid(),
                NickName = "51Br",
                Email = "51Br@gmail.com",
                Password = "1235",
                Country = "Brasil"
            };
            
            context.Add(user);
            context.AddRange(users);
            context.SaveChanges();

            return users;
            
        }
        
        private void DropDataBase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        
    }
}