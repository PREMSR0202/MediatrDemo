using MediatrDemo.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Library.Data
{
    public interface IDataRepository
    {
        List<MovieModel> GetMovies();

        MovieModel AddMovie(MovieModel movie);

    }
}
