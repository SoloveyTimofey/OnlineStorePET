using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class CreateBrandCommandHandler : IRequestHandler<BrandDTO, Brand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public CreateBrandCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Brand> Handle(BrandDTO request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.CreateBrandAsync(request);
        }
    }
}
