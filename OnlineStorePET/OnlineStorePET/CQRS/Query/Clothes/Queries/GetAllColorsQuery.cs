using MediatR;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Queries
{
    public class GetAllColorsQuery : IRequest<List<Color>>
    {

    }
}
