using FluentResults;
using MediatR;
using VerticalSliceApp.Infrastructure.Context;

namespace VerticalSliceApp.Features.Produtos.Commands
{
    public record UpdateProdutoCommand(Guid Id, string Nome, decimal Preco) : IRequest<Result>;

    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Result>
    {
        private readonly ProdutoRepository _repository;

        public UpdateProdutoCommandHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);

            if (produto is null)
                return Result.Fail("Produto não encontrado");

            produto.Update(request.Nome, request.Preco);
            await _repository.UpdateAsync(produto);

            return Result.Ok();
        }
    }
}
