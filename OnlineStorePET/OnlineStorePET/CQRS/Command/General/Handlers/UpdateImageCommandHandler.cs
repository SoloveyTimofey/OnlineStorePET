using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, Image>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public UpdateImageCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public Task<Image> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            return generalActionRepository.UpdateImageAsync(request.Id, request.PatchDoc);
        }
    }
}
