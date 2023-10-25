using System;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;

public class CatalogItem : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int CurrentStock { get; set; }
    public int PendingRestock { get; set; }
    public int CatalogTypeId { get; set; }
    public CatalogType? CatalogType { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrand? CatalogBrand { get; set; }

    public CatalogItem()
    {
        Name = "";
        Description = "";

        PictureUri = "";
    }
    public CatalogItem(int catalogTypeId,
        int catalogBrandId,
        string description,
        string name,
        decimal price,
        string pictureUri,
        int currentStock = 0,
        int pendingRestock = 0)
    {
        CatalogTypeId = catalogTypeId;
        CatalogBrandId = catalogBrandId;
        Description = description;
        Name = name;
        Price = price;
        PictureUri = pictureUri;
        CurrentStock = currentStock;
        PendingRestock = pendingRestock;
    }

    public void UpdateDetails(CatalogItemDetails details)
    {
        Guard.Against.NullOrEmpty(details.Name, nameof(details.Name));
        Guard.Against.NullOrEmpty(details.Description, nameof(details.Description));
        Guard.Against.NegativeOrZero(details.Price, nameof(details.Price));
        Guard.Against.Negative(details.PendingRestock, nameof(details.PendingRestock));

        Name = details.Name;
        Description = details.Description;
        Price = details.Price;
        CurrentStock = details.CurrentStock;
        PendingRestock = details.PendingRestock;

    }

    public void UpdateBrand(int catalogBrandId)
    {
        Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
        CatalogBrandId = catalogBrandId;
    }

    public void UpdateType(int catalogTypeId)
    {
        Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));
        CatalogTypeId = catalogTypeId;
    }

    public void UpdatePictureUri(string pictureName)
    {
        if (string.IsNullOrEmpty(pictureName))
        {
            PictureUri = string.Empty;
            return;
        }
        PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
    }

    public void RemoveStock(int units)
    {
        Guard.Against.NegativeOrZero(units, nameof(units));
        if (CurrentStock < units)
        {
            throw new ApplicationException($"Not enough stock. Current stock: {CurrentStock}.");
        }
        CurrentStock -= units;
    }

    public readonly record struct CatalogItemDetails
    {
        public string? Name { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public int CurrentStock { get; }
        public int PendingRestock { get; }

        public CatalogItemDetails(string? name, string? description, decimal price, int currentStock, int pendingRestock)
        {
            Name = name;
            Description = description;
            Price = price;
            CurrentStock = currentStock;
            PendingRestock = pendingRestock;
        }
    }
}
