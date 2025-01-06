using Catalog.Services.Dtos;

namespace Catalog.Services.Application
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItems();
        Task<ItemDto?> GetItem(Guid id);
        Task<ItemDto> CreateItem(CreateItemDto createItemDto);
        Task<bool> UpdateItem(Guid id, ItemDto updatedItem);
        Task<bool> DeleteItem(Guid id);
    }
}
