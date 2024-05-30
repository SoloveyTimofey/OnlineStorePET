using MediatR;
using StoreDataModels.Shoes;

namespace StoreDataModels.DTO
{
    public record ShoeDTO : ItemDTO, IRequest<Shoe>
    {

       public long CategoryId { get; set; }
    }
}
