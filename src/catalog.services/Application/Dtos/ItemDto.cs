using System.ComponentModel.DataAnnotations;

namespace Catalog.Services.Dtos
{
    public record ItemDto(
        Guid Id, 
        [Required] string Name, 
        [Required] string Description, 
        [Range(0, double.MaxValue)] decimal Price, 
        DateTime CreatedDate);

    public record CreateItemDto(
        [Required] string Name, 
        [Required] string Description, 
        [Range(0, double.MaxValue)] decimal Price);

    public record UpdateItemDto(
        Guid Id, 
        [Required] string Name, 
        [Required] string Description, 
        [Range(0, double.MaxValue)] decimal Price);
}