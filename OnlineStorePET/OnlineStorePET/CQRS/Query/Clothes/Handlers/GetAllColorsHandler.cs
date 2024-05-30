using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.CQRS.Query.Clothes.Queries;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Handlers
{
    public class GetAllColorsHandler : IRequestHandler<GetAllColorsQuery, List<Color>>
    {
        private readonly IGeneralGetRepository generalGetRepository;
        public GetAllColorsHandler(IGeneralGetRepository generalGetRepository)
        {
            this.generalGetRepository = generalGetRepository;
        }

        public async Task<List<Color>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            return await generalGetRepository.GetAllColorsAsync().Result.ToListAsync();
        }
    }
}
