using MediatR;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.Data;
using MediatrDemo.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Library.Handlers
{
    public class AddMoviesHandler : IRequestHandler<AddMoviesCommand, MovieModel>
    {

        private readonly IDataRepository dataRepository;

        public AddMoviesHandler(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public async Task<MovieModel> Handle(AddMoviesCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dataRepository.AddMovie(request.Model));
        }
    }
}
