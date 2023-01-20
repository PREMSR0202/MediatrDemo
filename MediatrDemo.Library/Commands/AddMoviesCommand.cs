using MediatR;
using MediatrDemo.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Library.Commands
{
    public record AddMoviesCommand(MovieModel Model) : IRequest<MovieModel>;
}
