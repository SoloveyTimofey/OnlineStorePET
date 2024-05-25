using System.ComponentModel.DataAnnotations.Schema;

namespace LoadingImagesToDB.Models
{
    public class ImageModel
    {
        public long Id { get; set; }
        [Column(TypeName= "varbinary(MAX)")]
        public byte[] Image { get; set; } = null!;
    }
}
