using AutoMapper;
using commercetools.Sdk.Api.Models.Categories;
using MediatR;
using Microsoft.Extensions.Logging;
using Commerce.Browse.Service.Domain.Exceptions;
using Commerce.Browse.Service.Domain.Extensions;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.Domain.Commands;
using Commerce.Browse.Service.Domain.Configurations;
using Commerce.Browse.Service.Domain.Models;
using Category = Commerce.Browse.Service.Domain.Models.Category;

namespace Commerce.Browse.Service.Domain.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ProductModel>
    {
        private readonly IProductCommerceToolsProvider _productCommerceToolsProvider;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductHandler> _logger;

        public GetProductHandler(IProductCommerceToolsProvider productCommerceToolsProvider, IMapper mapper, ILogger<GetProductHandler> logger)
        {
            _productCommerceToolsProvider = productCommerceToolsProvider;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<ProductModel> Handle(GetProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var categoriesFinal = new List<Category>();
                CustomException.OnInformation(_logger, SeverityLevel.Information, LogLevelEnum.Debug, $"Process Initiated for getting the customer Information by product key- {command.ProductId} for project key - {Settings.ProjectKey}");
                _logger.LogInformation($"Process Initiated for getting the customer Information by customer key- {command.ProductId} for project key - {Settings.ProjectKey} ");
                var response = await _productCommerceToolsProvider.GetProductById(command.ProductKey, Settings.ProjectKey);
                var categories = response?.Categories;
                var finalProduct = _mapper.Map<ProductModel>(response);
                if (categories != null)
                {
                    categoriesFinal = GetCategoriesFromResponse(categories);
                    finalProduct.Categories = categoriesFinal;
                }
                CustomException.OnInformation(_logger, SeverityLevel.Information, LogLevelEnum.Debug, $"Process Initiated for getting the customer Information by customer key- {command.ProductId} for project key - {Settings.ProjectKey}");

                return finalProduct;
            }
            catch (Exception ex)
            {
                CustomException.OnError(_logger, SeverityLevel.Critical, LogLevelEnum.Event, $"Error occured while geting the customer Information by customer key- {command.ProductId} for project key - {Settings.ProjectKey} with message - {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        public List<Category> GetCategoriesFromResponse(IList<ICategoryReference> categories)
        {
            List<Category> resultList = new List<Category>();

            //var mapedData = _mapper.Map<Category>(categories.FirstOrDefault());
            if (categories != null)
            {
                var category = new Category
                {
                    Id = categories.FirstOrDefault().Id,
                    Name = categories.FirstOrDefault().Obj.Name.FirstOrDefault().Value,
                    Seo = categories.FirstOrDefault().Obj.Name.FirstOrDefault().Value.ToString().ToLower().Replace(" ", "-")
                };
                resultList.Add(category);
            }
            
            var parent = categories?.FirstOrDefault()?.Obj.Parent;
            while (parent != null)
            {
                
                var parentCategory = new Category
                {
                    Id = parent.Id,
                    Name = parent.Obj.Name.FirstOrDefault().Value,
                    Seo = parent.Obj.Name.FirstOrDefault().Value.ToString().ToLower().Replace(" ", "-")
                };
                resultList.Add(parentCategory);
                parent = parent.Obj.Parent;
            }
            return resultList;
        }

    }
}
