using MediatR;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.Domain.Commands;

namespace Commerce.Browse.Service.Domain.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductCommerceToolsProvider _productCommerceToolsProvider;

        public CreateProductHandler(IProductCommerceToolsProvider productCommerceToolsProvider)
        {
            _productCommerceToolsProvider = productCommerceToolsProvider;
        }

        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
