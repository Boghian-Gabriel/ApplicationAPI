using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    #region "ContextDB class"
    public class ContextDB : DbContext
    {
        #region "constructor"
        public ContextDB(DbContextOptions<ContextDB> option)
            : base(option)
        {
        }
        #endregion

        #region "properties"
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<ActorAdress> ActorAdress { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        #endregion

        #region "OnModelCreating"
        //Fluent API add default value from DB 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        #endregion     
    }
    #endregion
}
