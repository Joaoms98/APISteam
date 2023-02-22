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
        private FakeDataHelper fakeDataHelper;
        private IUnitOfWork unitOfWork;
        
        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "apisteam")
            .Options;

            context = new DataContext(options);
            fakeDataHelper = new FakeDataHelper(context);
            unitOfWork = new UnitOfWork(context);
        }

        [TestMethod]
        public void CreatedUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            var email="Ok@gmail.com";
            //Action
            unitOfWork.UserRepository.Create(email: email,password: "1234",nickName: "RicardoBr",country: "Brasil");
            //Assert
            Assert.AreEqual(email,context.User.Where(u => u.Email == email).FirstOrDefault().Email);
        }

        [TestMethod]
        public void UpdateUser_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            var id = Guid.NewGuid();
            User user = fakeDataHelper.SetupUser(new User{Id=id});

            //Action
            unitOfWork.UserRepository.Update(id,"CanelaArg","12345","Victor","Um cara legal","Argentina","Santa Fé",
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
            DropDataBase();
            var id = Guid.NewGuid();
            User user = fakeDataHelper.SetupUser(new User{Id=id});

            //Action
            unitOfWork.UserRepository.Delete(id);

            //Assert
            var actual = context.User.Find(id);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetUserById_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            var id = Guid.NewGuid();
            User user = fakeDataHelper.SetupUser(new User{Id=id});

            //Action
            var actual =  unitOfWork.UserRepository.GetById(id);

            //Assert
            Assert.AreEqual(actual.Id,id);
        }

        [TestMethod]
        public void ListAllUsers_WhenCalled_ReturnSuccess()
        {
            //Arrange
            DropDataBase();
            for(int i=0;i<25;i++)
            {
                fakeDataHelper.SetupUser();
            }

            //Action
            var actual = unitOfWork.UserRepository.ListAll();

            //Assert
            Assert.AreEqual(25, actual.Count());
        }

        [TestMethod]
        public void ListUserByNickName_WhenCalled_ReturnSucess()
        {
            //Arrange
            DropDataBase();
            fakeDataHelper.SetupUser(new User{NickName = "Canela_depressiva"});
            fakeDataHelper.SetupUser(new User{NickName = "Canela_com_banana"});

            for(int i=0;i<10;i++)
            {
                fakeDataHelper.SetupUser();
            }

            //Action
            var actual =  unitOfWork.UserRepository.ListByNickName("Canela");

            //Assert
            Assert.IsTrue(actual.Where(a => a.NickName.Contains("Canela")).Count() == 2);
        }

        private void DropDataBase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        
    }
}