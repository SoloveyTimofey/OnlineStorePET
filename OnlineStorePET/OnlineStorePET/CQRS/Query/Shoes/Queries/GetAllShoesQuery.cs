using MediatR;
using StoreDataModels.Shoes;

namespace OnlineStorePET.CQRS.Query.Shoes.Queries
{
    public class GetAllShoesQuery : IRequest<List<Shoe>>
    {
    }
}
