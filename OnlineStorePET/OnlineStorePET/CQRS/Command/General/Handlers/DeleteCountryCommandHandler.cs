using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public DeleteCountryCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            await generalActionRepository.DeleteCountryAsync(request.Id);
        }
    }
}
