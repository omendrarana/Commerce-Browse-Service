using AutoMapper;
using commercetools.Base.Client;
using commercetools.Sdk.Api.Models.Customers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.Domain.Commands;
using Commerce.Browse.Service.Domain.Handlers;
using Commerce.Browse.Service.Domain.Models;

namespace Commerce.Browse.Service.UnitTesting
{
    [TestClass]
    public class UnitTestBaseGetProductHandler
    {
        [TestMethod]
        public void TestBaseGetProductHandler()
        {
            //Arrange
            var customerKey = "Om01";
            var storeId = "sample";
            var productId = "hello";
            var projectKey = "training-0707-dotnet-dev";
            ICustomer _customer = new Customer() { Version = 1, Key = customerKey };
            var productModel = new ProductModel() ;
            var command = new GetProductCommand(storeId, productId);
            Domain.Configurations.Settings.SetCurrentProjectKey(projectKey);

            //Act
            Mock<IClient> _client = new Mock<IClient>();
            Mock<IMapper> _mapper = new Mock<IMapper>();
            Mock<ILogger<GetProductHandler>> _logger = new Mock<ILogger<GetProductHandler>>();
            Mock<IProductCommerceToolsProvider> _productProvider = new Mock<IProductCommerceToolsProvider>();
            _productProvider.Setup(x => x.GetCustomerByKey(customerKey, projectKey)).Returns(Task.FromResult(_customer));
            _mapper.Setup(x => x.Map<ProductModel>(_customer)).Returns(productModel);

            var getProductHandler = new GetProductHandler(_productProvider.Object, _mapper.Object, _logger.Object);
            var response = getProductHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsNotNull(response.Result);
           // Assert.AreEqual(customerKey, response.Result.CustomerKey);
        }
    }
}