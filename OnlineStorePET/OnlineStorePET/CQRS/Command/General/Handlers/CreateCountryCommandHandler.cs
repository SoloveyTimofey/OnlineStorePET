using MediatR;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;
using StoreDataModels.DTO;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CountryDTO, Country>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public CreateCountryCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }
        public async Task<Country> Handle(CountryDTO request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.CreateCountryAsync(request);
        }
    }
}
