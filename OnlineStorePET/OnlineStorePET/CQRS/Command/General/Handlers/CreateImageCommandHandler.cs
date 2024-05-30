using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class CreateImageCommandHandler : IRequestHandler<ImageDTO, Image>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public CreateImageCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Image> Handle(ImageDTO request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.CreateImageAsync(request);
        }
    }
}
