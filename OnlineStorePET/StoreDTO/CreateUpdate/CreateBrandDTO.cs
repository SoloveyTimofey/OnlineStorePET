using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDTO.CreateUpdate
{
    public record CreateBrandDTO
    {
        [Required]
        public string Name = null!;
        public string? Decsription;
        public long CountryId;
    }
}
