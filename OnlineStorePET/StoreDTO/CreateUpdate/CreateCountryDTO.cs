using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDTO.CreateUpdate
{
    public class CreateCountryDTO
    {
        [Required]
        public string Name = null!;
    }
}
