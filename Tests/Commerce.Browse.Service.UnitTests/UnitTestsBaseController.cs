using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Commerce.Browse.Service.WebApi.Controllers;
using Commerce.Browse.Service.Domain.Models;
using Commerce.Browse.Service.Domain.Commands;

namespace Commerce.Browse.service.UnitTesting
{
    [TestClass]
    public class UnitTestsBaseController
    {
        [TestMethod]
        public async Task GetBaseServiceAsync_ReturnsBaseModel_WhenSuccessful()
        {
            ///Arrange

            var customerKey = "my_customer_key";
            var expectedModel = new ProductModel ();

            //mock the mediator and set the expectation for the send method with any* GetBaseCommand
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetProductCommand>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(expectedModel);

            //instantiate the base controller and pass the mock mediator object
            var controller = new ProductController(mockMediator.Object);


            ///Act

            //call the GetBaseServiceAsync with the required parameter
            var result = await controller.GetProductServiceAsync("storeid","productid");

            ///Assert

            //assert that the result is equivalent to the expected model set up above
            Assert.AreEqual(expectedModel, result);
        }

    }
}