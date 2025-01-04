using EFDemo.Infra.Entities;
using EFDemo.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFDemo.Infra.Context
{
    public class MovieDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ef");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connstr = configuration.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connstr, options =>
            {
                options.CommandTimeout(5_000);
                options.EnableRetryOnFailure(maxRetryCount : 5);

            });

        }
    }
}
