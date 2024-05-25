namespace StoreDataModels.DTO
{
    public record ClothingDTO : ItemDTO
    {
        //public ClothingDTO(ItemDTO original) : base(original)
        //{
        //}

        public long CategoryId { get; set; }

        public long? SleeveLenghtId { get;set; }

        public long? FitId { get; set; }
    }
}
