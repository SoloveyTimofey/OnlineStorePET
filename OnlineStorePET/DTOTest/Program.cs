using StoreDataModels;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;


Brand brand = new Brand()
{
    Id = 1,
    Country = new Country() { Id = 1, Name = "Country" },
    Name = "Brand",
    CountryId = 1,
    Description = "Desc"
};

BrandDTO dto = DTOConverter.MapToDTO<Brand, BrandDTO>(brand);

Console.WriteLine(dto.Name);
Console.WriteLine(dto.Description);
Console.WriteLine(dto.CountryId);

Brand fromDto = DTOConverter.MapFromDTO<BrandDTO, Brand>(dto);

Console.WriteLine(fromDto.Name);

Console.ReadLine();