using EFDemo2.Infra.Context;
using EFDemo2.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.Controllers
{
    public class QueryController
    {
        private readonly MovieDbContext dbContext;

        public QueryController(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task GetActors()
        {
            // Deferred Execution
            var query = dbContext.Actors
                              .Where(a => a.FirstName.Contains("A"));

            //int actorCount = query.Count();

            query = query.Where(a => a.LastName.EndsWith("U"));

            var data = query
                .Select(a => new ActorViewModel()
                {
                    Id = a.Id,
                    FullName = a.FirstName + " " + a.LastName
                })
                .ToList();

            foreach (var item in data)
            {
                Console.WriteLine("Data: {0} - {1}", item.Id, item.FullName);
            }

        }

        public class ActorViewModel
        {
            public Guid Id { get; set; }

            public string FullName { get; set; }

            public int MovieCount { get; set; }
        }

        public void QueryableTest()
        {
            var filter = new MovieQueryFilter(MinViewCount: 5,
                                              MaxViewCount: null,
                                              FromCreatedDate: null,
                                              ToCreatedDate: null,
                                              Name: null);

            IQueryable<MovieEntity> query = dbContext.Movies.AsQueryable();

            if (filter.MinViewCount.HasValue)
                query = query.Where(i => i.ViewCount >= filter.MinViewCount.Value);

            if (filter.MaxViewCount.HasValue)
                query = query.Where(i => i.ViewCount <= filter.MaxViewCount.Value);

            if (filter.FromCreatedDate.HasValue)
                query = query.Where(i => i.CreatedDate >= filter.FromCreatedDate.Value);

            if (filter.ToCreatedDate.HasValue)
                query = query.Where(i => i.CreatedDate <= filter.ToCreatedDate.Value);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(i => i.Name.Contains(filter.Name));

            var movies = query.ToList();

            foreach (var item in movies)
            {
                Console.WriteLine("Movie Name : {0}", item.Name);
            }
        }

        public record MovieQueryFilter(int? MinViewCount,
                               int? MaxViewCount,
                               DateTime? FromCreatedDate,
                               DateTime? ToCreatedDate,
                               string Name);



        public void ChangeTrackerTest()
        {
            dbContext.Genres.Add(new GenreEntity()
            {
                CreatedDate = DateTime.Now,
                Name = "Tracking_Test_Genre"
            });

            var firstGenre = dbContext.Genres
                .First(i => i.Name == "Interceptor_Test_Genre");

            firstGenre.Name = "TEST";
            dbContext.Entry(firstGenre).Property(i => i.ModifiedDate).CurrentValue = DateTime.MaxValue;

            dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            //dbContext.Remove(firstGenre);

            Console.WriteLine(dbContext.ChangeTracker.DebugView.LongView);


            //dbContext.SaveChanges();

            //dbContext.ChangeTracker.DetectChanges();
        }



        public void SplitQueryTests()
        {
            //dbContext.Movies
            //         .Include(i => i.Photos)
            //         .AsSplitQuery()
            //         .ToList();

            dbContext.Directors
                     .Include(i => i.Movies)
                     .AsSplitQuery()
                     //.Select(i => new { i.FirstName, i.Movies.Count })
                     .ToList();
        }
    }

}
