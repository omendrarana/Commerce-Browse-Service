using AutoMapper;
using Commerce.Browse.Service.Domain.Models;
using commercetools.Sdk.Api.Models.Categories;
using commercetools.Sdk.Api.Models.Products;

namespace Commerce.Browse.Service.Domain.AutoMapperUtils
{
    public class ProductModelProfile : Profile
    {
        public ProductModelProfile()
        {
            CreateMap<ProductProjection, ProductModel>().ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name.Values.FirstOrDefault())).
                ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Description.FirstOrDefault())).
                ForMember(dest => dest.SkuId, opt => opt.MapFrom(src => src.MasterVariant.Sku)).
                ForMember(dest => dest.WegmansId, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "ItemNumber").FirstOrDefault().Value)).
                ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "UomPrice").FirstOrDefault().Value)).
                ForPath(dest => dest.BasePrice.price, opt => opt.MapFrom(src => src.MasterVariant.Prices.FirstOrDefault().Value.CentAmount)).
                ForPath(dest => dest.BasePrice.CurrencyCode, opt => opt.MapFrom(src => src.MasterVariant.Prices.FirstOrDefault().Value.CurrencyCode)).
                ForPath(dest => dest.BasePrice.FractionDigits, opt => opt.MapFrom(src => src.MasterVariant.Prices.FirstOrDefault().Value.FractionDigits)).
                ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.MasterVariant.Images.FirstOrDefault().Url)).
                ForMember(dest => dest.Brands, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "Brands").FirstOrDefault().Value)).
                ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "WegmansWellnessKeys").FirstOrDefault().Value)).
                ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "Ingredients").FirstOrDefault().Value)).
                ForMember(dest => dest.ItemSize, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "WebItemSize").FirstOrDefault().Value)).
                ForMember(dest => dest.isAlcoholicItem, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "IsAlcoholItem").FirstOrDefault().Value)).
                ForMember(dest => dest.IsSoldByWeight, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "IsSoldByWeight").FirstOrDefault().Value)).
                ForMember(dest => dest.OrderParameter, opt => opt.MapFrom(src => src.MasterVariant.Attributes.Where(attr => attr.Name == "OrderParameter").FirstOrDefault().Value)).
                ForMember(dest => dest.Categories, opt => opt.Ignore());

            CreateMap<CategoryReference, Models.Category>().ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Obj.Name))
            .ForPath(dest => dest.Seo, opt => opt.MapFrom(src => src.Obj.Name));
        }
    }
}
