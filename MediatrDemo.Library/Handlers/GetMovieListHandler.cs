using MediatR;
using MediatrDemo.Library.Data;
using MediatrDemo.Library.Model;
using MediatrDemo.Library.Queries;


namespace MediatrDemo.Library.Handlers
{
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, List<MovieModel>>
    {
        private readonly IDataRepository _repository;

        public GetMovieListHandler(IDataRepository repository)
        {
            _repository = repository;
        }

        public Task<List<MovieModel>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetMovies());
        }
    }
}
