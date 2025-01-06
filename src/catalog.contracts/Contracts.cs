namespace Catalog.Contracts
{
    public record CatalogItemCreated(Guid Id, string Name, string Description, decimal Price);
    public record CatalogItemUpdated(Guid Id, string Name, string Description, decimal Price);
    public record CatalogItemDeleted(Guid Id);    
}