using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceApp.Features.Produtos.Commands;
using VerticalSliceApp.Features.Produtos.Queries;

namespace VerticalSliceApp.Features.Produtos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProdutoCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProdutosListQuery());
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProdutoByIdQuery(id));

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProdutoCommand(id));
            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProdutoCommand command)
        {
            if (id != command.Id) return BadRequest("ID não bate");

            var result = await _mediator.Send(command);
            return result.IsSuccess ? NoContent() : NotFound(result.Errors);
        }
    }
}
