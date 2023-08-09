using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Commerce.Browse.Service.Domain.Models;
using Commerce.Browse.Service.Domain.Commands;

namespace Commerce.Browse.Service.WebApi.Controllers
{
    [Route("api/browse/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Return a product by Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route ("{storeId}/{productId}")]
        public async Task<ProductModel> GetProductServiceAsync(string storeId = "141", string productId = "16388")
        {
            //Sample codes to fetch header & querystring.
            //string authToken = this.HttpContext.Request.Headers.Authorization;
            //var tokenQuerystring = this.Request.Query["token"];

            return await _mediator.Send(new GetProductCommand(storeId, productId));
        }
    }
}
