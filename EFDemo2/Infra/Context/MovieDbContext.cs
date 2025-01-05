using EFDemo2.Infra.Entities;
using EFDemo2.Infra.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<DirectorEntity> Directors { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<ActorEntity> Actors { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ef");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();
                var connStr = configuration.GetConnectionString("SqlServer");

                optionsBuilder.UseSqlServer(connStr, options =>
                {
                    options.MigrationsHistoryTable("__EfMigrationHistory", schema: "ef");
                    options.CommandTimeout(5_000);
                    options.EnableRetryOnFailure(maxRetryCount: 5);
                });
            }
        }
    }

    public class DbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
            var connStr = configuration.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();

            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.MigrationsHistoryTable("__EfMigrationHistory", schema: "ef");
                options.CommandTimeout(5_000);
                options.EnableRetryOnFailure(maxRetryCount: 5);
            });

            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
