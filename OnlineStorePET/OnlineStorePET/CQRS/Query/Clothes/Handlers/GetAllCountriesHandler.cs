using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.CQRS.Query.Clothes.Queries;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Handlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, List<Country>>
    {
        private IGeneralGetRepository generalGetRepository;
        public GetAllCountriesHandler(IGeneralGetRepository generalGetRepository)
        {
            this.generalGetRepository = generalGetRepository;
        }
        public async Task<List<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await generalGetRepository.GetAllCountriesAsync().Result.ToListAsync();
        }
    }
}
