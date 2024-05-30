using MediatR;
using OnlineStorePET.CQRS.Command.General.Commands;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Handlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Brand>
    {
        private readonly IGeneralActionRepository generalActionRepository;
        public UpdateBrandCommandHandler(IGeneralActionRepository generalActionRepository)
        {
            this.generalActionRepository = generalActionRepository;
        }

        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            return await generalActionRepository.UpdateBrandAsync(request.Id, request.PatchDoc);
        }
    }
}
