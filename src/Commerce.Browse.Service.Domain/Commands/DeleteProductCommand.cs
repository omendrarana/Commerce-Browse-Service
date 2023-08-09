using MediatR;

namespace Commerce.Browse.Service.Domain.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string CustomerKey { get; set; }

        public DeleteProductCommand(string customerKey)
        {
            CustomerKey = customerKey;
        }
    }
}
