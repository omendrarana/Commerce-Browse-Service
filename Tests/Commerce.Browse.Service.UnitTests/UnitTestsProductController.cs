using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Commerce.Browse.Service.Domain.Commands;
using Commerce.Browse.Service.Domain.Models;
using Commerce.Browse.Service.WebApi.Controllers;
using MediatR;

namespace Commerce.ApiName.service.UnitTesting
{
    [TestClass]
    public class UnitTestsBaseController
    {
        [TestMethod]
        public async Task GetBaseServiceAsync_ReturnsBaseModel_WhenSuccessful()
        {
            ///Arrange

            var customerKey = "my_customer_key";
            var expectedModel = new ProductModel { ProductId = customerKey, Version = 0 };

            //mock the mediator and set the expectation for the send method with any* GetBaseCommand
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetProductCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedModel);

            //instantiate the base controller and pass the mock mediator object
            var controller = new ProductController(mockMediator.Object);


            ///Act

            //call the GetBaseServiceAsync with the required parameter
            var result = await controller.GetProductServiceAsync(customerKey);

            ///Assert

            //assert that the result is equivalent to the expected model set up above
            Assert.AreEqual(expectedModel, result);
        }

    }
}