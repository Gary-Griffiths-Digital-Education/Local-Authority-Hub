namespace WebUI.Services;

public class OrganisationViewModelService
{
    public OrganisationViewModelService(IRepository<Basket> basketRepository,
       IRepository<CatalogItem> itemRepository,
       IUriComposer uriComposer,
       IBasketQueryService basketQueryService)
    {
        _basketRepository = basketRepository;
        _uriComposer = uriComposer;
        _basketQueryService = basketQueryService;
        _itemRepository = itemRepository;
    }
}
