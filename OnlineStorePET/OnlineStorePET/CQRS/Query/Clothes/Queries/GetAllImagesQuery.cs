using MediatR;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Queries
{
    public class GetAllImagesQuery : IRequest<List<Image>>
    {
    }
}
