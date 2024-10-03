using MediatR;
using VerticalSliceApp.Domain;
using VerticalSliceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using FluentResults;

namespace VerticalSliceApp.Features.Produtos.Queries
{
    public record GetProdutoByIdQuery(Guid Id) : IRequest<Result<Produto>>;

    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Result<Produto>>
    {
        private readonly ProdutoRepository _repository;

        public GetProdutoByIdQueryHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Produto>> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _repository.GetByIdAsync(request.Id);

            if (produto is null)
                return Result.Fail("Produto não encontrado.");

            return Result.Ok(produto);
        }
    }
}
