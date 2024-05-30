using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStorePET.CQRS.Query.Shoes.Queries;
using OnlineStorePET.Services.Interfaces.Repositories;
using StoreDataModels.Shoes;

namespace OnlineStorePET.CQRS.Query.Shoes.Handlers
{
    public class GetAllShoesHandler : IRequestHandler<GetAllShoesQuery, List<Shoe>>
    {
        private readonly IShoeGetRepository shoeGetRepository;
        public GetAllShoesHandler(IShoeGetRepository shoeGetRepository)
        {
            this.shoeGetRepository = shoeGetRepository;
        }

        public async Task<List<Shoe>> Handle(GetAllShoesQuery request, CancellationToken cancellationToken)
        {
            return await shoeGetRepository.GetAllShoesAsync().Result.ToListAsync();
        }
    }
}
