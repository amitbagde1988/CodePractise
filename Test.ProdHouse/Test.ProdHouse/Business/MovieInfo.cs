using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ProdHouse.Models;

namespace Test.ProdHouse.Business
{
    public class MovieInfo
    {
        public static void Add(Movie newMovie)
        {
            using (Data.ProdHouseEntities dbContext = new Data.ProdHouseEntities())
            {
                dbContext.MoviesInfoes.Add(new Data.MoviesInfo
                {
                    Name = newMovie.Name,
                    Budget = newMovie.Budget,
                    Description = newMovie.Description,
                    Format = newMovie.Format,
                    Genre= String.Join(", ", newMovie.Genre.ToArray()),
                    Language = newMovie.Language,
                    Length = newMovie.MovieLength,
                    Type = newMovie.Type,
                    Status = newMovie.Status
                });
                dbContext.SaveChanges();
            }
        }
        public static bool Print(Movie movie)
        {
            return true;
        }
        public static List<Movie> GetAll()
        {
            using(Data.ProdHouseEntities dbContext = new Data.ProdHouseEntities())
            {
                List<Movie> _movies = new List<Movie>();
                var movies = dbContext.MoviesInfoes.ToList();
                foreach(var _movie in movies)
                {
                    _movies.Add(new Movie
                    {
                        ID = _movie.ID,
                        Name = _movie.Name,
                        Budget = _movie.Budget.Value,
                        Language = _movie.Language
                    });
                }
                return _movies;
            }
        }
        public static Movie GetOne(string name)
        {
            using (Data.ProdHouseEntities dbContext = new Data.ProdHouseEntities())
            {
                var _movie = dbContext.MoviesInfoes.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (_movie == null)
                    return null;
                return new Movie
                {
                    Name = _movie.Name,
                    Budget = _movie.Budget.Value,
                    Description = _movie.Description,
                    Format = _movie.Format,
                    Genre = _movie.Genre.Split(new char[] { ',' }).ToList(),
                    ID =_movie.ID,
                    Language =_movie.Language,
                    MovieLength =_movie.Length,
                    Status = _movie.Status,
                    Type = _movie.Type
                };
            }
        }
    }
}
