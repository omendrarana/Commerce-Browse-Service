using MediatR;
using Commerce.Browse.Service.Domain.Models;

namespace Commerce.Browse.Service.Domain.Commands
{
    public class UpdateProductCommand : IRequest<ProductModel>
    {
        public long Version { get; set; }

        public string CustomerKey { get; set; }

        public UpdateProductCommand(long version, string customerKey)
        {
            Version = version;
            CustomerKey = customerKey;
        }
    }
}
