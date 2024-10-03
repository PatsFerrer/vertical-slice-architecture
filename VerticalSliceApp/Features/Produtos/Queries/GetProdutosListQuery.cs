using FluentResults;
using MediatR;
using VerticalSliceApp.Domain;

namespace VerticalSliceApp.Features.Produtos.Queries
{
    public record GetProdutosListQuery : IRequest<Result<List<Produto>>>;

    public class GetProdutosListQueryHandler : IRequestHandler<GetProdutosListQuery, Result<List<Produto>>>
    {
        private readonly ProdutoRepository _repository;

        public GetProdutosListQueryHandler(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Produto>>> Handle(GetProdutosListQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _repository.GetAllAsync();
            return Result.Ok(produtos);
        }
    }
}
