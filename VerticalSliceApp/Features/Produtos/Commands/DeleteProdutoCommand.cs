using FluentResults;
using MediatR;
using VerticalSliceApp.Infrastructure.Context;

namespace VerticalSliceApp.Features.Produtos.Commands
{
    public record DeleteProdutoCommand(Guid Id) : IRequest<Result>;

    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Result>
    {
        private readonly ProdutoRepository _repository;

        public DeleteProdutoCommandHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);

            if (produto is null)
                return Result.Fail("Produto não encontrado");

            await _repository.DeleteAsync(produto);

            return Result.Ok();
        }
    }
}
