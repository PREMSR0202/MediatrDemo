using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MediatrDemo.Library.Model;

namespace MediatrDemo.Library.Queries
{
   public record GetMovieListQuery : IRequest<List<MovieModel>>;
}
