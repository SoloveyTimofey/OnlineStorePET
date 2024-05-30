using MediatR;
using StoreDataModels.Clothes;

namespace StoreDataModels.DTO
{
    public record ClothingDTO : ItemDTO, IRequest<Clothing>
    {
        public long CategoryId { get; set; }

        public long? SleeveLenghtId { get;set; }

        public long? FitId { get; set; }
    }
}
