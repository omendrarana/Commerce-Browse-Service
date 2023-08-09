using MediatR;
using Commerce.Browse.Service.Domain.Models;

namespace Commerce.Browse.Service.Domain.Commands
{
    public class GetProductCommand : IRequest<ProductModel>
    {
        public string ProductId { get; set; }
        public string StoreId { get; set; }
        public string ProductKey { get; set; }

        public GetProductCommand(string storeId, string productId)
        {
            StoreId = storeId;
            ProductId = productId;
            ProductKey = StoreId + "-" + ProductId;
        }

    }
}
