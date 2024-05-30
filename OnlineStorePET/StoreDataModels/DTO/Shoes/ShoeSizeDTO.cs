using MediatR;
using StoreDataModels.Shoes;
using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO
{
    public record ShoeSizeDTO: IRequest<ShoeSize>
    {
        public long Id { get; set; }

        [Range(20, 55)]
        public byte Size { get;set; }
    }
}
