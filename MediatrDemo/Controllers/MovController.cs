using MediatR;
using MediatrDemo.Library.Commands;
using MediatrDemo.Library.Handlers;
using MediatrDemo.Library.Model;
using MediatrDemo.Library.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatrDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovController : ControllerBase
    {
        public IMediator _mediator;
        public ILogger _logger;

        public MovController(IMediator mediator, ILogger logger) 
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<MovieModel>> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");
            var text = await response.Content.ReadAsStringAsync();
            console.writeline(text);
            return await _mediator.Send(new GetMovieListQuery());
        }

        [HttpGet("{id}")]
        public async Task<MovieModel> Get(Guid id)
        {
            return await _mediator.Send(new GetMovieByIdQuery(id));
        }

        [HttpPost]
        public async Task<MovieModel> Post(MovieModel model)
        {
            return await _mediator.Send(new AddMoviesCommand(model));
        }
    }
}
