using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public DeleteImageCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            return generalActionRepository.DeleteImageAsync(request.Id);
        }
    }
}
