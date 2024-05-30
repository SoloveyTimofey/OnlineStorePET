using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public UpdateCountryCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.UpdateCountryAsync(request.Id, request.PatchDoc);
        }
    }
}
