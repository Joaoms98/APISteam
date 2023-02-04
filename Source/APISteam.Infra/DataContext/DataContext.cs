using APISteam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.DataContext
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Developer> Developer { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Video> Video { get; set; }



    }
}