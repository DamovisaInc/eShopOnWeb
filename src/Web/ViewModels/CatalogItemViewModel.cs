﻿namespace Microsoft.eShopWeb.Web.ViewModels;

public class CatalogItemViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PictureUri { get; set; }
    public decimal Price { get; set; }
    public int CurrentStock { get; set; }
    public int PendingRestock { get; set; }
    public string? InStockText { get { return CurrentStock > 0 ? CurrentStock + " available" : PendingRestock > 0 ? "Preorder" : "Out of stock"; } }
    public bool AvailableToOrder { get { return CurrentStock > 0 || PendingRestock > 0; } }
    
}
