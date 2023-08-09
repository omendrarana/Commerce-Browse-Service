using commercetools.Base.Client;
using commercetools.Sdk.Api.Extensions;
using commercetools.Sdk.Api.Models.Customers;
using commercetools.Sdk.Api.Models.GraphQl;
using commercetools.Sdk.Api.Models.Products;
using commercetools.Sdk.Api.Models.Stores;
using System.Net.Sockets;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;

namespace Commerce.Browse.Service.CommerceTools.Provider.Providers
{
    public class ProductCommerceToolsProvider : IProductCommerceToolsProvider
    {
        private readonly IClient _client;

        public ProductCommerceToolsProvider(IClient clients)
        {
            _client = clients;
        }

        /// <summary>
        /// GetCustomerByKey: A sample Method to connect with CT
        /// </summary>
        /// <param name="customerKey"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ICustomer> GetCustomerByKey(string customerKey, string projectKey)
        {
            try
            {
                var CustimerSinghIn = await _client.WithApi().WithProjectKey(projectKey)
                .Customers()
                .WithKey(customerKey)
                .Get()
                .ExecuteAsync();

                return CustimerSinghIn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IProductProjection> GetProductById(string productKey, string projectKey)
        {
            try
            {
                var product = await _client.WithApi().WithProjectKey(projectKey)
               .ProductProjections()
               .Search()
               .Get()
               .WithFilter("key: \"" + productKey + "\"")
               .WithExpand("categories[*].id")
               .WithExpand("categories[*].parent.parent.parent")
               .ExecuteAsync();
                var productResponse = product?.Results?.FirstOrDefault();
                return productResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
