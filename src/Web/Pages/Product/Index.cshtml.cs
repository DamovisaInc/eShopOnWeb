using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Pages.Product;
public class IndexModel : PageModel
{
    private readonly ICatalogViewModelService _catalogViewModelService;

    public IndexModel(ICatalogViewModelService catalogViewModelService)
    {
        _catalogViewModelService = catalogViewModelService;
    }

    public required CatalogItemViewModel CatalogModel { get; set; } = new CatalogItemViewModel();

    public async Task OnGet(CatalogItemViewModel catalogModel)
    {
        CatalogModel = await _catalogViewModelService.GetCatalogItem(catalogModel.Id);
    }
}