using FluentResults;
using MediatR;
using VerticalSliceApp.Domain;

namespace VerticalSliceApp.Features.Produtos.Commands
{
    public record CreateProdutoCommand(string Nome, decimal Preco) : IRequest<Result<Guid>>;

    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Result<Guid>>
    {
        private readonly ProdutoRepository _repository;

        public CreateProdutoCommandHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.Preco);
            await _repository.AddAsync(produto);

            return Result.Ok(produto.Id);
        }
    }
}
