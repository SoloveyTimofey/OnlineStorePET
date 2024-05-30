using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDataModels.DTO
{
    public record ShoeSizeJunctionDTO : IRequest<ShoeSizeJunctionDTO>
    {
        public long Quantity { get; set; }

        public long ShoeSizeId { get; set; }

        public long ShoeId { get; set; }
    }
}
