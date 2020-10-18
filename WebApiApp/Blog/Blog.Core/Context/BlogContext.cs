using Blog.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
           
        }

        public BlogContext ()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Options.Settings.Default.ConnectionStringDevelopment);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            optionsBuilder.UseLazyLoadingProxies(false);
        }

        #region POCOS
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<User> User { get; set; }
        #endregion
    }
}
