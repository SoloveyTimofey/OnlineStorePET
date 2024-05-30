using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class CreateColorCommandHandler : IRequestHandler<ColorDTO, Color>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public CreateColorCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Color> Handle(ColorDTO request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.CreateColorAsync(request);
        }
    }
}
