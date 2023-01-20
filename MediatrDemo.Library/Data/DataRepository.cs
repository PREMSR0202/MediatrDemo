using MediatrDemo.Library.Model;

namespace MediatrDemo.Library.Data
{
    public class DataRepository : IDataRepository
    {

        private readonly DbContexts dbContexts;

        public DataRepository(DbContexts dbContexts)
        {
            this.dbContexts = dbContexts;
        }


        //private List<MovieModel> movies = new()
        //{
        //    new MovieModel {Id = 1,Title = "ABC", Description = "ABC"},
        //    new MovieModel {Id = 2,Title = "ABC", Description = "ABC"},
        //    new MovieModel {Id = 3,Title = "ABC", Description = "ABC"},
        //    new MovieModel {Id = 4,Title = "ABC", Description = "ABC"},
        //    new MovieModel {Id = 5,Title = "ABC", Description = "ABC"},
        //};

        public MovieModel AddMovie(MovieModel movie)
        {

            movie.Id = Guid.NewGuid();
            this.dbContexts.MovieModel.Add(movie);
            this.dbContexts.SaveChangesAsync();
            //this.movies.Add(new MovieModel
            //{ Id = movie.Id, Title = movie.Title, Description = movie.Description }
            //);

            //movies.ForEach((movie) =>
            //{
            //    Console.WriteLine($"Id = {movie.Id}, " +
            //        $"Title = {movie.Title}, " +
            //        $"Description = {movie.Description}");
            //});
            return movie;
        }

        public List<MovieModel> GetMovies()
        {
            return this.dbContexts.MovieModel.ToList();
        }

    }
}
