using Catalog.Contracts;
using Catalog.Services.Dtos;
using Catalog.Services.Repository.Entities;
using Commom.Interfaces;
using MassTransit;

namespace Catalog.Services.Application
{
    public class ItemService : IItemService
    {
        private readonly IRepositoryBase<Item> _itemsRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        
        public ItemService(IRepositoryBase<Item> itemsRepository, IPublishEndpoint publishEndpoint)
        {
            _itemsRepository = itemsRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = await _itemsRepository.GetAllAsync();
            return items.Select(item => new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate));
        }

        public async Task<ItemDto?> GetItem(Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            if (item == null)
            {
                return null;
            }
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }

        public async Task<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTime.UtcNow
            };
            await _itemsRepository.CreateAsync(item);
            await _publishEndpoint.Publish(new CatalogItemCreated(item.Id, item.Name, item.Description, item.Price));
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }

        public async Task<bool> UpdateItem(Guid id, ItemDto updatedItem)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            if (item == null)
            {
                return false;
            }

            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            item.Price = updatedItem.Price;

            await _itemsRepository.UpdateAsync(id, item);
            await _publishEndpoint.Publish(new CatalogItemUpdated(item.Id, item.Name, item.Description, item.Price));
            return true;
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            if (item == null)
            {
                return false;
            }

            await _itemsRepository.DeleteAsync(id);
            await _publishEndpoint.Publish(new CatalogItemDeleted(id));
            
            return true;
        }
    }
}
