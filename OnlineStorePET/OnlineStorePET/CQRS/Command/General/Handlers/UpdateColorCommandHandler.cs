using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, Color>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public UpdateColorCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Color> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.UpdateColorAsync(request.Id, request.patchDoc);
        }
    }
}
