using MediatR;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Queries
{
    public class GetAllBransQuery : IRequest<List<Brand>>
    {
    }
}
