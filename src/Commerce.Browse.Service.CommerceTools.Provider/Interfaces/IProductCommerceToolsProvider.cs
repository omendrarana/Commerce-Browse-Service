using commercetools.Sdk.Api.Models.Customers;
using commercetools.Sdk.Api.Models.Products;
using Commerce.Browse.Service.CommerceTools.Provider.Providers;

namespace Commerce.Browse.Service.CommerceTools.Provider.Interface
{
    public interface IProductCommerceToolsProvider
    {
        Task<ICustomer> GetCustomerByKey(string customerKey, string projectKey);
        //Task<IProductProjectionPagedSearchResponse> GetProductById(string productId, string projectKey);
        Task<IProductProjection> GetProductById(string productId, string projectKey);
    }
}
