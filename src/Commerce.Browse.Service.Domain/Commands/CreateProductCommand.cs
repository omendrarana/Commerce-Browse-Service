using MediatR;

namespace Commerce.Browse.Service.Domain.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public long Version { get; set; }

        public string CustomerKey { get; set; }

        public CreateProductCommand(long version, string customerKey)
        {
            Version = version;
            CustomerKey = customerKey;
        }

    }
}
