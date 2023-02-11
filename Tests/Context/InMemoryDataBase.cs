using APISteam.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Tests.Context
{
    [TestClass]
    public class InMemoryDataBase 
    {
        private DataContext context;

        public void Setup(){
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName:"apisteam")
            .Options;

            context = new DataContext(options);
        }
        
    }
}