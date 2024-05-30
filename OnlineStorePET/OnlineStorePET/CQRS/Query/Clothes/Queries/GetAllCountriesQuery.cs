using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Queries
{
    public class GetAllCountriesQuery : IRequest<List<Country>>
    {
    }
}
