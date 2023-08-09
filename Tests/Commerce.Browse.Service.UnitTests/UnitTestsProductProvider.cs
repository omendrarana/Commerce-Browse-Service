using AutoMapper;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.CommerceTools.Provider.Providers;
using Commerce.Browse.Service.Domain.Commands;
using Commerce.Browse.Service.Domain.Handlers;
using Commerce.Browse.Service.Domain.Models;
using commercetools.Base.Client;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Customers;
using commercetools.Sdk.Api.Models.Products;
using commercetools.Sdk.Api.Models.Stores;
using Commerce.Browse.Service.Domain.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Commerce.ApiName.service.UnitTesting
{
    [TestClass]
    public class UnitTestsProductProvider
    {

        [TestMethod]
        public async Task TestCommerceToolsProductProvider_ReturnsCTModel_WhenSuccessful()
        {
            //Arrange
            var projectKey = "wegmans-sandbox-01";
            var _client = new Mock<IClient>();
            var productKey = "141-16388";
            var command = new GetProductCommand("141", "16388");
            Settings.SetCurrentProjectKey(projectKey);
            var productResponse = new ProductProjection()
            {
                Id = "123",
                Version = 2,
                Key = "141-16388",
            };
            var productFinalResponse = new ProductModel()
            {
                ProductId = "e0c54244-ba21-47c0-bfa7-707ef96c0fc9",
                WegmansId = "9360",
                StoreId = string.Empty,
                Version = 42,
                SkuId = "141-9360",
            };
              
                //Act
                //_client.Setup(x => x.ExecuteAsync<ProductModel>(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).
                //    ReturnsAsync(productResponse);
                Mock <IMapper> _mapper = new Mock<IMapper>();
            Mock<ILogger<GetProductHandler>> _logger = new Mock<ILogger<GetProductHandler>>();
            Mock<IProductCommerceToolsProvider> _productProvider = new Mock<IProductCommerceToolsProvider>();
            _productProvider.Setup(x => x.GetProductById(productKey, projectKey)).ReturnsAsync(productResponse);
            _mapper.Setup(x => x.Map<ProductModel>(productResponse)).Returns(productFinalResponse);
            var getProductHandler = new GetProductHandler(_productProvider.Object, _mapper.Object, _logger.Object);
            var response = getProductHandler.Handle(command, new CancellationToken());
            
            //var baseProvider = new ProductCommerceToolsProvider(_client.Object);
            //var response = await baseProvider.GetProductById(productKey, projectKey);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(productFinalResponse, response.Result);
            Assert.AreEqual(productFinalResponse.ProductId, response.Result.ProductId);
        }
    }
}
