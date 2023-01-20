using MediatR;
using MediatrDemo.Library.Model;
using MediatrDemo.Library.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Library.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieModel>
    {

        private readonly IMediator mediator;

        public GetMovieByIdHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movies = await this.mediator.Send(new GetMovieListQuery());
            var movie = movies.FirstOrDefault(u => u.Id == request.id);
            return movie;
        }
    }
}
