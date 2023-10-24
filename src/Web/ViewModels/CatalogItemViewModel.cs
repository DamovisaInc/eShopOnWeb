namespace Microsoft.eShopWeb.Web.ViewModels;

public class CatalogItemViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Description { get {
        return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla convallis egestas rhoncus. Donec facilisis fermentum sem, ac viverra ante luctus vel. Donec vel mauris quam.";
    }}
    public string? PictureUri { get; set; }
    public decimal Price { get; set; }
    public int CurrentStock { get; set; }
    public int OnOrder { get; set; }
    public string? InStockText { get { return CurrentStock > 0 ? CurrentStock + " available" : OnOrder > 0 ? "Preorder" : "Out of stock"; } }
    public bool AvailableToOrder { get { return CurrentStock > 0 || OnOrder > 0; } }
    
}
