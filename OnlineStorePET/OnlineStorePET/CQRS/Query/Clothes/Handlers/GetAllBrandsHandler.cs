using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.CQRS.Query.Clothes.Queries;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBransQuery, List<Brand>>
    {
        private readonly IGeneralGetRepository generalGetRepository;
        public GetAllBrandsHandler(IGeneralGetRepository generalGetRepository)
        {
            this.generalGetRepository = generalGetRepository;
        }

        public async Task<List<Brand>> Handle(GetAllBransQuery request, CancellationToken cancellationToken)
        {
            return await generalGetRepository.GetAllBrandsAsync().Result.ToListAsync();
        }
    }
}
