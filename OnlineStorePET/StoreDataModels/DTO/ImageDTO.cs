using System.ComponentModel.DataAnnotations;

namespace StoreDataModels.DTO;

public record ImageDTO
{
    public string? Description { get; set; }
    public byte[] ImageBytes { get; set; } = null!;
    public ICollection<long> Items { get; set; } = [];
}
