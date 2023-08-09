using MediatR;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.Domain.Commands;

namespace Commerce.Browse.Service.Domain.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductCommerceToolsProvider _productCommerceToolsProvider;

        public DeleteProductHandler(IProductCommerceToolsProvider productCommerceToolsProvider)
        {
            _productCommerceToolsProvider = productCommerceToolsProvider;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
