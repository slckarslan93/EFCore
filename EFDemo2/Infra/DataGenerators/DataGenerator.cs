using Bogus;
using EFDemo2.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo2.Infra.DataGenerators
{
    internal abstract class DataGenerator
    {
        public static List<ActorEntity> GenerateActors(int count)
        {
            var actorFaker = new Faker<ActorEntity>("tr")
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past(5))
                .RuleFor(a => a.ModifiedDate, f => f.Date.Past(2))
                .RuleFor(a => a.FirstName, f => f.Name.FirstName())
                .RuleFor(a => a.LastName, f => f.Name.LastName())
                //.RuleFor(a => a.Movies, f => [])
                ;

            return actorFaker.Generate(count);
        }

        public static List<MovieEntity> GenerateMovies(int count)
        {
            var locale = "tr";
            var genreFaker = new Faker<GenreEntity>(locale)
                    .RuleFor(g => g.Id, f => Guid.NewGuid())
                    .RuleFor(g => g.CreatedDate, f => f.Date.Past(5))
                    .RuleFor(g => g.ModifiedDate, f => f.Date.Past(2))
                    .RuleFor(g => g.Name, f => f.Commerce.Categories(1).First());

            var directorFaker = new Faker<DirectorEntity>(locale)
                .RuleFor(d => d.Id, f => Guid.NewGuid())
                .RuleFor(d => d.CreatedDate, f => f.Date.Past(5))
                .RuleFor(d => d.ModifiedDate, f => f.Date.Past(2))
                .RuleFor(d => d.FirstName, f => f.Name.FirstName())
                .RuleFor(d => d.LastName, f => f.Name.LastName());

            var genres = genreFaker.Generate(5);
            var directors = directorFaker.Generate(5);
            var actors = GenerateActors(20);

            var movieFaker = new Faker<MovieEntity>(locale)
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.CreatedDate, f => f.Date.Past(5))
                .RuleFor(m => m.ModifiedDate, f => f.Date.Past(2))
                .RuleFor(m => m.Name, f => f.Lorem.Sentence(3))
                .RuleFor(m => m.DirectorId, f => f.PickRandom(directors).Id)
                .RuleFor(m => m.GenreId, f => f.PickRandom(genres).Id)
                .RuleFor(m => m.Director, f => f.PickRandom(directors))
                .RuleFor(m => m.Genre, f => f.PickRandom(genres))
                .RuleFor(m => m.Actors, f => f.PickRandom(actors, f.Random.Int(2, 5)).ToList());




            var movies = movieFaker.Generate(count);




            return movies;
        }
    }
}
