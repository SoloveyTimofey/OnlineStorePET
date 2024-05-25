using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataModels.DTO
{
    public abstract record ItemDTO
    {
        //public ItemDTO(string Name, string Price, Gender Gender,long ImageId, ICollection<long> Colors, long BrandId)
        //{
        //    this.Name = Name;
        //    this.Gender = Gender;
        //    this.ImageId = ImageId;
        //    this.Colors = Colors;
        //    this.BrandId = BrandId;
        //}
        //public ItemDTO(string Name, string Price, Gender Gender, byte[] ImageBytes, ICollection<long> Colors, long BrandId)
        //{
        //    this.Name = Name;
        //    this.Gender = Gender;
        //    this.ImageBytes = ImageBytes;
        //    this.Colors = Colors;
        //    this.BrandId = BrandId;
        //}

        [Required]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public long? ImageId;
        public byte[] ImageBytes { get; set; } = [];

        public long ColorId { get; set; }

        public long BrandId { get; set; }
    }
}
