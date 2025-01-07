using EFDemo2.Infra.Context;
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
    }
}
