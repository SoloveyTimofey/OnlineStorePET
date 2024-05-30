using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineStorePET.CQRS.Query.Clothes.Queries;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Query.Clothes.Handlers
{
    public class GetAllImagesHandler : IRequestHandler<GetAllImagesQuery, List<Image>>
    {
        private readonly IGeneralGetRepository generalGetRepository;
        public GetAllImagesHandler(IGeneralGetRepository generalGetRepository)
        {
            this.generalGetRepository = generalGetRepository;
        }
        public async Task<List<Image>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            return await generalGetRepository.GetAllImagesAsync().Result.ToListAsync();
        }
    }
}
