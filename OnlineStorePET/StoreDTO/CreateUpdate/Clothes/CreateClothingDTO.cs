using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDTO.CreateUpdate.Clothes
{
    public record CreateClothingDTO
    {
        [Required]
        public string Name = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price;
        [Required]
        public Gender Gender;

    }
}
