using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class DeleteColorCommandHandler: IRequestHandler<DeleteColorCommand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public DeleteColorCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }

        public async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            await generalActionRepository.DeleteColorAsync(request.Id);
        }
    }
}
