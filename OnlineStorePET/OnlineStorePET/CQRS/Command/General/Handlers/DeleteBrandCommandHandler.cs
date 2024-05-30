using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public DeleteBrandCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository= generalActionRepository;
        }

        public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await generalActionRepository.DeleteBrandAsync(request.Id);
        }
    }
}
